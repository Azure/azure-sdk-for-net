namespace Azure.ResourceManager.DefenderEasm
{
    public static partial class DefenderEasmExtensions
    {
        public static Azure.ResourceManager.DefenderEasm.LabelResource GetLabelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DefenderEasm.WorkspaceResource GetWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource> GetWorkspaceResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource>> GetWorkspaceResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DefenderEasm.WorkspaceResourceCollection GetWorkspaceResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DefenderEasm.WorkspaceResource> GetWorkspaceResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DefenderEasm.WorkspaceResource> GetWorkspaceResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabelResource() { }
        public virtual Azure.ResourceManager.DefenderEasm.LabelResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string labelName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.LabelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.LabelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.LabelResource> Update(Azure.ResourceManager.DefenderEasm.Models.LabelResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.LabelResource>> UpdateAsync(Azure.ResourceManager.DefenderEasm.Models.LabelResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabelResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DefenderEasm.LabelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DefenderEasm.LabelResource>, System.Collections.IEnumerable
    {
        protected LabelResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DefenderEasm.LabelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string labelName, Azure.ResourceManager.DefenderEasm.LabelResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DefenderEasm.LabelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string labelName, Azure.ResourceManager.DefenderEasm.LabelResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.LabelResource> Get(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DefenderEasm.LabelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DefenderEasm.LabelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.LabelResource>> GetAsync(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DefenderEasm.LabelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DefenderEasm.LabelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DefenderEasm.LabelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DefenderEasm.LabelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabelResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public LabelResourceData() { }
        public string Color { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.DefenderEasm.Models.ResourceState? ProvisioningState { get { throw null; } }
    }
    public partial class WorkspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceResource() { }
        public virtual Azure.ResourceManager.DefenderEasm.WorkspaceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.Models.TaskResource> GetByWorkspaceTask(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.Models.TaskResource>> GetByWorkspaceTaskAsync(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.LabelResource> GetLabelResource(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.LabelResource>> GetLabelResourceAsync(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DefenderEasm.LabelResourceCollection GetLabelResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource> Update(Azure.ResourceManager.DefenderEasm.Models.WorkspaceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource>> UpdateAsync(Azure.ResourceManager.DefenderEasm.Models.WorkspaceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DefenderEasm.WorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DefenderEasm.WorkspaceResource>, System.Collections.IEnumerable
    {
        protected WorkspaceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DefenderEasm.WorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.DefenderEasm.WorkspaceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DefenderEasm.WorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.DefenderEasm.WorkspaceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DefenderEasm.WorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DefenderEasm.WorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.WorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DefenderEasm.WorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DefenderEasm.WorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DefenderEasm.WorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DefenderEasm.WorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WorkspaceResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string DataPlaneEndpoint { get { throw null; } }
        public Azure.ResourceManager.DefenderEasm.Models.ResourceState? ProvisioningState { get { throw null; } }
    }
}
namespace Azure.ResourceManager.DefenderEasm.Models
{
    public static partial class ArmDefenderEasmModelFactory
    {
        public static Azure.ResourceManager.DefenderEasm.LabelResourceData LabelResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DefenderEasm.Models.ResourceState? provisioningState = default(Azure.ResourceManager.DefenderEasm.Models.ResourceState?), string displayName = null, string color = null) { throw null; }
        public static Azure.ResourceManager.DefenderEasm.Models.LabelResourcePatch LabelResourcePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DefenderEasm.Models.ResourceState? provisioningState = default(Azure.ResourceManager.DefenderEasm.Models.ResourceState?), string displayName = null, string color = null) { throw null; }
        public static Azure.ResourceManager.DefenderEasm.Models.TaskResource TaskResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DefenderEasm.Models.ResourceState? provisioningState = default(Azure.ResourceManager.DefenderEasm.Models.ResourceState?), string startedAt = null, string completedAt = null, string lastPolledAt = null, string state = null, string phase = null, string reason = null, System.BinaryData metadata = null) { throw null; }
        public static Azure.ResourceManager.DefenderEasm.WorkspaceResourceData WorkspaceResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DefenderEasm.Models.ResourceState? provisioningState = default(Azure.ResourceManager.DefenderEasm.Models.ResourceState?), string dataPlaneEndpoint = null) { throw null; }
    }
    public partial class LabelResourcePatch : Azure.ResourceManager.Models.ResourceData
    {
        public LabelResourcePatch() { }
        public string Color { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.DefenderEasm.Models.ResourceState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceState : System.IEquatable<Azure.ResourceManager.DefenderEasm.Models.ResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceState(string value) { throw null; }
        public static Azure.ResourceManager.DefenderEasm.Models.ResourceState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.ResourceState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.ResourceState ConfiguringApplication { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.ResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.ResourceState CreatingArtifacts { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.ResourceState DeletingArtifacts { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.ResourceState Failed { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.ResourceState InstallingApplication { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.ResourceState MigratingApplicationData { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.ResourceState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.ResourceState ProvisioningResources { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.ResourceState RunningValidations { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.ResourceState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DefenderEasm.Models.ResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DefenderEasm.Models.ResourceState left, Azure.ResourceManager.DefenderEasm.Models.ResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DefenderEasm.Models.ResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DefenderEasm.Models.ResourceState left, Azure.ResourceManager.DefenderEasm.Models.ResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TaskResource : Azure.ResourceManager.Models.ResourceData
    {
        public TaskResource() { }
        public string CompletedAt { get { throw null; } set { } }
        public string LastPolledAt { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string Phase { get { throw null; } set { } }
        public Azure.ResourceManager.DefenderEasm.Models.ResourceState? ProvisioningState { get { throw null; } }
        public string Reason { get { throw null; } set { } }
        public string StartedAt { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
    }
    public partial class WorkspaceResourcePatch
    {
        public WorkspaceResourcePatch() { }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
