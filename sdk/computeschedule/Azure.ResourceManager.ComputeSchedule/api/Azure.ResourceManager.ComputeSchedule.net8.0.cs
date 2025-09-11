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
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult> ExecuteVirtualMachineDeallocate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult> ExecuteVirtualMachineDeallocate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>> ExecuteVirtualMachineDeallocateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>> ExecuteVirtualMachineDeallocateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult> VirtualMachinesExecuteCreateScheduledAction(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult>> VirtualMachinesExecuteCreateScheduledActionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult> VirtualMachinesExecuteDeleteScheduledAction(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult>> VirtualMachinesExecuteDeleteScheduledActionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeSchedule.Mocking
{
    public partial class MockableComputeScheduleSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeScheduleSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult> CancelVirtualMachineOperations(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult> CancelVirtualMachineOperations(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult>> CancelVirtualMachineOperationsAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsResult>> CancelVirtualMachineOperationsAsync(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult> ExecuteVirtualMachineDeallocate(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult> ExecuteVirtualMachineDeallocate(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>> ExecuteVirtualMachineDeallocateAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeallocateResourceOperationResult>> ExecuteVirtualMachineDeallocateAsync(string locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult> VirtualMachinesExecuteCreateScheduledAction(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.CreateResourceOperationResult>> VirtualMachinesExecuteCreateScheduledActionAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult> VirtualMachinesExecuteDeleteScheduledAction(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeSchedule.Models.DeleteResourceOperationResult>> VirtualMachinesExecuteDeleteScheduledActionAsync(Azure.Core.AzureLocation locationparameter, Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.ComputeSchedule.Models.ExecuteCreateContent ExecuteCreateContent(Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload resourceConfigParameters = null, Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail executionParameters = null, string correlationid = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ExecuteDeleteContent ExecuteDeleteContent(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionExecutionParameterDetail executionParameters = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null, string correlationId = null, bool? isForceDeletion = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.GetOperationErrorsResult GetOperationErrorsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.GetOperationStatusResult GetOperationStatusResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.HibernateResourceOperationResult HibernateResourceOperationResult(string description = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails OperationErrorDetails(string errorCode = null, string errorDetails = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.DateTimeOffset? errorDetailsTimestamp = default(System.DateTimeOffset?), string azureOperationName = null, string crpOperationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.OperationErrorsResult OperationErrorsResult(string operationId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? activationOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeSchedule.Models.OperationErrorDetails> operationErrors = null, string requestErrorCode = null, string requestErrorDetails = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails ResourceOperationDetails(string operationId = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType? opType = default(Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationType?), string subscriptionId = null, System.DateTimeOffset? deadline = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType? deadlineType = default(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionDeadlineType?), Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState? state = default(Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState?), string timezone = null, string operationTimezone = null, Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError resourceOperationError = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeSchedule.Models.UserRequestRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationError ResourceOperationError(string errorCode = null, string errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationResult ResourceOperationResult(Azure.Core.ResourceIdentifier resourceId = null, string errorCode = null, string errorDetails = null, Azure.ResourceManager.ComputeSchedule.Models.ResourceOperationDetails operation = null) { throw null; }
        public static Azure.ResourceManager.ComputeSchedule.Models.ResourceProvisionPayload ResourceProvisionPayload(System.Collections.Generic.IDictionary<string, System.BinaryData> baseProfile = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> resourceOverrides = null, int resourceCount = 0, string resourcePrefix = null) { throw null; }
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
        public string Correlationid { get { throw null; } set { } }
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
