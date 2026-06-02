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
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult> BulkCancelOperations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult>> BulkCancelOperationsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult> BulkCreateOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>> BulkCreateOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult> BulkDeallocateOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult> BulkDeleteOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>> BulkDeleteOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult> BulkGetOperationsStatus(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult>> BulkGetOperationsStatusAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult> BulkHibernateOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>> BulkHibernateOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult> BulkReimageOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult>> BulkReimageOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult> BulkStartOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>> BulkStartOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult> BulkVdiFlexCreateOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>> BulkVdiFlexCreateOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetLocationBasedLaunchBulkInstancesOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>> GetLocationBasedLaunchBulkInstancesOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource GetLocationBasedLaunchBulkInstancesOperationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationCollection GetLocationBasedLaunchBulkInstancesOperations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetLocationBasedLaunchBulkInstancesOperations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetLocationBasedLaunchBulkInstancesOperationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo> GetVirtualMachines(string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo> GetVirtualMachinesAsync(string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
}
namespace Azure.ResourceManager.Compute.BulkActions.Mocking
{
    public partial class MockableComputeBulkActionsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeBulkActionsArmClient() { }
        public virtual Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource GetLocationBasedLaunchBulkInstancesOperationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeBulkActionsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeBulkActionsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult> BulkCancelOperations(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult>> BulkCancelOperationsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult> BulkCreateOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>> BulkCreateOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult> BulkDeallocateOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult> BulkDeleteOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult>> BulkDeleteOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult> BulkGetOperationsStatus(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult>> BulkGetOperationsStatusAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult> BulkHibernateOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult>> BulkHibernateOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult> BulkReimageOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult>> BulkReimageOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult> BulkStartOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult>> BulkStartOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult> BulkVdiFlexCreateOperation(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult>> BulkVdiFlexCreateOperationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetLocationBasedLaunchBulkInstancesOperation(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource>> GetLocationBasedLaunchBulkInstancesOperationAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationCollection GetLocationBasedLaunchBulkInstancesOperations(Azure.Core.AzureLocation location) { throw null; }
    }
    public partial class MockableComputeBulkActionsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeBulkActionsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetLocationBasedLaunchBulkInstancesOperations(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationResource> GetLocationBasedLaunchBulkInstancesOperationsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetOperationStatus(Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetOperationStatusAsync(Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentSettingName? SettingName { get { throw null; } set { } }
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
    public readonly partial struct AdditionalUnattendContentSettingName : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentSettingName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdditionalUnattendContentSettingName(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentSettingName AutoLogon { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentSettingName FirstLogonCommands { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentSettingName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentSettingName left, Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentSettingName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentSettingName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentSettingName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentSettingName left, Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContentSettingName right) { throw null; }
        public override string ToString() { throw null; }
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
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent BulkActionsExecuteReimageRequestContent(Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy executionParametersRetryPolicy = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null, Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload reimageParameters = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteVdiCreateRequestContent BulkActionsExecuteVdiCreateRequestContent(Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload resourceConfigParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy executionParametersRetryPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult BulkActionsReimageResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties BulkActionsVdiFlexProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile> vmSizeProfiles = null, Azure.ResourceManager.Compute.BulkActions.Models.OsType osType = default(Azure.ResourceManager.Compute.BulkActions.Models.OsType), Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile priorityProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy zoneAllocationPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo BulkActionsVirtualMachineInfo(string name = null, Azure.Core.ResourceIdentifier id = null, string type = null, Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus operationStatus = default(Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus), Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError error = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties BulkActionVmExtensionProperties(string forceUpdateTag = null, string publisher = null, string type = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.Collections.Generic.IDictionary<string, System.BinaryData> settings = null, System.Collections.Generic.IDictionary<string, System.BinaryData> protectedSettings = null, bool? shouldSuppressFailures = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.KeyVaultSecretReference protectedSettingsFromKeyVault = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties BulkActionVMProperties(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsPolicy scheduledEventsPolicy = null, Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile storageProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.HardwareProfile hardwareProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities additionalCapabilities = null, Azure.ResourceManager.Compute.BulkActions.Models.OSProfile osProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile networkProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.SecurityProfile securityProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics bootDiagnostics = null, string licenseType = null, string extensionsTimeBudget = null, Azure.ResourceManager.Compute.BulkActions.Models.ScheduledEventsProfile scheduledEventsProfile = null, string userData = null, Azure.ResourceManager.Resources.Models.WritableSubResource capacityReservationGroup = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VMGalleryApplication> galleryApplications = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension> vmExtensions = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration BulkVMConfiguration(Azure.ResourceManager.Models.ArmPlan plan = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement placement = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties properties = null, string computeApiVersion = null, string name = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsContent CancelOperationsContent(System.Collections.Generic.IEnumerable<string> operationIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult CancelOperationsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError ComputeApiError(string code = null, string target = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase> details = null, Azure.ResourceManager.Compute.BulkActions.Models.InnerError innererror = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase ComputeApiErrorBase(string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement ComputeBulkActionsPlacement(Azure.ResourceManager.Compute.BulkActions.Models.ZonePlacementPolicyType? zonePlacementPolicy = default(Azure.ResourceManager.Compute.BulkActions.Models.ZonePlacementPolicyType?), System.Collections.Generic.IEnumerable<string> includeZones = null, System.Collections.Generic.IEnumerable<string> excludeZones = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile ComputeProfile(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties virtualMachineProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension> extensions = null, string computeApiVersion = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.CreateResourceOperationResult CreateResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DeallocateResourceOperationResult DeallocateResourceOperationResult(string description = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DeleteResourceOperationResult DeleteResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent ExecuteCreateContent(Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload resourceConfigParameters = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy executionParametersRetryPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeallocateContent ExecuteDeallocateContent(Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy executionParametersRetryPolicy = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteDeleteContent ExecuteDeleteContent(Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy executionParametersRetryPolicy = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null, bool? isForceDeletion = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteHibernateContent ExecuteHibernateContent(Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy executionParametersRetryPolicy = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ExecuteStartContent ExecuteStartContent(Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy executionParametersRetryPolicy = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo FallbackOperationInfo(Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType lastOpType = default(Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType), string status = null, Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError error = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusContent GetOperationStatusContent(System.Collections.Generic.IEnumerable<string> operationIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult GetOperationStatusResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.HibernateResourceOperationResult HibernateResourceOperationResult(string description = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.InnerError InnerError(string exceptionType = null, string errorDetail = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties LaunchBulkInstancesOperationProperties(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState? provisioningState = default(Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState?), int capacity = 0, Azure.ResourceManager.Compute.BulkActions.Models.CapacityType? capacityType = default(Azure.ResourceManager.Compute.BulkActions.Models.CapacityType?), Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile priorityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile> vmSizesProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes vmAttributes = null, Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile computeProfile = null, Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy zoneAllocationPolicy = null, Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.LocationBasedLaunchBulkInstancesOperationData LocationBasedLaunchBulkInstancesOperationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties properties = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Models.ArmPlan plan = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkProfile NetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference> networkInterfaces = null, Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion? networkApiVersion = default(Azure.ResourceManager.Compute.BulkActions.Models.NetworkApiVersion?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration> networkInterfaceConfigurations = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.OSProfile OSProfile(string computerName = null, string adminUsername = null, string adminPassword = null, string customData = null, Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration windowsConfiguration = null, Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration linuxConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup> secrets = null, bool? allowExtensionOperations = default(bool?), bool? isGuestProvisionSignalRequired = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload ReimagePayload(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent baseProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride> resourceOverrides = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ReimageResourceOverride ReimageResourceOverride(Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent profile = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails ResourceOperationDetails(string operationId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceId = null, Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType? opType = default(Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType?), string subscriptionId = null, System.DateTimeOffset? deadline = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType? deadlineType = default(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType?), Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState? state = default(Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState?), string timezone = null, Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError resourceOperationError = null, Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo fallbackOperationInfo = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError ResourceOperationError(string errorCode = null, string errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult ResourceOperationResult(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceId = null, string errorCode = null, string errorDetails = null, Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails operation = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload ResourceProvisionPayload(Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration baseProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration> resourceOverrides = null, int resourceCount = 0, string resourcePrefix = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload ResourceProvisionVdiPayload(Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration baseProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration> resourceOverrides = null, int resourceCount = 0, string resourcePrefix = null, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties flexProperties = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.StartResourceOperationResult StartResourceOperationResult(string description = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.StorageProfile StorageProfile(Azure.ResourceManager.Compute.BulkActions.Models.ImageReference imageReference = null, Azure.ResourceManager.Compute.BulkActions.Models.OSDisk osDisk = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.DataDisk> dataDisks = null, Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes? diskControllerType = default(Azure.ResourceManager.Compute.BulkActions.Models.DiskControllerTypes?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VaultSecretGroup VaultSecretGroup(Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VaultCertificate> vaultCertificates = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfiguration VirtualMachineNetworkInterfaceConfiguration(string name = null, Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties VirtualMachineNetworkInterfaceConfigurationProperties(bool? isPrimary = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior? deleteOption = default(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior?), bool? enableAcceleratedNetworking = default(bool?), bool? disableTcpStateTracking = default(bool?), bool? enableFpga = default(bool?), bool? enableIPForwarding = default(bool?), Azure.ResourceManager.Resources.Models.WritableSubResource networkSecurityGroup = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration> ipConfigurations = null, Azure.ResourceManager.Resources.Models.WritableSubResource dscpConfiguration = null, Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode? auxiliaryMode = default(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliaryMode?), Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku? auxiliarySku = default(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceAuxiliarySku?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties VirtualMachineNetworkInterfaceIPConfigurationProperties(Azure.ResourceManager.Resources.Models.WritableSubResource subnet = null, bool? isPrimary = default(bool?), Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration publicIPAddressConfiguration = null, Azure.ResourceManager.Compute.BulkActions.Models.IPVersions? privateIPAddressVersion = default(Azure.ResourceManager.Compute.BulkActions.Models.IPVersions?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> applicationSecurityGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> applicationGatewayBackendAddressPools = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> loadBalancerBackendAddressPools = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration VirtualMachinePublicIPAddressConfiguration(string name = null, Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties properties = null, Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAddressSku sku = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties VirtualMachinePublicIPAddressConfigurationProperties(int? idleTimeoutInMinutes = default(int?), Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior? deleteOption = default(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior?), Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration dnsSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag> ipTags = null, Azure.ResourceManager.Resources.Models.WritableSubResource publicIPPrefix = null, Azure.ResourceManager.Compute.BulkActions.Models.IPVersions? publicIPAddressVersion = default(Azure.ResourceManager.Compute.BulkActions.Models.IPVersions?), Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod? publicIPAllocationMethod = default(Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod?)) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VMAttributes VMAttributes(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger vCpuCount = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble memoryInGiB = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ArchitectureType> architectureTypes = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble memoryInGiBPerVCpu = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport? localStorageSupport = default(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport?), Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble localStorageInGiB = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.LocalStorageDiskType> localStorageDiskTypes = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger dataDiskCount = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger networkInterfaceCount = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxDouble networkBandwidthInMbps = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport? rdmaSupport = default(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport?), Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger rdmaNetworkInterfaceCount = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport? acceleratorSupport = default(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorManufacturer> acceleratorManufacturers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.AcceleratorType> acceleratorTypes = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeMinMaxInteger acceleratorCount = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VMCategory> vmCategories = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.CpuManufacturer> cpuManufacturers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.HyperVGeneration> hyperVGenerations = null, Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport? burstableSupport = default(Azure.ResourceManager.Compute.BulkActions.Models.VMAttributeSupport?), System.Collections.Generic.IEnumerable<string> allowedVMSizes = null, System.Collections.Generic.IEnumerable<string> excludedVMSizes = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration WindowsConfiguration(bool? shouldProvisionVmAgent = default(bool?), bool? enableAutomaticUpdates = default(bool?), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent> additionalUnattendContent = null, Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchSettings patchSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.WinRMListener> winRMListeners = null) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy ZoneAllocationPolicy(Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy? distributionStrategy = default(Azure.ResourceManager.Compute.BulkActions.Models.DistributionStrategy?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.ZonePreference> zonePreferences = null) { throw null; }
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
    public partial class BulkActionsExecuteReimageRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsExecuteReimageRequestContent>
    {
        public BulkActionsExecuteReimageRequestContent(System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> resourcesIds) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy ExecutionParametersRetryPolicy { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ReimagePayload ReimageParameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
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
        public BulkActionsExecuteVdiCreateRequestContent(Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionVdiPayload resourceConfigParameters) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy ExecutionParametersRetryPolicy { get { throw null; } }
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
    public partial class BulkActionsReimageResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult>
    {
        internal BulkActionsReimageResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> Results { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsReimageResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsVdiFlexProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties>
    {
        public BulkActionsVdiFlexProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile> vmSizeProfiles, Azure.ResourceManager.Compute.BulkActions.Models.OsType osType, Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile priorityProfile) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.OsType OsType { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile PriorityProfile { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.VmSizeProfile> VmSizeProfiles { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ZoneAllocationPolicy ZoneAllocationPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsVirtualMachineInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo>
    {
        internal BulkActionsVirtualMachineInfo() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMOperationStatus OperationStatus { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionsVirtualMachineReimageParametersContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVirtualMachineReimageParametersContent>
    {
        public BulkActionsVirtualMachineReimageParametersContent() { }
        public string ExactVersion { get { throw null; } set { } }
        public bool? IsTempDisk { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsOsProfileProvisioningContent OsProfile { get { throw null; } set { } }
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
    public partial class BulkActionVMExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension>
    {
        public BulkActionVMExtension(string name, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties properties) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVmExtensionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public bool? ShouldSuppressFailures { get { throw null; } set { } }
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
    public partial class BulkActionVMProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties>
    {
        public BulkActionVMProperties() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource CapacityReservationGroup { get { throw null; } set { } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension> VmExtensions { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkVMConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration>
    {
        public BulkVMConfiguration() { }
        public string ComputeApiVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement Placement { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class CancelOperationsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult>
    {
        internal CancelOperationsResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.CancelOperationsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeAllocationStrategy : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ComputeAllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeAllocationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeAllocationStrategy CapacityOptimized { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeAllocationStrategy LowestPrice { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ComputeAllocationStrategy Prioritized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ComputeAllocationStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ComputeAllocationStrategy left, Azure.ResourceManager.Compute.BulkActions.Models.ComputeAllocationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ComputeAllocationStrategy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ComputeAllocationStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ComputeAllocationStrategy left, Azure.ResourceManager.Compute.BulkActions.Models.ComputeAllocationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeApiError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError>
    {
        internal ComputeApiError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase> Details { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeApiErrorBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase>
    {
        internal ComputeApiErrorBase() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeApiErrorBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsPlacement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement>
    {
        public ComputeBulkActionsPlacement() { }
        public System.Collections.Generic.IList<string> ExcludeZones { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludeZones { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ZonePlacementPolicyType? ZonePlacementPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeBulkActionsPlacement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile>
    {
        public ComputeProfile(Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties virtualMachineProfile) { }
        public string ComputeApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMExtension> Extensions { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionVMProperties VirtualMachineProfile { get { throw null; } set { } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> Results { get { throw null; } }
        public string Type { get { throw null; } }
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
        public bool? IsToBeDetached { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
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
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> Results { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> Results { get { throw null; } }
        public string Type { get { throw null; } }
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
    public readonly partial struct DiffDiskOption : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskOption(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOption Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOption other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOption left, Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOption left, Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOption right) { throw null; }
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
        public Azure.ResourceManager.Compute.BulkActions.Models.DiffDiskOption? Option { get { throw null; } set { } }
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
    public partial class DiskEncryptionSetParametersContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent>
    {
        public DiskEncryptionSetParametersContent() { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ExecuteCreateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ExecuteCreateContent>
    {
        public ExecuteCreateContent(Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload resourceConfigParameters) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy ExecutionParametersRetryPolicy { get { throw null; } }
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
        public ExecuteDeallocateContent(System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> resourcesIds) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy ExecutionParametersRetryPolicy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
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
        public ExecuteDeleteContent(System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> resourcesIds) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy ExecutionParametersRetryPolicy { get { throw null; } }
        public bool? IsForceDeletion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
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
        public ExecuteHibernateContent(System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> resourcesIds) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy ExecutionParametersRetryPolicy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
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
        public ExecuteStartContent(System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> resourcesIds) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy ExecutionParametersRetryPolicy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
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
    public partial class FallbackOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo>
    {
        internal FallbackOperationInfo() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError Error { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType LastOpType { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class GetOperationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult>
    {
        internal GetOperationStatusResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.GetOperationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> Results { get { throw null; } }
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
    public readonly partial struct HostEndpointMode : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostEndpointMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointMode Audit { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointMode Enforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointMode left, Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointMode left, Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HostEndpointSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings>
    {
        public HostEndpointSettings() { }
        public string InVMAccessControlProfileReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointMode? Mode { get { throw null; } set { } }
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
    public partial class ImageReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>
    {
        public ImageReference() { }
        public string CommunityGalleryImageId { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string SharedGalleryImageId { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ImageReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ImageReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InnerError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.InnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.InnerError>
    {
        internal InnerError() { }
        public string ErrorDetail { get { throw null; } }
        public string ExceptionType { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.InnerError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.InnerError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.InnerError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.InnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.InnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.InnerError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.InnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.InnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.InnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public KeyVaultKeyReference(string keyUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public string KeyUri { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource SourceVault { get { throw null; } set { } }
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
        public KeyVaultSecretReference(string secretUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public string SecretUri { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource SourceVault { get { throw null; } set { } }
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
    public partial class LaunchBulkInstancesOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProperties>
    {
        public LaunchBulkInstancesOperationProperties(int capacity, Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile priorityProfile, Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile computeProfile) { }
        public int Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.CapacityType? CapacityType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeProfile ComputeProfile { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile PriorityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy RetryPolicy { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LaunchBulkInstancesOperationProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LaunchBulkInstancesOperationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState left, Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState left, Azure.ResourceManager.Compute.BulkActions.Models.LaunchBulkInstancesOperationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration>
    {
        public LinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public bool? EnableVMAgentPlatformUpdates { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.LinuxPatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ShouldProvisionVmAgent { get { throw null; } set { } }
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
    public partial class ManagedDiskParametersContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>
    {
        public ManagedDiskParametersContent() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent DiskEncryptionSet { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VMDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.StorageAccountTypes? StorageAccountType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ManagedDiskParametersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkInterfaceDeleteBehavior : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkInterfaceDeleteBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior Delete { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior left, Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior left, Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkInterfaceReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>
    {
        public NetworkInterfaceReference() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceReferenceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceReferenceProperties>
    {
        public NetworkInterfaceReferenceProperties() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior? DeleteOption { get { throw null; } set { } }
        public bool? IsPrimary { get { throw null; } set { } }
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
        public bool? IsGuestProvisionSignalRequired { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
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
    public partial class PriorityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.PriorityProfile>
    {
        public PriorityProfile() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ComputeAllocationStrategy? AllocationStrategy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineEvictionPolicyTypes? EvictionPolicy { get { throw null; } set { } }
        public float? MaxPricePerVM { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePriorityTypes? Type { get { throw null; } set { } }
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
    public readonly partial struct ProxyAgentMode : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProxyAgentMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentMode Audit { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentMode Enforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentMode left, Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentMode left, Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProxyAgentSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentSettings>
    {
        public ProxyAgentSettings() { }
        public bool? AddProxyAgentExtension { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.HostEndpointSettings Imds { get { throw null; } set { } }
        public int? KeyIncarnationId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ProxyAgentMode? Mode { get { throw null; } set { } }
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
    public partial class ResourceOperationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails>
    {
        internal ResourceOperationDetails() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public System.DateTimeOffset? Deadline { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionDeadlineType? DeadlineType { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.FallbackOperationInfo FallbackOperationInfo { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType? OpType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError ResourceOperationError { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy RetryPolicy { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionOperationState? State { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string Timezone { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceOperationError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError>
    {
        internal ResourceOperationError() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult>
    {
        internal ResourceOperationResult() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationDetails Operation { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceOperationType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceOperationType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType Create { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType Delete { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType Hibernate { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType Start { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType left, Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType left, Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceProvisionPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.ResourceProvisionPayload>
    {
        public ResourceProvisionPayload(int resourceCount) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration BaseProfile { get { throw null; } set { } }
        public int ResourceCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration> ResourceOverrides { get { throw null; } }
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
        public ResourceProvisionVdiPayload(int resourceCount, Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties flexProperties) { }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration BaseProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.BulkActionsVdiFlexProperties FlexProperties { get { throw null; } }
        public int ResourceCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.BulkVMConfiguration> ResourceOverrides { get { throw null; } }
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
        public bool? IsEncryptionAtHostEnabled { get { throw null; } set { } }
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
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationResult> Results { get { throw null; } }
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
    public partial class UserRequestRetryPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy>
    {
        public UserRequestRetryPolicy() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.ResourceOperationType? OnFailureAction { get { throw null; } set { } }
        public int? RetryCount { get { throw null; } set { } }
        public int? RetryWindowInMinutes { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.UserRequestRetryPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Resources.Models.WritableSubResource SourceVault { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineEvictionPolicyTypes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineEvictionPolicyTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineEvictionPolicyTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineEvictionPolicyTypes Deallocate { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineEvictionPolicyTypes Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineEvictionPolicyTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineEvictionPolicyTypes left, Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineEvictionPolicyTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineEvictionPolicyTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineEvictionPolicyTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineEvictionPolicyTypes left, Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineEvictionPolicyTypes right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior? DeleteOption { get { throw null; } set { } }
        public bool? DisableTcpStateTracking { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource DscpConfiguration { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration> IpConfigurations { get { throw null; } }
        public bool? IsPrimary { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource NetworkSecurityGroup { get { throw null; } set { } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationSecurityGroups { get { throw null; } }
        public bool? IsPrimary { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.IPVersions? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource Subnet { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachinePriorityTypes : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePriorityTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachinePriorityTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePriorityTypes Regular { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePriorityTypes Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePriorityTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePriorityTypes left, Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePriorityTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePriorityTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePriorityTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePriorityTypes left, Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePriorityTypes right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.Compute.BulkActions.Models.NetworkInterfaceDeleteBehavior? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.VirtualMachineIpTag> IpTags { get { throw null; } }
        public Azure.ResourceManager.Compute.BulkActions.Models.IPVersions? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.PublicIPAllocationMethod? PublicIPAllocationMethod { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource PublicIPPrefix { get { throw null; } set { } }
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
        public Azure.ResourceManager.Compute.BulkActions.Models.DiskEncryptionSetParametersContent DiskEncryptionSet { get { throw null; } set { } }
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
        public bool? ShouldTreatFailureAsDeploymentFailure { get { throw null; } set { } }
        public string Tags { get { throw null; } set { } }
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
    public partial class WindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsConfiguration>
    {
        public WindowsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.BulkActions.Models.AdditionalUnattendContent> AdditionalUnattendContent { get { throw null; } }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ShouldProvisionVmAgent { get { throw null; } set { } }
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
    public partial class WindowsPatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchSettings>
    {
        public WindowsPatchSettings() { }
        public Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public bool? EnableHotpatching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.BulkActions.Models.WindowsVMGuestPatchMode? PatchMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.BulkActions.Models.WindowsPatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZonePlacementPolicyType : System.IEquatable<Azure.ResourceManager.Compute.BulkActions.Models.ZonePlacementPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZonePlacementPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ZonePlacementPolicyType Any { get { throw null; } }
        public static Azure.ResourceManager.Compute.BulkActions.Models.ZonePlacementPolicyType Auto { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.BulkActions.Models.ZonePlacementPolicyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.BulkActions.Models.ZonePlacementPolicyType left, Azure.ResourceManager.Compute.BulkActions.Models.ZonePlacementPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ZonePlacementPolicyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.BulkActions.Models.ZonePlacementPolicyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.BulkActions.Models.ZonePlacementPolicyType left, Azure.ResourceManager.Compute.BulkActions.Models.ZonePlacementPolicyType right) { throw null; }
        public override string ToString() { throw null; }
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
