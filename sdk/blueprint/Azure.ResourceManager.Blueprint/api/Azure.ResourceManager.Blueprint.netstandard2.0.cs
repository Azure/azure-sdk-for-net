namespace Azure.ResourceManager.Blueprint
{
    public partial class ArtifactData : Azure.ResourceManager.Models.ResourceData
    {
        public ArtifactData() { }
    }
    public partial class AssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Blueprint.AssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Blueprint.AssignmentResource>, System.Collections.IEnumerable
    {
        protected AssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.AssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assignmentName, Azure.ResourceManager.Blueprint.AssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.AssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assignmentName, Azure.ResourceManager.Blueprint.AssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.AssignmentResource> Get(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Blueprint.AssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Blueprint.AssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.AssignmentResource>> GetAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Blueprint.AssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Blueprint.AssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Blueprint.AssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Blueprint.AssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public AssignmentData(Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentity identity, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ParameterValue> parameters, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ResourceGroupValue> resourceGroups, Azure.Core.AzureLocation location) { }
        public string BlueprintId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public Azure.ResourceManager.Blueprint.Models.AssignmentLockSettings Locks { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ParameterValue> Parameters { get { throw null; } }
        public Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ResourceGroupValue> ResourceGroups { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public Azure.ResourceManager.Blueprint.Models.AssignmentStatus Status { get { throw null; } }
    }
    public partial class AssignmentOperationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Blueprint.AssignmentOperationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Blueprint.AssignmentOperationResource>, System.Collections.IEnumerable
    {
        protected AssignmentOperationCollection() { }
        public virtual Azure.Response<bool> Exists(string assignmentOperationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assignmentOperationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.AssignmentOperationResource> Get(string assignmentOperationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Blueprint.AssignmentOperationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Blueprint.AssignmentOperationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.AssignmentOperationResource>> GetAsync(string assignmentOperationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Blueprint.AssignmentOperationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Blueprint.AssignmentOperationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Blueprint.AssignmentOperationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Blueprint.AssignmentOperationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssignmentOperationData : Azure.ResourceManager.Models.ResourceData
    {
        public AssignmentOperationData() { }
        public string AssignmentState { get { throw null; } set { } }
        public string BlueprintVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Blueprint.Models.AssignmentDeploymentJob> Deployments { get { throw null; } }
        public string TimeCreated { get { throw null; } set { } }
        public string TimeFinished { get { throw null; } set { } }
        public string TimeStarted { get { throw null; } set { } }
    }
    public partial class AssignmentOperationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssignmentOperationResource() { }
        public virtual Azure.ResourceManager.Blueprint.AssignmentOperationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceScope, string assignmentName, string assignmentOperationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.AssignmentOperationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.AssignmentOperationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssignmentResource() { }
        public virtual Azure.ResourceManager.Blueprint.AssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceScope, string assignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.AssignmentResource> Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Blueprint.Models.AssignmentDeleteBehavior? deleteBehavior = default(Azure.ResourceManager.Blueprint.Models.AssignmentDeleteBehavior?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.AssignmentResource>> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Blueprint.Models.AssignmentDeleteBehavior? deleteBehavior = default(Azure.ResourceManager.Blueprint.Models.AssignmentDeleteBehavior?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.AssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.AssignmentOperationResource> GetAssignmentOperation(string assignmentOperationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.AssignmentOperationResource>> GetAssignmentOperationAsync(string assignmentOperationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Blueprint.AssignmentOperationCollection GetAssignmentOperations() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.AssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.AssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Blueprint.AssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.AssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Blueprint.AssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.Models.WhoIsBlueprintContract> WhoIsBlueprint(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.Models.WhoIsBlueprintContract>> WhoIsBlueprintAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlueprintArtifactCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Blueprint.BlueprintArtifactResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Blueprint.BlueprintArtifactResource>, System.Collections.IEnumerable
    {
        protected BlueprintArtifactCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.BlueprintArtifactResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string artifactName, Azure.ResourceManager.Blueprint.ArtifactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.BlueprintArtifactResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string artifactName, Azure.ResourceManager.Blueprint.ArtifactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.BlueprintArtifactResource> Get(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Blueprint.BlueprintArtifactResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Blueprint.BlueprintArtifactResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.BlueprintArtifactResource>> GetAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Blueprint.BlueprintArtifactResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Blueprint.BlueprintArtifactResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Blueprint.BlueprintArtifactResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Blueprint.BlueprintArtifactResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BlueprintArtifactResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BlueprintArtifactResource() { }
        public virtual Azure.ResourceManager.Blueprint.ArtifactData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceScope, string blueprintName, string artifactName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.BlueprintArtifactResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.BlueprintArtifactResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.BlueprintArtifactResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.BlueprintArtifactResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.BlueprintArtifactResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Blueprint.ArtifactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.BlueprintArtifactResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Blueprint.ArtifactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlueprintCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Blueprint.BlueprintResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Blueprint.BlueprintResource>, System.Collections.IEnumerable
    {
        protected BlueprintCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.BlueprintResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string blueprintName, Azure.ResourceManager.Blueprint.BlueprintData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.BlueprintResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string blueprintName, Azure.ResourceManager.Blueprint.BlueprintData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string blueprintName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string blueprintName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.BlueprintResource> Get(string blueprintName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Blueprint.BlueprintResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Blueprint.BlueprintResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.BlueprintResource>> GetAsync(string blueprintName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Blueprint.BlueprintResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Blueprint.BlueprintResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Blueprint.BlueprintResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Blueprint.BlueprintResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BlueprintData : Azure.ResourceManager.Models.ResourceData
    {
        public BlueprintData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.BinaryData Layout { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ParameterDefinition> Parameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ResourceGroupDefinition> ResourceGroups { get { throw null; } }
        public Azure.ResourceManager.Blueprint.Models.BlueprintStatus Status { get { throw null; } }
        public Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope? TargetScope { get { throw null; } set { } }
        public System.BinaryData Versions { get { throw null; } set { } }
    }
    public static partial class BlueprintExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Blueprint.AssignmentResource> GetAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.AssignmentResource>> GetAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Blueprint.AssignmentOperationResource GetAssignmentOperationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Blueprint.AssignmentResource GetAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Blueprint.AssignmentCollection GetAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Blueprint.BlueprintResource> GetBlueprint(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string blueprintName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Blueprint.BlueprintArtifactResource GetBlueprintArtifactResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.BlueprintResource>> GetBlueprintAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string blueprintName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Blueprint.BlueprintResource GetBlueprintResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Blueprint.BlueprintCollection GetBlueprints(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource GetBlueprintVersionArtifactResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Blueprint.PublishedBlueprintResource GetPublishedBlueprintResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class BlueprintResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BlueprintResource() { }
        public virtual Azure.ResourceManager.Blueprint.BlueprintData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceScope, string blueprintName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.BlueprintResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.BlueprintResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.BlueprintResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.BlueprintResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.BlueprintArtifactResource> GetBlueprintArtifact(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.BlueprintArtifactResource>> GetBlueprintArtifactAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Blueprint.BlueprintArtifactCollection GetBlueprintArtifacts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.PublishedBlueprintResource> GetPublishedBlueprint(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.PublishedBlueprintResource>> GetPublishedBlueprintAsync(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Blueprint.PublishedBlueprintCollection GetPublishedBlueprints() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Blueprint.PublishedBlueprintResource> GetPublishedBlueprints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Blueprint.PublishedBlueprintResource> GetPublishedBlueprintsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.BlueprintResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Blueprint.BlueprintData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.BlueprintResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Blueprint.BlueprintData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlueprintVersionArtifactCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource>, System.Collections.IEnumerable
    {
        protected BlueprintVersionArtifactCollection() { }
        public virtual Azure.Response<bool> Exists(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource> Get(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource>> GetAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BlueprintVersionArtifactResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BlueprintVersionArtifactResource() { }
        public virtual Azure.ResourceManager.Blueprint.ArtifactData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceScope, string blueprintName, string versionId, string artifactName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PublishedBlueprintCollection : Azure.ResourceManager.ArmCollection
    {
        protected PublishedBlueprintCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.PublishedBlueprintResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string versionId, Azure.ResourceManager.Blueprint.PublishedBlueprintData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.PublishedBlueprintResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string versionId, Azure.ResourceManager.Blueprint.PublishedBlueprintData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.PublishedBlueprintResource> Get(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.PublishedBlueprintResource>> GetAsync(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PublishedBlueprintData : Azure.ResourceManager.Models.ResourceData
    {
        public PublishedBlueprintData() { }
        public string BlueprintName { get { throw null; } set { } }
        public string ChangeNotes { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ParameterDefinition> Parameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ResourceGroupDefinition> ResourceGroups { get { throw null; } }
        public Azure.ResourceManager.Blueprint.Models.BlueprintStatus Status { get { throw null; } }
        public Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope? TargetScope { get { throw null; } set { } }
    }
    public partial class PublishedBlueprintResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PublishedBlueprintResource() { }
        public virtual Azure.ResourceManager.Blueprint.PublishedBlueprintData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceScope, string blueprintName, string versionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.PublishedBlueprintResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.PublishedBlueprintResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.PublishedBlueprintResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.PublishedBlueprintResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource> GetBlueprintVersionArtifact(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Blueprint.BlueprintVersionArtifactResource>> GetBlueprintVersionArtifactAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Blueprint.BlueprintVersionArtifactCollection GetBlueprintVersionArtifacts() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.PublishedBlueprintResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Blueprint.PublishedBlueprintData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Blueprint.PublishedBlueprintResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Blueprint.PublishedBlueprintData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Blueprint.Models
{
    public static partial class ArmBlueprintModelFactory
    {
        public static Azure.ResourceManager.Blueprint.ArtifactData ArtifactData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = "Unknown") { throw null; }
        public static Azure.ResourceManager.Blueprint.AssignmentData AssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentity identity = null, string displayName = null, string description = null, string blueprintId = null, string scope = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ParameterValue> parameters = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ResourceGroupValue> resourceGroups = null, Azure.ResourceManager.Blueprint.Models.AssignmentStatus status = null, Azure.ResourceManager.Blueprint.Models.AssignmentLockSettings locks = null, Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState? provisioningState = default(Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState?), Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation)) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentJobCreatedResource AssignmentJobCreatedResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> properties = null) { throw null; }
        public static Azure.ResourceManager.Blueprint.AssignmentOperationData AssignmentOperationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string blueprintVersion = null, string assignmentState = null, string timeCreated = null, string timeStarted = null, string timeFinished = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Blueprint.Models.AssignmentDeploymentJob> deployments = null) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentStatus AssignmentStatus(System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> managedResources = null) { throw null; }
        public static Azure.ResourceManager.Blueprint.BlueprintData BlueprintData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string description = null, Azure.ResourceManager.Blueprint.Models.BlueprintStatus status = null, Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope? targetScope = default(Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ParameterDefinition> parameters = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ResourceGroupDefinition> resourceGroups = null, System.BinaryData versions = null, System.BinaryData layout = null) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.BlueprintResourceStatusBase BlueprintResourceStatusBase(System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.BlueprintStatus BlueprintStatus(System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.PolicyAssignmentArtifact PolicyAssignmentArtifact(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string description = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, string policyDefinitionId = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ParameterValue> parameters = null, string resourceGroup = null) { throw null; }
        public static Azure.ResourceManager.Blueprint.PublishedBlueprintData PublishedBlueprintData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string description = null, Azure.ResourceManager.Blueprint.Models.BlueprintStatus status = null, Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope? targetScope = default(Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ParameterDefinition> parameters = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ResourceGroupDefinition> resourceGroups = null, string blueprintName = null, string changeNotes = null) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.RoleAssignmentArtifact RoleAssignmentArtifact(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string description = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, string roleDefinitionId = null, System.BinaryData principalIds = null, string resourceGroup = null) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.TemplateArtifact TemplateArtifact(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string description = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, System.BinaryData template = null, string resourceGroup = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ParameterValue> parameters = null) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.WhoIsBlueprintContract WhoIsBlueprintContract(string objectId = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssignmentDeleteBehavior : System.IEquatable<Azure.ResourceManager.Blueprint.Models.AssignmentDeleteBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssignmentDeleteBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentDeleteBehavior All { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentDeleteBehavior None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Blueprint.Models.AssignmentDeleteBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Blueprint.Models.AssignmentDeleteBehavior left, Azure.ResourceManager.Blueprint.Models.AssignmentDeleteBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Blueprint.Models.AssignmentDeleteBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Blueprint.Models.AssignmentDeleteBehavior left, Azure.ResourceManager.Blueprint.Models.AssignmentDeleteBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssignmentDeploymentJob
    {
        public AssignmentDeploymentJob() { }
        public string Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Blueprint.Models.AssignmentDeploymentJobResult> History { get { throw null; } }
        public string JobId { get { throw null; } set { } }
        public string JobState { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Uri RequestUri { get { throw null; } set { } }
        public Azure.ResourceManager.Blueprint.Models.AssignmentDeploymentJobResult Result { get { throw null; } set { } }
    }
    public partial class AssignmentDeploymentJobResult
    {
        public AssignmentDeploymentJobResult() { }
        public Azure.ResourceManager.Blueprint.Models.AzureResourceManagerError Error { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Blueprint.Models.AssignmentJobCreatedResource> Resources { get { throw null; } }
    }
    public partial class AssignmentJobCreatedResource : Azure.ResourceManager.Models.ResourceData
    {
        public AssignmentJobCreatedResource() { }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssignmentLockMode : System.IEquatable<Azure.ResourceManager.Blueprint.Models.AssignmentLockMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssignmentLockMode(string value) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentLockMode AllResourcesDoNotDelete { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentLockMode AllResourcesReadOnly { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentLockMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Blueprint.Models.AssignmentLockMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Blueprint.Models.AssignmentLockMode left, Azure.ResourceManager.Blueprint.Models.AssignmentLockMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Blueprint.Models.AssignmentLockMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Blueprint.Models.AssignmentLockMode left, Azure.ResourceManager.Blueprint.Models.AssignmentLockMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssignmentLockSettings
    {
        public AssignmentLockSettings() { }
        public System.Collections.Generic.IList<string> ExcludedActions { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedPrincipals { get { throw null; } }
        public Azure.ResourceManager.Blueprint.Models.AssignmentLockMode? Mode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssignmentProvisioningState : System.IEquatable<Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssignmentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState Cancelling { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState Deploying { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState Locking { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState Validating { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState left, Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState left, Azure.ResourceManager.Blueprint.Models.AssignmentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssignmentStatus : Azure.ResourceManager.Blueprint.Models.BlueprintResourceStatusBase
    {
        internal AssignmentStatus() { }
        public System.Collections.Generic.IReadOnlyList<string> ManagedResources { get { throw null; } }
    }
    public partial class AzureResourceManagerError
    {
        public AzureResourceManagerError() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public partial class BlueprintResourceStatusBase
    {
        internal BlueprintResourceStatusBase() { }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
    }
    public partial class BlueprintStatus : Azure.ResourceManager.Blueprint.Models.BlueprintResourceStatusBase
    {
        internal BlueprintStatus() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlueprintTargetScope : System.IEquatable<Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlueprintTargetScope(string value) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope ManagementGroup { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope Subscription { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope left, Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope left, Azure.ResourceManager.Blueprint.Models.BlueprintTargetScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedServiceIdentity
    {
        public ManagedServiceIdentity(Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentityType identityType) { }
        public Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentityType IdentityType { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentityType left, Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentityType left, Azure.ResourceManager.Blueprint.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParameterDefinition
    {
        public ParameterDefinition(Azure.ResourceManager.Blueprint.Models.TemplateParameterType templateParameterType) { }
        public System.Collections.Generic.IList<System.BinaryData> AllowedValues { get { throw null; } }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string StrongType { get { throw null; } set { } }
        public Azure.ResourceManager.Blueprint.Models.TemplateParameterType TemplateParameterType { get { throw null; } set { } }
    }
    public partial class ParameterValue
    {
        public ParameterValue() { }
        public Azure.ResourceManager.Blueprint.Models.SecretValueReference Reference { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class PolicyAssignmentArtifact : Azure.ResourceManager.Blueprint.ArtifactData
    {
        public PolicyAssignmentArtifact(string policyDefinitionId, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ParameterValue> parameters) { }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ParameterValue> Parameters { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
    }
    public partial class ResourceGroupDefinition
    {
        public ResourceGroupDefinition() { }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string StrongType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ResourceGroupValue
    {
        public ResourceGroupValue() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class RoleAssignmentArtifact : Azure.ResourceManager.Blueprint.ArtifactData
    {
        public RoleAssignmentArtifact(string roleDefinitionId, System.BinaryData principalIds) { }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.BinaryData PrincipalIds { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
    }
    public partial class SecretValueReference
    {
        public SecretValueReference(Azure.ResourceManager.Resources.Models.WritableSubResource keyVault, string secretName) { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
    }
    public partial class TemplateArtifact : Azure.ResourceManager.Blueprint.ArtifactData
    {
        public TemplateArtifact(System.BinaryData template, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ParameterValue> parameters) { }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Blueprint.Models.ParameterValue> Parameters { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public System.BinaryData Template { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemplateParameterType : System.IEquatable<Azure.ResourceManager.Blueprint.Models.TemplateParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemplateParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Blueprint.Models.TemplateParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.TemplateParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.TemplateParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.TemplateParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.TemplateParameterType SecureObject { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.TemplateParameterType SecureString { get { throw null; } }
        public static Azure.ResourceManager.Blueprint.Models.TemplateParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Blueprint.Models.TemplateParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Blueprint.Models.TemplateParameterType left, Azure.ResourceManager.Blueprint.Models.TemplateParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Blueprint.Models.TemplateParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Blueprint.Models.TemplateParameterType left, Azure.ResourceManager.Blueprint.Models.TemplateParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WhoIsBlueprintContract
    {
        internal WhoIsBlueprintContract() { }
        public string ObjectId { get { throw null; } }
    }
}
