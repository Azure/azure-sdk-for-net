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
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult> BulkAcknowledgeOperationErrors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult>> BulkAcknowledgeOperationErrorsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult> BulkCancelOperations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult>> BulkCancelOperationsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult> BulkCreateOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>> BulkCreateOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult> BulkDeallocateOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult> BulkDeleteOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>> BulkDeleteOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult> BulkGetOperationsStatus(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult>> BulkGetOperationsStatusAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult> BulkHibernateOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>> BulkHibernateOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> BulkListOperationErrors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, int? lookbackInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> BulkListOperationErrorsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, int? lookbackInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult> BulkReimageOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult>> BulkReimageOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult> BulkStartOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>> BulkStartOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult> BulkVdiFlexCreateOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>> BulkVdiFlexCreateOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetAsyncOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsyncOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources> GetByVms(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources> GetByVmsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> GetLocationBasedBulkCreateCustom(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>> GetLocationBasedBulkCreateCustomAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource GetLocationBasedBulkCreateCustomResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomCollection GetLocationBasedBulkCreateCustoms(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> GetLocationBasedBulkCreateCustoms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> GetLocationBasedBulkCreateCustomsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetLocationBasedLaunchBulkInstancesOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>> GetLocationBasedLaunchBulkInstancesOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource GetLocationBasedLaunchBulkInstancesOperationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationCollection GetLocationBasedLaunchBulkInstancesOperations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetLocationBasedLaunchBulkInstancesOperations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetLocationBasedLaunchBulkInstancesOperationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource> GetOccurrenceByVms(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource> GetOccurrenceByVmsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.OccurrenceResource GetOccurrenceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> GetScheduledAction(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource>> GetScheduledActionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource GetScheduledActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.ScheduledActionCollection GetScheduledActions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> GetScheduledActions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> GetScheduledActionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocationBasedBulkCreateCustomCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>, System.Collections.IEnumerable
    {
        protected LocationBasedBulkCreateCustomCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocationBasedBulkCreateCustomData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>
    {
        public LocationBasedBulkCreateCustomData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocationBasedBulkCreateCustomResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocationBasedBulkCreateCustomResource() { }
        public virtual Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, Azure.Core.AzureLocation location, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteInstances = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteInstances = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocationBasedLaunchBulkInstancesOperationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>, System.Collections.IEnumerable
    {
        protected LocationBasedLaunchBulkInstancesOperationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocationBasedLaunchBulkInstancesOperationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>
    {
        public LocationBasedLaunchBulkInstancesOperationData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocationBasedLaunchBulkInstancesOperationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocationBasedLaunchBulkInstancesOperationResource() { }
        public virtual Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, Azure.Core.AzureLocation location, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteInstances = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteInstances = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine> GetVirtualMachines(string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine> GetVirtualMachinesAsync(string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OccurrenceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource>, System.Collections.IEnumerable
    {
        protected OccurrenceCollection() { }
        public virtual Azure.Response<bool> Exists(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource> Get(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource>> GetAsync(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource> GetIfExists(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource>> GetIfExistsAsync(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OccurrenceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>
    {
        internal OccurrenceData() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.OccurrenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.OccurrenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OccurrenceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OccurrenceResource() { }
        public virtual Azure.ResourceManager.Compute.BulkActions.OccurrenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult> Cancel(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult>> CancelAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scheduledActionName, string occurrenceId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult> Delay(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult>> DelayAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource> GetResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource> GetResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.OccurrenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.OccurrenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.OccurrenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource>, System.Collections.IEnumerable
    {
        protected ScheduledActionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scheduledActionName, Azure.ResourceManager.Compute.BulkActions.ScheduledActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scheduledActionName, Azure.ResourceManager.Compute.BulkActions.ScheduledActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> Get(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource>> GetAsync(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> GetIfExists(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource>> GetIfExistsAsync(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScheduledActionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>
    {
        public ScheduledActionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.ScheduledActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.ScheduledActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScheduledActionResource() { }
        public virtual Azure.ResourceManager.Compute.BulkActions.ScheduledActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult> AttachResources(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult>> AttachResourcesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult> CancelNextOccurrence(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult>> CancelNextOccurrenceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scheduledActionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult> DetachResources(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult>> DetachResourcesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Disable(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Enable(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource> GetOccurrence(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource>> GetOccurrenceAsync(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.BulkActions.OccurrenceCollection GetOccurrences() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource> GetResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource> GetResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult> PatchResources(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult>> PatchResourcesAsync(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.ScheduledActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.ScheduledActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.ScheduledActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource> TriggerManualOccurrence(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.BulkActions.OccurrenceResource>> TriggerManualOccurrenceAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.BulkActions.Mocking
{
    public partial class MockableComputeBulkActionsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeBulkActionsArmClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources> GetByVms(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources> GetByVmsAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource GetLocationBasedBulkCreateCustomResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource GetLocationBasedLaunchBulkInstancesOperationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource> GetOccurrenceByVms(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource> GetOccurrenceByVmsAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.BulkActions.OccurrenceResource GetOccurrenceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource GetScheduledActionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeBulkActionsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeBulkActionsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult> BulkAcknowledgeOperationErrors(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult>> BulkAcknowledgeOperationErrorsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult> BulkCancelOperations(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult>> BulkCancelOperationsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult> BulkCreateOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>> BulkCreateOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult> BulkDeallocateOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult> BulkDeleteOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>> BulkDeleteOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult> BulkGetOperationsStatus(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult>> BulkGetOperationsStatusAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult> BulkHibernateOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>> BulkHibernateOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> BulkListOperationErrors(Azure.Core.AzureLocation location, int? lookbackInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> BulkListOperationErrorsAsync(Azure.Core.AzureLocation location, int? lookbackInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult> BulkReimageOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult>> BulkReimageOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult> BulkStartOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>> BulkStartOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult> BulkVdiFlexCreateOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>> BulkVdiFlexCreateOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> GetLocationBasedBulkCreateCustom(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource>> GetLocationBasedBulkCreateCustomAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomCollection GetLocationBasedBulkCreateCustoms(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetLocationBasedLaunchBulkInstancesOperation(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>> GetLocationBasedLaunchBulkInstancesOperationAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationCollection GetLocationBasedLaunchBulkInstancesOperations(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> GetScheduledAction(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource>> GetScheduledActionAsync(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.BulkActions.ScheduledActionCollection GetScheduledActions() { throw null; }
    }
    public partial class MockableComputeBulkActionsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeBulkActionsSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetAsyncOperationStatus(Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsyncOperationStatusAsync(Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> GetLocationBasedBulkCreateCustoms(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomResource> GetLocationBasedBulkCreateCustomsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetLocationBasedLaunchBulkInstancesOperations(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetLocationBasedLaunchBulkInstancesOperationsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetOperationStatus(Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetOperationStatusAsync(Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> GetScheduledActions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.ScheduledActionResource> GetScheduledActionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.BulkActions.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcceleratorManufacturer : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcceleratorManufacturer(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer AMD { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer Nvidia { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer Xilinx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer left, Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer left, Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcceleratorType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcceleratorType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorType FPGA { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorType GPU { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorType left, Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorType left, Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdditionalCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities>
    {
        public AdditionalCapabilities() { }
        public bool? HibernationEnabled { get { throw null; } set { } }
        public bool? UltraSSDEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdditionalUnattendContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent>
    {
        public AdditionalUnattendContent() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentComponentName? ComponentName { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentPassName? PassName { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.SettingNames? SettingName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdditionalUnattendContentComponentName : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentComponentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdditionalUnattendContentComponentName(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentComponentName MicrosoftWindowsShellSetup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentComponentName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentComponentName left, Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentComponentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentComponentName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentComponentName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentComponentName left, Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentComponentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdditionalUnattendContentPassName : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentPassName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdditionalUnattendContentPassName(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentPassName OobeSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentPassName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentPassName left, Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentPassName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentPassName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentPassName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentPassName left, Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentPassName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllocationStrategy : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllocationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy CapacityOptimized { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy LowestPrice { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy Prioritized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy left, Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy left, Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiError>
    {
        internal ApiError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase> Details { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ApiError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ApiError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ApiError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ApiError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiErrorBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase>
    {
        internal ApiErrorBase() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArchitectureType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArchitectureType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType ARM64 { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType X64 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType left, Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType left, Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmComputeBulkActionsModelFactory
    {
        public static Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities AdditionalCapabilities(bool? ultraSSDEnabled = default(bool?), bool? hibernationEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent AdditionalUnattendContent(Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentPassName? passName = default(Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentPassName?), Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentComponentName? componentName = default(Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentComponentName?), Azure.ResourceManager.Compute.BulkActions.Models.SettingNames? settingName = default(Azure.ResourceManager.Compute.BulkActions.Models.SettingNames?), string content = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ApiError ApiError(string code = null, string target = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase> details = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError innererror = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ApiErrorBase ApiErrorBase(string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics BootDiagnostics(bool? enabled = default(bool?), string storageUri = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail BulkActionExecutionParameterDetail(Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail BulkActionExecutionParameterDetail(Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference? optimizationPreference = default(Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference?), Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy retryPolicy = null, bool? verifyVmAgentHealth = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent BulkActionsAcknowledgeBulkOperationErrorsRequestContent(System.Collections.Generic.IEnumerable<string> operationIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult BulkActionsAcknowledgeBulkOperationErrorsResponseResult(System.Collections.Generic.IEnumerable<string> acknowledged = null, System.Collections.Generic.IEnumerable<string> notFound = null, System.Collections.Generic.IEnumerable<string> skipped = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent BulkActionsCancelOccurrenceRequestContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent BulkActionsDelayRequestContent(System.DateTimeOffset delay = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent BulkActionsExecuteReimageRequestContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null, Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext resourcesWithContext = null, Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload reimageParameters = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent BulkActionsExecuteVdiCreateRequestContent(Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload resourceConfigParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent BulkActionsOsProfileProvisioningContent(string adminPassword = null, string customData = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent BulkActionsRecurringScheduledActionsExecutionParametersContent(Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference? optimizationPreference = default(Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference?), Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult BulkActionsReimageResourceOperationResponseResult(string description = null, string resourceTypeName = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent BulkActionsResourceAttachRequestContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput> resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent BulkActionsResourceDetachRequestContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult BulkActionsResourceOperationResponseResult(int totalResources = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus> resourcesStatuses = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent BulkActionsResourcePatchRequestContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput> resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent BulkActionsVirtualMachineReimageParametersContent(bool? tempDisk = default(bool?), string exactVersion = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent osProfile = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension BulkactionVMExtension(string name = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties BulkActionVmExtensionProperties(string forceUpdateTag = null, string publisher = null, string type = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.Collections.Generic.IDictionary<string, System.BinaryData> settings = null, System.Collections.Generic.IDictionary<string, System.BinaryData> protectedSettings = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference protectedSettingsFromKeyVault = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties BulkactionVMProperties(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy scheduledEventsPolicy = null, Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile storageProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile hardwareProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities additionalCapabilities = null, Azure.ResourceManager.Compute.BulkActions.Models.OSProfile osProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile networkProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile securityProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics bootDiagnostics = null, string licenseType = null, string extensionsTimeBudget = null, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile scheduledEventsProfile = null, string userData = null, string capacityReservationGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication> galleryApplications = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension> vmExtensions = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride BulkCreateCustomOverride(string virtualMachineName = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties virtualMachineProfile = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity identity = null, Azure.ResourceManager.Models.ArmPlan plan = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension> extensions = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase BulkCreateCustomOverrideBase(Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties virtualMachineProfile = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity identity = null, Azure.ResourceManager.Models.ArmPlan plan = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension> extensions = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile BulkCreateCustomOverridesProfile(string virtualMachineNamePrefix = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride> overrides = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile BulkCreateCustomPriorityProfile(Azure.ResourceManager.Compute.BulkActions.Models.PriorityType? type = default(Azure.ResourceManager.Compute.BulkActions.Models.PriorityType?), float? maxPricePerVM = default(float?), Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy? evictionPolicy = default(Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy?), Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomAllocationStrategy? allocationStrategy = default(Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomAllocationStrategy?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties BulkCreateCustomProperties(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState?), int capacity = 0, Azure.ResourceManager.Compute.BulkActions.Models.CapacityType? capacityType = default(Azure.ResourceManager.Compute.BulkActions.Models.CapacityType?), Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile priorityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile> vmSizesProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile computeProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy zoneAllocationPolicy = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile overridesProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile BulkCreateCustomVmSizeProfile(string name = null, int rank = 0, Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase @override = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy BulkCreateCustomZoneAllocationPolicy(Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy? distributionStrategy = default(Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference> zonePreferences = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError BulkInstancesInnerError(string exceptionType = null, string errorDetail = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy BulkOperationRetryPolicy(int? retryCount = default(int?), int? retryWindowInMinutes = default(int?), Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind? onFailureAction = default(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsContent CancelBulkOperationsContent(System.Collections.Generic.IEnumerable<string> operationIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CancelBulkOperationsResult CancelBulkOperationsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo ComputeBulkFallbackOperationInfo(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind lastOperationKind = default(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind), string status = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError error = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails ComputeBulkOperationDetails(string operationId = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind? operationKind = default(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind?), System.Guid? subscriptionId = default(System.Guid?), System.DateTimeOffset? deadlineOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind? deadlineKind = default(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind?), Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState? state = default(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState?), string timeZone = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError error = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo fallbackOperationInfo = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails ComputeBulkOperationDetails(string operationId = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind? operationKind = default(Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind?), System.Guid? subscriptionId = default(System.Guid?), System.DateTimeOffset? deadlineOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind? deadlineKind = default(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind?), Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState? state = default(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionOperationState?), string timeZone = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError error = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo fallbackOperationInfo = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy retryPolicy = null, string resourceContext = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError ComputeBulkOperationError(string errorCode = null, string errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult ComputeBulkOperationResult(Azure.Core.ResourceIdentifier resourceId = null, string errorCode = null, string errorDetails = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails operation = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult ComputeBulkOperationResult(Azure.Core.ResourceIdentifier resourceId = null, string errorCode = null, string errorDetails = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationDetails operation = null, Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo virtualMachineInfo = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile ComputeProfile(Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties virtualMachineProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension> extensions = null, string computeApiVersion = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult CreateResourceOperationResult(string description = null, string resourceTypeName = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DataDisk DataDisk(int lun = 0, string name = null, string vhdUri = null, string imageUri = null, Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes? caching = default(Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes?), bool? writeAcceleratorEnabled = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes createOption = default(Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes), int? diskSizeGB = default(int?), Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent managedDisk = null, string sourceResourceId = null, bool? toBeDetached = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.DiskDetachOptionTypes? detachOption = default(Azure.ResourceManager.Compute.BulkActions.Models.DiskDetachOptionTypes?), Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes? deleteOption = default(Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult DeallocateResourceOperationResult(string description = null, string resourceTypeName = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult DeleteResourceOperationResult(string description = null, string resourceTypeName = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings DiffDiskSettings(Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOptions? option = default(Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOptions?), Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement? placement = default(Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent DiskEncryptionSetParametersContent(string id = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings DiskEncryptionSettings(Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference diskEncryptionKey = null, Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference keyEncryptionKey = null, bool? enabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph EventGridAndResourceGraph(bool? enable = default(bool?), string scheduledEventsApiVersion = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent ExecuteCreateContent(Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload resourceConfigParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent ExecuteDeallocateContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent ExecuteDeallocateContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null, Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext resourcesWithContext = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent ExecuteDeleteContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null, Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext resourcesWithContext = null, bool? isForceDeletion = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent ExecuteDeleteContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null, bool? isForceDeletion = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent ExecuteHibernateContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent ExecuteHibernateContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null, Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext resourcesWithContext = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent ExecuteStartContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent ExecuteStartContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources resources = null, Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext resourcesWithContext = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties FlexProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile> vmSizeProfiles = null, Azure.ResourceManager.Compute.BulkActions.Models.OsType osType = default(Azure.ResourceManager.Compute.BulkActions.Models.OsType), Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile priorityProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy zoneAllocationPolicy = null, int? minCapacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusContent GetBulkOperationStatusContent(System.Collections.Generic.IEnumerable<string> operationIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.GetBulkOperationStatusResult GetBulkOperationStatusResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile HardwareProfile(string vmSize = null, Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties vmSizeProperties = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult HibernateResourceOperationResult(string description = null, string resourceTypeName = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings HostEndpointSettings(Azure.ResourceManager.Compute.BulkActions.Models.Modes? mode = default(Azure.ResourceManager.Compute.BulkActions.Models.Modes?), string inVMAccessControlProfileReferenceId = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ImageReference ImageReference(string id = null, string publisher = null, string offer = null, string sku = null, string version = null, string sharedGalleryImageId = null, string communityGalleryImageId = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference KeyVaultKeyReference(string keyUri = null, string sourceVaultId = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference KeyVaultSecretReference(string secretUri = null, string sourceVaultId = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties LaunchBulkInstancesOperationProperties(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState?), int capacity = 0, Azure.ResourceManager.Compute.BulkActions.Models.CapacityType? capacityType = default(Azure.ResourceManager.Compute.BulkActions.Models.CapacityType?), Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile priorityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile> vmSizesProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes vmAttributes = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile computeProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy zoneAllocationPolicy = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration LinuxConfiguration(bool? disablePasswordAuthentication = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey> sshPublicKeys = null, bool? provisionVMAgent = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings patchSettings = null, bool? enableVMAgentPlatformUpdates = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings LinuxPatchSettings(Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchMode? patchMode = default(Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchMode?), Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchAssessmentMode? assessmentMode = default(Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchAssessmentMode?), Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings automaticByPlatformSettings = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings LinuxVMGuestPatchAutomaticByPlatformSettings(Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting? rebootSetting = default(Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting?), bool? bypassPlatformSafetyChecksOnUserSchedule = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.LocationBasedBulkCreateCustomData LocationBasedBulkCreateCustomData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties properties = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Models.ArmPlan plan = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData LocationBasedLaunchBulkInstancesOperationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties properties = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Models.ArmPlan plan = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent ManagedDiskParametersContent(string id = null, Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes? storageAccountType = default(Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes?), string diskEncryptionSetId = null, Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile securityProfile = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference NetworkInterfaceReference(string id = null, Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties NetworkInterfaceReferenceProperties(bool? primary = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions? deleteOption = default(Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile NetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference> networkInterfaces = null, Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion? networkApiVersion = default(Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration> networkInterfaceConfigurations = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties NotificationProperties(string destination = null, Azure.ResourceManager.Compute.BulkActions.Models.NotificationType type = default(Azure.ResourceManager.Compute.BulkActions.Models.NotificationType), Azure.ResourceManager.Compute.BulkActions.Models.Language language = default(Azure.ResourceManager.Compute.BulkActions.Models.Language), bool? disabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.OccurrenceData OccurrenceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties OccurrenceExtensionProperties(Azure.Core.ResourceIdentifier resourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> notificationSettings = null, System.DateTimeOffset scheduledOn = default(System.DateTimeOffset), Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState?), Azure.ResponseError errorDetails = null, Azure.Core.ResourceIdentifier scheduledActionId = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource OccurrenceExtensionResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties OccurrenceProperties(System.DateTimeOffset scheduledOn = default(System.DateTimeOffset), Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary resultSummary = null, Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState? provisioningState = default(Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource OccurrenceResource(string name = null, Azure.Core.ResourceIdentifier id = null, string type = null, Azure.Core.ResourceIdentifier resourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> notificationSettings = null, System.DateTimeOffset scheduledOn = default(System.DateTimeOffset), Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary OccurrenceResultSummary(int total = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary> statuses = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OSDisk OSDisk(Azure.ResourceManager.Compute.BulkActions.Models.OperatingSystemTypes? osType = default(Azure.ResourceManager.Compute.BulkActions.Models.OperatingSystemTypes?), Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings encryptionSettings = null, string name = null, string vhdUri = null, string imageUri = null, Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes? caching = default(Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes?), bool? writeAcceleratorEnabled = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings diffDiskSettings = null, Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes createOption = default(Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes), int? diskSizeGB = default(int?), Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent managedDisk = null, Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes? deleteOption = default(Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile OSImageNotificationProfile(string notBeforeTimeout = null, bool? enable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OSProfile OSProfile(string computerName = null, string adminUsername = null, string adminPassword = null, string customData = null, Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration windowsConfiguration = null, Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration linuxConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup> secrets = null, bool? allowExtensionOperations = default(bool?), bool? requireGuestProvisionSignal = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings PatchSettings(Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode? patchMode = default(Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode?), bool? enableHotpatching = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode? assessmentMode = default(Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode?), Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings automaticByPlatformSettings = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile PriorityProfile(Azure.ResourceManager.Compute.BulkActions.Models.PriorityType? type = default(Azure.ResourceManager.Compute.BulkActions.Models.PriorityType?), float? maxPricePerVM = default(float?), Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy? evictionPolicy = default(Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy?), Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy? allocationStrategy = default(Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings ProxyAgentSettings(bool? enabled = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.Mode? mode = default(Azure.ResourceManager.Compute.BulkActions.Models.Mode?), int? keyIncarnationId = default(int?), Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings wireServer = null, Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings imds = null, bool? addProxyAgentExtension = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku PublicIPAddressSku(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuName? name = default(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuName?), Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuTier? tier = default(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuTier?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy RecurringScheduledActionsRetryPolicy(int? retryCount = default(int?), int? retryWindowInMinutes = default(int?), Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType? onFailureAction = default(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload ReimagePayload(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent baseProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride> resourceOverrides = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride ReimageResourceOverride(Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent profile = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload ResourceProvisionPayload(System.Collections.Generic.IDictionary<string, System.BinaryData> baseProfile = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> resourceOverrides = null, int resourceCount = 0, string resourcePrefix = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload ResourceProvisionVdiPayload(System.Collections.Generic.IDictionary<string, System.BinaryData> baseProfile = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> resourceOverrides = null, int resourceCount = 0, string resourcePrefix = null, Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties flexProperties = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary ResourceResultSummary(string code = null, int count = 0, Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus ResourceStatus(Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationStatus status = default(Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationStatus), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext ResourcesWithContext(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext> resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext ResourceWithContext(Azure.Core.ResourceIdentifier resourceId = null, string resourceContext = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.ScheduledActionData ScheduledActionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch ScheduledActionPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties ScheduledActionProperties(Azure.ResourceManager.Compute.BulkActions.Models.ResourceType resourceType = default(Azure.ResourceManager.Compute.BulkActions.Models.ResourceType), Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType actionType = default(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType), System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule schedule = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> notificationSettings = null, bool? disabled = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState? provisioningState = default(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource ScheduledActionResource(string name = null, Azure.Core.ResourceIdentifier id = null, string type = null, Azure.Core.ResourceIdentifier resourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> notificationSettings = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput ScheduledActionResourceInput(Azure.Core.ResourceIdentifier resourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> notificationSettings = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources ScheduledActionResources(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties ScheduledActionsExtensionProperties(Azure.ResourceManager.Compute.BulkActions.Models.ResourceType resourceType = default(Azure.ResourceManager.Compute.BulkActions.Models.ResourceType), Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType actionType = default(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType), System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule schedule = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> notificationSettings = null, bool? disabled = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState? provisioningState = default(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> resourceNotificationSettings = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule ScheduledActionsSchedule(System.TimeSpan scheduledTime = default(System.TimeSpan), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.WeekDay> requestedWeekDays = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.Month> requestedMonths = null, System.Collections.Generic.IEnumerable<int> requestedDaysOfTheMonth = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType? deadlineType = default(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate ScheduledActionsScheduleUpdate(System.TimeSpan? scheduledTime = default(System.TimeSpan?), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.WeekDay> requestedWeekDays = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.Month> requestedMonths = null, System.Collections.Generic.IEnumerable<int> requestedDaysOfTheMonth = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent executionParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType? deadlineType = default(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties ScheduledActionUpdateProperties(Azure.ResourceManager.Compute.BulkActions.Models.ResourceType? resourceType = default(Azure.ResourceManager.Compute.BulkActions.Models.ResourceType?), Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType? actionType = default(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate schedule = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> notificationSettings = null, bool? disabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy ScheduledEventsPolicy(bool? userInitiatedRedeployAutomaticallyApprove = default(bool?), bool? userInitiatedRebootAutomaticallyApprove = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph scheduledEventsAdditionalPublishingTargetsEventGridAndResourceGraph = null, bool? allInstancesDownAutomaticallyApprove = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile ScheduledEventsProfile(Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile terminateNotificationProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile osImageNotificationProfile = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile SecurityProfile(Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings uefiSettings = null, bool? encryptionAtHost = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.SecurityTypes? securityType = default(Azure.ResourceManager.Compute.BulkActions.Models.SecurityTypes?), string userAssignedIdentityResourceId = null, Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings proxyAgentSettings = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey SshPublicKey(string path = null, string keyData = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult StartResourceOperationResult(string description = null, string resourceTypeName = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile StorageProfile(Azure.ResourceManager.Compute.BulkActions.Models.ImageReference imageReference = null, Azure.ResourceManager.Compute.BulkActions.Models.OSDisk osDisk = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.DataDisk> dataDisks = null, Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes? diskControllerType = default(Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.SubResource SubResource(string id = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile TerminateNotificationProfile(string notBeforeTimeout = null, bool? enable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings UefiSettings(bool? secureBootEnabled = default(bool?), bool? vTpmEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue UserAssignedIdentitiesValue(string principalId = null, string clientId = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources UserRequestResources(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> ids = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate VaultCertificate(string certificateUri = null, string certificateStore = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup VaultSecretGroup(string sourceVaultId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate> vaultCertificates = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine VirtualMachine(string name = null, Azure.Core.ResourceIdentifier id = null, string type = null, Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus operationStatus = default(Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus), Azure.ResourceManager.Compute.BulkActions.Models.ApiError error = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity VirtualMachineIdentity(string principalId = null, string tenantId = null, Azure.ResourceManager.Compute.BulkActions.Models.ResourceIdentityType? type = default(Azure.ResourceManager.Compute.BulkActions.Models.ResourceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo VirtualMachineInfo(string vmSize = null, string zone = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag VirtualMachineIpTag(string ipTagType = null, string tag = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration VirtualMachineNetworkInterfaceConfiguration(string name = null, Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties VirtualMachineNetworkInterfaceConfigurationProperties(bool? primary = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions? deleteOption = default(Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions?), bool? enableAcceleratedNetworking = default(bool?), bool? disableTcpStateTracking = default(bool?), bool? enableFpga = default(bool?), bool? enableIPForwarding = default(bool?), string networkSecurityGroupId = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration> ipConfigurations = null, string dscpConfigurationId = null, Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode? auxiliaryMode = default(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode?), Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku? auxiliarySku = default(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration VirtualMachineNetworkInterfaceIPConfiguration(string name = null, Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties VirtualMachineNetworkInterfaceIPConfigurationProperties(string subnetId = null, bool? primary = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration publicIPAddressConfiguration = null, Azure.ResourceManager.Compute.BulkActions.Models.IPVersions? privateIPAddressVersion = default(Azure.ResourceManager.Compute.BulkActions.Models.IPVersions?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.SubResource> applicationSecurityGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.SubResource> applicationGatewayBackendAddressPools = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.SubResource> loadBalancerBackendAddressPools = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration VirtualMachinePublicIPAddressConfiguration(string name = null, Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties properties = null, Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku sku = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties VirtualMachinePublicIPAddressConfigurationProperties(int? idleTimeoutInMinutes = default(int?), Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions? deleteOption = default(Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions?), Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration dnsSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag> ipTags = null, string publicIPPrefixId = null, Azure.ResourceManager.Compute.BulkActions.Models.IPVersions? publicIPAddressVersion = default(Azure.ResourceManager.Compute.BulkActions.Models.IPVersions?), Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod? publicIPAllocationMethod = default(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration VirtualMachinePublicIPAddressDnsSettingsConfiguration(string domainNameLabel = null, Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes? domainNameLabelScope = default(Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble VMAttributeMinMaxDouble(double? min = default(double?), double? max = default(double?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger VMAttributeMinMaxInteger(int? min = default(int?), int? max = default(int?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes VMAttributes(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger vCpuCount = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble memoryInGiB = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType> architectureTypes = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble memoryInGiBPerVCpu = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport? localStorageSupport = default(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport?), Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble localStorageInGiB = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.LocalStorageDiskType> localStorageDiskTypes = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger dataDiskCount = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger networkInterfaceCount = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble networkBandwidthInMbps = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport? rdmaSupport = default(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport?), Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger rdmaNetworkInterfaceCount = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport? acceleratorSupport = default(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer> acceleratorManufacturers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorType> acceleratorTypes = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger acceleratorCount = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VMCategory> vmCategories = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer> cpuManufacturers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.HyperVGeneration> hyperVGenerations = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport? burstableSupport = default(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport?), System.Collections.Generic.IEnumerable<string> allowedVMSizes = null, System.Collections.Generic.IEnumerable<string> excludedVMSizes = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile VMDiskSecurityProfile(Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes? securityEncryptionType = default(Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes?), string diskEncryptionSetId = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication VMGalleryApplication(string tags = null, int? order = default(int?), string packageReferenceId = null, string configurationReference = null, bool? treatFailureAsDeploymentFailure = default(bool?), bool? enableAutomaticUpgrade = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile VmSizeProfile(string name = null, int rank = 0) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties VmSizeProperties(int? vCpusAvailable = default(int?), int? vCpusPerCore = default(int?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration WindowsConfiguration(bool? provisionVMAgent = default(bool?), bool? enableAutomaticUpdates = default(bool?), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent> additionalUnattendContent = null, Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings patchSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener> winRMListeners = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings WindowsVMGuestPatchAutomaticByPlatformSettings(Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting? rebootSetting = default(Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting?), bool? bypassPlatformSafetyChecksOnUserSchedule = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener WinRMListener(Azure.ResourceManager.Compute.BulkActions.Models.ProtocolTypes? protocol = default(Azure.ResourceManager.Compute.BulkActions.Models.ProtocolTypes?), string certificateUri = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy ZoneAllocationPolicy(Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy? distributionStrategy = default(Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference> zonePreferences = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference ZonePreference(string zone = null, int rank = 0) { throw null; }
    }
    public partial class BootDiagnostics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics>
    {
        public BootDiagnostics() { }
        public bool? Enabled { get { throw null; } set { } }
        public string StorageUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference? OptimizationPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy RetryPolicy { get { throw null; } set { } }
        public bool? VerifyVmAgentHealth { get { throw null; } set { } }
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
    public partial class BulkActionsAcknowledgeBulkOperationErrorsRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent>
    {
        public BulkActionsAcknowledgeBulkOperationErrorsRequestContent(System.Collections.Generic.IEnumerable<string> operationIds) { }
        public System.Collections.Generic.IList<string> OperationIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsAcknowledgeBulkOperationErrorsResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult>
    {
        internal BulkActionsAcknowledgeBulkOperationErrorsResponseResult() { }
        public System.Collections.Generic.IList<string> Acknowledged { get { throw null; } }
        public System.Collections.Generic.IList<string> NotFound { get { throw null; } }
        public System.Collections.Generic.IList<string> Skipped { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsAcknowledgeBulkOperationErrorsResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsCancelOccurrenceRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent>
    {
        public BulkActionsCancelOccurrenceRequestContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourceIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsCancelOccurrenceRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsDelayRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent>
    {
        public BulkActionsDelayRequestContent(System.DateTimeOffset delay, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds) { }
        public System.DateTimeOffset Delay { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourceIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsDelayRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsExecuteReimageRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent>
    {
        public BulkActionsExecuteReimageRequestContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload ReimageParameters { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources Resources { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext ResourcesWithContext { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsExecuteVdiCreateRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent>
    {
        public BulkActionsExecuteVdiCreateRequestContent(Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload resourceConfigParameters, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload ResourceConfigParameters { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsOsProfileProvisioningContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent>
    {
        public BulkActionsOsProfileProvisioningContent() { }
        public string AdminPassword { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsRecurringScheduledActionsExecutionParametersContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent>
    {
        public BulkActionsRecurringScheduledActionsExecutionParametersContent() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference? OptimizationPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy RetryPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsReimageResourceOperationResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult>
    {
        internal BulkActionsReimageResourceOperationResponseResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ResourceTypeName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsResourceAttachRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent>
    {
        public BulkActionsResourceAttachRequestContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput> resources) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput> Resources { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceAttachRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsResourceDetachRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent>
    {
        public BulkActionsResourceDetachRequestContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resources) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Resources { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceDetachRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsResourceOperationResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult>
    {
        internal BulkActionsResourceOperationResponseResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus> ResourcesStatuses { get { throw null; } }
        public int TotalResources { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourceOperationResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsResourcePatchRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent>
    {
        public BulkActionsResourcePatchRequestContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput> resources) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput> Resources { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsResourcePatchRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsVirtualMachineReimageParametersContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent>
    {
        public BulkActionsVirtualMachineReimageParametersContent() { }
        public string ExactVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent OsProfile { get { throw null; } set { } }
        public bool? TempDisk { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkactionVMExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension>
    {
        public BulkactionVMExtension(string name, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties properties) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionVmExtensionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties>
    {
        public BulkActionVmExtensionProperties() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ProtectedSettings { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference ProtectedSettingsFromKeyVault { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkactionVMProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties>
    {
        public BulkactionVMProperties() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public string CapacityReservationGroupId { get { throw null; } set { } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication> GalleryApplications { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.OSProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension> VmExtensions { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BulkCreateCustomAllocationStrategy : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomAllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BulkCreateCustomAllocationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomAllocationStrategy LowestPrice { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomAllocationStrategy Prioritized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomAllocationStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomAllocationStrategy left, Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomAllocationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomAllocationStrategy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomAllocationStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomAllocationStrategy left, Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomAllocationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BulkCreateCustomDistributionStrategy : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BulkCreateCustomDistributionStrategy(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy BestEffortBalanced { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy BestEffortSingleZone { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy Prioritized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy left, Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy left, Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BulkCreateCustomOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride>
    {
        public BulkCreateCustomOverride() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension> Extensions { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string VirtualMachineName { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties VirtualMachineProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkCreateCustomOverrideBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase>
    {
        public BulkCreateCustomOverrideBase() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension> Extensions { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties VirtualMachineProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkCreateCustomOverridesProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile>
    {
        public BulkCreateCustomOverridesProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverride> Overrides { get { throw null; } }
        public string VirtualMachineNamePrefix { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkCreateCustomPriorityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile>
    {
        public BulkCreateCustomPriorityProfile() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomAllocationStrategy? AllocationStrategy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy? EvictionPolicy { get { throw null; } set { } }
        public float? MaxPricePerVM { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.PriorityType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkCreateCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties>
    {
        public BulkCreateCustomProperties(int capacity, Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile priorityProfile, Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile computeProfile) { }
        public int Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.CapacityType? CapacityType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile ComputeProfile { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail ExecutionParameters { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverridesProfile OverridesProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomPriorityProfile PriorityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile> VmSizesProfile { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy ZoneAllocationPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkCreateCustomVmSizeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile>
    {
        public BulkCreateCustomVmSizeProfile(string name, int rank) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomOverrideBase Override { get { throw null; } set { } }
        public int Rank { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomVmSizeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkCreateCustomZoneAllocationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy>
    {
        public BulkCreateCustomZoneAllocationPolicy() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomDistributionStrategy? DistributionStrategy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference> ZonePreferences { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkCreateCustomZoneAllocationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkInstancesInnerError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError>
    {
        internal BulkInstancesInnerError() { }
        public string ErrorDetail { get { throw null; } }
        public string ExceptionType { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkInstancesInnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CachingTypes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CachingTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes None { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes left, Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes left, Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.CapacityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CapacityType VCpu { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CapacityType VM { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.CapacityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.CapacityType left, Azure.ResourceManager.Compute.BulkActions.Models.CapacityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.CapacityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.CapacityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.CapacityType left, Azure.ResourceManager.Compute.BulkActions.Models.CapacityType right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionDeadlineKind? DeadlineKind { get { throw null; } }
        public System.DateTimeOffset? DeadlineOn { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationError Error { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkFallbackOperationInfo FallbackOperationInfo { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind? OperationKind { get { throw null; } }
        public string ResourceContext { get { throw null; } }
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
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationKind GetInstanceView { get { throw null; } }
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
        public Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo VirtualMachineInfo { get { throw null; } }
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
    public partial class ComputeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile>
    {
        public ComputeProfile(Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties virtualMachineProfile) { }
        public string ComputeApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMExtension> Extensions { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkactionVMProperties VirtualMachineProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CpuManufacturer : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CpuManufacturer(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer AMD { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer Ampere { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer Intel { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer Microsoft { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer left, Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer left, Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>
    {
        internal CreateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ResourceTypeName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkOperationResult> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DataDisk>
    {
        public DataDisk(int lun, Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes createOption) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.DiskDetachOptionTypes? DetachOption { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public string ImageUri { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public bool? ToBeDetached { get { throw null; } set { } }
        public string VhdUri { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.DataDisk JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.DataDisk PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.DataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.DataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeleteOptions : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeleteOptions(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions Delete { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions left, Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions left, Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskOptions : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskOptions(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOptions Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOptions other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOptions left, Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOptions (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOptions? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOptions left, Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskPlacement : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement CacheDisk { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement NvmeDisk { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement ResourceDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement left, Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement left, Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiffDiskSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings>
    {
        public DiffDiskSettings() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOptions? Option { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskPlacement? Placement { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskControllerTypes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskControllerTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes NVMe { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes SCSI { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes left, Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes left, Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskCreateOptionTypes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskCreateOptionTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes Attach { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes Copy { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes Empty { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes FromImage { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes Restore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes left, Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes left, Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDeleteOptionTypes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDeleteOptionTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes Delete { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes left, Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes left, Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDetachOptionTypes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.DiskDetachOptionTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDetachOptionTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiskDetachOptionTypes ForceDetach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.DiskDetachOptionTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.DiskDetachOptionTypes left, Azure.ResourceManager.Compute.BulkActions.Models.DiskDetachOptionTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiskDetachOptionTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiskDetachOptionTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.DiskDetachOptionTypes left, Azure.ResourceManager.Compute.BulkActions.Models.DiskDetachOptionTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskEncryptionSetParametersContent : Azure.ResourceManager.Compute.BulkActions.Models.SubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent>
    {
        public DiskEncryptionSetParametersContent() { }
        protected override Azure.ResourceManager.Compute.BulkActions.Models.SubResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Compute.BulkActions.Models.SubResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskEncryptionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings>
    {
        public DiskEncryptionSettings() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference DiskEncryptionKey { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference KeyEncryptionKey { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DistributionStrategy : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DistributionStrategy(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy BestEffortBalanced { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy BestEffortSingleZone { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy Prioritized { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy StrictBalanced { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy left, Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy left, Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainNameLabelScopeTypes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainNameLabelScopeTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes NoReuse { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes left, Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes left, Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridAndResourceGraph : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph>
    {
        public EventGridAndResourceGraph() { }
        public bool? Enable { get { throw null; } set { } }
        public string ScheduledEventsApiVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvictionPolicy : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvictionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy Deallocate { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy left, Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy left, Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExecuteCreateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent>
    {
        public ExecuteCreateContent(Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload resourceConfigParameters, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload ResourceConfigParameters { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteDeallocateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent>
    {
        public ExecuteDeallocateContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources Resources { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext ResourcesWithContext { get { throw null; } set { } }
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
        public ExecuteDeleteContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public bool? IsForceDeletion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources Resources { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext ResourcesWithContext { get { throw null; } set { } }
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
        public ExecuteHibernateContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources Resources { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext ResourcesWithContext { get { throw null; } set { } }
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
        public ExecuteStartContent(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail executionParameters) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestResources Resources { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext ResourcesWithContext { get { throw null; } set { } }
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
    public partial class FlexProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties>
    {
        public FlexProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile> vmSizeProfiles, Azure.ResourceManager.Compute.BulkActions.Models.OsType osType, Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile priorityProfile) { }
        public int? MinCapacity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.OsType OsType { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile PriorityProfile { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile> VmSizeProfiles { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy ZoneAllocationPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HardwareProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile>
    {
        public HardwareProfile() { }
        public string VmSize { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties VmSizeProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HostEndpointSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings>
    {
        public HostEndpointSettings() { }
        public string InVMAccessControlProfileReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.Modes? Mode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVGeneration : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.HyperVGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVGeneration(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.HyperVGeneration Gen1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.HyperVGeneration Gen2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.HyperVGeneration other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.HyperVGeneration left, Azure.ResourceManager.Compute.BulkActions.Models.HyperVGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.HyperVGeneration (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.HyperVGeneration? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.HyperVGeneration left, Azure.ResourceManager.Compute.BulkActions.Models.HyperVGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageReference : Azure.ResourceManager.Compute.BulkActions.Models.SubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>
    {
        public ImageReference() { }
        public string CommunityGalleryImageId { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string SharedGalleryImageId { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.ResourceManager.Compute.BulkActions.Models.SubResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Compute.BulkActions.Models.SubResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPVersions : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.IPVersions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPVersions(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.IPVersions IPv4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.IPVersions IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.IPVersions other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.IPVersions left, Azure.ResourceManager.Compute.BulkActions.Models.IPVersions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.IPVersions (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.IPVersions? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.IPVersions left, Azure.ResourceManager.Compute.BulkActions.Models.IPVersions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultKeyReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference>
    {
        public KeyVaultKeyReference(string keyUri) { }
        public string KeyUri { get { throw null; } set { } }
        public string SourceVaultId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultKeyReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference>
    {
        public KeyVaultSecretReference(string secretUri) { }
        public string SecretUri { get { throw null; } set { } }
        public string SourceVaultId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Language : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.Language>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Language(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Language EnUs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.Language other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.Language left, Azure.ResourceManager.Compute.BulkActions.Models.Language right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.Language (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.Language? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.Language left, Azure.ResourceManager.Compute.BulkActions.Models.Language right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LaunchBulkInstancesOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties>
    {
        public LaunchBulkInstancesOperationProperties(int capacity, Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile priorityProfile, Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile computeProfile) { }
        public int Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.CapacityType? CapacityType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile ComputeProfile { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile PriorityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkOperationRetryPolicy RetryPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes VmAttributes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile> VmSizesProfile { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy ZoneAllocationPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration>
    {
        public LinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public bool? EnableVMAgentPlatformUpdates { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ProvisionVMAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey> SshPublicKeys { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchAssessmentMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchAssessmentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchAssessmentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxPatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings>
    {
        public LinuxPatchSettings() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchMode? PatchMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVMGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVMGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxVMGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>
    {
        public LinuxVMGuestPatchAutomaticByPlatformSettings() { }
        public bool? BypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVMGuestPatchMode : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVMGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchMode left, Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchMode left, Azure.ResourceManager.Compute.BulkActions.Models.LinuxVMGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocalStorageDiskType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.LocalStorageDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalStorageDiskType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LocalStorageDiskType HDD { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LocalStorageDiskType SSD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.LocalStorageDiskType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.LocalStorageDiskType left, Azure.ResourceManager.Compute.BulkActions.Models.LocalStorageDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.LocalStorageDiskType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.LocalStorageDiskType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.LocalStorageDiskType left, Azure.ResourceManager.Compute.BulkActions.Models.LocalStorageDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedDiskParametersContent : Azure.ResourceManager.Compute.BulkActions.Models.SubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>
    {
        public ManagedDiskParametersContent() { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes? StorageAccountType { get { throw null; } set { } }
        protected override Azure.ResourceManager.Compute.BulkActions.Models.SubResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Compute.BulkActions.Models.SubResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Mode : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.Mode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Mode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Mode Audit { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Mode Enforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.Mode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.Mode left, Azure.ResourceManager.Compute.BulkActions.Models.Mode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.Mode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.Mode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.Mode left, Azure.ResourceManager.Compute.BulkActions.Models.Mode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Modes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.Modes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Modes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Modes Audit { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Modes Disabled { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Modes Enforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.Modes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.Modes left, Azure.ResourceManager.Compute.BulkActions.Models.Modes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.Modes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.Modes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.Modes left, Azure.ResourceManager.Compute.BulkActions.Models.Modes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Month : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.Month>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Month(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Month All { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Month April { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Month August { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Month December { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Month February { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Month January { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Month July { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Month June { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Month March { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Month May { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Month November { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Month October { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.Month September { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.Month other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.Month left, Azure.ResourceManager.Compute.BulkActions.Models.Month right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.Month (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.Month? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.Month left, Azure.ResourceManager.Compute.BulkActions.Models.Month right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkApiVersion : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkApiVersion(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion _20201101 { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion _20221101 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion left, Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion left, Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkInterfaceAuxiliaryMode : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkInterfaceAuxiliaryMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode AcceleratedConnections { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode Floating { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkInterfaceAuxiliarySku : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkInterfaceAuxiliarySku(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku A1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku A2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku A4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku A8 { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku left, Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku left, Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkInterfaceReference : Azure.ResourceManager.Compute.BulkActions.Models.SubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>
    {
        public NetworkInterfaceReference() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties Properties { get { throw null; } set { } }
        protected override Azure.ResourceManager.Compute.BulkActions.Models.SubResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Compute.BulkActions.Models.SubResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceReferenceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties>
    {
        public NetworkInterfaceReferenceProperties() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile>
    {
        public NetworkProfile() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference> NetworkInterfaces { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties>
    {
        public NotificationProperties(string destination, Azure.ResourceManager.Compute.BulkActions.Models.NotificationType type, Azure.ResourceManager.Compute.BulkActions.Models.Language language) { }
        public string Destination { get { throw null; } set { } }
        public bool? Disabled { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.Language Language { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.NotificationType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.NotificationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NotificationType Email { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.NotificationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.NotificationType left, Azure.ResourceManager.Compute.BulkActions.Models.NotificationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.NotificationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.NotificationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.NotificationType left, Azure.ResourceManager.Compute.BulkActions.Models.NotificationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OccurrenceExtensionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties>
    {
        internal OccurrenceExtensionProperties() { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> NotificationSettings { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ScheduledActionId { get { throw null; } }
        public System.DateTimeOffset ScheduledOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OccurrenceExtensionResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource>
    {
        internal OccurrenceExtensionResource() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OccurrenceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties>
    {
        internal OccurrenceProperties() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary ResultSummary { get { throw null; } }
        public System.DateTimeOffset ScheduledOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OccurrenceResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource>
    {
        internal OccurrenceResource() { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> NotificationSettings { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.DateTimeOffset ScheduledOn { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OccurrenceResultSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary>
    {
        internal OccurrenceResultSummary() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary> Statuses { get { throw null; } }
        public int Total { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResultSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OccurrenceState : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OccurrenceState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState Cancelling { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState Created { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState Rescheduling { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState Scheduled { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState left, Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState left, Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatingSystemTypes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.OperatingSystemTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatingSystemTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OperatingSystemTypes Linux { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OperatingSystemTypes Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.OperatingSystemTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.OperatingSystemTypes left, Azure.ResourceManager.Compute.BulkActions.Models.OperatingSystemTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.OperatingSystemTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.OperatingSystemTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.OperatingSystemTypes left, Azure.ResourceManager.Compute.BulkActions.Models.OperatingSystemTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OptimizationPreference : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OptimizationPreference(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference Availability { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference Cost { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference CostAvailabilityBalanced { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference left, Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference left, Azure.ResourceManager.Compute.BulkActions.Models.OptimizationPreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OSDisk>
    {
        public OSDisk(Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes createOption) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.CachingTypes? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.DiskCreateOptionTypes CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.DiskDeleteOptionTypes? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSettings EncryptionSettings { get { throw null; } set { } }
        public string ImageUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.OperatingSystemTypes? OsType { get { throw null; } set { } }
        public string VhdUri { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OSDisk JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OSDisk PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.OSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.OSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSImageNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile>
    {
        public OSImageNotificationProfile() { }
        public bool? Enable { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OSProfile>
    {
        public OSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public bool? AllowExtensionOperations { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public bool? RequireGuestProvisionSignal { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OSProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.OSProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.OSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.OSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.OSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.OSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OsType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.OsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OsType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OsType Linux { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OsType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.OsType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.OsType left, Azure.ResourceManager.Compute.BulkActions.Models.OsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.OsType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.OsType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.OsType left, Azure.ResourceManager.Compute.BulkActions.Models.OsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings>
    {
        public PatchSettings() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public bool? EnableHotpatching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode? PatchMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PriorityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile>
    {
        public PriorityProfile() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.AllocationStrategy? AllocationStrategy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.EvictionPolicy? EvictionPolicy { get { throw null; } set { } }
        public float? MaxPricePerVM { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.PriorityType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PriorityType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.PriorityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PriorityType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.PriorityType Regular { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.PriorityType Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.PriorityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.PriorityType left, Azure.ResourceManager.Compute.BulkActions.Models.PriorityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.PriorityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.PriorityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.PriorityType left, Azure.ResourceManager.Compute.BulkActions.Models.PriorityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtocolTypes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ProtocolTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtocolTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ProtocolTypes Http { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ProtocolTypes Https { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ProtocolTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ProtocolTypes left, Azure.ResourceManager.Compute.BulkActions.Models.ProtocolTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ProtocolTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ProtocolTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ProtocolTypes left, Azure.ResourceManager.Compute.BulkActions.Models.ProtocolTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState left, Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState left, Azure.ResourceManager.Compute.BulkActions.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProxyAgentSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings>
    {
        public ProxyAgentSettings() { }
        public bool? AddProxyAgentExtension { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings Imds { get { throw null; } set { } }
        public int? KeyIncarnationId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.Mode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings WireServer { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicIPAddressSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku>
    {
        public PublicIPAddressSku() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAddressSkuName : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAddressSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuName left, Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuName left, Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAddressSkuTier : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAddressSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuTier Global { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuTier Regional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuTier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuTier left, Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuTier left, Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAllocationMethod : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod left, Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod left, Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecurringScheduledActionsDeadlineType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecurringScheduledActionsDeadlineType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType CompleteBy { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType InitiateAt { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType left, Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType left, Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecurringScheduledActionsProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecurringScheduledActionsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState left, Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState left, Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecurringScheduledActionsResourceOperationType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecurringScheduledActionsResourceOperationType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType Create { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType Delete { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType Hibernate { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType Start { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType left, Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType left, Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecurringScheduledActionsRetryPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy>
    {
        public RecurringScheduledActionsRetryPolicy() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsResourceOperationType? OnFailureAction { get { throw null; } set { } }
        public int? RetryCount { get { throw null; } set { } }
        public int? RetryWindowInMinutes { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsRetryPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReimagePayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload>
    {
        public ReimagePayload() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent BaseProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride> ResourceOverrides { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReimageResourceOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride>
    {
        public ReimageResourceOverride(Azure.Core.ResourceIdentifier resourceId, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent profile) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent Profile { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
        SystemAssignedUserAssigned = 2,
        None = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceOperationStatus : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationStatus left, Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationStatus left, Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState left, Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState left, Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceProvisionPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload>
    {
        public ResourceProvisionPayload(int resourceCount) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> BaseProfile { get { throw null; } }
        public int ResourceCount { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> ResourceOverrides { get { throw null; } }
        public string ResourcePrefix { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceProvisionVdiPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload>
    {
        public ResourceProvisionVdiPayload(int resourceCount, Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties flexProperties) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> BaseProfile { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.FlexProperties FlexProperties { get { throw null; } }
        public int ResourceCount { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> ResourceOverrides { get { throw null; } }
        public string ResourcePrefix { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceResultSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary>
    {
        internal ResourceResultSummary() { }
        public string Code { get { throw null; } }
        public int Count { get { throw null; } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceResultSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus>
    {
        internal ResourceStatus() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcesWithContext : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext>
    {
        public ResourcesWithContext(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext> resources) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext> Resources { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourcesWithContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceType VirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceType VirtualMachineScaleSet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ResourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ResourceType left, Azure.ResourceManager.Compute.BulkActions.Models.ResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ResourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ResourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ResourceType left, Azure.ResourceManager.Compute.BulkActions.Models.ResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceWithContext : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext>
    {
        public ResourceWithContext(Azure.Core.ResourceIdentifier resourceId, string resourceContext) { }
        public string ResourceContext { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceWithContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch>
    {
        public ScheduledActionPatch() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties>
    {
        public ScheduledActionProperties(Azure.ResourceManager.Compute.BulkActions.Models.ResourceType resourceType, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType actionType, System.DateTimeOffset startOn, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule schedule, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> notificationSettings) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType ActionType { get { throw null; } set { } }
        public bool? Disabled { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> NotificationSettings { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceType ResourceType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule Schedule { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource>
    {
        internal ScheduledActionResource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> NotificationSettings { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionResourceInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput>
    {
        public ScheduledActionResourceInput(Azure.Core.ResourceIdentifier resourceId) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> NotificationSettings { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResourceInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionResources : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources>
    {
        internal ScheduledActionResources() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionsExtensionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties>
    {
        internal ScheduledActionsExtensionProperties() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType ActionType { get { throw null; } }
        public bool? Disabled { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> NotificationSettings { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> ResourceNotificationSettings { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceType ResourceType { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule Schedule { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsExtensionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionsSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule>
    {
        public ScheduledActionsSchedule(System.TimeSpan scheduledTime, string timeZone) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType? DeadlineType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent ExecutionParameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> RequestedDaysOfTheMonth { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.Month> RequestedMonths { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.WeekDay> RequestedWeekDays { get { throw null; } }
        public System.TimeSpan ScheduledTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionsScheduleUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate>
    {
        public ScheduledActionsScheduleUpdate() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.RecurringScheduledActionsDeadlineType? DeadlineType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsRecurringScheduledActionsExecutionParametersContent ExecutionParameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> RequestedDaysOfTheMonth { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.Month> RequestedMonths { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.WeekDay> RequestedWeekDays { get { throw null; } }
        public System.TimeSpan? ScheduledTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType Hibernate { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType Start { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType left, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType left, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduledActionUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties>
    {
        public ScheduledActionUpdateProperties() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionType? ActionType { get { throw null; } set { } }
        public bool? Disabled { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.NotificationProperties> NotificationSettings { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceType? ResourceType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionsScheduleUpdate Schedule { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledEventsPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy>
    {
        public ScheduledEventsPolicy() { }
        public bool? AllInstancesDownAutomaticallyApprove { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.EventGridAndResourceGraph ScheduledEventsAdditionalPublishingTargetsEventGridAndResourceGraph { get { throw null; } set { } }
        public bool? UserInitiatedRebootAutomaticallyApprove { get { throw null; } set { } }
        public bool? UserInitiatedRedeployAutomaticallyApprove { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledEventsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile>
    {
        public ScheduledEventsProfile() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.OSImageNotificationProfile OsImageNotificationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile TerminateNotificationProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityEncryptionTypes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityEncryptionTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes DiskWithVMGuestState { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes NonPersistedTPM { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes VMGuestStateOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes left, Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes left, Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile>
    {
        public SecurityProfile() { }
        public bool? EncryptionAtHost { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings ProxyAgentSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.SecurityTypes? SecurityType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings UefiSettings { get { throw null; } set { } }
        public string UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityTypes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.SecurityTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.SecurityTypes ConfidentialVM { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.SecurityTypes TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.SecurityTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.SecurityTypes left, Azure.ResourceManager.Compute.BulkActions.Models.SecurityTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.SecurityTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.SecurityTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.SecurityTypes left, Azure.ResourceManager.Compute.BulkActions.Models.SecurityTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SettingNames : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.SettingNames>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SettingNames(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.SettingNames AutoLogon { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.SettingNames FirstLogonCommands { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.SettingNames other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.SettingNames left, Azure.ResourceManager.Compute.BulkActions.Models.SettingNames right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.SettingNames (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.SettingNames? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.SettingNames left, Azure.ResourceManager.Compute.BulkActions.Models.SettingNames right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SshPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey>
    {
        public SshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.SshPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountTypes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes PremiumV2LRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes PremiumZRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes StandardSSDLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes StandardSSDZRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes UltraSSDLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes left, Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes left, Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile>
    {
        public StorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.DataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes? DiskControllerType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.OSDisk OsDisk { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.SubResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.SubResource>
    {
        public SubResource() { }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.SubResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.SubResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.SubResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.SubResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.SubResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.SubResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.SubResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.SubResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.SubResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TerminateNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile>
    {
        public TerminateNotificationProfile() { }
        public bool? Enable { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.TerminateNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UefiSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings>
    {
        public UefiSettings() { }
        public bool? SecureBootEnabled { get { throw null; } set { } }
        public bool? VTpmEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UefiSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAssignedIdentitiesValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue>
    {
        public UserAssignedIdentitiesValue() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class VaultCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate>
    {
        public VaultCertificate() { }
        public string CertificateStore { get { throw null; } set { } }
        public string CertificateUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultSecretGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup>
    {
        public VaultSecretGroup() { }
        public string SourceVaultId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate> VaultCertificates { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachine : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine>
    {
        internal VirtualMachine() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ApiError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus OperationStatus { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity>
    {
        public VirtualMachineIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Compute.BulkActions.Models.UserAssignedIdentitiesValue> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo>
    {
        internal VirtualMachineInfo() { }
        public string VmSize { get { throw null; } }
        public string Zone { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineIpTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag>
    {
        public VirtualMachineIpTag() { }
        public string IpTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>
    {
        public VirtualMachineNetworkInterfaceConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>
    {
        public VirtualMachineNetworkInterfaceConfigurationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration> ipConfigurations) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode? AuxiliaryMode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku? AuxiliarySku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public bool? DisableTcpStateTracking { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public string DscpConfigurationId { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration> IpConfigurations { get { throw null; } }
        public string NetworkSecurityGroupId { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>
    {
        public VirtualMachineNetworkInterfaceIPConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceIPConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>
    {
        public VirtualMachineNetworkInterfaceIPConfigurationProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.SubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.SubResource> ApplicationSecurityGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.SubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public bool? Primary { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.IPVersions? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachinePublicIPAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration>
    {
        public VirtualMachinePublicIPAddressConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachinePublicIPAddressConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>
    {
        public VirtualMachinePublicIPAddressConfigurationProperties() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag> IpTags { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.IPVersions? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod? PublicIPAllocationMethod { get { throw null; } set { } }
        public string PublicIPPrefixId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachinePublicIPAddressDnsSettingsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>
    {
        public VirtualMachinePublicIPAddressDnsSettingsConfiguration(string domainNameLabel) { }
        public string DomainNameLabel { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.DomainNameLabelScopeTypes? DomainNameLabelScope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMAttributeMinMaxDouble : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble>
    {
        public VMAttributeMinMaxDouble() { }
        public double? Max { get { throw null; } set { } }
        public double? Min { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMAttributeMinMaxInteger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger>
    {
        public VMAttributeMinMaxInteger() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMAttributes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes>
    {
        public VMAttributes(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger vCpuCount, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble memoryInGiB, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType> architectureTypes) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger AcceleratorCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer> AcceleratorManufacturers { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport? AcceleratorSupport { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorType> AcceleratorTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedVMSizes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType> ArchitectureTypes { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport? BurstableSupport { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer> CpuManufacturers { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger DataDiskCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedVMSizes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.HyperVGeneration> HyperVGenerations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.LocalStorageDiskType> LocalStorageDiskTypes { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble LocalStorageInGiB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport? LocalStorageSupport { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble MemoryInGiB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble MemoryInGiBPerVCpu { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble NetworkBandwidthInMbps { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger NetworkInterfaceCount { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger RdmaNetworkInterfaceCount { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport? RdmaSupport { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger VCpuCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.VMCategory> VmCategories { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMAttributeSupport : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMAttributeSupport(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport Excluded { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport Included { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport left, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport left, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMCategory : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.VMCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMCategory(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMCategory ComputeOptimized { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMCategory FpgaAccelerated { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMCategory GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMCategory GpuAccelerated { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMCategory HighPerformanceCompute { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMCategory MemoryOptimized { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMCategory StorageOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.VMCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.VMCategory left, Azure.ResourceManager.Compute.BulkActions.Models.VMCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.VMCategory (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.VMCategory? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.VMCategory left, Azure.ResourceManager.Compute.BulkActions.Models.VMCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VMDiskSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile>
    {
        public VMDiskSecurityProfile() { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.SecurityEncryptionTypes? SecurityEncryptionType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMGalleryApplication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication>
    {
        public VMGalleryApplication(string packageReferenceId) { }
        public string ConfigurationReference { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public string PackageReferenceId { get { throw null; } set { } }
        public string Tags { get { throw null; } set { } }
        public bool? TreatFailureAsDeploymentFailure { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMOperationStatus : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus CancelFailedStatusUnknown { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus Cancelling { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus left, Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus left, Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmSizeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile>
    {
        public VmSizeProfile(string name, int rank) { }
        public string Name { get { throw null; } set { } }
        public int Rank { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmSizeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties>
    {
        public VmSizeProperties() { }
        public int? VCpusAvailable { get { throw null; } set { } }
        public int? VCpusPerCore { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeekDay : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.WeekDay>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeekDay(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WeekDay All { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WeekDay Friday { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WeekDay Monday { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WeekDay Saturday { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WeekDay Sunday { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WeekDay Thursday { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WeekDay Tuesday { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WeekDay Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.WeekDay other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.WeekDay left, Azure.ResourceManager.Compute.BulkActions.Models.WeekDay right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.WeekDay (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.WeekDay? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.WeekDay left, Azure.ResourceManager.Compute.BulkActions.Models.WeekDay right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration>
    {
        public WindowsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent> AdditionalUnattendContent { get { throw null; } }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.PatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ProvisionVMAgent { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener> WinRMListeners { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVMGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVMGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsVMGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>
    {
        public WindowsVMGuestPatchAutomaticByPlatformSettings() { }
        public bool? BypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVMGuestPatchMode : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVMGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode AutomaticByOS { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode left, Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode left, Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WinRMListener : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener>
    {
        public WinRMListener() { }
        public string CertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ProtocolTypes? Protocol { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ZoneAllocationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy>
    {
        public ZoneAllocationPolicy() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy? DistributionStrategy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference> ZonePreferences { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ZonePreference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference>
    {
        public ZonePreference(string zone, int rank) { }
        public int Rank { get { throw null; } set { } }
        public string Zone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
