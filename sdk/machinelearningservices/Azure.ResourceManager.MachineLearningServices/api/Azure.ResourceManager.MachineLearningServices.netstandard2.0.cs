namespace Azure.ResourceManager.MachineLearningServices
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource GetBatchDeploymentTrackedResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource GetBatchEndpointTrackedResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.CodeContainerResource GetCodeContainerResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.CodeVersionResource GetCodeVersionResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ComponentContainerResource GetComponentContainerResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ComponentVersionResource GetComponentVersionResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ComputeResource GetComputeResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.DatasetContainerResource GetDatasetContainerResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.DatasetVersionResource GetDatasetVersionResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.DatastoreResource GetDatastoreResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource GetEnvironmentContainerResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource GetEnvironmentVersionResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.JobBaseResource GetJobBaseResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ModelContainerResource GetModelContainerResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.ModelVersionResource GetModelVersionResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource GetOnlineDeploymentTrackedResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource GetOnlineEndpointTrackedResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Workspace GetWorkspace(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.WorkspaceConnection GetWorkspaceConnection(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
    }
    public partial class BatchDeploymentTrackedResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected BatchDeploymentTrackedResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.BatchDeploymentDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.BatchDeploymentDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.BatchDeploymentUpdateOperation Update(Azure.ResourceManager.MachineLearningServices.Models.PartialBatchDeploymentPartialTrackedResource body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.BatchDeploymentUpdateOperation> UpdateAsync(Azure.ResourceManager.MachineLearningServices.Models.PartialBatchDeploymentPartialTrackedResource body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchDeploymentTrackedResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>, System.Collections.IEnumerable
    {
        protected BatchDeploymentTrackedResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.BatchDeploymentCreateOrUpdateOperation CreateOrUpdate(string deploymentName, Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResourceData body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.BatchDeploymentCreateOrUpdateOperation> CreateOrUpdateAsync(string deploymentName, Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResourceData body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchDeploymentTrackedResourceData : Azure.ResourceManager.Models.TrackedResource
    {
        public BatchDeploymentTrackedResourceData(Azure.ResourceManager.Resources.Models.Location location, Azure.ResourceManager.MachineLearningServices.Models.BatchDeployment properties) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchDeployment Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class BatchEndpointTrackedResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected BatchEndpointTrackedResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.BatchEndpointDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.BatchEndpointDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResourceCollection GetBatchDeploymentTrackedResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.BatchEndpointUpdateOperation Update(Azure.ResourceManager.MachineLearningServices.Models.PartialBatchEndpointPartialTrackedResource body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.BatchEndpointUpdateOperation> UpdateAsync(Azure.ResourceManager.MachineLearningServices.Models.PartialBatchEndpointPartialTrackedResource body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchEndpointTrackedResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>, System.Collections.IEnumerable
    {
        protected BatchEndpointTrackedResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.BatchEndpointCreateOrUpdateOperation CreateOrUpdate(string endpointName, Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResourceData body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.BatchEndpointCreateOrUpdateOperation> CreateOrUpdateAsync(string endpointName, Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResourceData body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> GetAll(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> GetAllAsync(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> GetIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> GetIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchEndpointTrackedResourceData : Azure.ResourceManager.Models.TrackedResource
    {
        public BatchEndpointTrackedResourceData(Azure.ResourceManager.Resources.Models.Location location, Azure.ResourceManager.MachineLearningServices.Models.BatchEndpoint properties) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchEndpoint Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class CodeContainerResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected CodeContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.CodeContainerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.CodeContainerDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.CodeContainerDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.CodeVersionResourceCollection GetCodeVersionResources() { throw null; }
    }
    public partial class CodeContainerResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>, System.Collections.IEnumerable
    {
        protected CodeContainerResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.CodeContainerCreateOrUpdateOperation CreateOrUpdate(string name, Azure.ResourceManager.MachineLearningServices.Models.CodeContainer properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.CodeContainerCreateOrUpdateOperation> CreateOrUpdateAsync(string name, Azure.ResourceManager.MachineLearningServices.Models.CodeContainer properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.CodeContainerResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.CodeContainerResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.CodeContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.CodeContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CodeContainerResourceData : Azure.ResourceManager.Models.Resource
    {
        public CodeContainerResourceData(Azure.ResourceManager.MachineLearningServices.Models.CodeContainer properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.CodeContainer Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class CodeVersionResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected CodeVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.CodeVersionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.CodeVersionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.CodeVersionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeVersionResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>, System.Collections.IEnumerable
    {
        protected CodeVersionResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.CodeVersionCreateOrUpdateOperation CreateOrUpdate(string version, Azure.ResourceManager.MachineLearningServices.Models.CodeVersion properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.CodeVersionCreateOrUpdateOperation> CreateOrUpdateAsync(string version, Azure.ResourceManager.MachineLearningServices.Models.CodeVersion properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.CodeVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.CodeVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.CodeVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.CodeVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CodeVersionResourceData : Azure.ResourceManager.Models.Resource
    {
        public CodeVersionResourceData(Azure.ResourceManager.MachineLearningServices.Models.CodeVersion properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.CodeVersion Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class ComponentContainerResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ComponentContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.ComponentContainerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ComponentContainerDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ComponentContainerDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.ComponentVersionResourceCollection GetComponentVersionResources() { throw null; }
    }
    public partial class ComponentContainerResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource>, System.Collections.IEnumerable
    {
        protected ComponentContainerResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ComponentContainerCreateOrUpdateOperation CreateOrUpdate(string name, Azure.ResourceManager.MachineLearningServices.Models.ComponentContainer properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ComponentContainerCreateOrUpdateOperation> CreateOrUpdateAsync(string name, Azure.ResourceManager.MachineLearningServices.Models.ComponentContainer properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComponentContainerResourceData : Azure.ResourceManager.Models.Resource
    {
        public ComponentContainerResourceData(Azure.ResourceManager.MachineLearningServices.Models.ComponentContainer properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ComponentContainer Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class ComponentVersionResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ComponentVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.ComponentVersionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ComponentVersionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ComponentVersionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComponentVersionResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource>, System.Collections.IEnumerable
    {
        protected ComponentVersionResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ComponentVersionCreateOrUpdateOperation CreateOrUpdate(string version, Azure.ResourceManager.MachineLearningServices.Models.ComponentVersion properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ComponentVersionCreateOrUpdateOperation> CreateOrUpdateAsync(string version, Azure.ResourceManager.MachineLearningServices.Models.ComponentVersion properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComponentVersionResourceData : Azure.ResourceManager.Models.Resource
    {
        public ComponentVersionResourceData(Azure.ResourceManager.MachineLearningServices.Models.ComponentVersion properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ComponentVersion Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class ComputeResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ComputeResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.ComputeResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ComputeDeleteOperation Delete(Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction underlyingResourceAction, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ComputeDeleteOperation> DeleteAsync(Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction underlyingResourceAction, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.AmlComputeNodeInformation> GetNodes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.AmlComputeNodeInformation> GetNodesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ComputeRestartOperation Restart(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ComputeRestartOperation> RestartAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ComputeStartOperation Start(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ComputeStartOperation> StartAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ComputeStopOperation Stop(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ComputeStopOperation> StopAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ComputeUpdateOperation Update(Azure.ResourceManager.MachineLearningServices.Models.ScaleSettingsInformation properties = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ComputeUpdateOperation> UpdateAsync(Azure.ResourceManager.MachineLearningServices.Models.ScaleSettingsInformation properties = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ComputeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComputeResource>, System.Collections.IEnumerable
    {
        protected ComputeResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ComputeCreateOrUpdateOperation CreateOrUpdate(string computeName, Azure.ResourceManager.MachineLearningServices.ComputeResourceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ComputeCreateOrUpdateOperation> CreateOrUpdateAsync(string computeName, Azure.ResourceManager.MachineLearningServices.ComputeResourceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource> Get(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ComputeResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ComputeResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> GetAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource> GetIfExists(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> GetIfExistsAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.ComputeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ComputeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.ComputeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ComputeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComputeResourceData : Azure.ResourceManager.Models.Resource
    {
        public ComputeResourceData() { }
        public Azure.ResourceManager.MachineLearningServices.Models.Identity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Compute Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DatasetContainerResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected DatasetContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.DatasetContainerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.DatasetContainerDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.DatasetContainerDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.DatasetVersionResourceCollection GetDatasetVersionResources() { throw null; }
    }
    public partial class DatasetContainerResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource>, System.Collections.IEnumerable
    {
        protected DatasetContainerResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.DatasetContainerCreateOrUpdateOperation CreateOrUpdate(string name, Azure.ResourceManager.MachineLearningServices.Models.DatasetContainer properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.DatasetContainerCreateOrUpdateOperation> CreateOrUpdateAsync(string name, Azure.ResourceManager.MachineLearningServices.Models.DatasetContainer properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatasetContainerResourceData : Azure.ResourceManager.Models.Resource
    {
        public DatasetContainerResourceData(Azure.ResourceManager.MachineLearningServices.Models.DatasetContainer properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.DatasetContainer Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class DatasetVersionResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected DatasetVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.DatasetVersionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.DatasetVersionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.DatasetVersionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatasetVersionResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource>, System.Collections.IEnumerable
    {
        protected DatasetVersionResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.DatasetVersionCreateOrUpdateOperation CreateOrUpdate(string version, Azure.ResourceManager.MachineLearningServices.Models.DatasetVersion properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.DatasetVersionCreateOrUpdateOperation> CreateOrUpdateAsync(string version, Azure.ResourceManager.MachineLearningServices.Models.DatasetVersion properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatasetVersionResourceData : Azure.ResourceManager.Models.Resource
    {
        public DatasetVersionResourceData(Azure.ResourceManager.MachineLearningServices.Models.DatasetVersion properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.DatasetVersion Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class DatastoreResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected DatastoreResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.DatastoreResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.DatastoreDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.DatastoreDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoreResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.DatastoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.DatastoreResource>, System.Collections.IEnumerable
    {
        protected DatastoreResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.DatastoreCreateOrUpdateOperation CreateOrUpdate(string name, Azure.ResourceManager.MachineLearningServices.Models.Datastore properties, bool? skipValidation = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.DatastoreCreateOrUpdateOperation> CreateOrUpdateAsync(string name, Azure.ResourceManager.MachineLearningServices.Models.Datastore properties, bool? skipValidation = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.DatastoreResource> GetAll(string skip = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.DatastoreResource> GetAllAsync(string skip = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.DatastoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.DatastoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.DatastoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.DatastoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatastoreResourceData : Azure.ResourceManager.Models.Resource
    {
        public DatastoreResourceData(Azure.ResourceManager.MachineLearningServices.Models.Datastore properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.Datastore Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class EnvironmentContainerResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected EnvironmentContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResourceCollection GetEnvironmentVersionResources() { throw null; }
    }
    public partial class EnvironmentContainerResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>, System.Collections.IEnumerable
    {
        protected EnvironmentContainerResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerCreateOrUpdateOperation CreateOrUpdate(string name, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainer properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerCreateOrUpdateOperation> CreateOrUpdateAsync(string name, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainer properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnvironmentContainerResourceData : Azure.ResourceManager.Models.Resource
    {
        public EnvironmentContainerResourceData(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainer properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainer Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class EnvironmentVersionResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected EnvironmentVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.EnvironmentVersionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentVersionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentVersionResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource>, System.Collections.IEnumerable
    {
        protected EnvironmentVersionResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.EnvironmentVersionCreateOrUpdateOperation CreateOrUpdate(string version, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentVersion properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentVersionCreateOrUpdateOperation> CreateOrUpdateAsync(string version, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentVersion properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnvironmentVersionResourceData : Azure.ResourceManager.Models.Resource
    {
        public EnvironmentVersionResourceData(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentVersion properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.EnvironmentVersion Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class JobBaseResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected JobBaseResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.JobBaseResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.JobDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.JobDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobBaseResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.JobBaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.JobBaseResource>, System.Collections.IEnumerable
    {
        protected JobBaseResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.JobCreateOrUpdateOperation CreateOrUpdate(string id, Azure.ResourceManager.MachineLearningServices.Models.JobBase properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.JobCreateOrUpdateOperation> CreateOrUpdateAsync(string id, Azure.ResourceManager.MachineLearningServices.Models.JobBase properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.JobBaseResource> GetAll(string skip = null, string jobType = null, string tag = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.JobBaseResource> GetAllAsync(string skip = null, string jobType = null, string tag = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource> GetIfExists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource>> GetIfExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.JobBaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.JobBaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.JobBaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.JobBaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobBaseResourceData : Azure.ResourceManager.Models.Resource
    {
        public JobBaseResourceData(Azure.ResourceManager.MachineLearningServices.Models.JobBase properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.JobBase Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public static partial class ManagementGroupExtensions
    {
    }
    public partial class ModelContainerResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ModelContainerResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.ModelContainerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ModelContainerDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ModelContainerDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.ModelVersionResourceCollection GetModelVersionResources() { throw null; }
    }
    public partial class ModelContainerResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>, System.Collections.IEnumerable
    {
        protected ModelContainerResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ModelContainerCreateOrUpdateOperation CreateOrUpdate(string name, Azure.ResourceManager.MachineLearningServices.Models.ModelContainer properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ModelContainerCreateOrUpdateOperation> CreateOrUpdateAsync(string name, Azure.ResourceManager.MachineLearningServices.Models.ModelContainer properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ModelContainerResource> GetAll(string skip = null, int? count = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ModelContainerResource> GetAllAsync(string skip = null, int? count = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.ModelContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.ModelContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ModelContainerResourceData : Azure.ResourceManager.Models.Resource
    {
        public ModelContainerResourceData(Azure.ResourceManager.MachineLearningServices.Models.ModelContainer properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelContainer Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class ModelVersionResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ModelVersionResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.ModelVersionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ModelVersionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ModelVersionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelVersionResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>, System.Collections.IEnumerable
    {
        protected ModelVersionResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.ModelVersionCreateOrUpdateOperation CreateOrUpdate(string version, Azure.ResourceManager.MachineLearningServices.Models.ModelVersion properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.ModelVersionCreateOrUpdateOperation> CreateOrUpdateAsync(string version, Azure.ResourceManager.MachineLearningServices.Models.ModelVersion properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.ModelVersionResource> GetAll(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, string feed = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.ModelVersionResource> GetAllAsync(string skip = null, string orderBy = null, int? top = default(int?), string version = null, string description = null, int? offset = default(int?), string tags = null, string properties = null, string feed = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.ModelVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.ModelVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ModelVersionResourceData : Azure.ResourceManager.Models.Resource
    {
        public ModelVersionResourceData(Azure.ResourceManager.MachineLearningServices.Models.ModelVersion properties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelVersion Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class OnlineDeploymentTrackedResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected OnlineDeploymentTrackedResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.OnlineDeploymentDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.OnlineDeploymentDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DeploymentLogs> GetLogs(Azure.ResourceManager.MachineLearningServices.Models.ContainerType? containerType = default(Azure.ResourceManager.MachineLearningServices.Models.ContainerType?), int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DeploymentLogs>> GetLogsAsync(Azure.ResourceManager.MachineLearningServices.Models.ContainerType? containerType = default(Azure.ResourceManager.MachineLearningServices.Models.ContainerType?), int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.DeploymentSkuResourceType> GetSkus(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.DeploymentSkuResourceType> GetSkusAsync(int? count = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.OnlineDeploymentUpdateOperation Update(Azure.ResourceManager.MachineLearningServices.Models.PartialOnlineDeploymentPartialTrackedResource body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.OnlineDeploymentUpdateOperation> UpdateAsync(Azure.ResourceManager.MachineLearningServices.Models.PartialOnlineDeploymentPartialTrackedResource body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineDeploymentTrackedResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>, System.Collections.IEnumerable
    {
        protected OnlineDeploymentTrackedResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.OnlineDeploymentCreateOrUpdateOperation CreateOrUpdate(string deploymentName, Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResourceData body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.OnlineDeploymentCreateOrUpdateOperation> CreateOrUpdateAsync(string deploymentName, Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResourceData body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> GetAll(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> GetAllAsync(string orderBy = null, int? top = default(int?), string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OnlineDeploymentTrackedResourceData : Azure.ResourceManager.Models.TrackedResource
    {
        public OnlineDeploymentTrackedResourceData(Azure.ResourceManager.Resources.Models.Location location, Azure.ResourceManager.MachineLearningServices.Models.OnlineDeployment properties) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.OnlineDeployment Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class OnlineEndpointTrackedResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected OnlineEndpointTrackedResource() { }
        public virtual Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpointDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpointDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResourceCollection GetOnlineDeploymentTrackedResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthToken> GetToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthToken>> GetTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpointRegenerateKeysOperation RegenerateKeys(Azure.ResourceManager.MachineLearningServices.Models.KeyType keyType, string keyValue = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpointRegenerateKeysOperation> RegenerateKeysAsync(Azure.ResourceManager.MachineLearningServices.Models.KeyType keyType, string keyValue = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpointUpdateOperation Update(Azure.ResourceManager.MachineLearningServices.Models.PartialOnlineEndpointPartialTrackedResource body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpointUpdateOperation> UpdateAsync(Azure.ResourceManager.MachineLearningServices.Models.PartialOnlineEndpointPartialTrackedResource body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpointTrackedResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>, System.Collections.IEnumerable
    {
        protected OnlineEndpointTrackedResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpointCreateOrUpdateOperation CreateOrUpdate(string endpointName, Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResourceData body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpointCreateOrUpdateOperation> CreateOrUpdateAsync(string endpointName, Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResourceData body, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> GetAll(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearningServices.Models.OrderString? orderBy = default(Azure.ResourceManager.MachineLearningServices.Models.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> GetAllAsync(string name = null, int? count = default(int?), Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType? computeType = default(Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType?), string skip = null, string tags = null, string properties = null, Azure.ResourceManager.MachineLearningServices.Models.OrderString? orderBy = default(Azure.ResourceManager.MachineLearningServices.Models.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> GetIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> GetIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OnlineEndpointTrackedResourceData : Azure.ResourceManager.Models.TrackedResource
    {
        public OnlineEndpointTrackedResourceData(Azure.ResourceManager.Resources.Models.Location location, Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpoint properties) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.OnlineEndpoint Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionCreateOrUpdateOperation CreateOrUpdate(string privateEndpointConnectionName, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionCreateOrUpdateOperation> CreateOrUpdateAsync(string privateEndpointConnectionName, Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.Resource
    {
        public PrivateEndpointConnectionData() { }
        public Azure.ResourceManager.MachineLearningServices.Models.Identity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.MachineLearningServices.WorkspaceCollection GetWorkspaces(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.ResourceQuota> GetQuotas(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.ResourceQuota> GetQuotasAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.Usage> GetUsages(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.Usage> GetUsagesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSize>> GetVirtualMachineSizes(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSize>>> GetVirtualMachineSizesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetWorkspaceByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetWorkspaceByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Workspace> GetWorkspaces(this Azure.ResourceManager.Resources.Subscription subscription, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Workspace> GetWorkspacesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.UpdateWorkspaceQuotas>> UpdateQuotas(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.Models.QuotaBaseProperties> value = null, string quotaUpdateParametersLocation = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.UpdateWorkspaceQuotas>>> UpdateQuotasAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.Models.QuotaBaseProperties> value = null, string quotaUpdateParametersLocation = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class TenantExtensions
    {
    }
    public partial class Workspace : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected Workspace() { }
        public virtual Azure.ResourceManager.MachineLearningServices.WorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.WorkspaceDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.WorkspaceDiagnoseOperation Diagnose(Azure.ResourceManager.MachineLearningServices.Models.DiagnoseRequestProperties value = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceDiagnoseOperation> DiagnoseAsync(Azure.ResourceManager.MachineLearningServices.Models.DiagnoseRequestProperties value = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResourceCollection GetBatchEndpointTrackedResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.CodeContainerResourceCollection GetCodeContainerResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.ComponentContainerResourceCollection GetComponentContainerResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.ComputeResourceCollection GetComputeResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.DatasetContainerResourceCollection GetDatasetContainerResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.DatastoreResourceCollection GetDatastoreResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResourceCollection GetEnvironmentContainerResources() { throw null; }
        public Azure.ResourceManager.MachineLearningServices.JobBaseResourceCollection GetJobBaseResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListWorkspaceKeysResult> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListWorkspaceKeysResult>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.ModelContainerResourceCollection GetModelContainerResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.NotebookAccessTokenResult> GetNotebookAccessToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.NotebookAccessTokenResult>> GetNotebookAccessTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListNotebookKeysResult> GetNotebookKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListNotebookKeysResult>> GetNotebookKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResourceCollection GetOnlineEndpointTrackedResources() { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.FqdnEndpoints>> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.FqdnEndpoints>>> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.PrivateLinkResource>> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.PrivateLinkResource>>> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListStorageAccountKeysResult> GetStorageAccountKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListStorageAccountKeysResult>> GetStorageAccountKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionCollection GetWorkspaceConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.AmlUserFeature> GetWorkspaceFeatures(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.AmlUserFeature> GetWorkspaceFeaturesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.WorkspacePrepareNotebookOperation PrepareNotebook(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.WorkspacePrepareNotebookOperation> PrepareNotebookAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.WorkspaceResyncKeysOperation ResyncKeys(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceResyncKeysOperation> ResyncKeysAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace> Update(Azure.ResourceManager.MachineLearningServices.Models.WorkspaceUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> UpdateAsync(Azure.ResourceManager.MachineLearningServices.Models.WorkspaceUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.Workspace>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.Workspace>, System.Collections.IEnumerable
    {
        protected WorkspaceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.WorkspaceCreateOrUpdateOperation CreateOrUpdate(string workspaceName, Azure.ResourceManager.MachineLearningServices.WorkspaceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceCreateOrUpdateOperation> CreateOrUpdateAsync(string workspaceName, Azure.ResourceManager.MachineLearningServices.WorkspaceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Workspace> GetAll(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Workspace> GetAllAsync(string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.Workspace> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.Workspace>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.Workspace> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.Workspace>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected WorkspaceConnection() { }
        public virtual Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.WorkspaceConnectionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceConnectionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>, System.Collections.IEnumerable
    {
        protected WorkspaceConnectionCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.Models.WorkspaceConnectionCreateOperation CreateOrUpdate(string connectionName, Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceConnectionCreateOperation> CreateOrUpdateAsync(string connectionName, Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection> Get(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection> GetAll(string target = null, string category = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection> GetAllAsync(string target = null, string category = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>> GetAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection> GetIfExists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>> GetIfExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceConnectionData : Azure.ResourceManager.Models.Resource
    {
        public WorkspaceConnectionData() { }
        public string AuthType { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ValueFormat? ValueFormat { get { throw null; } set { } }
    }
    public partial class WorkspaceData : Azure.ResourceManager.Models.Resource
    {
        public WorkspaceData() { }
        public bool? AllowPublicAccessWhenBehindVnet { get { throw null; } set { } }
        public string ApplicationInsights { get { throw null; } set { } }
        public string ContainerRegistry { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DiscoveryUrl { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EncryptionProperty Encryption { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public bool? HbiWorkspace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Identity Identity { get { throw null; } set { } }
        public string ImageBuildCompute { get { throw null; } set { } }
        public string KeyVault { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public string MlFlowTrackingUri { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.NotebookResourceInfo NotebookInfo { get { throw null; } }
        public string PrimaryUserAssignedIdentity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public int? PrivateLinkCount { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ServiceManagedResourcesSettings ServiceManagedResourcesSettings { get { throw null; } set { } }
        public string ServiceProvisionedResourceGroup { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.SharedPrivateLinkResource> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.Sku Sku { get { throw null; } set { } }
        public string StorageAccount { get { throw null; } set { } }
        public bool? StorageHnsEnabled { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TenantId { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
    }
}
namespace Azure.ResourceManager.MachineLearningServices.Models
{
    public partial class AccountKeyDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials
    {
        public AccountKeyDatastoreCredentials(Azure.ResourceManager.MachineLearningServices.Models.AccountKeyDatastoreSecrets secrets) { }
        public Azure.ResourceManager.MachineLearningServices.Models.AccountKeyDatastoreSecrets Secrets { get { throw null; } set { } }
    }
    public partial class AccountKeyDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets
    {
        public AccountKeyDatastoreSecrets() { }
        public string Key { get { throw null; } set { } }
    }
    public partial class AKS : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public AKS() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AKSProperties Properties { get { throw null; } set { } }
    }
    public partial class AksComputeSecrets : Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets
    {
        internal AksComputeSecrets() { }
        public string AdminKubeConfig { get { throw null; } }
        public string ImagePullSecretName { get { throw null; } }
        public string UserKubeConfig { get { throw null; } }
    }
    public partial class AksComputeSecretsProperties
    {
        internal AksComputeSecretsProperties() { }
        public string AdminKubeConfig { get { throw null; } }
        public string ImagePullSecretName { get { throw null; } }
        public string UserKubeConfig { get { throw null; } }
    }
    public partial class AksNetworkingConfiguration
    {
        public AksNetworkingConfiguration() { }
        public string DnsServiceIP { get { throw null; } set { } }
        public string DockerBridgeCidr { get { throw null; } set { } }
        public string ServiceCidr { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
    }
    public partial class AKSProperties
    {
        public AKSProperties() { }
        public int? AgentCount { get { throw null; } set { } }
        public string AgentVmSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AksNetworkingConfiguration AksNetworkingConfiguration { get { throw null; } set { } }
        public string ClusterFqdn { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose? ClusterPurpose { get { throw null; } set { } }
        public string LoadBalancerSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType? LoadBalancerType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SslConfiguration SslConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.SystemService> SystemServices { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllocationState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.AllocationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllocationState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.AllocationState Resizing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.AllocationState Steady { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.AllocationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.AllocationState left, Azure.ResourceManager.MachineLearningServices.Models.AllocationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.AllocationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.AllocationState left, Azure.ResourceManager.MachineLearningServices.Models.AllocationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AmlCompute : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public AmlCompute() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AmlComputeProperties Properties { get { throw null; } set { } }
    }
    public partial class AmlComputeNodeInformation
    {
        internal AmlComputeNodeInformation() { }
        public string NodeId { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.NodeState? NodeState { get { throw null; } }
        public int? Port { get { throw null; } }
        public string PrivateIpAddress { get { throw null; } }
        public string PublicIpAddress { get { throw null; } }
        public string RunId { get { throw null; } }
    }
    public partial class AmlComputeProperties
    {
        public AmlComputeProperties() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AllocationState? AllocationState { get { throw null; } }
        public System.DateTimeOffset? AllocationStateTransitionTime { get { throw null; } }
        public int? CurrentNodeCount { get { throw null; } }
        public bool? EnableNodePublicIp { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Models.ErrorResponse> Errors { get { throw null; } }
        public bool? IsolatedNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.NodeStateCounts NodeStateCounts { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.OsType? OsType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> PropertyBag { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess? RemoteLoginPortPublicAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ScaleSettings ScaleSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource Subnet { get { throw null; } set { } }
        public int? TargetNodeCount { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.UserAccountCredentials UserAccountCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource VirtualMachineImage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.VmPriority? VmPriority { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class AmlToken : Azure.ResourceManager.MachineLearningServices.Models.IdentityConfiguration
    {
        public AmlToken() { }
    }
    public partial class AmlUserFeature
    {
        internal AmlUserFeature() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationSharingPolicy : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationSharingPolicy(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy Personal { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy left, Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy left, Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssetBase : Azure.ResourceManager.MachineLearningServices.Models.ResourceBase
    {
        public AssetBase() { }
        public bool? IsAnonymous { get { throw null; } set { } }
    }
    public partial class AssetContainer : Azure.ResourceManager.MachineLearningServices.Models.ResourceBase
    {
        public AssetContainer() { }
        public string LatestVersion { get { throw null; } }
        public string NextVersion { get { throw null; } }
    }
    public partial class AssetReferenceBase
    {
        public AssetReferenceBase() { }
    }
    public partial class AssignedUser
    {
        public AssignedUser(string objectId, string tenantId) { }
        public string ObjectId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
    }
    public partial class AutoPauseProperties
    {
        public AutoPauseProperties() { }
        public int? DelayInMinutes { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class AutoScaleProperties
    {
        public AutoScaleProperties() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
    }
    public partial class AzureBlobDatastore : Azure.ResourceManager.MachineLearningServices.Models.Datastore
    {
        public AzureBlobDatastore(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials, string accountName, string containerName) : base (default(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class AzureDataLakeGen1Datastore : Azure.ResourceManager.MachineLearningServices.Models.Datastore
    {
        public AzureDataLakeGen1Datastore(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials, string storeName) : base (default(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials)) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
    }
    public partial class AzureDataLakeGen2Datastore : Azure.ResourceManager.MachineLearningServices.Models.Datastore
    {
        public AzureDataLakeGen2Datastore(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials, string accountName, string filesystem) : base (default(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Filesystem { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class AzureFileDatastore : Azure.ResourceManager.MachineLearningServices.Models.Datastore
    {
        public AzureFileDatastore(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials, string accountName, string fileShareName) : base (default(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials)) { }
        public string AccountName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string FileShareName { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity? ServiceDataAccessAuthIdentity { get { throw null; } set { } }
    }
    public partial class BanditPolicy : Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicy
    {
        public BanditPolicy() { }
        public float? SlackAmount { get { throw null; } set { } }
        public float? SlackFactor { get { throw null; } set { } }
    }
    public partial class BasicBinding : Azure.ResourceManager.MachineLearningServices.Models.Binding
    {
        public BasicBinding() { }
        public string Destination { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
    }
    public partial class BatchDeployment : Azure.ResourceManager.MachineLearningServices.Models.EndpointDeploymentPropertiesBase
    {
        public BatchDeployment() { }
        public string Compute { get { throw null; } set { } }
        public int? ErrorThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel? LoggingLevel { get { throw null; } set { } }
        public int? MaxConcurrencyPerInstance { get { throw null; } set { } }
        public long? MiniBatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AssetReferenceBase Model { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction? OutputAction { get { throw null; } set { } }
        public string OutputFileName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceConfiguration Resources { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchRetrySettings RetrySettings { get { throw null; } set { } }
    }
    public partial class BatchDeploymentCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>
    {
        protected BatchDeploymentCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchDeploymentDeleteOperation : Azure.Operation
    {
        protected BatchDeploymentDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchDeploymentUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>
    {
        protected BatchDeploymentUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchDeploymentTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchEndpoint : Azure.ResourceManager.MachineLearningServices.Models.EndpointPropertiesBase
    {
        public BatchEndpoint(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode authMode) : base (default(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode)) { }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchEndpointDefaults Defaults { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class BatchEndpointCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>
    {
        protected BatchEndpointCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchEndpointDefaults
    {
        public BatchEndpointDefaults() { }
        public string DeploymentName { get { throw null; } set { } }
    }
    public partial class BatchEndpointDeleteOperation : Azure.Operation
    {
        protected BatchEndpointDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchEndpointUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>
    {
        protected BatchEndpointUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.BatchEndpointTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchLoggingLevel : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchLoggingLevel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel Debug { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel Info { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel left, Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel left, Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchOutputAction : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchOutputAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction AppendRow { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction SummaryOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction left, Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction left, Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchRetrySettings
    {
        public BatchRetrySettings() { }
        public int? MaxRetries { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingCurrency : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingCurrency(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency USD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency left, Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency left, Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Binding
    {
        public Binding() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BindingType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.BindingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BindingType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.BindingType Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.BindingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.BindingType left, Azure.ResourceManager.MachineLearningServices.Models.BindingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.BindingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.BindingType left, Azure.ResourceManager.MachineLearningServices.Models.BindingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BuildContext
    {
        public BuildContext(string contextUri) { }
        public string ContextUri { get { throw null; } set { } }
        public string DockerfilePath { get { throw null; } set { } }
    }
    public partial class CertificateDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials
    {
        public CertificateDatastoreCredentials(System.Guid clientId, Azure.ResourceManager.MachineLearningServices.Models.CertificateDatastoreSecrets secrets, System.Guid tenantId, string thumbprint) { }
        public string AuthorityUrl { get { throw null; } set { } }
        public System.Guid ClientId { get { throw null; } set { } }
        public string ResourceUrl { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.CertificateDatastoreSecrets Secrets { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    public partial class CertificateDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets
    {
        public CertificateDatastoreSecrets() { }
        public string Certificate { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterPurpose : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterPurpose(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose DenseProd { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose DevTest { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose FastProd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose left, Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose left, Azure.ResourceManager.MachineLearningServices.Models.ClusterPurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CodeConfiguration
    {
        public CodeConfiguration(string scoringScript) { }
        public string CodeId { get { throw null; } set { } }
        public string ScoringScript { get { throw null; } set { } }
    }
    public partial class CodeContainer : Azure.ResourceManager.MachineLearningServices.Models.AssetContainer
    {
        public CodeContainer() { }
    }
    public partial class CodeContainerCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>
    {
        protected CodeContainerCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.CodeContainerResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeContainerResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeContainerDeleteOperation : Azure.Operation
    {
        protected CodeContainerDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeVersion : Azure.ResourceManager.MachineLearningServices.Models.AssetBase
    {
        public CodeVersion() { }
        public string CodeUri { get { throw null; } set { } }
    }
    public partial class CodeVersionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>
    {
        protected CodeVersionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.CodeVersionResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.CodeVersionResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeVersionDeleteOperation : Azure.Operation
    {
        protected CodeVersionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommandJob : Azure.ResourceManager.MachineLearningServices.Models.JobBase
    {
        public CommandJob(string command) { }
        public string CodeId { get { throw null; } set { } }
        public string Command { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.DistributionConfiguration Distribution { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.IdentityConfiguration Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobInput> Inputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.CommandJobLimits Limits { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobOutput> Outputs { get { throw null; } set { } }
        public object Parameters { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceConfiguration Resources { get { throw null; } set { } }
    }
    public partial class CommandJobLimits : Azure.ResourceManager.MachineLearningServices.Models.JobLimits
    {
        public CommandJobLimits() { }
    }
    public partial class ComponentContainer : Azure.ResourceManager.MachineLearningServices.Models.AssetContainer
    {
        public ComponentContainer() { }
    }
    public partial class ComponentContainerCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource>
    {
        protected ComponentContainerCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.ComponentContainerResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentContainerResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComponentContainerDeleteOperation : Azure.Operation
    {
        protected ComponentContainerDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComponentJob
    {
        public ComponentJob() { }
        public string ComponentId { get { throw null; } set { } }
        public string ComputeId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobInput> Inputs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobOutput> Outputs { get { throw null; } set { } }
        public object Overrides { get { throw null; } set { } }
    }
    public partial class Components1D3SwueSchemasComputeresourceAllof1
    {
        public Components1D3SwueSchemasComputeresourceAllof1() { }
        public Azure.ResourceManager.MachineLearningServices.Models.Compute Properties { get { throw null; } set { } }
    }
    public partial class ComponentVersion : Azure.ResourceManager.MachineLearningServices.Models.AssetBase
    {
        public ComponentVersion() { }
        public object ComponentSpec { get { throw null; } set { } }
    }
    public partial class ComponentVersionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource>
    {
        protected ComponentVersionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.ComponentVersionResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComponentVersionResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComponentVersionDeleteOperation : Azure.Operation
    {
        protected ComponentVersionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Compute
    {
        public Compute() { }
        public string ComputeLocation { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? IsAttachedCompute { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Models.ErrorResponse> ProvisioningErrors { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class ComputeCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.ComputeResource>
    {
        protected ComputeCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.ComputeResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeDeleteOperation : Azure.Operation
    {
        protected ComputeDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeInstance : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public ComputeInstance() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceProperties Properties { get { throw null; } set { } }
    }
    public partial class ComputeInstanceApplication
    {
        internal ComputeInstanceApplication() { }
        public string DisplayName { get { throw null; } }
        public string EndpointUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeInstanceAuthorizationType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeInstanceAuthorizationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType Personal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType left, Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType left, Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeInstanceConnectivityEndpoints
    {
        internal ComputeInstanceConnectivityEndpoints() { }
        public string PrivateIpAddress { get { throw null; } }
        public string PublicIpAddress { get { throw null; } }
    }
    public partial class ComputeInstanceCreatedBy
    {
        internal ComputeInstanceCreatedBy() { }
        public string UserId { get { throw null; } }
        public string UserName { get { throw null; } }
        public string UserOrgId { get { throw null; } }
    }
    public partial class ComputeInstanceLastOperation
    {
        internal ComputeInstanceLastOperation() { }
        public Azure.ResourceManager.MachineLearningServices.Models.OperationName? OperationName { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.OperationStatus? OperationStatus { get { throw null; } }
        public System.DateTimeOffset? OperationTime { get { throw null; } }
    }
    public partial class ComputeInstanceProperties
    {
        public ComputeInstanceProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceApplication> Applications { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy? ApplicationSharingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType? ComputeInstanceAuthorizationType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceConnectivityEndpoints ConnectivityEndpoints { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceCreatedBy CreatedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Models.ErrorResponse> Errors { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceLastOperation LastOperation { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.PersonalComputeInstanceSettings PersonalComputeInstanceSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SetupScripts SetupScripts { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceSshSettings SshSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState? State { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource Subnet { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class ComputeInstanceSshSettings
    {
        public ComputeInstanceSshSettings() { }
        public string AdminPublicKey { get { throw null; } set { } }
        public string AdminUserName { get { throw null; } }
        public int? SshPort { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess? SshPublicAccess { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeInstanceState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeInstanceState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState JobRunning { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Restarting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState SettingUp { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState SetupFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Starting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Stopped { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Stopping { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Unusable { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState UserSettingUp { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState UserSetupFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState left, Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState left, Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeRestartOperation : Azure.Operation
    {
        protected ComputeRestartOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeSecrets
    {
        internal ComputeSecrets() { }
    }
    public partial class ComputeStartOperation : Azure.Operation
    {
        protected ComputeStartOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeStopOperation : Azure.Operation
    {
        protected ComputeStopOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType AKS { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType AmlCompute { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType ComputeInstance { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType Databricks { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType DataFactory { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType DataLakeAnalytics { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType HDInsight { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType SynapseSpark { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType VirtualMachine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ComputeType left, Azure.ResourceManager.MachineLearningServices.Models.ComputeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ComputeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ComputeType left, Azure.ResourceManager.MachineLearningServices.Models.ComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.ComputeResource>
    {
        protected ComputeUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.ComputeResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ComputeResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerResourceRequirements
    {
        public ContainerResourceRequirements() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ContainerResourceSettings ContainerResourceLimits { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ContainerResourceSettings ContainerResourceRequests { get { throw null; } set { } }
    }
    public partial class ContainerResourceSettings
    {
        public ContainerResourceSettings() { }
        public string Cpu { get { throw null; } set { } }
        public string Gpu { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ContainerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ContainerType InferenceServer { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ContainerType StorageInitializer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ContainerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ContainerType left, Azure.ResourceManager.MachineLearningServices.Models.ContainerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ContainerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ContainerType left, Azure.ResourceManager.MachineLearningServices.Models.ContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDbSettings
    {
        public CosmosDbSettings() { }
        public int? CollectionsThroughput { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.CreatedByType left, Azure.ResourceManager.MachineLearningServices.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.CreatedByType left, Azure.ResourceManager.MachineLearningServices.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CredentialsType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.CredentialsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CredentialsType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.CredentialsType AccountKey { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CredentialsType Certificate { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CredentialsType None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CredentialsType Sas { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CredentialsType ServicePrincipal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.CredentialsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.CredentialsType left, Azure.ResourceManager.MachineLearningServices.Models.CredentialsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.CredentialsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.CredentialsType left, Azure.ResourceManager.MachineLearningServices.Models.CredentialsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Databricks : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public Databricks() { }
        public Azure.ResourceManager.MachineLearningServices.Models.DatabricksProperties Properties { get { throw null; } set { } }
    }
    public partial class DatabricksComputeSecrets : Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets
    {
        internal DatabricksComputeSecrets() { }
        public string DatabricksAccessToken { get { throw null; } }
    }
    public partial class DatabricksComputeSecretsProperties
    {
        internal DatabricksComputeSecretsProperties() { }
        public string DatabricksAccessToken { get { throw null; } }
    }
    public partial class DatabricksProperties
    {
        public DatabricksProperties() { }
        public string DatabricksAccessToken { get { throw null; } set { } }
        public string WorkspaceUrl { get { throw null; } set { } }
    }
    public partial class DataFactory : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public DataFactory() { }
    }
    public partial class DataLakeAnalytics : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public DataLakeAnalytics() { }
        public Azure.ResourceManager.MachineLearningServices.Models.DataLakeAnalyticsProperties Properties { get { throw null; } set { } }
    }
    public partial class DataLakeAnalyticsProperties
    {
        public DataLakeAnalyticsProperties() { }
        public string DataLakeStoreAccountName { get { throw null; } set { } }
    }
    public partial class DataPathAssetReference : Azure.ResourceManager.MachineLearningServices.Models.AssetReferenceBase
    {
        public DataPathAssetReference() { }
        public string DatastoreId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class DatasetContainer : Azure.ResourceManager.MachineLearningServices.Models.AssetContainer
    {
        public DatasetContainer() { }
    }
    public partial class DatasetContainerCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource>
    {
        protected DatasetContainerCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.DatasetContainerResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetContainerResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatasetContainerDeleteOperation : Azure.Operation
    {
        protected DatasetContainerDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatasetVersion : Azure.ResourceManager.MachineLearningServices.Models.AssetBase
    {
        public DatasetVersion(System.Collections.Generic.IEnumerable<Azure.ResourceManager.MachineLearningServices.Models.UriReference> paths) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.UriReference> Paths { get { throw null; } }
    }
    public partial class DatasetVersionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource>
    {
        protected DatasetVersionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.DatasetVersionResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatasetVersionResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatasetVersionDeleteOperation : Azure.Operation
    {
        protected DatasetVersionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Datastore : Azure.ResourceManager.MachineLearningServices.Models.ResourceBase
    {
        public Datastore(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials) { }
        public Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials Credentials { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } }
    }
    public partial class DatastoreCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.DatastoreResource>
    {
        protected DatastoreCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.DatastoreResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.DatastoreResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoreCredentials
    {
        public DatastoreCredentials() { }
    }
    public partial class DatastoreDeleteOperation : Azure.Operation
    {
        protected DatastoreDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoreSecrets
    {
        public DatastoreSecrets() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatastoreType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.DatastoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatastoreType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.DatastoreType AzureBlob { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DatastoreType AzureDataLakeGen1 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DatastoreType AzureDataLakeGen2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DatastoreType AzureFile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.DatastoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.DatastoreType left, Azure.ResourceManager.MachineLearningServices.Models.DatastoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.DatastoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.DatastoreType left, Azure.ResourceManager.MachineLearningServices.Models.DatastoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DefaultScaleSettings : Azure.ResourceManager.MachineLearningServices.Models.OnlineScaleSettings
    {
        public DefaultScaleSettings() { }
    }
    public partial class DeploymentLogs
    {
        internal DeploymentLogs() { }
        public string Content { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Scaling { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentSkuResourceType
    {
        internal DeploymentSkuResourceType() { }
        public Azure.ResourceManager.MachineLearningServices.Models.SkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.SkuSetting Sku { get { throw null; } }
    }
    public partial class DiagnoseRequestProperties
    {
        public DiagnoseRequestProperties() { }
        public System.Collections.Generic.IDictionary<string, object> ApplicationInsights { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> ContainerRegistry { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> DnsResolution { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> KeyVault { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Nsg { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Others { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> ResourceLock { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> StorageAccount { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Udr { get { throw null; } }
    }
    public partial class DiagnoseResponseResult
    {
        internal DiagnoseResponseResult() { }
        public Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResponseResultValue Value { get { throw null; } }
    }
    public partial class DiagnoseResponseResultValue
    {
        internal DiagnoseResponseResultValue() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> ApplicationInsightsResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> ContainerRegistryResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> DnsResolutionResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> KeyVaultResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> NetworkSecurityRuleResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> OtherResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> ResourceLockResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> StorageAccountResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResult> UserDefinedRouteResults { get { throw null; } }
    }
    public partial class DiagnoseResult
    {
        internal DiagnoseResult() { }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel? Level { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiagnoseResultLevel : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiagnoseResultLevel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel Error { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel Information { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel left, Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel left, Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResultLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DistributionConfiguration
    {
        public DistributionConfiguration() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DistributionType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.DistributionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DistributionType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.DistributionType Mpi { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DistributionType PyTorch { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DistributionType TensorFlow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.DistributionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.DistributionType left, Azure.ResourceManager.MachineLearningServices.Models.DistributionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.DistributionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.DistributionType left, Azure.ResourceManager.MachineLearningServices.Models.DistributionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EarlyTerminationPolicy
    {
        public EarlyTerminationPolicy() { }
        public int? DelayEvaluation { get { throw null; } set { } }
        public int? EvaluationInterval { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EarlyTerminationPolicyType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EarlyTerminationPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType Bandit { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType MedianStopping { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType TruncationSelection { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType left, Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType left, Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionProperty
    {
        public EncryptionProperty(Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus status, Azure.ResourceManager.MachineLearningServices.Models.KeyVaultProperties keyVaultProperties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.IdentityForCmk Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus left, Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus left, Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointAuthKeys
    {
        public EndpointAuthKeys() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointAuthMode : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointAuthMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode AADToken { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode AMLToken { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode Key { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode left, Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode left, Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointAuthToken
    {
        internal EndpointAuthToken() { }
        public string AccessToken { get { throw null; } }
        public long? ExpiryTimeUtc { get { throw null; } }
        public long? RefreshAfterTimeUtc { get { throw null; } }
        public string TokenType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointComputeType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointComputeType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType AzureMLCompute { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType left, Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType left, Azure.ResourceManager.MachineLearningServices.Models.EndpointComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointDeploymentPropertiesBase
    {
        public EndpointDeploymentPropertiesBase() { }
        public Azure.ResourceManager.MachineLearningServices.Models.CodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
    }
    public partial class EndpointPropertiesBase
    {
        public EndpointPropertiesBase(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode authMode) { }
        public Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode AuthMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthKeys Keys { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public string ScoringUri { get { throw null; } }
        public string SwaggerUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentContainer : Azure.ResourceManager.MachineLearningServices.Models.AssetContainer
    {
        public EnvironmentContainer() { }
    }
    public partial class EnvironmentContainerCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>
    {
        protected EnvironmentContainerCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentContainerResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentContainerDeleteOperation : Azure.Operation
    {
        protected EnvironmentContainerDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType Curated { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType UserCreated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType left, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType left, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentVersion : Azure.ResourceManager.MachineLearningServices.Models.AssetBase
    {
        public EnvironmentVersion() { }
        public Azure.ResourceManager.MachineLearningServices.Models.BuildContext Build { get { throw null; } set { } }
        public string CondaFile { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EnvironmentType? EnvironmentType { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.InferenceContainerProperties InferenceConfig { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType? OsType { get { throw null; } set { } }
    }
    public partial class EnvironmentVersionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource>
    {
        protected EnvironmentVersionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.EnvironmentVersionResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentVersionDeleteOperation : Azure.Operation
    {
        protected EnvironmentVersionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EstimatedVMPrice
    {
        internal EstimatedVMPrice() { }
        public Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType OsType { get { throw null; } }
        public double RetailPrice { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.VMTier VmTier { get { throw null; } }
    }
    public partial class EstimatedVMPrices
    {
        internal EstimatedVMPrices() { }
        public Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency BillingCurrency { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure UnitOfMeasure { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.EstimatedVMPrice> Values { get { throw null; } }
    }
    public partial class ExternalFqdnResponse
    {
        internal ExternalFqdnResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.FqdnEndpoints> Value { get { throw null; } }
    }
    public partial class FlavorData
    {
        public FlavorData() { }
        public System.Collections.Generic.IDictionary<string, string> Data { get { throw null; } set { } }
    }
    public partial class FqdnEndpoint
    {
        internal FqdnEndpoint() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.FqdnEndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class FqdnEndpointDetail
    {
        internal FqdnEndpointDetail() { }
        public int? Port { get { throw null; } }
    }
    public partial class FqdnEndpoints
    {
        internal FqdnEndpoints() { }
        public Azure.ResourceManager.MachineLearningServices.Models.FqdnEndpointsProperties Properties { get { throw null; } }
    }
    public partial class FqdnEndpointsProperties
    {
        internal FqdnEndpointsProperties() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.FqdnEndpoint> Endpoints { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Goal : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.Goal>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Goal(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.Goal Maximize { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Goal Minimize { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.Goal other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.Goal left, Azure.ResourceManager.MachineLearningServices.Models.Goal right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.Goal (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.Goal left, Azure.ResourceManager.MachineLearningServices.Models.Goal right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsight : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public HDInsight() { }
        public Azure.ResourceManager.MachineLearningServices.Models.HDInsightProperties Properties { get { throw null; } set { } }
    }
    public partial class HDInsightProperties
    {
        public HDInsightProperties() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } set { } }
        public int? SshPort { get { throw null; } set { } }
    }
    public partial class IdAssetReference : Azure.ResourceManager.MachineLearningServices.Models.AssetReferenceBase
    {
        public IdAssetReference(string assetId) { }
        public string AssetId { get { throw null; } set { } }
    }
    public partial class Identity
    {
        public Identity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public partial class IdentityConfiguration
    {
        public IdentityConfiguration() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityConfigurationType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.IdentityConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.IdentityConfigurationType AMLToken { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.IdentityConfigurationType Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.IdentityConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.IdentityConfigurationType left, Azure.ResourceManager.MachineLearningServices.Models.IdentityConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.IdentityConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.IdentityConfigurationType left, Azure.ResourceManager.MachineLearningServices.Models.IdentityConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IdentityForCmk
    {
        public IdentityForCmk() { }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class InferenceContainerProperties
    {
        public InferenceContainerProperties() { }
        public Azure.ResourceManager.MachineLearningServices.Models.Route LivenessRoute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Route ReadinessRoute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Route ScoringRoute { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InputDataDeliveryMode : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.InputDataDeliveryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InputDataDeliveryMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.InputDataDeliveryMode Download { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.InputDataDeliveryMode ReadOnlyMount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.InputDataDeliveryMode ReadWriteMount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.InputDataDeliveryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.InputDataDeliveryMode left, Azure.ResourceManager.MachineLearningServices.Models.InputDataDeliveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.InputDataDeliveryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.InputDataDeliveryMode left, Azure.ResourceManager.MachineLearningServices.Models.InputDataDeliveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InstanceTypeSchema
    {
        public InstanceTypeSchema() { }
        public System.Collections.Generic.IDictionary<string, string> NodeSelector { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.InstanceTypeSchemaResources Resources { get { throw null; } set { } }
    }
    public partial class InstanceTypeSchemaResources
    {
        public InstanceTypeSchemaResources() { }
        public System.Collections.Generic.IDictionary<string, string> Limits { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Requests { get { throw null; } }
    }
    public partial class Job : Azure.ResourceManager.MachineLearningServices.Models.JobBase
    {
        public Job() { }
    }
    public partial class JobBase : Azure.ResourceManager.MachineLearningServices.Models.ResourceBase
    {
        public JobBase() { }
        public string ComputeId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExperimentName { get { throw null; } set { } }
        public string ParentJobName { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobService> Services { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.JobStatus? Status { get { throw null; } }
    }
    public partial class JobCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.JobBaseResource>
    {
        protected JobCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.JobBaseResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.JobBaseResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobDeleteOperation : Azure.Operation
    {
        protected JobDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobInput
    {
        public JobInput() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class JobInputDataset : Azure.ResourceManager.MachineLearningServices.Models.JobInput
    {
        public JobInputDataset(string datasetId) { }
        public string DatasetId { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.InputDataDeliveryMode? Mode { get { throw null; } set { } }
    }
    public partial class JobInputLiteral : Azure.ResourceManager.MachineLearningServices.Models.JobInput
    {
        public JobInputLiteral() { }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobInputType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.JobInputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobInputType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobInputType Dataset { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobInputType Literal { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobInputType Uri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.JobInputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.JobInputType left, Azure.ResourceManager.MachineLearningServices.Models.JobInputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.JobInputType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.JobInputType left, Azure.ResourceManager.MachineLearningServices.Models.JobInputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobInputUri : Azure.ResourceManager.MachineLearningServices.Models.JobInput
    {
        public JobInputUri(Azure.ResourceManager.MachineLearningServices.Models.UriReference uri) { }
        public Azure.ResourceManager.MachineLearningServices.Models.InputDataDeliveryMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.UriReference Uri { get { throw null; } set { } }
    }
    public partial class JobLimits
    {
        public JobLimits() { }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobLimitsType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.JobLimitsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobLimitsType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobLimitsType Command { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobLimitsType Sweep { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.JobLimitsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.JobLimitsType left, Azure.ResourceManager.MachineLearningServices.Models.JobLimitsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.JobLimitsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.JobLimitsType left, Azure.ResourceManager.MachineLearningServices.Models.JobLimitsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobOutput
    {
        public JobOutput() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class JobOutputDataset : Azure.ResourceManager.MachineLearningServices.Models.JobOutput
    {
        public JobOutputDataset() { }
        public Azure.ResourceManager.MachineLearningServices.Models.OutputDataDeliveryMode? Mode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobOutputType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.JobOutputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobOutputType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobOutputType Dataset { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobOutputType Uri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.JobOutputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.JobOutputType left, Azure.ResourceManager.MachineLearningServices.Models.JobOutputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.JobOutputType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.JobOutputType left, Azure.ResourceManager.MachineLearningServices.Models.JobOutputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobOutputUri : Azure.ResourceManager.MachineLearningServices.Models.JobOutput
    {
        public JobOutputUri() { }
        public Azure.ResourceManager.MachineLearningServices.Models.OutputDataDeliveryMode? Mode { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.UriReference Uri { get { throw null; } }
    }
    public partial class JobService
    {
        public JobService() { }
        public string Endpoint { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } }
        public string JobServiceType { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus CancelRequested { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Finalizing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus NotResponding { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Preparing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.JobStatus left, Azure.ResourceManager.MachineLearningServices.Models.JobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.JobStatus left, Azure.ResourceManager.MachineLearningServices.Models.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.JobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobType Base { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobType Command { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobType Pipeline { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobType Sweep { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.JobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.JobType left, Azure.ResourceManager.MachineLearningServices.Models.JobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.JobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.JobType left, Azure.ResourceManager.MachineLearningServices.Models.JobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.KeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.KeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.KeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.KeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.KeyType left, Azure.ResourceManager.MachineLearningServices.Models.KeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.KeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.KeyType left, Azure.ResourceManager.MachineLearningServices.Models.KeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties(string keyVaultArmId, string keyIdentifier) { }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
        public string KeyVaultArmId { get { throw null; } set { } }
    }
    public partial class Kubernetes : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public Kubernetes() { }
        public Azure.ResourceManager.MachineLearningServices.Models.KubernetesProperties Properties { get { throw null; } set { } }
    }
    public partial class KubernetesOnlineDeployment : Azure.ResourceManager.MachineLearningServices.Models.OnlineDeployment
    {
        public KubernetesOnlineDeployment() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ContainerResourceRequirements ContainerResourceRequirements { get { throw null; } set { } }
    }
    public partial class KubernetesProperties
    {
        public KubernetesProperties() { }
        public string DefaultInstanceType { get { throw null; } set { } }
        public string ExtensionInstanceReleaseTrain { get { throw null; } set { } }
        public string ExtensionPrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.InstanceTypeSchema> InstanceTypes { get { throw null; } }
        public string Namespace { get { throw null; } set { } }
        public string RelayConnectionString { get { throw null; } set { } }
        public string ServiceBusConnectionString { get { throw null; } set { } }
        public string VcName { get { throw null; } set { } }
    }
    public partial class KubernetesSchema
    {
        public KubernetesSchema() { }
        public Azure.ResourceManager.MachineLearningServices.Models.KubernetesProperties Properties { get { throw null; } set { } }
    }
    public partial class ListNotebookKeysResult
    {
        internal ListNotebookKeysResult() { }
        public string PrimaryAccessKey { get { throw null; } }
        public string SecondaryAccessKey { get { throw null; } }
    }
    public partial class ListStorageAccountKeysResult
    {
        internal ListStorageAccountKeysResult() { }
        public string UserStorageKey { get { throw null; } }
    }
    public partial class ListWorkspaceKeysResult
    {
        internal ListWorkspaceKeysResult() { }
        public string AppInsightsInstrumentationKey { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.RegistryListCredentialsResult ContainerRegistryCredentials { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ListNotebookKeysResult NotebookAccessKeys { get { throw null; } }
        public string UserStorageKey { get { throw null; } }
        public string UserStorageResourceId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadBalancerType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadBalancerType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType InternalLoadBalancer { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType PublicIp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType left, Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType left, Azure.ResourceManager.MachineLearningServices.Models.LoadBalancerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedIdentity : Azure.ResourceManager.MachineLearningServices.Models.IdentityConfiguration
    {
        public ManagedIdentity() { }
        public System.Guid? ClientId { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class ManagedOnlineDeployment : Azure.ResourceManager.MachineLearningServices.Models.OnlineDeployment
    {
        public ManagedOnlineDeployment() { }
    }
    public partial class MedianStoppingPolicy : Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicy
    {
        public MedianStoppingPolicy() { }
    }
    public partial class ModelContainer : Azure.ResourceManager.MachineLearningServices.Models.AssetContainer
    {
        public ModelContainer() { }
    }
    public partial class ModelContainerCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>
    {
        protected ModelContainerCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.ModelContainerResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelContainerResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelContainerDeleteOperation : Azure.Operation
    {
        protected ModelContainerDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelFormat : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ModelFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelFormat(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ModelFormat Custom { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ModelFormat MLFlow { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ModelFormat OpenAI { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ModelFormat Triton { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ModelFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ModelFormat left, Azure.ResourceManager.MachineLearningServices.Models.ModelFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ModelFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ModelFormat left, Azure.ResourceManager.MachineLearningServices.Models.ModelFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelVersion : Azure.ResourceManager.MachineLearningServices.Models.AssetBase
    {
        public ModelVersion(string modelUri) { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.FlavorData> Flavors { get { throw null; } set { } }
        public string JobName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelFormat? ModelFormat { get { throw null; } set { } }
        public string ModelUri { get { throw null; } set { } }
    }
    public partial class ModelVersionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>
    {
        protected ModelVersionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.ModelVersionResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.ModelVersionResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelVersionDeleteOperation : Azure.Operation
    {
        protected ModelVersionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Mpi : Azure.ResourceManager.MachineLearningServices.Models.DistributionConfiguration
    {
        public Mpi() { }
        public int? ProcessCountPerInstance { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.NodeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Idle { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Leaving { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Preempted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Preparing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Unusable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.NodeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.NodeState left, Azure.ResourceManager.MachineLearningServices.Models.NodeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.NodeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.NodeState left, Azure.ResourceManager.MachineLearningServices.Models.NodeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeStateCounts
    {
        internal NodeStateCounts() { }
        public int? IdleNodeCount { get { throw null; } }
        public int? LeavingNodeCount { get { throw null; } }
        public int? PreemptedNodeCount { get { throw null; } }
        public int? PreparingNodeCount { get { throw null; } }
        public int? RunningNodeCount { get { throw null; } }
        public int? UnusableNodeCount { get { throw null; } }
    }
    public partial class NoneDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials
    {
        public NoneDatastoreCredentials() { }
    }
    public partial class NotebookAccessTokenResult
    {
        internal NotebookAccessTokenResult() { }
        public string AccessToken { get { throw null; } }
        public int? ExpiresIn { get { throw null; } }
        public string HostName { get { throw null; } }
        public string NotebookResourceId { get { throw null; } }
        public string PublicDns { get { throw null; } }
        public string RefreshToken { get { throw null; } }
        public string Scope { get { throw null; } }
        public string TokenType { get { throw null; } }
    }
    public partial class NotebookPreparationError
    {
        internal NotebookPreparationError() { }
        public string ErrorMessage { get { throw null; } }
        public int? StatusCode { get { throw null; } }
    }
    public partial class NotebookResourceInfo
    {
        internal NotebookResourceInfo() { }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.NotebookPreparationError NotebookPreparationError { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class Objective
    {
        public Objective(Azure.ResourceManager.MachineLearningServices.Models.Goal goal, string primaryMetric) { }
        public Azure.ResourceManager.MachineLearningServices.Models.Goal Goal { get { throw null; } set { } }
        public string PrimaryMetric { get { throw null; } set { } }
    }
    public partial class OnlineDeployment : Azure.ResourceManager.MachineLearningServices.Models.EndpointDeploymentPropertiesBase
    {
        public OnlineDeployment() { }
        public bool? AppInsightsEnabled { get { throw null; } set { } }
        public string InstanceType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ProbeSettings LivenessProbe { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string ModelMountPath { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.DeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ProbeSettings ReadinessProbe { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.OnlineRequestSettings RequestSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.OnlineScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    public partial class OnlineDeploymentCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>
    {
        protected OnlineDeploymentCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineDeploymentDeleteOperation : Azure.Operation
    {
        protected OnlineDeploymentDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineDeploymentUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>
    {
        protected OnlineDeploymentUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineDeploymentTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpoint : Azure.ResourceManager.MachineLearningServices.Models.EndpointPropertiesBase
    {
        public OnlineEndpoint(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode authMode) : base (default(Azure.ResourceManager.MachineLearningServices.Models.EndpointAuthMode)) { }
        public bool? AllowPublicAccess { get { throw null; } set { } }
        public string Compute { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EndpointProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, int> Traffic { get { throw null; } set { } }
    }
    public partial class OnlineEndpointCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>
    {
        protected OnlineEndpointCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpointDeleteOperation : Azure.Operation
    {
        protected OnlineEndpointDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpointRegenerateKeysOperation : Azure.Operation
    {
        protected OnlineEndpointRegenerateKeysOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineEndpointUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>
    {
        protected OnlineEndpointUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.OnlineEndpointTrackedResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineRequestSettings
    {
        public OnlineRequestSettings() { }
        public int? MaxConcurrentRequestsPerInstance { get { throw null; } set { } }
        public System.TimeSpan? MaxQueueWait { get { throw null; } set { } }
        public System.TimeSpan? RequestTimeout { get { throw null; } set { } }
    }
    public partial class OnlineScaleSettings
    {
        public OnlineScaleSettings() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatingSystemType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType left, Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType left, Azure.ResourceManager.MachineLearningServices.Models.OperatingSystemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationName : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationName(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Create { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Delete { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Reimage { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Restart { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Start { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OperationName left, Azure.ResourceManager.MachineLearningServices.Models.OperationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OperationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OperationName left, Azure.ResourceManager.MachineLearningServices.Models.OperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus ReimageFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus RestartFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus StartFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus StopFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OperationStatus left, Azure.ResourceManager.MachineLearningServices.Models.OperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OperationStatus left, Azure.ResourceManager.MachineLearningServices.Models.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrderString : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OrderString>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderString(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OrderString CreatedAtAsc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OrderString CreatedAtDesc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OrderString UpdatedAtAsc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OrderString UpdatedAtDesc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OrderString other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OrderString left, Azure.ResourceManager.MachineLearningServices.Models.OrderString right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OrderString (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OrderString left, Azure.ResourceManager.MachineLearningServices.Models.OrderString right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OsType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OsType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OsType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OsType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OsType left, Azure.ResourceManager.MachineLearningServices.Models.OsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OsType left, Azure.ResourceManager.MachineLearningServices.Models.OsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutputDataDeliveryMode : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OutputDataDeliveryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutputDataDeliveryMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OutputDataDeliveryMode ReadWriteMount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OutputDataDeliveryMode Upload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OutputDataDeliveryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OutputDataDeliveryMode left, Azure.ResourceManager.MachineLearningServices.Models.OutputDataDeliveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OutputDataDeliveryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OutputDataDeliveryMode left, Azure.ResourceManager.MachineLearningServices.Models.OutputDataDeliveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutputPathAssetReference : Azure.ResourceManager.MachineLearningServices.Models.AssetReferenceBase
    {
        public OutputPathAssetReference() { }
        public string JobId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class PartialAssetReferenceBase
    {
        public PartialAssetReferenceBase() { }
    }
    public partial class PartialBatchDeployment
    {
        public PartialBatchDeployment() { }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialCodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public string Compute { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public int? ErrorThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchLoggingLevel? LoggingLevel { get { throw null; } set { } }
        public int? MaxConcurrencyPerInstance { get { throw null; } set { } }
        public long? MiniBatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialAssetReferenceBase Model { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchOutputAction? OutputAction { get { throw null; } set { } }
        public string OutputFileName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialBatchRetrySettings RetrySettings { get { throw null; } set { } }
    }
    public partial class PartialBatchDeploymentPartialTrackedResource
    {
        public PartialBatchDeploymentPartialTrackedResource() { }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialBatchDeployment Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PartialBatchEndpoint
    {
        public PartialBatchEndpoint() { }
        public Azure.ResourceManager.MachineLearningServices.Models.BatchEndpointDefaults Defaults { get { throw null; } set { } }
    }
    public partial class PartialBatchEndpointPartialTrackedResource
    {
        public PartialBatchEndpointPartialTrackedResource() { }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialBatchEndpoint Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PartialBatchRetrySettings
    {
        public PartialBatchRetrySettings() { }
        public int? MaxRetries { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class PartialCodeConfiguration
    {
        public PartialCodeConfiguration() { }
        public string CodeId { get { throw null; } set { } }
        public string ScoringScript { get { throw null; } set { } }
    }
    public partial class PartialContainerResourceRequirements
    {
        public PartialContainerResourceRequirements() { }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialContainerResourceSettings ContainerResourceLimits { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialContainerResourceSettings ContainerResourceRequests { get { throw null; } set { } }
    }
    public partial class PartialContainerResourceSettings
    {
        public PartialContainerResourceSettings() { }
        public string Cpu { get { throw null; } set { } }
        public string Gpu { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
    }
    public partial class PartialDataPathAssetReference : Azure.ResourceManager.MachineLearningServices.Models.PartialAssetReferenceBase
    {
        public PartialDataPathAssetReference() { }
        public string DatastoreId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class PartialDefaultScaleSettings : Azure.ResourceManager.MachineLearningServices.Models.PartialOnlineScaleSettings
    {
        public PartialDefaultScaleSettings() { }
    }
    public partial class PartialIdAssetReference : Azure.ResourceManager.MachineLearningServices.Models.PartialAssetReferenceBase
    {
        public PartialIdAssetReference() { }
        public string AssetId { get { throw null; } set { } }
    }
    public partial class PartialKubernetesOnlineDeployment : Azure.ResourceManager.MachineLearningServices.Models.PartialOnlineDeployment
    {
        public PartialKubernetesOnlineDeployment() { }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialContainerResourceRequirements ContainerResourceRequirements { get { throw null; } set { } }
    }
    public partial class PartialManagedOnlineDeployment : Azure.ResourceManager.MachineLearningServices.Models.PartialOnlineDeployment
    {
        public PartialManagedOnlineDeployment() { }
        public string ModelMountPath { get { throw null; } set { } }
    }
    public partial class PartialOnlineDeployment
    {
        public PartialOnlineDeployment() { }
        public bool? AppInsightsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialProbeSettings LivenessProbe { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialProbeSettings ReadinessProbe { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialOnlineRequestSettings RequestSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialOnlineScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    public partial class PartialOnlineDeploymentPartialTrackedResource
    {
        public PartialOnlineDeploymentPartialTrackedResource() { }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialOnlineDeployment Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PartialOnlineEndpoint
    {
        public PartialOnlineEndpoint() { }
        public System.Collections.Generic.IDictionary<string, int> Traffic { get { throw null; } set { } }
    }
    public partial class PartialOnlineEndpointPartialTrackedResource
    {
        public PartialOnlineEndpointPartialTrackedResource() { }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialOnlineEndpoint Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PartialSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PartialOnlineRequestSettings
    {
        public PartialOnlineRequestSettings() { }
        public int? MaxConcurrentRequestsPerInstance { get { throw null; } set { } }
        public System.TimeSpan? MaxQueueWait { get { throw null; } set { } }
        public System.TimeSpan? RequestTimeout { get { throw null; } set { } }
    }
    public partial class PartialOnlineScaleSettings
    {
        public PartialOnlineScaleSettings() { }
    }
    public partial class PartialOutputPathAssetReference : Azure.ResourceManager.MachineLearningServices.Models.PartialAssetReferenceBase
    {
        public PartialOutputPathAssetReference() { }
        public string JobId { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class PartialProbeSettings
    {
        public PartialProbeSettings() { }
        public int? FailureThreshold { get { throw null; } set { } }
        public System.TimeSpan? InitialDelay { get { throw null; } set { } }
        public System.TimeSpan? Period { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class PartialResourceIdentity
    {
        public PartialResourceIdentity() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityAssignment? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public partial class PartialSku
    {
        public PartialSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SkuTier? Tier { get { throw null; } set { } }
    }
    public partial class PartialTargetUtilizationScaleSettings : Azure.ResourceManager.MachineLearningServices.Models.PartialOnlineScaleSettings
    {
        public PartialTargetUtilizationScaleSettings() { }
        public int? MaxInstances { get { throw null; } set { } }
        public int? MinInstances { get { throw null; } set { } }
        public System.TimeSpan? PollingInterval { get { throw null; } set { } }
        public int? TargetUtilizationPercentage { get { throw null; } set { } }
    }
    public partial class Password
    {
        internal Password() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class PersonalComputeInstanceSettings
    {
        public PersonalComputeInstanceSettings() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AssignedUser AssignedUser { get { throw null; } set { } }
    }
    public partial class PipelineJob : Azure.ResourceManager.MachineLearningServices.Models.JobBase
    {
        public PipelineJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.Binding> Bindings { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.ComponentJob> ComponentJobs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobInput> Inputs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobOutput> Outputs { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
    }
    public partial class PrivateEndpoint
    {
        public PrivateEndpoint() { }
        public string Id { get { throw null; } }
        public string SubnetArmId { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>
    {
        protected PrivateEndpointConnectionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public readonly partial struct PrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.Models.Resource
    {
        public PrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.Identity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PrivateLinkResourceListResult
    {
        internal PrivateLinkResourceListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.PrivateLinkResource> Value { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class ProbeSettings
    {
        public ProbeSettings() { }
        public int? FailureThreshold { get { throw null; } set { } }
        public System.TimeSpan? InitialDelay { get { throw null; } set { } }
        public System.TimeSpan? Period { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess left, Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess left, Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PyTorch : Azure.ResourceManager.MachineLearningServices.Models.DistributionConfiguration
    {
        public PyTorch() { }
        public int? ProcessCountPerInstance { get { throw null; } set { } }
    }
    public partial class QuotaBaseProperties
    {
        public QuotaBaseProperties() { }
        public string Id { get { throw null; } set { } }
        public long? Limit { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit? Unit { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaUnit : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaUnit(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit left, Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit left, Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReferenceType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ReferenceType DataPath { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ReferenceType Id { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ReferenceType OutputPath { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ReferenceType left, Azure.ResourceManager.MachineLearningServices.Models.ReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ReferenceType left, Azure.ResourceManager.MachineLearningServices.Models.ReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegistryListCredentialsResult
    {
        internal RegistryListCredentialsResult() { }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.Password> Passwords { get { throw null; } }
        public string Username { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteLoginPortPublicAccess : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteLoginPortPublicAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess left, Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess left, Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceBase
    {
        public ResourceBase() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class ResourceConfiguration
    {
        public ResourceConfiguration() { }
        public int? InstanceCount { get { throw null; } set { } }
        public string InstanceType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Properties { get { throw null; } set { } }
    }
    public partial class ResourceIdentity
    {
        public ResourceIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityAssignment? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceIdentityAssignment : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityAssignment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceIdentityAssignment(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityAssignment None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityAssignment SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityAssignment SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityAssignment UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityAssignment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityAssignment left, Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityAssignment right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityAssignment (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityAssignment left, Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityAssignment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        SystemAssignedUserAssigned = 1,
        UserAssigned = 2,
        None = 3,
    }
    public partial class ResourceName
    {
        internal ResourceName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ResourceQuota
    {
        internal ResourceQuota() { }
        public string AmlWorkspaceLocation { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceName Name { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit? Unit { get { throw null; } }
    }
    public partial class Route
    {
        public Route(string path, int port) { }
        public string Path { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SamplingAlgorithm : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SamplingAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm Bayesian { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm Grid { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm Random { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm left, Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm left, Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SasDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials
    {
        public SasDatastoreCredentials(Azure.ResourceManager.MachineLearningServices.Models.SasDatastoreSecrets secrets) { }
        public Azure.ResourceManager.MachineLearningServices.Models.SasDatastoreSecrets Secrets { get { throw null; } set { } }
    }
    public partial class SasDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets
    {
        public SasDatastoreSecrets() { }
        public string SasToken { get { throw null; } set { } }
    }
    public partial class ScaleSettings
    {
        public ScaleSettings(int maxNodeCount) { }
        public int MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
        public System.TimeSpan? NodeIdleTimeBeforeScaleDown { get { throw null; } set { } }
    }
    public partial class ScaleSettingsInformation
    {
        public ScaleSettingsInformation() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ScaleType Default { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ScaleType TargetUtilization { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ScaleType left, Azure.ResourceManager.MachineLearningServices.Models.ScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ScaleType left, Azure.ResourceManager.MachineLearningServices.Models.ScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptReference
    {
        public ScriptReference() { }
        public string ScriptArguments { get { throw null; } set { } }
        public string ScriptData { get { throw null; } set { } }
        public string ScriptSource { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
    }
    public partial class ScriptsToExecute
    {
        public ScriptsToExecute() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ScriptReference CreationScript { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ScriptReference StartupScript { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretsType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.SecretsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretsType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.SecretsType AccountKey { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SecretsType Certificate { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SecretsType Sas { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SecretsType ServicePrincipal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.SecretsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.SecretsType left, Azure.ResourceManager.MachineLearningServices.Models.SecretsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.SecretsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.SecretsType left, Azure.ResourceManager.MachineLearningServices.Models.SecretsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceDataAccessAuthIdentity : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceDataAccessAuthIdentity(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity WorkspaceSystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity WorkspaceUserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity left, Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity left, Azure.ResourceManager.MachineLearningServices.Models.ServiceDataAccessAuthIdentity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceManagedResourcesSettings
    {
        public ServiceManagedResourcesSettings() { }
        public Azure.ResourceManager.MachineLearningServices.Models.CosmosDbSettings CosmosDb { get { throw null; } set { } }
    }
    public partial class ServicePrincipalDatastoreCredentials : Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials
    {
        public ServicePrincipalDatastoreCredentials(System.Guid clientId, Azure.ResourceManager.MachineLearningServices.Models.ServicePrincipalDatastoreSecrets secrets, System.Guid tenantId) { }
        public string AuthorityUrl { get { throw null; } set { } }
        public System.Guid ClientId { get { throw null; } set { } }
        public string ResourceUrl { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ServicePrincipalDatastoreSecrets Secrets { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public partial class ServicePrincipalDatastoreSecrets : Azure.ResourceManager.MachineLearningServices.Models.DatastoreSecrets
    {
        public ServicePrincipalDatastoreSecrets() { }
        public string ClientSecret { get { throw null; } set { } }
    }
    public partial class SetupScripts
    {
        public SetupScripts() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ScriptsToExecute Scripts { get { throw null; } set { } }
    }
    public partial class SharedPrivateLinkResource
    {
        public SharedPrivateLinkResource() { }
        public string GroupId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class Sku
    {
        public Sku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SkuTier? Tier { get { throw null; } set { } }
    }
    public partial class SkuCapacity
    {
        internal SkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType? ScaleType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuScaleType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuScaleType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType left, Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType left, Azure.ResourceManager.MachineLearningServices.Models.SkuScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuSetting
    {
        internal SkuSetting() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.SkuTier? Tier { get { throw null; } }
    }
    public enum SkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SshPublicAccess : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SshPublicAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess left, Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess left, Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SslConfiguration
    {
        public SslConfiguration() { }
        public string Cert { get { throw null; } set { } }
        public string Cname { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string LeafDomainLabel { get { throw null; } set { } }
        public bool? OverwriteExistingDomain { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslConfigurationStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslConfigurationStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus Auto { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus left, Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus left, Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status Failure { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status InvalidQuotaBelowClusterMinimum { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status InvalidQuotaExceedsSubscriptionLimit { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status InvalidVMFamilyName { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status OperationNotEnabledForRegion { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status OperationNotSupportedForSku { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status Success { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status Undefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.Status left, Azure.ResourceManager.MachineLearningServices.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.Status left, Azure.ResourceManager.MachineLearningServices.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SweepJob : Azure.ResourceManager.MachineLearningServices.Models.JobBase
    {
        public SweepJob(Azure.ResourceManager.MachineLearningServices.Models.Objective objective, Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm samplingAlgorithm, object searchSpace) { }
        public Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicy EarlyTermination { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.IdentityConfiguration Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobInput> Inputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SweepJobLimits Limits { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Objective Objective { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.JobOutput> Outputs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SamplingAlgorithm SamplingAlgorithm { get { throw null; } set { } }
        public object SearchSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TrialComponent Trial { get { throw null; } set { } }
    }
    public partial class SweepJobLimits : Azure.ResourceManager.MachineLearningServices.Models.JobLimits
    {
        public SweepJobLimits() { }
        public int? MaxConcurrentTrials { get { throw null; } set { } }
        public int? MaxTotalTrials { get { throw null; } set { } }
        public System.TimeSpan? TrialTimeout { get { throw null; } set { } }
    }
    public partial class SynapseSpark : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public SynapseSpark() { }
        public Azure.ResourceManager.MachineLearningServices.Models.SynapseSparkProperties Properties { get { throw null; } set { } }
    }
    public partial class SynapseSparkProperties
    {
        public SynapseSparkProperties() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AutoPauseProperties AutoPauseProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AutoScaleProperties AutoScaleProperties { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public string NodeSize { get { throw null; } set { } }
        public string NodeSizeFamily { get { throw null; } set { } }
        public string PoolName { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SparkVersion { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string WorkspaceName { get { throw null; } set { } }
    }
    public partial class SystemService
    {
        internal SystemService() { }
        public string PublicIpAddress { get { throw null; } }
        public string SystemServiceType { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class TargetUtilizationScaleSettings : Azure.ResourceManager.MachineLearningServices.Models.OnlineScaleSettings
    {
        public TargetUtilizationScaleSettings() { }
        public int? MaxInstances { get { throw null; } set { } }
        public int? MinInstances { get { throw null; } set { } }
        public System.TimeSpan? PollingInterval { get { throw null; } set { } }
        public int? TargetUtilizationPercentage { get { throw null; } set { } }
    }
    public partial class TensorFlow : Azure.ResourceManager.MachineLearningServices.Models.DistributionConfiguration
    {
        public TensorFlow() { }
        public int? ParameterServerCount { get { throw null; } set { } }
        public int? WorkerCount { get { throw null; } set { } }
    }
    public partial class TrialComponent
    {
        public TrialComponent(string command) { }
        public string CodeId { get { throw null; } set { } }
        public string Command { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.DistributionConfiguration Distribution { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceConfiguration Resources { get { throw null; } set { } }
    }
    public partial class TruncationSelectionPolicy : Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicy
    {
        public TruncationSelectionPolicy() { }
        public int? TruncationPercentage { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnderlyingResourceAction : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnderlyingResourceAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction Delete { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction left, Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction left, Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnitOfMeasure : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnitOfMeasure(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure OneHour { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure left, Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure left, Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateWorkspaceQuotas
    {
        internal UpdateWorkspaceQuotas() { }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.Status? Status { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit? Unit { get { throw null; } }
    }
    public partial class UpdateWorkspaceQuotasResult
    {
        internal UpdateWorkspaceQuotasResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.UpdateWorkspaceQuotas> Value { get { throw null; } }
    }
    public partial class UriReference
    {
        public UriReference() { }
        public string File { get { throw null; } set { } }
        public string Folder { get { throw null; } set { } }
    }
    public partial class Usage
    {
        internal Usage() { }
        public string AmlWorkspaceLocation { get { throw null; } }
        public long? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.UsageName Name { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.UsageUnit? Unit { get { throw null; } }
    }
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageUnit : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.UsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.UsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.UsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.UsageUnit left, Azure.ResourceManager.MachineLearningServices.Models.UsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.UsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.UsageUnit left, Azure.ResourceManager.MachineLearningServices.Models.UsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserAccountCredentials
    {
        public UserAccountCredentials(string adminUserName) { }
        public string AdminUserName { get { throw null; } set { } }
        public string AdminUserPassword { get { throw null; } set { } }
        public string AdminUserSshPublicKey { get { throw null; } set { } }
    }
    public partial class UserAssignedIdentity
    {
        public UserAssignedIdentity() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValueFormat : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ValueFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValueFormat(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ValueFormat Json { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ValueFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ValueFormat left, Azure.ResourceManager.MachineLearningServices.Models.ValueFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ValueFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ValueFormat left, Azure.ResourceManager.MachineLearningServices.Models.ValueFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachine : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public VirtualMachine() { }
        public Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineProperties Properties { get { throw null; } set { } }
    }
    public partial class VirtualMachineProperties
    {
        public VirtualMachineProperties() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } set { } }
        public bool? IsNotebookInstanceCompute { get { throw null; } set { } }
        public int? SshPort { get { throw null; } set { } }
        public string VirtualMachineSize { get { throw null; } set { } }
    }
    public partial class VirtualMachineSecrets : Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets
    {
        internal VirtualMachineSecrets() { }
        public Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } }
    }
    public partial class VirtualMachineSize
    {
        internal VirtualMachineSize() { }
        public Azure.ResourceManager.MachineLearningServices.Models.EstimatedVMPrices EstimatedVMPrices { get { throw null; } }
        public string Family { get { throw null; } }
        public int? Gpus { get { throw null; } }
        public bool? LowPriorityCapable { get { throw null; } }
        public int? MaxResourceVolumeMB { get { throw null; } }
        public double? MemoryGB { get { throw null; } }
        public string Name { get { throw null; } }
        public int? OsVhdSizeMB { get { throw null; } }
        public bool? PremiumIO { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedComputeTypes { get { throw null; } }
        public int? VCPUs { get { throw null; } }
    }
    public partial class VirtualMachineSizeListResult
    {
        internal VirtualMachineSizeListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSize> Value { get { throw null; } }
    }
    public partial class VirtualMachineSshCredentials
    {
        public VirtualMachineSshCredentials() { }
        public string Password { get { throw null; } set { } }
        public string PrivateKeyData { get { throw null; } set { } }
        public string PublicKeyData { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMPriceOSType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMPriceOSType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType left, Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType left, Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmPriority : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.VmPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmPriority(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.VmPriority Dedicated { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.VmPriority LowPriority { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.VmPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.VmPriority left, Azure.ResourceManager.MachineLearningServices.Models.VmPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.VmPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.VmPriority left, Azure.ResourceManager.MachineLearningServices.Models.VmPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMTier : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.VMTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMTier(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMTier LowPriority { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMTier Spot { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.VMTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.VMTier left, Azure.ResourceManager.MachineLearningServices.Models.VMTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.VMTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.VMTier left, Azure.ResourceManager.MachineLearningServices.Models.VMTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceConnectionCreateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>
    {
        protected WorkspaceConnectionCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.WorkspaceConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.WorkspaceConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceConnectionDeleteOperation : Azure.Operation
    {
        protected WorkspaceConnectionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.Workspace>
    {
        protected WorkspaceCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.Workspace Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceDeleteOperation : Azure.Operation
    {
        protected WorkspaceDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceDiagnoseOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResponseResult>
    {
        protected WorkspaceDiagnoseOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResponseResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResponseResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DiagnoseResponseResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacePrepareNotebookOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.Models.NotebookResourceInfo>
    {
        protected WorkspacePrepareNotebookOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.Models.NotebookResourceInfo Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.NotebookResourceInfo>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.NotebookResourceInfo>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceResyncKeysOperation : Azure.Operation
    {
        protected WorkspaceResyncKeysOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.Workspace>
    {
        protected WorkspaceUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.Workspace Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Workspace>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceUpdateParameters
    {
        public WorkspaceUpdateParameters() { }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Identity Identity { get { throw null; } set { } }
        public string ImageBuildCompute { get { throw null; } set { } }
        public string PrimaryUserAssignedIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ServiceManagedResourcesSettings ServiceManagedResourcesSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
