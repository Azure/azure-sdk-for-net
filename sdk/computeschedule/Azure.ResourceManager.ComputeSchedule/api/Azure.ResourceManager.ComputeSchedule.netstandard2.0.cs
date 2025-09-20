namespace Azure.ResourceManager.ComputeSchedule
{
    public partial class AzureResourceManagerComputeScheduleContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerComputeScheduleContext() { }
        public static Azure.ResourceManager.ComputeSchedule.AzureResourceManagerComputeScheduleContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ComputeScheduleExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult> CancelVirtualMachineOperations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult> CancelVirtualMachineOperations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult>> CancelVirtualMachineOperationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult>> CancelVirtualMachineOperationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult> ExecuteVirtualMachineCreateOperation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult>> ExecuteVirtualMachineCreateOperationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult> ExecuteVirtualMachineDeallocate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult> ExecuteVirtualMachineDeallocate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>> ExecuteVirtualMachineDeallocateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>> ExecuteVirtualMachineDeallocateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult> ExecuteVirtualMachineDeleteOperation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult>> ExecuteVirtualMachineDeleteOperationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult> ExecuteVirtualMachineHibernate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult> ExecuteVirtualMachineHibernate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>> ExecuteVirtualMachineHibernateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>> ExecuteVirtualMachineHibernateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult> ExecuteVirtualMachineStart(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult> ExecuteVirtualMachineStart(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>> ExecuteVirtualMachineStartAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>> ExecuteVirtualMachineStartAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData> GetAssociatedOccurrences(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData> GetAssociatedOccurrencesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources> GetAssociatedScheduledActions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources> GetAssociatedScheduledActionsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> GetScheduledAction(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>> GetScheduledActionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource GetScheduledActionOccurrenceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.ScheduledActionResource GetScheduledActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.ScheduledActionCollection GetScheduledActions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> GetScheduledActions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> GetScheduledActionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult> GetVirtualMachineOperationErrors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult> GetVirtualMachineOperationErrors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult>> GetVirtualMachineOperationErrorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult>> GetVirtualMachineOperationErrorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult> GetVirtualMachineOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult> GetVirtualMachineOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult>> GetVirtualMachineOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult>> GetVirtualMachineOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult> SubmitVirtualMachineDeallocate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult> SubmitVirtualMachineDeallocate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>> SubmitVirtualMachineDeallocateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>> SubmitVirtualMachineDeallocateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult> SubmitVirtualMachineHibernate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult> SubmitVirtualMachineHibernate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>> SubmitVirtualMachineHibernateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>> SubmitVirtualMachineHibernateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult> SubmitVirtualMachineStart(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult> SubmitVirtualMachineStart(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>> SubmitVirtualMachineStartAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>> SubmitVirtualMachineStartAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScheduledActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>, System.Collections.IEnumerable
    {
        protected ScheduledActionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scheduledActionName, Azure.ResourceManager.ComputeSchedule.ScheduledActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scheduledActionName, Azure.ResourceManager.ComputeSchedule.ScheduledActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> Get(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>> GetAsync(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> GetIfExists(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>> GetIfExistsAsync(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScheduledActionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>
    {
        public ScheduledActionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.ScheduledActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.ScheduledActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionOccurrenceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource>, System.Collections.IEnumerable
    {
        protected ScheduledActionOccurrenceCollection() { }
        public virtual Azure.Response<bool> Exists(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource> Get(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource>> GetAsync(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource> GetIfExists(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource>> GetIfExistsAsync(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScheduledActionOccurrenceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>
    {
        internal ScheduledActionOccurrenceData() { }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionOccurrenceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScheduledActionOccurrenceResource() { }
        public virtual Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult> Cancel(Azure.ResourceManager.ComputeSchedule.Models.OccurrenceCancelContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult>> CancelAsync(Azure.ResourceManager.ComputeSchedule.Models.OccurrenceCancelContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scheduledActionName, string occurrenceId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult> Delay(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeSchedule.Models.OccurrenceDelayContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult>> DelayAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeSchedule.Models.OccurrenceDelayContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceData> GetAttachedResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceData> GetAttachedResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScheduledActionResource() { }
        public virtual Azure.ResourceManager.ComputeSchedule.ScheduledActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult> AttachResources(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceAttachContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult>> AttachResourcesAsync(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceAttachContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult> CancelNextOccurrence(Azure.ResourceManager.ComputeSchedule.Models.OccurrenceCancelContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult>> CancelNextOccurrenceAsync(Azure.ResourceManager.ComputeSchedule.Models.OccurrenceCancelContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scheduledActionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult> DetachResources(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceDetachContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult>> DetachResourcesAsync(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceDetachContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Disable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Enable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData> GetAttachedResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData> GetAttachedResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource> GetScheduledActionOccurrence(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource>> GetScheduledActionOccurrenceAsync(string occurrenceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceCollection GetScheduledActionOccurrences() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult> PatchResources(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourcePatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult>> PatchResourcesAsync(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourcePatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeSchedule.ScheduledActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.ScheduledActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.ScheduledActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource> TriggerManualOccurrence(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource>> TriggerManualOccurrenceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> Update(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>> UpdateAsync(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeSchedule.Mocking
{
    public partial class MockableComputeScheduleArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeScheduleArmClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData> GetAssociatedOccurrences(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData> GetAssociatedOccurrencesAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources> GetAssociatedScheduledActions(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources> GetAssociatedScheduledActionsAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceResource GetScheduledActionOccurrenceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeSchedule.ScheduledActionResource GetScheduledActionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeScheduleResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeScheduleResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> GetScheduledAction(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource>> GetScheduledActionAsync(string scheduledActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeSchedule.ScheduledActionCollection GetScheduledActions() { throw null; }
    }
    public partial class MockableComputeScheduleSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeScheduleSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult> CancelVirtualMachineOperations(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult> CancelVirtualMachineOperations(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult>> CancelVirtualMachineOperationsAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult>> CancelVirtualMachineOperationsAsync(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult> ExecuteVirtualMachineCreateOperation(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult>> ExecuteVirtualMachineCreateOperationAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult> ExecuteVirtualMachineDeallocate(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult> ExecuteVirtualMachineDeallocate(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>> ExecuteVirtualMachineDeallocateAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>> ExecuteVirtualMachineDeallocateAsync(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult> ExecuteVirtualMachineDeleteOperation(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult>> ExecuteVirtualMachineDeleteOperationAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult> ExecuteVirtualMachineHibernate(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult> ExecuteVirtualMachineHibernate(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>> ExecuteVirtualMachineHibernateAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>> ExecuteVirtualMachineHibernateAsync(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult> ExecuteVirtualMachineStart(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult> ExecuteVirtualMachineStart(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>> ExecuteVirtualMachineStartAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>> ExecuteVirtualMachineStartAsync(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> GetScheduledActions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeSchedule.ScheduledActionResource> GetScheduledActionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult> GetVirtualMachineOperationErrors(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult> GetVirtualMachineOperationErrors(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult>> GetVirtualMachineOperationErrorsAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult>> GetVirtualMachineOperationErrorsAsync(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult> GetVirtualMachineOperationStatus(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult> GetVirtualMachineOperationStatus(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult>> GetVirtualMachineOperationStatusAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult>> GetVirtualMachineOperationStatusAsync(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult> SubmitVirtualMachineDeallocate(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult> SubmitVirtualMachineDeallocate(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>> SubmitVirtualMachineDeallocateAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>> SubmitVirtualMachineDeallocateAsync(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult> SubmitVirtualMachineHibernate(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult> SubmitVirtualMachineHibernate(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>> SubmitVirtualMachineHibernateAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>> SubmitVirtualMachineHibernateAsync(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult> SubmitVirtualMachineStart(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult> SubmitVirtualMachineStart(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>> SubmitVirtualMachineStartAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>> SubmitVirtualMachineStartAsync(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeSchedule.Models
{
    public static partial class ArmComputeScheduleModelFactory
    {
        public static Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult CancelOperationsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult CreateResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult DeallocateResourceOperationResult(string description = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult DeleteResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent ExecuteCreateContent(Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload resourceConfigParameters = null, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail executionParameters = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent ExecuteDeleteContent(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail executionParameters = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null, string correlationId = null, bool? isForceDeletion = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult GetOperationErrorsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult GetOperationStatusResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult HibernateResourceOperationResult(string description = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionProperties OccurrenceExtensionProperties(Azure.Core.ResourceIdentifier resourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> notificationSettings = null, System.DateTimeOffset scheduledOn = default(System.DateTimeOffset), Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState? provisioningState = default(Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState?), Azure.ResponseError errorDetails = null, Azure.Core.ResourceIdentifier scheduledActionId = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData OccurrenceExtensionResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceData OccurrenceResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier resourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> notificationSettings = null, System.DateTimeOffset scheduledOn = default(System.DateTimeOffset), Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState? provisioningState = default(Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResultSummary OccurrenceResultSummary(int total = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ResourceResultSummary> statuses = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails OperationErrorDetails(string errorCode = null, string errorDetails = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.DateTimeOffset? errorDetailsTimestamp = default(System.DateTimeOffset?), string azureOperationName = null, string crpOperationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult OperationErrorsResult(string operationId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? activationOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails> operationErrors = null, string requestErrorCode = null, string requestErrorDetails = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails ResourceOperationDetails(string operationId = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType? opType = default(Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType?), string subscriptionId = null, System.DateTimeOffset? deadline = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType? deadlineType = default(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType?), Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState? state = default(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState?), string timezone = null, string operationTimezone = null, Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError resourceOperationError = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeSchedule.Models.UserRequestRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError ResourceOperationError(string errorCode = null, string errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult ResourceOperationResult(Azure.Core.ResourceIdentifier resourceId = null, string errorCode = null, string errorDetails = null, Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails operation = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload ResourceProvisionPayload(System.Collections.Generic.IDictionary<string, System.BinaryData> baseProfile = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> resourceOverrides = null, int resourceCount = 0, string resourcePrefix = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ResourceResultSummary ResourceResultSummary(string code = null, int count = 0, Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.ScheduledActionData ScheduledActionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.ScheduledActionOccurrenceData ScheduledActionOccurrenceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceProperties ScheduledActionOccurrenceProperties(System.DateTimeOffset scheduledOn = default(System.DateTimeOffset), Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResultSummary resultSummary = null, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState? provisioningState = default(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState?)) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionProperties ScheduledActionProperties(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType resourceType = default(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType), Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType actionType = default(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType), System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule schedule = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> notificationSettings = null, bool? disabled = default(bool?), Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState? provisioningState = default(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData ScheduledActionResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier resourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> notificationSettings = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult ScheduledActionResourceOperationResult(int totalResources = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceStatus> resourcesStatuses = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources ScheduledActionResources(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceStatus ScheduledActionResourceStatus(Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationStatus status = default(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationStatus), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsExtensionProperties ScheduledActionsExtensionProperties(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType resourceType = default(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType), Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType actionType = default(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType), System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule schedule = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> notificationSettings = null, bool? disabled = default(bool?), Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState? provisioningState = default(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> resourceNotificationSettings = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult StartResourceOperationResult(string description = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule UserRequestSchedule(System.DateTimeOffset? deadline = default(System.DateTimeOffset?), System.DateTimeOffset? userRequestDeadline = default(System.DateTimeOffset?), string timezone = null, string userRequestTimezone = null, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType deadlineType = default(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType)) { throw null; }
    }
    public partial class CancelOperationsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent>
    {
        public CancelOperationsContent(System.Collections.Generic.IEnumerable<string> operationIds, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public System.Collections.Generic.IList<string> OperationIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CancelOperationsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult>
    {
        internal CancelOperationsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult>
    {
        internal CreateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> Results { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeallocateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>
    {
        internal DeallocateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeleteResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult>
    {
        internal DeleteResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> Results { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteCreateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent>
    {
        public ExecuteCreateContent(Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload resourceConfigParameters, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail executionParameters) { }
        public string CorrelationId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload ResourceConfigParameters { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteDeallocateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent>
    {
        public ExecuteDeallocateContent(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail executionParameters, Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources resources, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteDeleteContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent>
    {
        public ExecuteDeleteContent(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail executionParameters, Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources resources) { }
        public string CorrelationId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public bool? IsForceDeletion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteHibernateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent>
    {
        public ExecuteHibernateContent(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail executionParameters, Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources resources, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteHibernateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteStartContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent>
    {
        public ExecuteStartContent(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail executionParameters, Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources resources, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ExecuteStartContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetOperationErrorsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent>
    {
        public GetOperationErrorsContent(System.Collections.Generic.IEnumerable<string> operationIds) { }
        public System.Collections.Generic.IList<string> OperationIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetOperationErrorsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult>
    {
        internal GetOperationErrorsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult> Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetOperationStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent>
    {
        public GetOperationStatusContent(System.Collections.Generic.IEnumerable<string> operationIds, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public System.Collections.Generic.IList<string> OperationIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetOperationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult>
    {
        internal GetOperationStatusResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HibernateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>
    {
        internal HibernateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationLanguage : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.NotificationLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationLanguage(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.NotificationLanguage EnUs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.NotificationLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.NotificationLanguage left, Azure.ResourceManager.ComputeSchedule.Models.NotificationLanguage right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.NotificationLanguage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.NotificationLanguage left, Azure.ResourceManager.ComputeSchedule.Models.NotificationLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotificationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings>
    {
        public NotificationSettings(string destination, Azure.ResourceManager.ComputeSchedule.Models.NotificationType type, Azure.ResourceManager.ComputeSchedule.Models.NotificationLanguage language) { }
        public string Destination { get { throw null; } set { } }
        public bool? IsDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeSchedule.Models.NotificationLanguage Language { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeSchedule.Models.NotificationType Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationType : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.NotificationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.NotificationType Email { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.NotificationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.NotificationType left, Azure.ResourceManager.ComputeSchedule.Models.NotificationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.NotificationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.NotificationType left, Azure.ResourceManager.ComputeSchedule.Models.NotificationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OccurrenceCancelContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceCancelContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceCancelContent>
    {
        public OccurrenceCancelContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OccurrenceCancelContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceCancelContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceCancelContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OccurrenceCancelContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceCancelContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceCancelContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceCancelContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OccurrenceDelayContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceDelayContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceDelayContent>
    {
        public OccurrenceDelayContent(System.DateTimeOffset delay, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds) { }
        public System.DateTimeOffset Delay { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OccurrenceDelayContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceDelayContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceDelayContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OccurrenceDelayContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceDelayContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceDelayContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceDelayContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OccurrenceExtensionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionProperties>
    {
        internal OccurrenceExtensionProperties() { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> NotificationSettings { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ScheduledActionId { get { throw null; } }
        public System.DateTimeOffset ScheduledOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OccurrenceExtensionResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData>
    {
        internal OccurrenceExtensionResourceData() { }
        public Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceExtensionResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OccurrenceResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceData>
    {
        internal OccurrenceResourceData() { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> NotificationSettings { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.DateTimeOffset ScheduledOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OccurrenceResourceProvisioningState : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OccurrenceResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState left, Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState left, Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OccurrenceResultSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResultSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResultSummary>
    {
        internal OccurrenceResultSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.ResourceResultSummary> Statuses { get { throw null; } }
        public int Total { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResultSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResultSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResultSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResultSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResultSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResultSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResultSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails>
    {
        internal OperationErrorDetails() { }
        public string AzureOperationName { get { throw null; } }
        public string CrpOperationId { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? ErrorDetailsTimestamp { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationErrorsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult>
    {
        internal OperationErrorsResult() { }
        public System.DateTimeOffset? ActivationOn { get { throw null; } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails> OperationErrors { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string RequestErrorCode { get { throw null; } }
        public string RequestErrorDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceOperationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails>
    {
        internal ResourceOperationDetails() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public System.DateTimeOffset? Deadline { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType? DeadlineType { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string OperationTimezone { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType? OpType { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError ResourceOperationError { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.UserRequestRetryPolicy RetryPolicy { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState? State { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string Timezone { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceOperationError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError>
    {
        internal ResourceOperationError() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult>
    {
        internal ResourceOperationResult() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails Operation { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceOperationType : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceOperationType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType Hibernate { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType Start { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType left, Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType left, Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceProvisionPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload>
    {
        public ResourceProvisionPayload(int resourceCount) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> BaseProfile { get { throw null; } }
        public int ResourceCount { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> ResourceOverrides { get { throw null; } }
        public string ResourcePrefix { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceResultSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceResultSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceResultSummary>
    {
        internal ResourceResultSummary() { }
        public string Code { get { throw null; } }
        public int Count { get { throw null; } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ResourceResultSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceResultSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceResultSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ResourceResultSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceResultSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceResultSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ResourceResultSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionDeadlineType : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionDeadlineType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType CompleteBy { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType InitiateAt { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduledActionExecutionParameterDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail>
    {
        public ScheduledActionExecutionParameterDetail() { }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOptimizationPreference? OptimizationPreference { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeSchedule.Models.UserRequestRetryPolicy RetryPolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionOccurrenceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceProperties>
    {
        internal ScheduledActionOccurrenceProperties() { }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.OccurrenceResultSummary ResultSummary { get { throw null; } }
        public System.DateTimeOffset ScheduledOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionOccurrenceState : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionOccurrenceState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState Cancelling { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState Created { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState Rescheduling { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState Scheduled { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOccurrenceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionOperationState : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionOperationState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState Blocked { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState Executing { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState PendingExecution { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState PendingScheduling { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState Scheduled { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionOptimizationPreference : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOptimizationPreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionOptimizationPreference(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOptimizationPreference Availability { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOptimizationPreference Cost { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOptimizationPreference CostAvailabilityBalanced { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOptimizationPreference other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOptimizationPreference left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOptimizationPreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOptimizationPreference (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOptimizationPreference left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOptimizationPreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduledActionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatch>
    {
        public ScheduledActionPatch() { }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatchProperties>
    {
        public ScheduledActionPatchProperties() { }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType? ActionType { get { throw null; } set { } }
        public bool? Disabled { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> NotificationSettings { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType? ResourceType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule Schedule { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionProperties>
    {
        public ScheduledActionProperties(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType resourceType, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType actionType, System.DateTimeOffset startOn, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule schedule, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> notificationSettings) { }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType ActionType { get { throw null; } set { } }
        public bool? Disabled { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> NotificationSettings { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType ResourceType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule Schedule { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionResourceAttachContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceAttachContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceAttachContent>
    {
        public ScheduledActionResourceAttachContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData> resources) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData> Resources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceAttachContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceAttachContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceAttachContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceAttachContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceAttachContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceAttachContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceAttachContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData>
    {
        public ScheduledActionResourceData(Azure.Core.ResourceIdentifier resourceId) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> NotificationSettings { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionResourceDetachContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceDetachContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceDetachContent>
    {
        public ScheduledActionResourceDetachContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resources) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Resources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceDetachContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceDetachContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceDetachContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceDetachContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceDetachContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceDetachContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceDetachContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult>
    {
        internal ScheduledActionResourceOperationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceStatus> ResourcesStatuses { get { throw null; } }
        public int TotalResources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionResourceOperationStatus : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionResourceOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationStatus left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationStatus left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduledActionResourcePatchContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourcePatchContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourcePatchContent>
    {
        public ScheduledActionResourcePatchContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData> resources) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceData> Resources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourcePatchContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourcePatchContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourcePatchContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourcePatchContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourcePatchContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourcePatchContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourcePatchContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionResourceProvisioningState : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduledActionResources : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources>
    {
        internal ScheduledActionResources() { }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsExtensionProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionResourceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceStatus>
    {
        internal ScheduledActionResourceStatus() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceOperationStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionResourceType : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionResourceType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType VirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType VirtualMachineScaleSet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduledActionsExtensionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsExtensionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsExtensionProperties>
    {
        internal ScheduledActionsExtensionProperties() { }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType ActionType { get { throw null; } }
        public bool? Disabled { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> NotificationSettings { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.NotificationSettings> ResourceNotificationSettings { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionResourceType ResourceType { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule Schedule { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsExtensionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsExtensionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsExtensionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsExtensionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsExtensionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsExtensionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsExtensionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionsSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule>
    {
        public ScheduledActionsSchedule(System.TimeSpan scheduledTime, string timeZone, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay> requestedWeekDays, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth> requestedMonths, System.Collections.Generic.IEnumerable<int> requestedDaysOfTheMonth) { }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType? DeadlineType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail ExecutionParameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> RequestedDaysOfTheMonth { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth> RequestedMonths { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay> RequestedWeekDays { get { throw null; } }
        public System.TimeSpan ScheduledTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionsScheduleMonth : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionsScheduleMonth(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth All { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth April { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth August { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth December { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth February { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth January { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth July { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth June { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth March { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth May { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth November { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth October { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth September { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleMonth right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionsScheduleWeekDay : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionsScheduleWeekDay(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay All { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay Friday { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay Monday { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay Saturday { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay Sunday { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay Thursday { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay Tuesday { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionsScheduleWeekDay right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionType : System.IEquatable<Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType Hibernate { get { throw null; } }
        public static Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType Start { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType left, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StartResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>
    {
        internal StartResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.StartResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubmitDeallocateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent>
    {
        public SubmitDeallocateContent(Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule schedule, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail executionParameters, Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources resources, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule Schedule { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitDeallocateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubmitHibernateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent>
    {
        public SubmitHibernateContent(Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule schedule, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail executionParameters, Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources resources, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule Schedule { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitHibernateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubmitStartContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent>
    {
        public SubmitStartContent(Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule schedule, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail executionParameters, Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources resources, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail ExecutionParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        public Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule Schedule { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.SubmitStartContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserRequestResources : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources>
    {
        public UserRequestResources(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> ids) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Ids { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserRequestRetryPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestRetryPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestRetryPolicy>
    {
        public UserRequestRetryPolicy() { }
        public int? RetryCount { get { throw null; } set { } }
        public int? RetryWindowInMinutes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.UserRequestRetryPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestRetryPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestRetryPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.UserRequestRetryPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestRetryPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestRetryPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestRetryPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserRequestSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule>
    {
        public UserRequestSchedule(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType deadlineType) { }
        public System.DateTimeOffset? Deadline { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType DeadlineType { get { throw null; } }
        public string Timezone { get { throw null; } set { } }
        public System.DateTimeOffset? UserRequestDeadline { get { throw null; } set { } }
        public string UserRequestTimezone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeSchedule.Models.UserRequestSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
