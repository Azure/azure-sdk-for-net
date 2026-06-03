namespace Azure.ResourceManager.ComputeBulkActions
{
    public partial class AzureResourceManagerComputeBulkActionsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerComputeBulkActionsContext() { }
        public static Azure.ResourceManager.ComputeBulkActions.AzureResourceManagerComputeBulkActionsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BulkActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>, System.Collections.IEnumerable
    {
        protected BulkActionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.ComputeBulkActions.BulkActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.ComputeBulkActions.BulkActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BulkActionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>
    {
        public BulkActionData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.BulkActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.BulkActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BulkActionResource() { }
        public virtual Azure.ResourceManager.ComputeBulkActions.BulkActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, Azure.Core.AzureLocation location, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteInstances = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteInstances = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult> GetVirtualMachines(string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult> GetVirtualMachinesAsync(string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.BulkActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.BulkActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.BulkActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeBulkActions.BulkActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeBulkActions.BulkActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ComputeBulkActionsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetBulkAction(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>> GetBulkActionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.BulkActionResource GetBulkActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.BulkActionCollection GetBulkActions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetBulkActions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetBulkActionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult> VirtualMachinesCancelOperations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult>> VirtualMachinesCancelOperationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult> VirtualMachinesExecuteCreate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult>> VirtualMachinesExecuteCreateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult> VirtualMachinesExecuteDeallocate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult>> VirtualMachinesExecuteDeallocateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult> VirtualMachinesExecuteDelete(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult>> VirtualMachinesExecuteDeleteAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult> VirtualMachinesExecuteHibernate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult>> VirtualMachinesExecuteHibernateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult> VirtualMachinesExecuteStart(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult>> VirtualMachinesExecuteStartAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult> VirtualMachinesGetOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult>> VirtualMachinesGetOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeBulkActions.Mocking
{
    public partial class MockableComputeBulkActionsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeBulkActionsArmClient() { }
        public virtual Azure.ResourceManager.ComputeBulkActions.BulkActionResource GetBulkActionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeBulkActionsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeBulkActionsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetBulkAction(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>> GetBulkActionAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeBulkActions.BulkActionCollection GetBulkActions(Azure.Core.AzureLocation location) { throw null; }
    }
    public partial class MockableComputeBulkActionsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeBulkActionsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetBulkActions(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetBulkActionsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetOperationStatus(Azure.Core.AzureLocation location, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetOperationStatusAsync(Azure.Core.AzureLocation location, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult> VirtualMachinesCancelOperations(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult>> VirtualMachinesCancelOperationsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult> VirtualMachinesExecuteCreate(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult>> VirtualMachinesExecuteCreateAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult> VirtualMachinesExecuteDeallocate(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult>> VirtualMachinesExecuteDeallocateAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult> VirtualMachinesExecuteDelete(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult>> VirtualMachinesExecuteDeleteAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult> VirtualMachinesExecuteHibernate(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult>> VirtualMachinesExecuteHibernateAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult> VirtualMachinesExecuteStart(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult>> VirtualMachinesExecuteStartAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult> VirtualMachinesGetOperationStatus(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult>> VirtualMachinesGetOperationStatusAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeBulkActions.Models
{
    public static partial class ArmComputeBulkActionsModelFactory
    {
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent BulkActionCancelOperationsContent(System.Collections.Generic.IEnumerable<string> operationIds = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult BulkActionCancelOperationsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile BulkActionComputeProfile(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile virtualMachineProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension> extensions = null, string computeApiVersion = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult BulkActionCreateResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.BulkActionData BulkActionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties properties = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Models.ArmPlan plan = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult BulkActionDeallocateResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult BulkActionDeleteResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent BulkActionExecuteCreateContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload resourceConfigParameters = null, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent BulkActionExecuteDeallocateContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent BulkActionExecuteDeleteContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null, string correlationId = null, bool? isForceDeletion = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent BulkActionExecuteHibernateContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent BulkActionExecuteStartContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig BulkActionExecutionConfig(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference? optimizationPreference = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference?), Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent BulkActionGetOperationStatusContent(System.Collections.Generic.IEnumerable<string> operationIds = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult BulkActionGetOperationStatusResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult BulkActionHibernateResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails BulkActionResourceOperationDetails(string operationId = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType? opType = default(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType?), string subscriptionId = null, System.DateTimeOffset? deadlineOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType? deadlineType = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType?), Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState? state = default(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState?), string timezone = null, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError resourceOperationError = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError BulkActionResourceOperationError(string errorCode = null, string errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo BulkActionResourceOperationInfo(Azure.Core.ResourceIdentifier resourceId = null, string errorCode = null, string errorDetails = null, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails operation = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload BulkActionResourceProvisionPayload(System.Collections.Generic.IDictionary<string, System.BinaryData> baseProfile = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> resourceOverrides = null, int resourceCount = 0, string resourcePrefix = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy BulkActionRetryPolicy(int? retryCount = default(int?), int? retryWindowInMinutes = default(int?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult BulkActionStartResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult BulkActionVirtualMachineResult(string name = null, Azure.Core.ResourceIdentifier id = null, string type = null, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus operationStatus = default(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError error = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities ComputeBulkActionsAdditionalCapabilities(bool? isUltraSsdEnabled = default(bool?), bool? isHibernationEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent ComputeBulkActionsAdditionalUnattendContent(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentPassName? passName = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentPassName?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentComponentName? componentName = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentComponentName?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentSettingName? settingName = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentSettingName?), string content = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError ComputeBulkActionsApiError(string code = null, string target = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase> details = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError innerError = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase ComputeBulkActionsApiErrorBase(string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics ComputeBulkActionsBootDiagnostics(bool? isEnabled = default(bool?), string storageUri = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk ComputeBulkActionsDataDisk(int lun = 0, string name = null, string vhdUri = null, string imageUri = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType? caching = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType?), bool? isWriteAcceleratorEnabled = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType createOption = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType), int? diskSizeGB = default(int?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo managedDisk = null, Azure.Core.ResourceIdentifier sourceResourceId = null, bool? isToBeDetached = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDetachOptionType? detachOption = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDetachOptionType?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType? deleteOption = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings ComputeBulkActionsDiffDiskSettings(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskOption? option = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskOption?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement? placement = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSetReference ComputeBulkActionsDiskEncryptionSetReference(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings ComputeBulkActionsDiskEncryptionSettings(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference diskEncryptionKey = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference keyEncryptionKey = null, bool? isEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph ComputeBulkActionsEventGridAndResourceGraph(bool? isEnabled = default(bool?), string scheduledEventsApiVersion = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings ComputeBulkActionsHostEndpointSettings(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode? mode = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode?), Azure.Core.ResourceIdentifier inVMAccessControlProfileReferenceId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsImageReference ComputeBulkActionsImageReference(Azure.Core.ResourceIdentifier id = null, string publisher = null, string offer = null, string sku = null, string version = null, string sharedGalleryImageId = null, string communityGalleryImageId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError ComputeBulkActionsInnerError(string exceptionType = null, string errorDetail = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference ComputeBulkActionsKeyVaultKeyReference(string keyUri = null, Azure.Core.ResourceIdentifier sourceVaultId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference ComputeBulkActionsKeyVaultSecretReference(string secretUri = null, Azure.Core.ResourceIdentifier sourceVaultId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties ComputeBulkActionsLaunchBulkInstancesOperationProperties(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState? provisioningState = default(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState?), int capacity = 0, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType? capacityType = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile priorityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile> vmSizesProfile = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes vmAttributes = null, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile computeProfile = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy zoneAllocationPolicy = null, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration ComputeBulkActionsLinuxConfiguration(bool? isPasswordAuthenticationDisabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey> sshPublicKeys = null, bool? isVMAgentProvisioned = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings patchSettings = null, bool? isVMAgentPlatformUpdatesEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings ComputeBulkActionsLinuxPatchSettings(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchMode? patchMode = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchMode?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchAssessmentMode? assessmentMode = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchAssessmentMode?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings automaticByPlatformSettings = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting? rebootSetting = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting?), bool? isBypassPlatformSafetyChecksOnUserSchedule = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo ComputeBulkActionsManagedDiskInfo(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType? storageAccountType = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType?), Azure.Core.ResourceIdentifier diskEncryptionSetId = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile securityProfile = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference ComputeBulkActionsNetworkInterfaceReference(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties ComputeBulkActionsNetworkInterfaceReferenceProperties(bool? isPrimary = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption? deleteOption = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile ComputeBulkActionsNetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference> networkInterfaces = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion? networkApiVersion = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration> networkInterfaceConfigurations = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk ComputeBulkActionsOSDisk(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOperatingSystemType? osType = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOperatingSystemType?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings encryptionSettings = null, string name = null, string vhdUri = null, string imageUri = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType? caching = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType?), bool? isWriteAcceleratorEnabled = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings diffDiskSettings = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType createOption = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType), int? diskSizeGB = default(int?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo managedDisk = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType? deleteOption = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile ComputeBulkActionsOSImageNotificationProfile(string notBeforeTimeout = null, bool? isEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile ComputeBulkActionsOSProfile(string computerName = null, string adminUsername = null, string adminPassword = null, string customData = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration windowsConfiguration = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration linuxConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup> secrets = null, bool? isExtensionOperationsAllowed = default(bool?), bool? isGuestProvisionSignalRequired = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings ComputeBulkActionsPatchSettings(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode? patchMode = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode?), bool? isHotpatchingEnabled = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsPatchAssessmentMode? assessmentMode = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsPatchAssessmentMode?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings automaticByPlatformSettings = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile ComputeBulkActionsPriorityProfile(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineType? type = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineType?), float? maxPricePerVM = default(float?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEvictionPolicy? evictionPolicy = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEvictionPolicy?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy? allocationStrategy = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings ComputeBulkActionsProxyAgentSettings(bool? isEnabled = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentMode? mode = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentMode?), int? keyIncarnationId = default(int?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings wireServer = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings imds = null, bool? shouldAddProxyAgentExtension = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku ComputeBulkActionsPublicIPAddressSku(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuName? name = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuName?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuTier? tier = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuTier?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy ComputeBulkActionsScheduledEventsPolicy(bool? isRedeployAutomaticallyApproved = default(bool?), bool? isRebootAutomaticallyApproved = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph scheduledEventsAdditionalPublishingTargetsEventGridAndResourceGraph = null, bool? isAllInstancesDownAutomaticallyApproved = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile ComputeBulkActionsScheduledEventsProfile(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile terminateNotificationProfile = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile osImageNotificationProfile = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile ComputeBulkActionsSecurityProfile(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings uefiSettings = null, bool? isEncryptionAtHostEnabled = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType? securityType = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType?), Azure.Core.ResourceIdentifier userAssignedIdentityResourceId = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings proxyAgentSettings = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey ComputeBulkActionsSshPublicKey(string path = null, string keyData = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile ComputeBulkActionsStorageProfile(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsImageReference imageReference = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk osDisk = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk> dataDisks = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskControllerType? diskControllerType = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskControllerType?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource ComputeBulkActionsSubResource(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile ComputeBulkActionsTerminateNotificationProfile(string notBeforeTimeout = null, bool? isEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings ComputeBulkActionsUefiSettings(bool? isSecureBootEnabled = default(bool?), bool? isVTpmEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate ComputeBulkActionsVaultCertificate(string certificateUri = null, string certificateStore = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup ComputeBulkActionsVaultSecretGroup(Azure.Core.ResourceIdentifier sourceVaultId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate> vaultCertificates = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension ComputeBulkActionsVirtualMachineExtension(string name = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties ComputeBulkActionsVirtualMachineExtensionProperties(string forceUpdateTag = null, string publisher = null, string type = null, string typeHandlerVersion = null, bool? isAutoUpgradeMinorVersionEnabled = default(bool?), bool? isAutomaticUpgradeEnabled = default(bool?), System.Collections.Generic.IDictionary<string, System.BinaryData> settings = null, System.Collections.Generic.IDictionary<string, System.BinaryData> protectedSettings = null, bool? isSuppressFailures = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference protectedSettingsFromKeyVault = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag ComputeBulkActionsVirtualMachineIpTag(string ipTagType = null, string tag = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration(string name = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties(bool? isPrimary = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption? deleteOption = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption?), bool? isAcceleratedNetworkingEnabled = default(bool?), bool? isTcpStateTrackingDisabled = default(bool?), bool? isFpgaEnabled = default(bool?), bool? isIPForwardingEnabled = default(bool?), Azure.Core.ResourceIdentifier networkSecurityGroupId = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration> ipConfigurations = null, Azure.Core.ResourceIdentifier dscpConfigurationId = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode? auxiliaryMode = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku? auxiliarySku = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration(string name = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties(Azure.Core.ResourceIdentifier subnetId = null, bool? isPrimary = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration publicIPAddressConfiguration = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion? privateIPAddressVersion = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource> applicationSecurityGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource> applicationGatewayBackendAddressPools = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource> loadBalancerBackendAddressPools = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile ComputeBulkActionsVirtualMachineProfile(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy scheduledEventsPolicy = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile storageProfile = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities additionalCapabilities = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile osProfile = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile networkProfile = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile securityProfile = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics bootDiagnostics = null, string licenseType = null, string extensionsTimeBudget = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile scheduledEventsProfile = null, string userData = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication> galleryApplications = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration(string name = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties properties = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku sku = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties(int? idleTimeoutInMinutes = default(int?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption? deleteOption = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration dnsSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag> ipTags = null, Azure.Core.ResourceIdentifier publicIPPrefixId = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion? publicIPAddressVersion = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAllocationMethod? publicIPAllocationMethod = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAllocationMethod?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration(string domainNameLabel = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType? domainNameLabelScope = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble ComputeBulkActionsVMAttributeMinMaxDouble(double? min = default(double?), double? max = default(double?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger ComputeBulkActionsVMAttributeMinMaxInteger(int? min = default(int?), int? max = default(int?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes ComputeBulkActionsVMAttributes(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger vCpuCount = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble memoryInGiB = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsArchitectureType> architectureTypes = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble memoryInGiBPerVCpu = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport? localStorageSupport = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble localStorageInGiB = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLocalStorageDiskType> localStorageDiskTypes = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger dataDiskCount = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger networkInterfaceCount = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble networkBandwidthInMbps = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport? rdmaSupport = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger rdmaNetworkInterfaceCount = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport? acceleratorSupport = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorManufacturer> acceleratorManufacturers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorType> acceleratorTypes = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger acceleratorCount = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory> vmCategories = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer> cpuManufacturers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHyperVGeneration> hyperVGenerations = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport? burstableSupport = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport?), System.Collections.Generic.IEnumerable<string> allowedVMSizes = null, System.Collections.Generic.IEnumerable<string> excludedVMSizes = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile ComputeBulkActionsVMDiskSecurityProfile(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType? securityEncryptionType = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType?), Azure.Core.ResourceIdentifier diskEncryptionSetId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication ComputeBulkActionsVMGalleryApplication(string tags = null, int? order = default(int?), Azure.Core.ResourceIdentifier packageReferenceId = null, string configurationReference = null, bool? shouldTreatFailureAsDeploymentFailure = default(bool?), bool? isAutomaticUpgradeEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile ComputeBulkActionsVmSizeProfile(string name = null, int? rank = default(int?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration ComputeBulkActionsWindowsConfiguration(bool? isVMAgentProvisioned = default(bool?), bool? enableAutomaticUpdates = default(bool?), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent> additionalUnattendContent = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings patchSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener> winRMListeners = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting? rebootSetting = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting?), bool? isBypassPlatformSafetyChecksOnUserSchedule = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener ComputeBulkActionsWinRMListener(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType? protocol = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType?), string certificateUri = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy ComputeBulkActionsZoneAllocationPolicy(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy distributionStrategy = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference> zonePreferences = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference ComputeBulkActionsZonePreference(string zone = null, int? rank = default(int?)) { throw null; }
    }
    public partial class BulkActionCancelOperationsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent>
    {
        public BulkActionCancelOperationsContent(System.Collections.Generic.IEnumerable<string> operationIds, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public System.Collections.Generic.IList<string> OperationIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionCancelOperationsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult>
    {
        internal BulkActionCancelOperationsResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCancelOperationsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionComputeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile>
    {
        public BulkActionComputeProfile(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile virtualMachineProfile) { }
        public string ComputeApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension> Extensions { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile VirtualMachineProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionCreateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult>
    {
        internal BulkActionCreateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionCreateResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionDeallocateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult>
    {
        internal BulkActionDeallocateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeallocateResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionDeleteResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult>
    {
        internal BulkActionDeleteResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionDeleteResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionExecuteCreateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent>
    {
        public BulkActionExecuteCreateContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload resourceConfigParameters, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters) { }
        public string CorrelationId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig ExecutionParameters { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload ResourceConfigParameters { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteCreateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionExecuteDeallocateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent>
    {
        public BulkActionExecuteDeallocateContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig ExecutionParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeallocateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionExecuteDeleteContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent>
    {
        public BulkActionExecuteDeleteContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig ExecutionParameters { get { throw null; } }
        public bool? IsForceDeletion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteDeleteContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionExecuteHibernateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent>
    {
        public BulkActionExecuteHibernateContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig ExecutionParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteHibernateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionExecuteStartContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent>
    {
        public BulkActionExecuteStartContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig ExecutionParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecuteStartContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionExecutionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig>
    {
        public BulkActionExecutionConfig() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference? OptimizationPreference { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy RetryPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionGetOperationStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent>
    {
        public BulkActionGetOperationStatusContent(System.Collections.Generic.IEnumerable<string> operationIds, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public System.Collections.Generic.IList<string> OperationIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionGetOperationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult>
    {
        internal BulkActionGetOperationStatusResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionGetOperationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionHibernateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult>
    {
        internal BulkActionHibernateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionHibernateResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BulkActionOperationState : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BulkActionOperationState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState Blocked { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState Executing { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState PendingExecution { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState PendingScheduling { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState Scheduled { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState left, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState left, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BulkActionProvisioningState : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BulkActionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState left, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState left, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BulkActionResourceOperationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails>
    {
        internal BulkActionResourceOperationDetails() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public System.DateTimeOffset? DeadlineOn { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType? DeadlineType { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType? OpType { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError ResourceOperationError { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy RetryPolicy { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState? State { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string Timezone { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionResourceOperationError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError>
    {
        internal BulkActionResourceOperationError() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionResourceOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo>
    {
        internal BulkActionResourceOperationInfo() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationDetails Operation { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BulkActionResourceOperationType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BulkActionResourceOperationType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType Create { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType Delete { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType Hibernate { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType Start { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType left, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType left, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BulkActionResourceProvisionPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload>
    {
        public BulkActionResourceProvisionPayload(int resourceCount) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> BaseProfile { get { throw null; } }
        public int ResourceCount { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> ResourceOverrides { get { throw null; } }
        public string ResourcePrefix { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceProvisionPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionRetryPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy>
    {
        public BulkActionRetryPolicy() { }
        public int? RetryCount { get { throw null; } set { } }
        public int? RetryWindowInMinutes { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionStartResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult>
    {
        internal BulkActionStartResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionStartResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkActionVirtualMachineResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult>
    {
        internal BulkActionVirtualMachineResult() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus OperationStatus { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BulkActionVMOperationStatus : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BulkActionVMOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus CancelFailedStatusUnknown { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus Cancelling { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus left, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus left, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVMOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsAcceleratorManufacturer : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorManufacturer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsAcceleratorManufacturer(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorManufacturer AMD { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorManufacturer Nvidia { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorManufacturer Xilinx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorManufacturer other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorManufacturer left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorManufacturer right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorManufacturer (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorManufacturer? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorManufacturer left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorManufacturer right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsAcceleratorType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsAcceleratorType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorType Fpga { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorType Gpu { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsAdditionalCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities>
    {
        public ComputeBulkActionsAdditionalCapabilities() { }
        public bool? IsHibernationEnabled { get { throw null; } set { } }
        public bool? IsUltraSsdEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsAdditionalUnattendContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent>
    {
        public ComputeBulkActionsAdditionalUnattendContent() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentComponentName? ComponentName { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentPassName? PassName { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentSettingName? SettingName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsAdditionalUnattendContentComponentName : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentComponentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsAdditionalUnattendContentComponentName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentComponentName MicrosoftWindowsShellSetup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentComponentName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentComponentName left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentComponentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentComponentName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentComponentName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentComponentName left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentComponentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsAdditionalUnattendContentPassName : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentPassName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsAdditionalUnattendContentPassName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentPassName OobeSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentPassName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentPassName left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentPassName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentPassName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentPassName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentPassName left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentPassName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsAdditionalUnattendContentSettingName : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentSettingName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsAdditionalUnattendContentSettingName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentSettingName AutoLogon { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentSettingName FirstLogonCommands { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentSettingName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentSettingName left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentSettingName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentSettingName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentSettingName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentSettingName left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContentSettingName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsAllocationStrategy : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsAllocationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy CapacityOptimized { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy LowestPrice { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy Prioritized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsApiError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError>
    {
        internal ComputeBulkActionsApiError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase> Details { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsApiErrorBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase>
    {
        internal ComputeBulkActionsApiErrorBase() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsArchitectureType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsArchitectureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsArchitectureType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsArchitectureType ARM64 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsArchitectureType X64 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsArchitectureType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsArchitectureType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsArchitectureType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsArchitectureType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsArchitectureType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsArchitectureType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsArchitectureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsBootDiagnostics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics>
    {
        public ComputeBulkActionsBootDiagnostics() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string StorageUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsCachingType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsCachingType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType None { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsCapacityType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsCapacityType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType VCpu { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType VM { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsCpuManufacturer : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsCpuManufacturer(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer AMD { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer Ampere { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer Intel { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer Microsoft { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk>
    {
        public ComputeBulkActionsDataDisk(int lun, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType createOption) { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDetachOptionType? DetachOption { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public string ImageUri { get { throw null; } set { } }
        public bool? IsToBeDetached { get { throw null; } set { } }
        public bool? IsWriteAcceleratorEnabled { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public string VhdUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsDeadlineType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsDeadlineType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType CompleteBy { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType InitiateAt { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsDeleteOption : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsDeleteOption(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption Delete { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsDiffDiskOption : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsDiffDiskOption(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskOption Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskOption other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskOption left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskOption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskOption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskOption left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsDiffDiskPlacement : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsDiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement CacheDisk { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement NvmeDisk { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement ResourceDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsDiffDiskSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings>
    {
        public ComputeBulkActionsDiffDiskSettings() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskOption? Option { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskPlacement? Placement { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsDiskControllerType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskControllerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsDiskControllerType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskControllerType NVMe { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskControllerType SCSI { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskControllerType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskControllerType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskControllerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskControllerType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskControllerType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskControllerType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskControllerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsDiskCreateOptionType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsDiskCreateOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType Attach { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType Copy { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType Empty { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType FromImage { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType Restore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsDiskDeleteOptionType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsDiskDeleteOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType Delete { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsDiskDetachOptionType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDetachOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsDiskDetachOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDetachOptionType ForceDetach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDetachOptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDetachOptionType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDetachOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDetachOptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDetachOptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDetachOptionType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDetachOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsDiskEncryptionSetReference : Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSetReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSetReference>
    {
        public ComputeBulkActionsDiskEncryptionSetReference() { }
        protected override Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSetReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSetReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSetReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSetReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSetReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSetReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSetReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsDiskEncryptionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings>
    {
        public ComputeBulkActionsDiskEncryptionSettings() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference DiskEncryptionKey { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference KeyEncryptionKey { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsDomainNameLabelScopeType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsDomainNameLabelScopeType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType NoReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsEventGridAndResourceGraph : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph>
    {
        public ComputeBulkActionsEventGridAndResourceGraph() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string ScheduledEventsApiVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsEvictionPolicy : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEvictionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsEvictionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEvictionPolicy Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEvictionPolicy Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEvictionPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEvictionPolicy left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEvictionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEvictionPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEvictionPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEvictionPolicy left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEvictionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsHostEndpointMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsHostEndpointMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode Audit { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode Enforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsHostEndpointSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings>
    {
        public ComputeBulkActionsHostEndpointSettings() { }
        public Azure.Core.ResourceIdentifier InVMAccessControlProfileReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointMode? Mode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsHyperVGeneration : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHyperVGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsHyperVGeneration(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHyperVGeneration Gen1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHyperVGeneration Gen2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHyperVGeneration other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHyperVGeneration left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHyperVGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHyperVGeneration (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHyperVGeneration? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHyperVGeneration left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHyperVGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsImageReference : Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsImageReference>
    {
        public ComputeBulkActionsImageReference() { }
        public string CommunityGalleryImageId { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string SharedGalleryImageId { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsInnerError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError>
    {
        internal ComputeBulkActionsInnerError() { }
        public string ErrorDetail { get { throw null; } }
        public string ExceptionType { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsIPVersion : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsIPVersion(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsKeyVaultKeyReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference>
    {
        public ComputeBulkActionsKeyVaultKeyReference(string keyUri) { }
        public string KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultKeyReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsKeyVaultSecretReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference>
    {
        public ComputeBulkActionsKeyVaultSecretReference(string secretUri) { }
        public string SecretUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsLaunchBulkInstancesOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties>
    {
        public ComputeBulkActionsLaunchBulkInstancesOperationProperties(int capacity, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile priorityProfile, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile computeProfile) { }
        public int Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType? CapacityType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionComputeProfile ComputeProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile PriorityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy RetryPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes VmAttributes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile> VmSizesProfile { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy ZoneAllocationPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLaunchBulkInstancesOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsLinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration>
    {
        public ComputeBulkActionsLinuxConfiguration() { }
        public bool? IsPasswordAuthenticationDisabled { get { throw null; } set { } }
        public bool? IsVMAgentPlatformUpdatesEnabled { get { throw null; } set { } }
        public bool? IsVMAgentProvisioned { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings PatchSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey> SshPublicKeys { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsLinuxPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsLinuxPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchAssessmentMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchAssessmentMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchAssessmentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchAssessmentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchAssessmentMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsLinuxPatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings>
    {
        public ComputeBulkActionsLinuxPatchSettings() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchMode? PatchMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxPatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings>
    {
        public ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings() { }
        public bool? IsBypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsLinuxVMGuestPatchMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsLinuxVMGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxVMGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsLocalStorageDiskType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLocalStorageDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsLocalStorageDiskType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLocalStorageDiskType Hdd { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLocalStorageDiskType Ssd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLocalStorageDiskType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLocalStorageDiskType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLocalStorageDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLocalStorageDiskType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLocalStorageDiskType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLocalStorageDiskType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLocalStorageDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsManagedDiskInfo : Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo>
    {
        public ComputeBulkActionsManagedDiskInfo() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType? StorageAccountType { get { throw null; } set { } }
        protected override Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsNetworkApiVersion : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsNetworkApiVersion(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion _20201101 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion _20221101 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsNetworkInterfaceAuxiliaryMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsNetworkInterfaceAuxiliaryMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode AcceleratedConnections { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode Floating { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsNetworkInterfaceAuxiliarySku : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsNetworkInterfaceAuxiliarySku(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku A1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku A2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku A4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku A8 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsNetworkInterfaceReference : Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference>
    {
        public ComputeBulkActionsNetworkInterfaceReference() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties Properties { get { throw null; } set { } }
        protected override Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsNetworkInterfaceReferenceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties>
    {
        public ComputeBulkActionsNetworkInterfaceReferenceProperties() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption? DeleteOption { get { throw null; } set { } }
        public bool? IsPrimary { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReferenceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile>
    {
        public ComputeBulkActionsNetworkProfile() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference> NetworkInterfaces { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsOperatingSystemType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsOperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOperatingSystemType Linux { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOperatingSystemType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOperatingSystemType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOperatingSystemType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOperatingSystemType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOperatingSystemType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOperatingSystemType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOperatingSystemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsOptimizationPreference : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsOptimizationPreference(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference Availability { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference Cost { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference CostAvailabilityBalanced { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOptimizationPreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk>
    {
        public ComputeBulkActionsOSDisk(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType createOption) { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskEncryptionSettings EncryptionSettings { get { throw null; } set { } }
        public string ImageUri { get { throw null; } set { } }
        public bool? IsWriteAcceleratorEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsManagedDiskInfo ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOperatingSystemType? OsType { get { throw null; } set { } }
        public string VhdUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsOSImageNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile>
    {
        public ComputeBulkActionsOSImageNotificationProfile() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile>
    {
        public ComputeBulkActionsOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        public bool? IsExtensionOperationsAllowed { get { throw null; } set { } }
        public bool? IsGuestProvisionSignalRequired { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsPatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings>
    {
        public ComputeBulkActionsPatchSettings() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public bool? IsHotpatchingEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode? PatchMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsPriorityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile>
    {
        public ComputeBulkActionsPriorityProfile() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAllocationStrategy? AllocationStrategy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEvictionPolicy? EvictionPolicy { get { throw null; } set { } }
        public float? MaxPricePerVM { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsProtocolType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsProtocolType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType Http { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType Https { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsProxyAgentMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsProxyAgentMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentMode Audit { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentMode Enforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsProxyAgentSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings>
    {
        public ComputeBulkActionsProxyAgentSettings() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings Imds { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? KeyIncarnationId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentMode? Mode { get { throw null; } set { } }
        public bool? ShouldAddProxyAgentExtension { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHostEndpointSettings WireServer { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsPublicIPAddressSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku>
    {
        public ComputeBulkActionsPublicIPAddressSku() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsPublicIPAddressSkuName : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsPublicIPAddressSkuName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuName left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuName left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsPublicIPAddressSkuTier : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsPublicIPAddressSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuTier Global { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuTier Regional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuTier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuTier left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuTier left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsPublicIPAllocationMethod : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsPublicIPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAllocationMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAllocationMethod left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAllocationMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAllocationMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAllocationMethod left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsScheduledEventsPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy>
    {
        public ComputeBulkActionsScheduledEventsPolicy() { }
        public bool? IsAllInstancesDownAutomaticallyApproved { get { throw null; } set { } }
        public bool? IsRebootAutomaticallyApproved { get { throw null; } set { } }
        public bool? IsRedeployAutomaticallyApproved { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsEventGridAndResourceGraph ScheduledEventsAdditionalPublishingTargetsEventGridAndResourceGraph { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsScheduledEventsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile>
    {
        public ComputeBulkActionsScheduledEventsProfile() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSImageNotificationProfile OsImageNotificationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile TerminateNotificationProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsSecurityEncryptionType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsSecurityEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType DiskWithVMGuestState { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType NonPersistedTPM { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType VMGuestStateOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile>
    {
        public ComputeBulkActionsSecurityProfile() { }
        public bool? IsEncryptionAtHostEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProxyAgentSettings ProxyAgentSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType? SecurityType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings UefiSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsSecurityType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsSecurityType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType ConfidentialVM { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsSshPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey>
    {
        public ComputeBulkActionsSshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSshPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsStorageAccountType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType PremiumV2LRS { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType PremiumZRS { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType StandardSSDLRS { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType StandardSSDZRS { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType UltraSSDLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile>
    {
        public ComputeBulkActionsStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDiskControllerType? DiskControllerType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk OsDisk { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsSubResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource>
    {
        public ComputeBulkActionsSubResource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsTerminateNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile>
    {
        public ComputeBulkActionsTerminateNotificationProfile() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsTerminateNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsUefiSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings>
    {
        public ComputeBulkActionsUefiSettings() { }
        public bool? IsSecureBootEnabled { get { throw null; } set { } }
        public bool? IsVTpmEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsUefiSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVaultCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate>
    {
        public ComputeBulkActionsVaultCertificate() { }
        public string CertificateStore { get { throw null; } set { } }
        public string CertificateUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVaultSecretGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup>
    {
        public ComputeBulkActionsVaultSecretGroup() { }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultCertificate> VaultCertificates { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVaultSecretGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVirtualMachineExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension>
    {
        public ComputeBulkActionsVirtualMachineExtension(string name, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties properties) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVirtualMachineExtensionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties>
    {
        public ComputeBulkActionsVirtualMachineExtensionProperties() { }
        public string ForceUpdateTag { get { throw null; } set { } }
        public bool? IsAutomaticUpgradeEnabled { get { throw null; } set { } }
        public bool? IsAutoUpgradeMinorVersionEnabled { get { throw null; } set { } }
        public bool? IsSuppressFailures { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ProtectedSettings { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsKeyVaultSecretReference ProtectedSettingsFromKeyVault { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public string Type { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVirtualMachineIpTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag>
    {
        public ComputeBulkActionsVirtualMachineIpTag() { }
        public string IpTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration>
    {
        public ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties>
    {
        public ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration> ipConfigurations) { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliaryMode? AuxiliaryMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceAuxiliarySku? AuxiliarySku { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption? DeleteOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.Core.ResourceIdentifier DscpConfigurationId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration> IpConfigurations { get { throw null; } }
        public bool? IsAcceleratedNetworkingEnabled { get { throw null; } set { } }
        public bool? IsFpgaEnabled { get { throw null; } set { } }
        public bool? IsIPForwardingEnabled { get { throw null; } set { } }
        public bool? IsPrimary { get { throw null; } set { } }
        public bool? IsTcpStateTrackingDisabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration>
    {
        public ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties>
    {
        public ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource> ApplicationSecurityGroups { get { throw null; } }
        public bool? IsPrimary { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineNetworkInterfaceIPConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVirtualMachineProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile>
    {
        public ComputeBulkActionsVirtualMachineProfile() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication> GalleryApplications { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration>
    {
        public ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAddressSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties>
    {
        public ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineIpTag> IpTags { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPublicIPAllocationMethod? PublicIPAllocationMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration>
    {
        public ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration(string domainNameLabel) { }
        public string DomainNameLabel { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDomainNameLabelScopeType? DomainNameLabelScope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachinePublicIPAddressDnsSettingsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsVirtualMachineType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsVirtualMachineType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineType Regular { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineType Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineType left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsVMAttributeMinMaxDouble : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble>
    {
        public ComputeBulkActionsVMAttributeMinMaxDouble() { }
        public double? Max { get { throw null; } set { } }
        public double? Min { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVMAttributeMinMaxInteger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger>
    {
        public ComputeBulkActionsVMAttributeMinMaxInteger() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVMAttributes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes>
    {
        public ComputeBulkActionsVMAttributes(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger vCpuCount, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble memoryInGiB, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsArchitectureType> architectureTypes) { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger AcceleratorCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorManufacturer> AcceleratorManufacturers { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport? AcceleratorSupport { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAcceleratorType> AcceleratorTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedVMSizes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsArchitectureType> ArchitectureTypes { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport? BurstableSupport { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCpuManufacturer> CpuManufacturers { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger DataDiskCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedVMSizes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsHyperVGeneration> HyperVGenerations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLocalStorageDiskType> LocalStorageDiskTypes { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble LocalStorageInGiB { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport? LocalStorageSupport { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble MemoryInGiB { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble MemoryInGiBPerVCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxDouble NetworkBandwidthInMbps { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger NetworkInterfaceCount { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger RdmaNetworkInterfaceCount { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport? RdmaSupport { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeMinMaxInteger VCpuCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory> VmCategories { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsVMAttributeSupport : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsVMAttributeSupport(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport Excluded { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport Included { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMAttributeSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsVMCategory : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsVMCategory(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory ComputeOptimized { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory FpgaAccelerated { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory GpuAccelerated { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory HighPerformanceCompute { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory MemoryOptimized { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory StorageOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsVMDiskSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile>
    {
        public ComputeBulkActionsVMDiskSecurityProfile() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityEncryptionType? SecurityEncryptionType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMDiskSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVMGalleryApplication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication>
    {
        public ComputeBulkActionsVMGalleryApplication(Azure.Core.ResourceIdentifier packageReferenceId) { }
        public string ConfigurationReference { get { throw null; } set { } }
        public bool? IsAutomaticUpgradeEnabled { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PackageReferenceId { get { throw null; } set { } }
        public bool? ShouldTreatFailureAsDeploymentFailure { get { throw null; } set { } }
        public string Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVMGalleryApplication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsVmSizeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile>
    {
        public ComputeBulkActionsVmSizeProfile(string name) { }
        public string Name { get { throw null; } set { } }
        public int? Rank { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVmSizeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsWindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration>
    {
        public ComputeBulkActionsWindowsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalUnattendContent> AdditionalUnattendContent { get { throw null; } }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public bool? IsVMAgentProvisioned { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings PatchSettings { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener> WinRMListeners { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsWindowsPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsWindowsPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsPatchAssessmentMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsPatchAssessmentMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsPatchAssessmentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsPatchAssessmentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsPatchAssessmentMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings>
    {
        public ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings() { }
        public bool? IsBypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsWindowsVMGuestPatchMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsWindowsVMGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode AutomaticByOS { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsVMGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsWinRMListener : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener>
    {
        public ComputeBulkActionsWinRMListener() { }
        public string CertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType? Protocol { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWinRMListener>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeBulkActionsZoneAllocationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy>
    {
        public ComputeBulkActionsZoneAllocationPolicy(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy distributionStrategy) { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy DistributionStrategy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference> ZonePreferences { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneAllocationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeBulkActionsZoneDistributionStrategy : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeBulkActionsZoneDistributionStrategy(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy BestEffortBalanced { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy BestEffortSingleZone { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy Prioritized { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy StrictBalanced { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy left, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZoneDistributionStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeBulkActionsZonePreference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference>
    {
        public ComputeBulkActionsZonePreference(string zone) { }
        public int? Rank { get { throw null; } set { } }
        public string Zone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
