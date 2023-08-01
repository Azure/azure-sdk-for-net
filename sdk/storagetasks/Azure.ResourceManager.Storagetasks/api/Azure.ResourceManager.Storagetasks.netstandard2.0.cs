namespace Azure.ResourceManager.Storagetasks
{
    public partial class StorageTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storagetasks.StorageTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storagetasks.StorageTaskResource>, System.Collections.IEnumerable
    {
        protected StorageTaskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storagetasks.StorageTaskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageTaskName, Azure.ResourceManager.Storagetasks.StorageTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storagetasks.StorageTaskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageTaskName, Azure.ResourceManager.Storagetasks.StorageTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storagetasks.StorageTaskResource> Get(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storagetasks.StorageTaskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storagetasks.StorageTaskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storagetasks.StorageTaskResource>> GetAsync(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storagetasks.StorageTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storagetasks.StorageTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storagetasks.StorageTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storagetasks.StorageTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageTaskData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StorageTaskData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Storagetasks.Models.StorageTaskAction Action { get { throw null; } set { } }
        public System.DateTimeOffset? CreationTimeInUtc { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Storagetasks.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public long? TaskVersion { get { throw null; } }
    }
    public partial class StorageTaskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageTaskResource() { }
        public virtual Azure.ResourceManager.Storagetasks.StorageTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Storagetasks.StorageTaskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storagetasks.StorageTaskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageTaskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storagetasks.StorageTaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storagetasks.StorageTaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetStorageTaskAssignments(string maxpagesize = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetStorageTaskAssignmentsAsync(string maxpagesize = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storagetasks.Models.StorageTaskReportInstance> GetStorageTasksReports(string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storagetasks.Models.StorageTaskReportInstance> GetStorageTasksReportsAsync(string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storagetasks.StorageTaskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storagetasks.StorageTaskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storagetasks.StorageTaskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storagetasks.StorageTaskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storagetasks.StorageTaskResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storagetasks.Models.StorageTaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storagetasks.StorageTaskResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storagetasks.Models.StorageTaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class StoragetasksExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Storagetasks.StorageTaskResource> GetStorageTask(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storagetasks.StorageTaskResource>> GetStorageTaskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storagetasks.StorageTaskResource GetStorageTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storagetasks.StorageTaskCollection GetStorageTasks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storagetasks.StorageTaskResource> GetStorageTasks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storagetasks.StorageTaskResource> GetStorageTasksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewAction> PreviewActionsStorageTask(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewAction storageTaskPreviewAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewAction>> PreviewActionsStorageTaskAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewAction storageTaskPreviewAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Storagetasks.Models
{
    public static partial class ArmStoragetasksModelFactory
    {
        public static Azure.ResourceManager.Storagetasks.StorageTaskData StorageTaskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, long? taskVersion = default(long?), bool? enabled = default(bool?), string description = null, Azure.ResourceManager.Storagetasks.Models.StorageTaskAction action = null, Azure.ResourceManager.Storagetasks.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Storagetasks.Models.ProvisioningState?), System.DateTimeOffset? creationTimeInUtc = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewBlobProperties StorageTaskPreviewBlobProperties(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewKeyValueProperties> properties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewKeyValueProperties> metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewKeyValueProperties> tags = null, Azure.ResourceManager.Storagetasks.Models.MatchedBlockName? matchedBlock = default(Azure.ResourceManager.Storagetasks.Models.MatchedBlockName?)) { throw null; }
        public static Azure.ResourceManager.Storagetasks.Models.StorageTaskReportInstance StorageTaskReportInstance(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Storagetasks.Models.StorageTaskReportProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Storagetasks.Models.StorageTaskReportProperties StorageTaskReportProperties(Azure.Core.ResourceIdentifier taskAssignmentId = null, Azure.Core.ResourceIdentifier storageAccountId = null, string startTime = null, string finishTime = null, string objectsTargetedCount = null, string objectsOperatedOnCount = null, string objectFailedCount = null, string objectsSucceededCount = null, string runStatusError = null, Azure.ResourceManager.Storagetasks.Models.RunStatusEnum? runStatusEnum = default(Azure.ResourceManager.Storagetasks.Models.RunStatusEnum?), string summaryReportPath = null, Azure.Core.ResourceIdentifier taskId = null, string taskVersion = null, Azure.ResourceManager.Storagetasks.Models.RunResult? runResult = default(Azure.ResourceManager.Storagetasks.Models.RunResult?)) { throw null; }
    }
    public partial class IfCondition
    {
        public IfCondition(string condition, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storagetasks.Models.StorageTaskOperation> operations) { }
        public string Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storagetasks.Models.StorageTaskOperation> Operations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MatchedBlockName : System.IEquatable<Azure.ResourceManager.Storagetasks.Models.MatchedBlockName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchedBlockName(string value) { throw null; }
        public static Azure.ResourceManager.Storagetasks.Models.MatchedBlockName Else { get { throw null; } }
        public static Azure.ResourceManager.Storagetasks.Models.MatchedBlockName If { get { throw null; } }
        public static Azure.ResourceManager.Storagetasks.Models.MatchedBlockName None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storagetasks.Models.MatchedBlockName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storagetasks.Models.MatchedBlockName left, Azure.ResourceManager.Storagetasks.Models.MatchedBlockName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storagetasks.Models.MatchedBlockName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storagetasks.Models.MatchedBlockName left, Azure.ResourceManager.Storagetasks.Models.MatchedBlockName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnFailure : System.IEquatable<Azure.ResourceManager.Storagetasks.Models.OnFailure>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnFailure(string value) { throw null; }
        public static Azure.ResourceManager.Storagetasks.Models.OnFailure Break { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storagetasks.Models.OnFailure other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storagetasks.Models.OnFailure left, Azure.ResourceManager.Storagetasks.Models.OnFailure right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storagetasks.Models.OnFailure (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storagetasks.Models.OnFailure left, Azure.ResourceManager.Storagetasks.Models.OnFailure right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnSuccess : System.IEquatable<Azure.ResourceManager.Storagetasks.Models.OnSuccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnSuccess(string value) { throw null; }
        public static Azure.ResourceManager.Storagetasks.Models.OnSuccess Continue { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storagetasks.Models.OnSuccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storagetasks.Models.OnSuccess left, Azure.ResourceManager.Storagetasks.Models.OnSuccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storagetasks.Models.OnSuccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storagetasks.Models.OnSuccess left, Azure.ResourceManager.Storagetasks.Models.OnSuccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ProvisioningState
    {
        ValidateSubscriptionQuotaBegin = 0,
        ValidateSubscriptionQuotaEnd = 1,
        Creating = 2,
        Succeeded = 3,
        Deleting = 4,
        Canceled = 5,
        Failed = 6,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunResult : System.IEquatable<Azure.ResourceManager.Storagetasks.Models.RunResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunResult(string value) { throw null; }
        public static Azure.ResourceManager.Storagetasks.Models.RunResult Failed { get { throw null; } }
        public static Azure.ResourceManager.Storagetasks.Models.RunResult Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storagetasks.Models.RunResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storagetasks.Models.RunResult left, Azure.ResourceManager.Storagetasks.Models.RunResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storagetasks.Models.RunResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storagetasks.Models.RunResult left, Azure.ResourceManager.Storagetasks.Models.RunResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStatusEnum : System.IEquatable<Azure.ResourceManager.Storagetasks.Models.RunStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.Storagetasks.Models.RunStatusEnum Finished { get { throw null; } }
        public static Azure.ResourceManager.Storagetasks.Models.RunStatusEnum InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storagetasks.Models.RunStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storagetasks.Models.RunStatusEnum left, Azure.ResourceManager.Storagetasks.Models.RunStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storagetasks.Models.RunStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storagetasks.Models.RunStatusEnum left, Azure.ResourceManager.Storagetasks.Models.RunStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageTaskAction
    {
        public StorageTaskAction(Azure.ResourceManager.Storagetasks.Models.IfCondition @if) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storagetasks.Models.StorageTaskOperation> ElseOperations { get { throw null; } set { } }
        public Azure.ResourceManager.Storagetasks.Models.IfCondition If { get { throw null; } set { } }
    }
    public partial class StorageTaskOperation
    {
        public StorageTaskOperation(Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName name) { }
        public Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Storagetasks.Models.OnFailure? OnFailure { get { throw null; } set { } }
        public Azure.ResourceManager.Storagetasks.Models.OnSuccess? OnSuccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTaskOperationName : System.IEquatable<Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTaskOperationName(string value) { throw null; }
        public static Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName DeleteBlob { get { throw null; } }
        public static Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName SetBlobExpiry { get { throw null; } }
        public static Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName SetBlobImmutabilityPolicy { get { throw null; } }
        public static Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName SetBlobLegalHold { get { throw null; } }
        public static Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName SetBlobTags { get { throw null; } }
        public static Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName SetBlobTier { get { throw null; } }
        public static Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName UndeleteBlob { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName left, Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName left, Azure.ResourceManager.Storagetasks.Models.StorageTaskOperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageTaskPatch
    {
        public StorageTaskPatch() { }
        public Azure.ResourceManager.Storagetasks.Models.StorageTaskAction Action { get { throw null; } set { } }
        public System.DateTimeOffset? CreationTimeInUtc { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Storagetasks.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public long? TaskVersion { get { throw null; } }
    }
    public partial class StorageTaskPreviewAction
    {
        public StorageTaskPreviewAction(Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewContainerProperties container, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewBlobProperties> blobs, Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewActionCondition action) { }
        public Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewActionCondition Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewBlobProperties> Blobs { get { throw null; } }
        public Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewContainerProperties Container { get { throw null; } set { } }
    }
    public partial class StorageTaskPreviewActionCondition
    {
        public StorageTaskPreviewActionCondition(Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewActionIfCondition @if, bool elseBlockExists) { }
        public bool ElseBlockExists { get { throw null; } set { } }
        public string IfCondition { get { throw null; } set { } }
    }
    public partial class StorageTaskPreviewActionIfCondition
    {
        public StorageTaskPreviewActionIfCondition() { }
        public string Condition { get { throw null; } set { } }
    }
    public partial class StorageTaskPreviewBlobProperties
    {
        public StorageTaskPreviewBlobProperties() { }
        public Azure.ResourceManager.Storagetasks.Models.MatchedBlockName? MatchedBlock { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewKeyValueProperties> Metadata { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewKeyValueProperties> Properties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewKeyValueProperties> Tags { get { throw null; } }
    }
    public partial class StorageTaskPreviewContainerProperties
    {
        public StorageTaskPreviewContainerProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storagetasks.Models.StorageTaskPreviewKeyValueProperties> Metadata { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class StorageTaskPreviewKeyValueProperties
    {
        public StorageTaskPreviewKeyValueProperties() { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class StorageTaskReportInstance : Azure.ResourceManager.Models.ResourceData
    {
        public StorageTaskReportInstance() { }
        public Azure.ResourceManager.Storagetasks.Models.StorageTaskReportProperties Properties { get { throw null; } set { } }
    }
    public partial class StorageTaskReportProperties
    {
        public StorageTaskReportProperties() { }
        public string FinishTime { get { throw null; } }
        public string ObjectFailedCount { get { throw null; } }
        public string ObjectsOperatedOnCount { get { throw null; } }
        public string ObjectsSucceededCount { get { throw null; } }
        public string ObjectsTargetedCount { get { throw null; } }
        public Azure.ResourceManager.Storagetasks.Models.RunResult? RunResult { get { throw null; } }
        public Azure.ResourceManager.Storagetasks.Models.RunStatusEnum? RunStatusEnum { get { throw null; } }
        public string RunStatusError { get { throw null; } }
        public string StartTime { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } }
        public string SummaryReportPath { get { throw null; } }
        public Azure.Core.ResourceIdentifier TaskAssignmentId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TaskId { get { throw null; } }
        public string TaskVersion { get { throw null; } }
    }
}
