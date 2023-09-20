namespace Azure.ResourceManager.Storageactions
{
    public static partial class StorageactionsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Storageactions.StorageTaskResource> GetStorageTask(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storageactions.StorageTaskResource>> GetStorageTaskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storageactions.StorageTaskResource GetStorageTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storageactions.StorageTaskCollection GetStorageTasks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storageactions.StorageTaskResource> GetStorageTasks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storageactions.StorageTaskResource> GetStorageTasksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewAction> PreviewActionsStorageTask(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewAction storageTaskPreviewAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewAction>> PreviewActionsStorageTaskAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewAction storageTaskPreviewAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storageactions.StorageTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storageactions.StorageTaskResource>, System.Collections.IEnumerable
    {
        protected StorageTaskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storageactions.StorageTaskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageTaskName, Azure.ResourceManager.Storageactions.StorageTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storageactions.StorageTaskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageTaskName, Azure.ResourceManager.Storageactions.StorageTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storageactions.StorageTaskResource> Get(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storageactions.StorageTaskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storageactions.StorageTaskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storageactions.StorageTaskResource>> GetAsync(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storageactions.StorageTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storageactions.StorageTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storageactions.StorageTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storageactions.StorageTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageTaskData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StorageTaskData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Storageactions.Models.StorageTaskAction Action { get { throw null; } set { } }
        public System.DateTimeOffset? CreationTimeInUtc { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Storageactions.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public long? TaskVersion { get { throw null; } }
    }
    public partial class StorageTaskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageTaskResource() { }
        public virtual Azure.ResourceManager.Storageactions.StorageTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Storageactions.StorageTaskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storageactions.StorageTaskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageTaskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storageactions.StorageTaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storageactions.StorageTaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetStorageTaskAssignments(string maxpagesize = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetStorageTaskAssignmentsAsync(string maxpagesize = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storageactions.Models.StorageTaskReportInstance> GetStorageTasksReports(string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storageactions.Models.StorageTaskReportInstance> GetStorageTasksReportsAsync(string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storageactions.StorageTaskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storageactions.StorageTaskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storageactions.StorageTaskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storageactions.StorageTaskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storageactions.StorageTaskResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storageactions.Models.StorageTaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storageactions.StorageTaskResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storageactions.Models.StorageTaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Storageactions.Models
{
    public static partial class ArmStorageactionsModelFactory
    {
        public static Azure.ResourceManager.Storageactions.StorageTaskData StorageTaskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, long? taskVersion = default(long?), bool? enabled = default(bool?), string description = null, Azure.ResourceManager.Storageactions.Models.StorageTaskAction action = null, Azure.ResourceManager.Storageactions.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Storageactions.Models.ProvisioningState?), System.DateTimeOffset? creationTimeInUtc = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewBlobProperties StorageTaskPreviewBlobProperties(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewKeyValueProperties> properties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewKeyValueProperties> metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewKeyValueProperties> tags = null, Azure.ResourceManager.Storageactions.Models.MatchedBlockName? matchedBlock = default(Azure.ResourceManager.Storageactions.Models.MatchedBlockName?)) { throw null; }
        public static Azure.ResourceManager.Storageactions.Models.StorageTaskReportInstance StorageTaskReportInstance(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Storageactions.Models.StorageTaskReportProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Storageactions.Models.StorageTaskReportProperties StorageTaskReportProperties(Azure.Core.ResourceIdentifier taskAssignmentId = null, Azure.Core.ResourceIdentifier storageAccountId = null, string startTime = null, string finishTime = null, string objectsTargetedCount = null, string objectsOperatedOnCount = null, string objectFailedCount = null, string objectsSucceededCount = null, string runStatusError = null, Azure.ResourceManager.Storageactions.Models.RunStatusEnum? runStatusEnum = default(Azure.ResourceManager.Storageactions.Models.RunStatusEnum?), string summaryReportPath = null, Azure.Core.ResourceIdentifier taskId = null, string taskVersion = null, Azure.ResourceManager.Storageactions.Models.RunResult? runResult = default(Azure.ResourceManager.Storageactions.Models.RunResult?)) { throw null; }
    }
    public partial class IfCondition
    {
        public IfCondition(string condition, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storageactions.Models.StorageTaskOperation> operations) { }
        public string Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storageactions.Models.StorageTaskOperation> Operations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MatchedBlockName : System.IEquatable<Azure.ResourceManager.Storageactions.Models.MatchedBlockName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchedBlockName(string value) { throw null; }
        public static Azure.ResourceManager.Storageactions.Models.MatchedBlockName Else { get { throw null; } }
        public static Azure.ResourceManager.Storageactions.Models.MatchedBlockName If { get { throw null; } }
        public static Azure.ResourceManager.Storageactions.Models.MatchedBlockName None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storageactions.Models.MatchedBlockName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storageactions.Models.MatchedBlockName left, Azure.ResourceManager.Storageactions.Models.MatchedBlockName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storageactions.Models.MatchedBlockName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storageactions.Models.MatchedBlockName left, Azure.ResourceManager.Storageactions.Models.MatchedBlockName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnFailure : System.IEquatable<Azure.ResourceManager.Storageactions.Models.OnFailure>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnFailure(string value) { throw null; }
        public static Azure.ResourceManager.Storageactions.Models.OnFailure Break { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storageactions.Models.OnFailure other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storageactions.Models.OnFailure left, Azure.ResourceManager.Storageactions.Models.OnFailure right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storageactions.Models.OnFailure (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storageactions.Models.OnFailure left, Azure.ResourceManager.Storageactions.Models.OnFailure right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnSuccess : System.IEquatable<Azure.ResourceManager.Storageactions.Models.OnSuccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnSuccess(string value) { throw null; }
        public static Azure.ResourceManager.Storageactions.Models.OnSuccess Continue { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storageactions.Models.OnSuccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storageactions.Models.OnSuccess left, Azure.ResourceManager.Storageactions.Models.OnSuccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storageactions.Models.OnSuccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storageactions.Models.OnSuccess left, Azure.ResourceManager.Storageactions.Models.OnSuccess right) { throw null; }
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
    public readonly partial struct RunResult : System.IEquatable<Azure.ResourceManager.Storageactions.Models.RunResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunResult(string value) { throw null; }
        public static Azure.ResourceManager.Storageactions.Models.RunResult Failed { get { throw null; } }
        public static Azure.ResourceManager.Storageactions.Models.RunResult Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storageactions.Models.RunResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storageactions.Models.RunResult left, Azure.ResourceManager.Storageactions.Models.RunResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storageactions.Models.RunResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storageactions.Models.RunResult left, Azure.ResourceManager.Storageactions.Models.RunResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStatusEnum : System.IEquatable<Azure.ResourceManager.Storageactions.Models.RunStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.Storageactions.Models.RunStatusEnum Finished { get { throw null; } }
        public static Azure.ResourceManager.Storageactions.Models.RunStatusEnum InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storageactions.Models.RunStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storageactions.Models.RunStatusEnum left, Azure.ResourceManager.Storageactions.Models.RunStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storageactions.Models.RunStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storageactions.Models.RunStatusEnum left, Azure.ResourceManager.Storageactions.Models.RunStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageTaskAction
    {
        public StorageTaskAction(Azure.ResourceManager.Storageactions.Models.IfCondition @if) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storageactions.Models.StorageTaskOperation> ElseOperations { get { throw null; } set { } }
        public Azure.ResourceManager.Storageactions.Models.IfCondition If { get { throw null; } set { } }
    }
    public partial class StorageTaskOperation
    {
        public StorageTaskOperation(Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName name) { }
        public Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Storageactions.Models.OnFailure? OnFailure { get { throw null; } set { } }
        public Azure.ResourceManager.Storageactions.Models.OnSuccess? OnSuccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTaskOperationName : System.IEquatable<Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTaskOperationName(string value) { throw null; }
        public static Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName DeleteBlob { get { throw null; } }
        public static Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName SetBlobExpiry { get { throw null; } }
        public static Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName SetBlobImmutabilityPolicy { get { throw null; } }
        public static Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName SetBlobLegalHold { get { throw null; } }
        public static Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName SetBlobTags { get { throw null; } }
        public static Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName SetBlobTier { get { throw null; } }
        public static Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName UndeleteBlob { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName left, Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName left, Azure.ResourceManager.Storageactions.Models.StorageTaskOperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageTaskPatch
    {
        public StorageTaskPatch() { }
        public Azure.ResourceManager.Storageactions.Models.StorageTaskAction Action { get { throw null; } set { } }
        public System.DateTimeOffset? CreationTimeInUtc { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Storageactions.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public long? TaskVersion { get { throw null; } }
    }
    public partial class StorageTaskPreviewAction
    {
        public StorageTaskPreviewAction(Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewContainerProperties container, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewBlobProperties> blobs, Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewActionCondition action) { }
        public Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewActionCondition Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewBlobProperties> Blobs { get { throw null; } }
        public Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewContainerProperties Container { get { throw null; } set { } }
    }
    public partial class StorageTaskPreviewActionCondition
    {
        public StorageTaskPreviewActionCondition(Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewActionIfCondition @if, bool elseBlockExists) { }
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
        public Azure.ResourceManager.Storageactions.Models.MatchedBlockName? MatchedBlock { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewKeyValueProperties> Metadata { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewKeyValueProperties> Properties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewKeyValueProperties> Tags { get { throw null; } }
    }
    public partial class StorageTaskPreviewContainerProperties
    {
        public StorageTaskPreviewContainerProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storageactions.Models.StorageTaskPreviewKeyValueProperties> Metadata { get { throw null; } }
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
        public Azure.ResourceManager.Storageactions.Models.StorageTaskReportProperties Properties { get { throw null; } set { } }
    }
    public partial class StorageTaskReportProperties
    {
        public StorageTaskReportProperties() { }
        public string FinishTime { get { throw null; } }
        public string ObjectFailedCount { get { throw null; } }
        public string ObjectsOperatedOnCount { get { throw null; } }
        public string ObjectsSucceededCount { get { throw null; } }
        public string ObjectsTargetedCount { get { throw null; } }
        public Azure.ResourceManager.Storageactions.Models.RunResult? RunResult { get { throw null; } }
        public Azure.ResourceManager.Storageactions.Models.RunStatusEnum? RunStatusEnum { get { throw null; } }
        public string RunStatusError { get { throw null; } }
        public string StartTime { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } }
        public string SummaryReportPath { get { throw null; } }
        public Azure.Core.ResourceIdentifier TaskAssignmentId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TaskId { get { throw null; } }
        public string TaskVersion { get { throw null; } }
    }
}
