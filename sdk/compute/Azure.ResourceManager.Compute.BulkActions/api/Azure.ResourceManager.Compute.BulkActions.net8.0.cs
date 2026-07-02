namespace Azure.ResourceManager.Compute.BulkActions
{
    public partial class AzureResourceManagerComputeBulkActionsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerComputeBulkActionsContext() { }
        public static Azure.ResourceManager.Compute.BulkActions.AzureResourceManagerComputeBulkActionsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ComputeBulkActionsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult> BulkCancelOperations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult>> BulkCancelOperationsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult> BulkDeallocateOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult> BulkDeleteOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>> BulkDeleteOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult> BulkGetOperationsStatus(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult>> BulkGetOperationsStatusAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult> BulkHibernateOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>> BulkHibernateOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult> BulkStartOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>> BulkStartOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.BulkActions.Mocking
{
    public partial class MockableComputeBulkActionsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeBulkActionsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult> BulkCancelOperations(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult>> BulkCancelOperationsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult> BulkDeallocateOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult> BulkDeleteOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>> BulkDeleteOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult> BulkGetOperationsStatus(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult>> BulkGetOperationsStatusAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult> BulkHibernateOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>> BulkHibernateOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult> BulkStartOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>> BulkStartOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.BulkActions.Models
{
    public static partial class ArmComputeBulkActionsModelFactory
    {
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail BulkActionExecutionParameterDetail(Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy BulkOperationRetryPolicy(int? retryCount = default(int?), int? retryWindowInMinutes = default(int?), Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind? onFailureAction = default(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent CancelBulkOperationsContent(System.Collections.Generic.IEnumerable<string> operationIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult CancelBulkOperationsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo ComputeBulkFallbackOperationInfo(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind lastOperationKind = default(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind), string status = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError error = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails ComputeBulkOperationDetails(string operationId = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind? operationKind = default(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind?), System.Guid? subscriptionId = default(System.Guid?), System.DateTimeOffset? deadlineOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind? deadlineType = default(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind?), Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState? state = default(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState?), string timeZone = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError error = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo fallbackOperationInfo = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError ComputeBulkOperationError(string errorCode = null, string errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult ComputeBulkOperationResult(Azure.Core.ResourceIdentifier resourceId = null, string errorCode = null, string errorDetails = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails operation = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult DeallocateResourceOperationResult(string description = null, string resourceTypeName = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult DeleteResourceOperationResult(string description = null, string resourceTypeName = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent ExecuteDeallocateContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent ExecuteDeleteContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null, bool? isForceDeletion = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent ExecuteHibernateContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent ExecuteStartContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent GetBulkOperationStatusContent(System.Collections.Generic.IEnumerable<string> operationIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult GetBulkOperationStatusResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult HibernateResourceOperationResult(string description = null, string resourceTypeName = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult StartResourceOperationResult(string description = null, string resourceTypeName = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources UserRequestResources(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> ids = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BulkActionDeadlineKind : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BulkActionDeadlineKind(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind CompleteBy { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind InitiateAt { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind left, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind left, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BulkActionExecutionParameterDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail>
    {
        public BulkActionExecutionParameterDetail() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy RetryPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BulkActionOperationState : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BulkActionOperationState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState Blocked { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState Executing { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState PendingExecution { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState PendingScheduling { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState Scheduled { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState left, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState left, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BulkOperationRetryPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy>
    {
        public BulkOperationRetryPolicy() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind? OnFailureAction { get { throw null; } set { } }
        public int? RetryCount { get { throw null; } set { } }
        public int? RetryWindowInMinutes { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CancelBulkOperationsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent>
    {
        public CancelBulkOperationsContent(System.Collections.Generic.IEnumerable<string> operationIds) { }
        public System.Collections.Generic.IList<string> OperationIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CancelBulkOperationsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult>
    {
        internal CancelBulkOperationsResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkFallbackOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo>
    {
        internal ComputeBulkFallbackOperationInfo() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError Error { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind LastOperationKind { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkOperationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails>
    {
        internal ComputeBulkOperationDetails() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public System.DateTimeOffset? DeadlineOn { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind? DeadlineType { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError Error { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo FallbackOperationInfo { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind? OperationKind { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy RetryPolicy { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState? State { get { throw null; } }
        public System.Guid? SubscriptionId { get { throw null; } }
        public string TimeZone { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkOperationError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError>
    {
        internal ComputeBulkOperationError() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkOperationKind : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkOperationKind(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind Create { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind Deallocate { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind Delete { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind Hibernate { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind Start { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind left, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind left, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult>
    {
        internal ComputeBulkOperationResult() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails Operation { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeallocateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>
    {
        internal DeallocateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ResourceTypeName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeleteResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>
    {
        internal DeleteResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ResourceTypeName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteDeallocateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent>
    {
        public ExecuteDeallocateContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources Resources { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteDeleteContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent>
    {
        public ExecuteDeleteContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public bool? IsForceDeletion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources Resources { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteHibernateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent>
    {
        public ExecuteHibernateContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources Resources { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteStartContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent>
    {
        public ExecuteStartContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources Resources { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetBulkOperationStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent>
    {
        public GetBulkOperationStatusContent(System.Collections.Generic.IEnumerable<string> operationIds) { }
        public System.Collections.Generic.IList<string> OperationIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetBulkOperationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult>
    {
        internal GetBulkOperationStatusResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HibernateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>
    {
        internal HibernateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ResourceTypeName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StartResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>
    {
        internal StartResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ResourceTypeName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserRequestResources : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources>
    {
        public UserRequestResources(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> ids) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Ids { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
