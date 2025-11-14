namespace Azure.ResourceManager.StorageActions
{
    public partial class AzureResourceManagerStorageActionsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerStorageActionsContext() { }
        public static Azure.ResourceManager.StorageActions.AzureResourceManagerStorageActionsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class StorageActionsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource> GetStorageTask(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource>> GetStorageTaskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageActions.StorageTaskResource GetStorageTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageActions.StorageTaskCollection GetStorageTasks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageActions.StorageTaskResource> GetStorageTasks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageActions.StorageTaskResource> GetStorageTasksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction> PreviewActions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction storageTaskPreviewAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction>> PreviewActionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction storageTaskPreviewAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageActions.StorageTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageActions.StorageTaskResource>, System.Collections.IEnumerable
    {
        protected StorageTaskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageActions.StorageTaskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageTaskName, Azure.ResourceManager.StorageActions.StorageTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageActions.StorageTaskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageTaskName, Azure.ResourceManager.StorageActions.StorageTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource> Get(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageActions.StorageTaskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageActions.StorageTaskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource>> GetAsync(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageActions.StorageTaskResource> GetIfExists(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageActions.StorageTaskResource>> GetIfExistsAsync(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageActions.StorageTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageActions.StorageTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageActions.StorageTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageActions.StorageTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageTaskData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.StorageTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.StorageTaskData>
    {
        public StorageTaskData(Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.StorageActions.Models.StorageTaskProperties properties) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.StorageTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.StorageTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.StorageTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.StorageTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.StorageTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.StorageTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.StorageTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.StorageTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.StorageTaskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageTaskResource() { }
        public virtual Azure.ResourceManager.StorageActions.StorageTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageTaskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetStorageTaskAssignments(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetStorageTaskAssignmentsAsync(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageActions.Models.StorageTaskReportInstance> GetStorageTasksReports(int? maxpagesize = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageActions.Models.StorageTaskReportInstance> GetStorageTasksReportsAsync(int? maxpagesize = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StorageActions.StorageTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.StorageTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.StorageTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.StorageTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.StorageTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.StorageTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.StorageTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageActions.StorageTaskResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageActions.Models.StorageTaskPatch storageTaskPatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageActions.StorageTaskResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageActions.Models.StorageTaskPatch storageTaskPatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StorageActions.Mocking
{
    public partial class MockableStorageActionsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageActionsArmClient() { }
        public virtual Azure.ResourceManager.StorageActions.StorageTaskResource GetStorageTaskResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableStorageActionsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageActionsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource> GetStorageTask(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageActions.StorageTaskResource>> GetStorageTaskAsync(string storageTaskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageActions.StorageTaskCollection GetStorageTasks() { throw null; }
    }
    public partial class MockableStorageActionsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageActionsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageActions.StorageTaskResource> GetStorageTasks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageActions.StorageTaskResource> GetStorageTasksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction> PreviewActions(Azure.Core.AzureLocation location, Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction storageTaskPreviewAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction>> PreviewActionsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction storageTaskPreviewAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StorageActions.Models
{
    public static partial class ArmStorageActionsModelFactory
    {
        public static Azure.ResourceManager.StorageActions.StorageTaskData StorageTaskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.StorageActions.Models.StorageTaskProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition StorageTaskIfCondition(string condition = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo> operations = null) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo StorageTaskOperationInfo(Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName name = default(Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName), System.Collections.Generic.IDictionary<string, string> parameters = null, Azure.ResourceManager.StorageActions.Models.OnSuccessAction? onSuccess = default(Azure.ResourceManager.StorageActions.Models.OnSuccessAction?), Azure.ResourceManager.StorageActions.Models.OnFailureAction? onFailure = default(Azure.ResourceManager.StorageActions.Models.OnFailureAction?)) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskPatch StorageTaskPatch(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties StorageTaskPreviewActionProperties(Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties container = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties> blobs = null, Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition action = null) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties StorageTaskPreviewBlobProperties(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties> properties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties> metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties> tags = null, Azure.ResourceManager.StorageActions.Models.MatchedBlockName? matchedBlock = default(Azure.ResourceManager.StorageActions.Models.MatchedBlockName?)) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties StorageTaskPreviewContainerProperties(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties> metadata = null) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskProperties StorageTaskProperties(long? taskVersion = default(long?), bool isEnabled = false, string description = null, Azure.ResourceManager.StorageActions.Models.StorageTaskAction action = null, Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState? provisioningState = default(Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState?), System.DateTimeOffset? creationTimeInUtc = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskReportInstance StorageTaskReportInstance(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties StorageTaskReportProperties(Azure.Core.ResourceIdentifier taskAssignmentId = null, Azure.Core.ResourceIdentifier storageAccountId = null, string startTime = null, string finishTime = null, string objectsTargetedCount = null, string objectsOperatedOnCount = null, string objectFailedCount = null, string objectsSucceededCount = null, string runStatusError = null, Azure.ResourceManager.StorageActions.Models.StorageTaskRunStatus? runStatusEnum = default(Azure.ResourceManager.StorageActions.Models.StorageTaskRunStatus?), string summaryReportPath = null, Azure.Core.ResourceIdentifier taskId = null, string taskVersion = null, Azure.ResourceManager.StorageActions.Models.StorageTaskRunResult? runResult = default(Azure.ResourceManager.StorageActions.Models.StorageTaskRunResult?)) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties StorageTaskUpdateProperties(long? taskVersion = default(long?), bool? enabled = default(bool?), string description = null, Azure.ResourceManager.StorageActions.Models.StorageTaskAction action = null, Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState? provisioningState = default(Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState?), System.DateTimeOffset? creationTimeInUtc = default(System.DateTimeOffset?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MatchedBlockName : System.IEquatable<Azure.ResourceManager.StorageActions.Models.MatchedBlockName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchedBlockName(string value) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.MatchedBlockName Else { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.MatchedBlockName If { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.MatchedBlockName None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageActions.Models.MatchedBlockName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageActions.Models.MatchedBlockName left, Azure.ResourceManager.StorageActions.Models.MatchedBlockName right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.MatchedBlockName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.MatchedBlockName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageActions.Models.MatchedBlockName left, Azure.ResourceManager.StorageActions.Models.MatchedBlockName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnFailureAction : System.IEquatable<Azure.ResourceManager.StorageActions.Models.OnFailureAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnFailureAction(string value) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.OnFailureAction Break { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageActions.Models.OnFailureAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageActions.Models.OnFailureAction left, Azure.ResourceManager.StorageActions.Models.OnFailureAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.OnFailureAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.OnFailureAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageActions.Models.OnFailureAction left, Azure.ResourceManager.StorageActions.Models.OnFailureAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnSuccessAction : System.IEquatable<Azure.ResourceManager.StorageActions.Models.OnSuccessAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnSuccessAction(string value) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.OnSuccessAction Continue { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageActions.Models.OnSuccessAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageActions.Models.OnSuccessAction left, Azure.ResourceManager.StorageActions.Models.OnSuccessAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.OnSuccessAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.OnSuccessAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageActions.Models.OnSuccessAction left, Azure.ResourceManager.StorageActions.Models.OnSuccessAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageTaskAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskAction>
    {
        public StorageTaskAction(Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition @if) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo> ElseOperations { get { throw null; } set { } }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition If { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskIfCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition>
    {
        public StorageTaskIfCondition(string condition, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo> operations) { }
        public string Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo> Operations { get { throw null; } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskIfCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo>
    {
        public StorageTaskOperationInfo(Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName name) { }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName Name { get { throw null; } set { } }
        public Azure.ResourceManager.StorageActions.Models.OnFailureAction? OnFailure { get { throw null; } set { } }
        public Azure.ResourceManager.StorageActions.Models.OnSuccessAction? OnSuccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskOperationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTaskOperationName : System.IEquatable<Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTaskOperationName(string value) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName DeleteBlob { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName SetBlobExpiry { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName SetBlobImmutabilityPolicy { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName SetBlobLegalHold { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName SetBlobTags { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName SetBlobTier { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName UndeleteBlob { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName left, Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName left, Azure.ResourceManager.StorageActions.Models.StorageTaskOperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageTaskPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPatch>
    {
        public StorageTaskPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskPreviewAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction>
    {
        public StorageTaskPreviewAction(Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties properties) { }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskPreviewActionCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition>
    {
        public StorageTaskPreviewActionCondition(Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionIfCondition @if, bool elseBlockExists) { }
        public bool ElseBlockExists { get { throw null; } set { } }
        public string IfCondition { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskPreviewActionIfCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionIfCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionIfCondition>
    {
        public StorageTaskPreviewActionIfCondition() { }
        public string Condition { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionIfCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionIfCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionIfCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionIfCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionIfCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionIfCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionIfCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionIfCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionIfCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskPreviewActionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties>
    {
        public StorageTaskPreviewActionProperties(Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties container, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties> blobs, Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition action) { }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionCondition Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties> Blobs { get { throw null; } }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties Container { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskPreviewBlobProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties>
    {
        public StorageTaskPreviewBlobProperties() { }
        public Azure.ResourceManager.StorageActions.Models.MatchedBlockName? MatchedBlock { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties> Metadata { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties> Properties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewBlobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskPreviewContainerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties>
    {
        public StorageTaskPreviewContainerProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties> Metadata { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewContainerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskPreviewKeyValueProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties>
    {
        public StorageTaskPreviewKeyValueProperties() { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskPreviewKeyValueProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskProperties>
    {
        public StorageTaskProperties(bool isEnabled, string description, Azure.ResourceManager.StorageActions.Models.StorageTaskAction action) { }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskAction Action { get { throw null; } set { } }
        public System.DateTimeOffset? CreationTimeInUtc { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState? ProvisioningState { get { throw null; } }
        public long? TaskVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTaskProvisioningState : System.IEquatable<Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTaskProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState ValidateSubscriptionQuotaBegin { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState ValidateSubscriptionQuotaEnd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState left, Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState left, Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageTaskReportInstance : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportInstance>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportInstance>
    {
        internal StorageTaskReportInstance() { }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskReportInstance System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportInstance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportInstance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskReportInstance System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportInstance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportInstance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportInstance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskReportProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties>
    {
        internal StorageTaskReportProperties() { }
        public string FinishTime { get { throw null; } }
        public string ObjectFailedCount { get { throw null; } }
        public string ObjectsOperatedOnCount { get { throw null; } }
        public string ObjectsSucceededCount { get { throw null; } }
        public string ObjectsTargetedCount { get { throw null; } }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskRunResult? RunResult { get { throw null; } }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskRunStatus? RunStatusEnum { get { throw null; } }
        public string RunStatusError { get { throw null; } }
        public string StartTime { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } }
        public string SummaryReportPath { get { throw null; } }
        public Azure.Core.ResourceIdentifier TaskAssignmentId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TaskId { get { throw null; } }
        public string TaskVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskReportProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTaskRunResult : System.IEquatable<Azure.ResourceManager.StorageActions.Models.StorageTaskRunResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTaskRunResult(string value) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskRunResult Failed { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskRunResult Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageActions.Models.StorageTaskRunResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageActions.Models.StorageTaskRunResult left, Azure.ResourceManager.StorageActions.Models.StorageTaskRunResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.StorageTaskRunResult (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.StorageTaskRunResult? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageActions.Models.StorageTaskRunResult left, Azure.ResourceManager.StorageActions.Models.StorageTaskRunResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTaskRunStatus : System.IEquatable<Azure.ResourceManager.StorageActions.Models.StorageTaskRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTaskRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskRunStatus Finished { get { throw null; } }
        public static Azure.ResourceManager.StorageActions.Models.StorageTaskRunStatus InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageActions.Models.StorageTaskRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageActions.Models.StorageTaskRunStatus left, Azure.ResourceManager.StorageActions.Models.StorageTaskRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.StorageTaskRunStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageActions.Models.StorageTaskRunStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageActions.Models.StorageTaskRunStatus left, Azure.ResourceManager.StorageActions.Models.StorageTaskRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageTaskUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties>
    {
        public StorageTaskUpdateProperties() { }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskAction Action { get { throw null; } set { } }
        public System.DateTimeOffset? CreationTimeInUtc { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.StorageActions.Models.StorageTaskProvisioningState? ProvisioningState { get { throw null; } }
        public long? TaskVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageActions.Models.StorageTaskUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
