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
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult> BulkCancelOperations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult>> BulkCancelOperationsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult> BulkDeallocateOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult> BulkDeleteOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>> BulkDeleteOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult> BulkGetOperationsStatus(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult>> BulkGetOperationsStatusAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult> BulkCancelOperations(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult>> BulkCancelOperationsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult> BulkDeallocateOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult> BulkDeleteOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>> BulkDeleteOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult> BulkGetOperationsStatus(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult>> BulkGetOperationsStatusAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy BulkOperationRetryPolicy(int? retryCount = default(int?), int? retryWindowInMinutes = default(int?), Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType? onFailureAction = default(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult CancelBulkOperationsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent CancelOperationsContent(System.Collections.Generic.IEnumerable<string> operationIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo ComputeBulkFallbackOperationInfo(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType lastOperationType = default(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType), string status = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError error = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails ComputeBulkOperationDetails(string operationId = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType? operationType = default(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType?), string subscriptionId = null, System.DateTimeOffset? deadlineOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType? deadlineType = default(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType?), Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState? state = default(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState?), string timeZone = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError error = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo fallbackOperationInfo = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError ComputeBulkOperationError(string errorCode = null, string errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult ComputeBulkOperationResult(Azure.Core.ResourceIdentifier resourceId = null, string errorCode = null, string errorDetails = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails operation = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult DeallocateResourceOperationResult(string description = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult DeleteResourceOperationResult(string description = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent ExecuteDeallocateContent(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent ExecuteDeleteContent(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null, bool? isForceDeletion = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent ExecuteHibernateContent(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent ExecuteStartContent(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult GetBulkOperationStatusResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent GetOperationStatusContent(System.Collections.Generic.IEnumerable<string> operationIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult HibernateResourceOperationResult(string description = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail ScheduledActionExecutionParameterDetail(Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult StartResourceOperationResult(string description = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources UserRequestResources(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> ids = null) { throw null; }
    }
    public partial class BulkOperationRetryPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy>
    {
        public BulkOperationRetryPolicy() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType? OnFailureAction { get { throw null; } set { } }
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
    public partial class CancelOperationsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent>
    {
        public CancelOperationsContent(System.Collections.Generic.IEnumerable<string> operationIds) { }
        public System.Collections.Generic.IList<string> OperationIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkFallbackOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo>
    {
        internal ComputeBulkFallbackOperationInfo() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError Error { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType LastOperationType { get { throw null; } }
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
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType? DeadlineType { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError Error { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo FallbackOperationInfo { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType? OperationType { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy RetryPolicy { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState? State { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkOperationType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkOperationType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType Create { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType Delete { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType Hibernate { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType Start { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType left, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType left, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeallocateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>
    {
        internal DeallocateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ResourceType { get { throw null; } }
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
        public string ResourceType { get { throw null; } }
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
        public ExecuteDeallocateContent(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail executionParameters, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
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
        public ExecuteDeleteContent(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail executionParameters, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
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
        public ExecuteHibernateContent(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail executionParameters, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
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
        public ExecuteStartContent(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail executionParameters, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
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
    public partial class GetOperationStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent>
    {
        public GetOperationStatusContent(System.Collections.Generic.IEnumerable<string> operationIds) { }
        public System.Collections.Generic.IList<string> OperationIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HibernateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>
    {
        internal HibernateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ResourceType { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionDeadlineType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionDeadlineType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType CompleteBy { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType InitiateAt { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType left, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType left, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduledActionExecutionParameterDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail>
    {
        public ScheduledActionExecutionParameterDetail() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy RetryPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionExecutionParameterDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionOperationState : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionOperationState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState Blocked { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState Executing { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState PendingExecution { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState PendingScheduling { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState Scheduled { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState left, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState left, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StartResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>
    {
        internal StartResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ResourceType { get { throw null; } }
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
