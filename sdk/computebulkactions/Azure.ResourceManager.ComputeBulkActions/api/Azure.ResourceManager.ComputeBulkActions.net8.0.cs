namespace Azure.ResourceManager.ComputeBulkActions
{
    public partial class AzureResourceManagerComputeBulkActionsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerComputeBulkActionsContext() { }
        public static Azure.ResourceManager.ComputeBulkActions.AzureResourceManagerComputeBulkActionsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BulkActionCollection : Azure.ResourceManager.ArmCollection
    {
        protected BulkActionCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(Azure.Core.AzureLocation location, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(Azure.Core.AzureLocation location, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetIfExists(Azure.Core.AzureLocation location, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeBulkActions.BulkActionResource>> GetIfExistsAsync(Azure.Core.AzureLocation location, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BulkActionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BulkActionResource() { }
        public virtual Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ComputeBulkActionsExtensions
    {
        public static Azure.ResourceManager.ComputeBulkActions.BulkActionResource GetBulkActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.BulkActionCollection GetBulkActions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.BulkActionCollection GetBulkActions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetBulkActions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetBulkActionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult> VirtualMachinesCancelOperations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult>> VirtualMachinesCancelOperationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult> VirtualMachinesExecuteCreate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult>> VirtualMachinesExecuteCreateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult> VirtualMachinesExecuteDeallocate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult>> VirtualMachinesExecuteDeallocateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult> VirtualMachinesExecuteDelete(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult>> VirtualMachinesExecuteDeleteAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult> VirtualMachinesExecuteHibernate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult>> VirtualMachinesExecuteHibernateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult> VirtualMachinesExecuteStart(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult>> VirtualMachinesExecuteStartAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult> VirtualMachinesGetOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult>> VirtualMachinesGetOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocationBasedLaunchBulkInstancesOperationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>
    {
        public LocationBasedLaunchBulkInstancesOperationData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.ComputeBulkActions.BulkActionCollection GetBulkActions() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetBulkActions(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeBulkActions.BulkActionResource> GetBulkActionsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult> VirtualMachinesCancelOperations(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult>> VirtualMachinesCancelOperationsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult> VirtualMachinesExecuteCreate(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult>> VirtualMachinesExecuteCreateAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult> VirtualMachinesExecuteDeallocate(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult>> VirtualMachinesExecuteDeallocateAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult> VirtualMachinesExecuteDelete(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult>> VirtualMachinesExecuteDeleteAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult> VirtualMachinesExecuteHibernate(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult>> VirtualMachinesExecuteHibernateAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult> VirtualMachinesExecuteStart(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult>> VirtualMachinesExecuteStartAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult> VirtualMachinesGetOperationStatus(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult>> VirtualMachinesGetOperationStatusAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeBulkActions.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcceleratorManufacturer : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorManufacturer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcceleratorManufacturer(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorManufacturer AMD { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorManufacturer Nvidia { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorManufacturer Xilinx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorManufacturer other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorManufacturer left, Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorManufacturer right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorManufacturer (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorManufacturer? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorManufacturer left, Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorManufacturer right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcceleratorType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcceleratorType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorType Fpga { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorType Gpu { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorType left, Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorType left, Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdditionalUnattendContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContent>
    {
        public AdditionalUnattendContent() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentComponentName? ComponentName { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentPassName? PassName { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentSettingName? SettingName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdditionalUnattendContentComponentName : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentComponentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdditionalUnattendContentComponentName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentComponentName MicrosoftWindowsShellSetup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentComponentName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentComponentName left, Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentComponentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentComponentName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentComponentName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentComponentName left, Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentComponentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdditionalUnattendContentPassName : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentPassName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdditionalUnattendContentPassName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentPassName OobeSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentPassName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentPassName left, Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentPassName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentPassName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentPassName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentPassName left, Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentPassName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdditionalUnattendContentSettingName : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentSettingName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdditionalUnattendContentSettingName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentSettingName AutoLogon { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentSettingName FirstLogonCommands { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentSettingName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentSettingName left, Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentSettingName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentSettingName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentSettingName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentSettingName left, Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContentSettingName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArchitectureType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ArchitectureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArchitectureType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ArchitectureType ARM64 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ArchitectureType X64 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ArchitectureType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ArchitectureType left, Azure.ResourceManager.ComputeBulkActions.Models.ArchitectureType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ArchitectureType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ArchitectureType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ArchitectureType left, Azure.ResourceManager.ComputeBulkActions.Models.ArchitectureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmComputeBulkActionsModelFactory
    {
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo BulkActionResourceOperationInfo(Azure.Core.ResourceIdentifier resourceId = null, string errorCode = null, string errorDetails = null, Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails operation = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult BulkActionVirtualMachineResult(string name = null, Azure.Core.ResourceIdentifier id = null, string type = null, Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus operationStatus = default(Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError error = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent CancelOperationsContent(System.Collections.Generic.IEnumerable<string> operationIds = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult CancelOperationsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError ComputeBulkActionsApiError(string code = null, string target = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase> details = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError innererror = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiErrorBase ComputeBulkActionsApiErrorBase(string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError ComputeBulkActionsInnerError(string exceptionType = null, string errorDetail = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile ComputeBulkActionsNetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference> networkInterfaces = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion? networkApiVersion = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration> networkInterfaceConfigurations = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile ComputeBulkActionsOSProfile(string computerName = null, string adminUsername = null, string adminPassword = null, string customData = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration windowsConfiguration = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration linuxConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup> secrets = null, bool? isExtensionOperationsAllowed = default(bool?), bool? isGuestProvisionSignalRequired = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageProfile ComputeBulkActionsStorageProfile(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsImageReference imageReference = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSDisk osDisk = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk> dataDisks = null, Azure.ResourceManager.ComputeBulkActions.Models.DiskControllerType? diskControllerType = default(Azure.ResourceManager.ComputeBulkActions.Models.DiskControllerType?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtensionProperties ComputeBulkActionsVirtualMachineExtensionProperties(string forceUpdateTag = null, string publisher = null, string type = null, string typeHandlerVersion = null, bool? isAutoUpgradeMinorVersionEnabled = default(bool?), bool? isAutomaticUpgradeEnabled = default(bool?), System.Collections.Generic.IDictionary<string, System.BinaryData> settings = null, System.Collections.Generic.IDictionary<string, System.BinaryData> protectedSettings = null, bool? isSuppressFailures = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference protectedSettingsFromKeyVault = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration ComputeBulkActionsWindowsConfiguration(bool? isVMAgentProvisioned = default(bool?), bool? enableAutomaticUpdates = default(bool?), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContent> additionalUnattendContent = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings patchSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.WinRMListener> winRMListeners = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile ComputeProfile(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile virtualMachineProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension> extensions = null, string computeApiVersion = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult CreateResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult DeallocateResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult DeleteResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent ExecuteCreateContent(Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload resourceConfigParameters = null, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent ExecuteDeallocateContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent ExecuteDeleteContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null, string correlationId = null, bool? isForceDeletion = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent ExecuteHibernateContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent ExecuteStartContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesIds = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent GetOperationStatusContent(System.Collections.Generic.IEnumerable<string> operationIds = null, string correlationId = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult GetOperationStatusResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult HibernateResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties LaunchBulkInstancesOperationProperties(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState? provisioningState = default(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState?), int capacity = 0, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType? capacityType = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile priorityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.VmSizeProfile> vmSizesProfile = null, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes vmAttributes = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile computeProfile = null, Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy zoneAllocationPolicy = null, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.LocationBasedLaunchBulkInstancesOperationData LocationBasedLaunchBulkInstancesOperationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties properties = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Models.ArmPlan plan = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails ResourceOperationDetails(string operationId = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType? opType = default(Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType?), string subscriptionId = null, System.DateTimeOffset? deadlineOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType? deadlineType = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType?), Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState? state = default(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState?), string timezone = null, Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError resourceOperationError = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy retryPolicy = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError ResourceOperationError(string errorCode = null, string errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload ResourceProvisionPayload(System.Collections.Generic.IDictionary<string, System.BinaryData> baseProfile = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> resourceOverrides = null, int resourceCount = 0, string resourcePrefix = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult StartResourceOperationResult(string description = null, string type = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> results = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup VaultSecretGroup(Azure.Core.ResourceIdentifier sourceVaultId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.VaultCertificate> vaultCertificates = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration VirtualMachineNetworkInterfaceConfiguration(string name = null, Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties VirtualMachineNetworkInterfaceConfigurationProperties(bool? isPrimary = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption? deleteOption = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption?), bool? isAcceleratedNetworkingEnabled = default(bool?), bool? isTcpStateTrackingDisabled = default(bool?), bool? isFpgaEnabled = default(bool?), bool? isIPForwardingEnabled = default(bool?), Azure.Core.ResourceIdentifier networkSecurityGroupId = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration> ipConfigurations = null, Azure.Core.ResourceIdentifier dscpConfigurationId = null, Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode? auxiliaryMode = default(Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode?), Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku? auxiliarySku = default(Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties VirtualMachineNetworkInterfaceIPConfigurationProperties(Azure.Core.ResourceIdentifier subnetId = null, bool? isPrimary = default(bool?), Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration publicIPAddressConfiguration = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion? privateIPAddressVersion = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource> applicationSecurityGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource> applicationGatewayBackendAddressPools = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource> loadBalancerBackendAddressPools = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration VirtualMachinePublicIPAddressConfiguration(string name = null, Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties properties = null, Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSku sku = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties VirtualMachinePublicIPAddressConfigurationProperties(int? idleTimeoutInMinutes = default(int?), Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption? deleteOption = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption?), Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration dnsSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineIpTag> ipTags = null, Azure.Core.ResourceIdentifier publicIPPrefixId = null, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion? publicIPAddressVersion = default(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion?), Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAllocationMethod? publicIPAllocationMethod = default(Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAllocationMethod?)) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes VMAttributes(Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger vCpuCount = null, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble memoryInGiB = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ArchitectureType> architectureTypes = null, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble memoryInGiBPerVCpu = null, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport? localStorageSupport = default(Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport?), Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble localStorageInGiB = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.LocalStorageDiskType> localStorageDiskTypes = null, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger dataDiskCount = null, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger networkInterfaceCount = null, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble networkBandwidthInMbps = null, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport? rdmaSupport = default(Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport?), Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger rdmaNetworkInterfaceCount = null, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport? acceleratorSupport = default(Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorManufacturer> acceleratorManufacturers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorType> acceleratorTypes = null, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger acceleratorCount = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.VMCategory> vmCategories = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer> cpuManufacturers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.HyperVGeneration> hyperVGenerations = null, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport? burstableSupport = default(Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport?), System.Collections.Generic.IEnumerable<string> allowedVMSizes = null, System.Collections.Generic.IEnumerable<string> excludedVMSizes = null) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy ZoneAllocationPolicy(Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy distributionStrategy = default(Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference> zonePreferences = null) { throw null; }
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
    public partial class BulkActionResourceOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo>
    {
        internal BulkActionResourceOperationInfo() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails Operation { get { throw null; } }
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
    public partial class BulkActionVirtualMachineResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionVirtualMachineResult>
    {
        internal BulkActionVirtualMachineResult() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsApiError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus OperationStatus { get { throw null; } }
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
    public partial class CancelOperationsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent>
    {
        public CancelOperationsContent(System.Collections.Generic.IEnumerable<string> operationIds, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public System.Collections.Generic.IList<string> OperationIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CancelOperationsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult>
    {
        internal CancelOperationsResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.CancelOperationsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsInnerError Innererror { get { throw null; } }
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
    public partial class ComputeBulkActionsDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDataDisk>
    {
        public ComputeBulkActionsDataDisk(int lun, Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.DiskDetachOptionType? DetachOption { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public string ImageUri { get { throw null; } set { } }
        public bool? IsToBeDetached { get { throw null; } set { } }
        public bool? IsWriteAcceleratorEnabled { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ManagedDiskInfo ManagedDisk { get { throw null; } set { } }
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
    public partial class ComputeBulkActionsLinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsLinuxConfiguration>
    {
        public ComputeBulkActionsLinuxConfiguration() { }
        public bool? IsPasswordAuthenticationDisabled { get { throw null; } set { } }
        public bool? IsVMAgentPlatformUpdatesEnabled { get { throw null; } set { } }
        public bool? IsVMAgentProvisioned { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchSettings PatchSettings { get { throw null; } set { } }
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
    public partial class ComputeBulkActionsNetworkInterfaceReference : Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkInterfaceReference>
    {
        public ComputeBulkActionsNetworkInterfaceReference() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceReferenceProperties Properties { get { throw null; } set { } }
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
    public partial class ComputeBulkActionsNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile>
    {
        public ComputeBulkActionsNetworkProfile() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
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
        public ComputeBulkActionsOSDisk(Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSettings EncryptionSettings { get { throw null; } set { } }
        public string ImageUri { get { throw null; } set { } }
        public bool? IsWriteAcceleratorEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ManagedDiskInfo ManagedDisk { get { throw null; } set { } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup> Secrets { get { throw null; } }
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
        public Azure.ResourceManager.ComputeBulkActions.Models.WindowsPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public bool? IsHotpatchingEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchMode? PatchMode { get { throw null; } set { } }
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
    public partial class ComputeBulkActionsSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityProfile>
    {
        public ComputeBulkActionsSecurityProfile() { }
        public bool? IsEncryptionAtHostEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentSettings ProxyAgentSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSecurityType? SecurityType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.UefiSettings UefiSettings { get { throw null; } set { } }
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
        public Azure.ResourceManager.ComputeBulkActions.Models.DiskControllerType? DiskControllerType { get { throw null; } set { } }
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
        public Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference ProtectedSettingsFromKeyVault { get { throw null; } set { } }
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
    public partial class ComputeBulkActionsVirtualMachineProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile>
    {
        public ComputeBulkActionsVirtualMachineProfile() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsAdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsBootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.VMGalleryApplication> GalleryApplications { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsOSProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
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
    public partial class ComputeBulkActionsWindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsWindowsConfiguration>
    {
        public ComputeBulkActionsWindowsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.AdditionalUnattendContent> AdditionalUnattendContent { get { throw null; } }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public bool? IsVMAgentProvisioned { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPatchSettings PatchSettings { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.WinRMListener> WinRMListeners { get { throw null; } }
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
    public partial class ComputeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile>
    {
        public ComputeProfile(Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile virtualMachineProfile) { }
        public string ComputeApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineExtension> Extensions { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsVirtualMachineProfile VirtualMachineProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CpuManufacturer : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CpuManufacturer(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer AMD { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer Ampere { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer Intel { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer Microsoft { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer left, Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer left, Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult>
    {
        internal CreateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.CreateResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeallocateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult>
    {
        internal DeallocateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DeallocateResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeleteResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult>
    {
        internal DeleteResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DeleteResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskOption : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskOption(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskOption Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskOption other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskOption left, Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskOption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskOption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskOption left, Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskPlacement : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskPlacement CacheDisk { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskPlacement NvmeDisk { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskPlacement ResourceDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskPlacement other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskPlacement left, Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskPlacement (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskPlacement? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskPlacement left, Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiffDiskSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskSettings>
    {
        public DiffDiskSettings() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskOption? Option { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskPlacement? Placement { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DiffDiskSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskControllerType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.DiskControllerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskControllerType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiskControllerType NVMe { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiskControllerType SCSI { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.DiskControllerType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.DiskControllerType left, Azure.ResourceManager.ComputeBulkActions.Models.DiskControllerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DiskControllerType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DiskControllerType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.DiskControllerType left, Azure.ResourceManager.ComputeBulkActions.Models.DiskControllerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskCreateOptionType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskCreateOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType Attach { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType Copy { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType Empty { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType FromImage { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType Restore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType left, Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType left, Azure.ResourceManager.ComputeBulkActions.Models.DiskCreateOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDeleteOptionType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.DiskDeleteOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDeleteOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiskDeleteOptionType Delete { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiskDeleteOptionType Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.DiskDeleteOptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.DiskDeleteOptionType left, Azure.ResourceManager.ComputeBulkActions.Models.DiskDeleteOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DiskDeleteOptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DiskDeleteOptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.DiskDeleteOptionType left, Azure.ResourceManager.ComputeBulkActions.Models.DiskDeleteOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDetachOptionType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.DiskDetachOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDetachOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DiskDetachOptionType ForceDetach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.DiskDetachOptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.DiskDetachOptionType left, Azure.ResourceManager.ComputeBulkActions.Models.DiskDetachOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DiskDetachOptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DiskDetachOptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.DiskDetachOptionType left, Azure.ResourceManager.ComputeBulkActions.Models.DiskDetachOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskEncryptionSetReference : Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSetReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSetReference>
    {
        public DiskEncryptionSetReference() { }
        protected override Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSetReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSetReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSetReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSetReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSetReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSetReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSetReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskEncryptionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSettings>
    {
        public DiskEncryptionSettings() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference DiskEncryptionKey { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultKeyReference KeyEncryptionKey { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.DiskEncryptionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainNameLabelScopeType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.DomainNameLabelScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainNameLabelScopeType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DomainNameLabelScopeType NoReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DomainNameLabelScopeType ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DomainNameLabelScopeType SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.DomainNameLabelScopeType TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.DomainNameLabelScopeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.DomainNameLabelScopeType left, Azure.ResourceManager.ComputeBulkActions.Models.DomainNameLabelScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DomainNameLabelScopeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.DomainNameLabelScopeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.DomainNameLabelScopeType left, Azure.ResourceManager.ComputeBulkActions.Models.DomainNameLabelScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridAndResourceGraph : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.EventGridAndResourceGraph>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.EventGridAndResourceGraph>
    {
        public EventGridAndResourceGraph() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string ScheduledEventsApiVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.EventGridAndResourceGraph JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.EventGridAndResourceGraph PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.EventGridAndResourceGraph System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.EventGridAndResourceGraph>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.EventGridAndResourceGraph>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.EventGridAndResourceGraph System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.EventGridAndResourceGraph>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.EventGridAndResourceGraph>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.EventGridAndResourceGraph>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteCreateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent>
    {
        public ExecuteCreateContent(Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload resourceConfigParameters, Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters) { }
        public string CorrelationId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig ExecutionParameters { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload ResourceConfigParameters { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteCreateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteDeallocateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent>
    {
        public ExecuteDeallocateContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig ExecutionParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeallocateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteDeleteContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent>
    {
        public ExecuteDeleteContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig ExecutionParameters { get { throw null; } }
        public bool? IsForceDeletion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteDeleteContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteHibernateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent>
    {
        public ExecuteHibernateContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig ExecutionParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteHibernateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteStartContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent>
    {
        public ExecuteStartContent(Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig executionParameters, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionExecutionConfig ExecutionParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ExecuteStartContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetOperationStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent>
    {
        public GetOperationStatusContent(System.Collections.Generic.IEnumerable<string> operationIds, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public System.Collections.Generic.IList<string> OperationIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetOperationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult>
    {
        internal GetOperationStatusResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.GetOperationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HibernateResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult>
    {
        internal HibernateResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.HibernateResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostEndpointMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostEndpointMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointMode Audit { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointMode Enforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointMode left, Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointMode left, Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HostEndpointSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointSettings>
    {
        public HostEndpointSettings() { }
        public Azure.Core.ResourceIdentifier InVMAccessControlProfileReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointMode? Mode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVGeneration : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.HyperVGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVGeneration(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.HyperVGeneration Gen1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.HyperVGeneration Gen2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.HyperVGeneration other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.HyperVGeneration left, Azure.ResourceManager.ComputeBulkActions.Models.HyperVGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.HyperVGeneration (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.HyperVGeneration? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.HyperVGeneration left, Azure.ResourceManager.ComputeBulkActions.Models.HyperVGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultKeyReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultKeyReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultKeyReference>
    {
        public KeyVaultKeyReference(string keyUri) { }
        public string KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultKeyReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultKeyReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultKeyReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultKeyReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultKeyReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultKeyReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultKeyReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultKeyReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultKeyReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference>
    {
        public KeyVaultSecretReference(string secretUri) { }
        public string SecretUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.KeyVaultSecretReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LaunchBulkInstancesOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties>
    {
        public LaunchBulkInstancesOperationProperties(int capacity, Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile priorityProfile, Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile computeProfile) { }
        public int Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsCapacityType? CapacityType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeProfile ComputeProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsPriorityProfile PriorityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy RetryPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes VmAttributes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.VmSizeProfile> VmSizesProfile { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy ZoneAllocationPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.LaunchBulkInstancesOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchAssessmentMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchAssessmentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchAssessmentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxPatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchSettings>
    {
        public LinuxPatchSettings() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchMode? PatchMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxPatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVMGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVMGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxVMGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>
    {
        public LinuxVMGuestPatchAutomaticByPlatformSettings() { }
        public bool? IsBypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVMGuestPatchMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVMGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchMode left, Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchMode left, Azure.ResourceManager.ComputeBulkActions.Models.LinuxVMGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocalStorageDiskType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.LocalStorageDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalStorageDiskType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.LocalStorageDiskType Hdd { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.LocalStorageDiskType Ssd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.LocalStorageDiskType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.LocalStorageDiskType left, Azure.ResourceManager.ComputeBulkActions.Models.LocalStorageDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.LocalStorageDiskType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.LocalStorageDiskType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.LocalStorageDiskType left, Azure.ResourceManager.ComputeBulkActions.Models.LocalStorageDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedDiskInfo : Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ManagedDiskInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ManagedDiskInfo>
    {
        public ManagedDiskInfo() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsStorageAccountType? StorageAccountType { get { throw null; } set { } }
        protected override Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ManagedDiskInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ManagedDiskInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ManagedDiskInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ManagedDiskInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ManagedDiskInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ManagedDiskInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ManagedDiskInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkInterfaceAuxiliaryMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkInterfaceAuxiliaryMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode AcceleratedConnections { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode Floating { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkInterfaceAuxiliarySku : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkInterfaceAuxiliarySku(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku A1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku A2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku A4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku A8 { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku left, Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku left, Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkInterfaceReferenceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceReferenceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceReferenceProperties>
    {
        public NetworkInterfaceReferenceProperties() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption? DeleteOption { get { throw null; } set { } }
        public bool? IsPrimary { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceReferenceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceReferenceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceReferenceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceReferenceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceReferenceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceReferenceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceReferenceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceReferenceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceReferenceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSImageNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.OSImageNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.OSImageNotificationProfile>
    {
        public OSImageNotificationProfile() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.OSImageNotificationProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.OSImageNotificationProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.OSImageNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.OSImageNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.OSImageNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.OSImageNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.OSImageNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.OSImageNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.OSImageNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProxyAgentMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProxyAgentMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentMode Audit { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentMode Enforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentMode left, Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentMode left, Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProxyAgentSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentSettings>
    {
        public ProxyAgentSettings() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointSettings Imds { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? KeyIncarnationId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentMode? Mode { get { throw null; } set { } }
        public bool? ShouldAddProxyAgentExtension { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.HostEndpointSettings WireServer { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ProxyAgentSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicIPAddressSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSku>
    {
        public PublicIPAddressSku() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAddressSkuName : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAddressSkuName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuName left, Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuName left, Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAddressSkuTier : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAddressSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuTier Global { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuTier Regional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuTier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuTier left, Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuTier left, Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAllocationMethod : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAllocationMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAllocationMethod left, Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAllocationMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAllocationMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAllocationMethod left, Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceOperationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails>
    {
        internal ResourceOperationDetails() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public System.DateTimeOffset? DeadlineOn { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeadlineType? DeadlineType { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType? OpType { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError ResourceOperationError { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionRetryPolicy RetryPolicy { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.BulkActionOperationState? State { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string Timezone { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceOperationError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError>
    {
        internal ResourceOperationError() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceOperationType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceOperationType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType Create { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType Delete { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType Hibernate { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType Start { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType left, Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType left, Azure.ResourceManager.ComputeBulkActions.Models.ResourceOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceProvisionPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload>
    {
        public ResourceProvisionPayload(int resourceCount) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> BaseProfile { get { throw null; } }
        public int ResourceCount { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> ResourceOverrides { get { throw null; } }
        public string ResourcePrefix { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ResourceProvisionPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledEventsPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsPolicy>
    {
        public ScheduledEventsPolicy() { }
        public bool? IsAllInstancesDownAutomaticallyApproved { get { throw null; } set { } }
        public bool? IsRebootAutomaticallyApproved { get { throw null; } set { } }
        public bool? IsRedeployAutomaticallyApproved { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.EventGridAndResourceGraph ScheduledEventsAdditionalPublishingTargetsEventGridAndResourceGraph { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledEventsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsProfile>
    {
        public ScheduledEventsProfile() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.OSImageNotificationProfile OsImageNotificationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.TerminateNotificationProfile TerminateNotificationProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ScheduledEventsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityEncryptionType : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.SecurityEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.SecurityEncryptionType DiskWithVMGuestState { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.SecurityEncryptionType NonPersistedTPM { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.SecurityEncryptionType VMGuestStateOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.SecurityEncryptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.SecurityEncryptionType left, Azure.ResourceManager.ComputeBulkActions.Models.SecurityEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.SecurityEncryptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.SecurityEncryptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.SecurityEncryptionType left, Azure.ResourceManager.ComputeBulkActions.Models.SecurityEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StartResourceOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult>
    {
        internal StartResourceOperationResult() { }
        public string Description { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.BulkActionResourceOperationInfo> Results { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.StartResourceOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TerminateNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.TerminateNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.TerminateNotificationProfile>
    {
        public TerminateNotificationProfile() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.TerminateNotificationProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.TerminateNotificationProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.TerminateNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.TerminateNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.TerminateNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.TerminateNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.TerminateNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.TerminateNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.TerminateNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UefiSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.UefiSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.UefiSettings>
    {
        public UefiSettings() { }
        public bool? IsSecureBootEnabled { get { throw null; } set { } }
        public bool? IsVTpmEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.UefiSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.UefiSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.UefiSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.UefiSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.UefiSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.UefiSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.UefiSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.UefiSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.UefiSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultCertificate>
    {
        public VaultCertificate() { }
        public string CertificateStore { get { throw null; } set { } }
        public string CertificateUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VaultCertificate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VaultCertificate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VaultCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VaultCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultSecretGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup>
    {
        public VaultSecretGroup() { }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.VaultCertificate> VaultCertificates { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VaultSecretGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineIpTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineIpTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineIpTag>
    {
        public VirtualMachineIpTag() { }
        public string IpTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineIpTag JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineIpTag PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineIpTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineIpTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineIpTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineIpTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineIpTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineIpTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineIpTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>
    {
        public VirtualMachineNetworkInterfaceConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>
    {
        public VirtualMachineNetworkInterfaceConfigurationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration> ipConfigurations) { }
        public Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliaryMode? AuxiliaryMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.NetworkInterfaceAuxiliarySku? AuxiliarySku { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption? DeleteOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.Core.ResourceIdentifier DscpConfigurationId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration> IpConfigurations { get { throw null; } }
        public bool? IsAcceleratedNetworkingEnabled { get { throw null; } set { } }
        public bool? IsFpgaEnabled { get { throw null; } set { } }
        public bool? IsIPForwardingEnabled { get { throw null; } set { } }
        public bool? IsPrimary { get { throw null; } set { } }
        public bool? IsTcpStateTrackingDisabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>
    {
        public VirtualMachineNetworkInterfaceIPConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceIPConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>
    {
        public VirtualMachineNetworkInterfaceIPConfigurationProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource> ApplicationSecurityGroups { get { throw null; } }
        public bool? IsPrimary { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineNetworkInterfaceIPConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachinePublicIPAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration>
    {
        public VirtualMachinePublicIPAddressConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAddressSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachinePublicIPAddressConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>
    {
        public VirtualMachinePublicIPAddressConfigurationProperties() { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsDeleteOption? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachineIpTag> IpTags { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsIPVersion? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.PublicIPAllocationMethod? PublicIPAllocationMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachinePublicIPAddressDnsSettingsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>
    {
        public VirtualMachinePublicIPAddressDnsSettingsConfiguration(string domainNameLabel) { }
        public string DomainNameLabel { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.DomainNameLabelScopeType? DomainNameLabelScope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMAttributeMinMaxDouble : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble>
    {
        public VMAttributeMinMaxDouble() { }
        public double? Max { get { throw null; } set { } }
        public double? Min { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMAttributeMinMaxInteger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger>
    {
        public VMAttributeMinMaxInteger() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMAttributes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes>
    {
        public VMAttributes(Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger vCpuCount, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble memoryInGiB, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeBulkActions.Models.ArchitectureType> architectureTypes) { }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger AcceleratorCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorManufacturer> AcceleratorManufacturers { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport? AcceleratorSupport { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.AcceleratorType> AcceleratorTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedVMSizes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ArchitectureType> ArchitectureTypes { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport? BurstableSupport { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.CpuManufacturer> CpuManufacturers { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger DataDiskCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedVMSizes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.HyperVGeneration> HyperVGenerations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.LocalStorageDiskType> LocalStorageDiskTypes { get { throw null; } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble LocalStorageInGiB { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport? LocalStorageSupport { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble MemoryInGiB { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble MemoryInGiBPerVCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxDouble NetworkBandwidthInMbps { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger NetworkInterfaceCount { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger RdmaNetworkInterfaceCount { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport? RdmaSupport { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeMinMaxInteger VCpuCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.VMCategory> VmCategories { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMAttributeSupport : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMAttributeSupport(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport Excluded { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport Included { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport left, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport left, Azure.ResourceManager.ComputeBulkActions.Models.VMAttributeSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMCategory : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.VMCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMCategory(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMCategory ComputeOptimized { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMCategory FpgaAccelerated { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMCategory GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMCategory GpuAccelerated { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMCategory HighPerformanceCompute { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMCategory MemoryOptimized { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMCategory StorageOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.VMCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.VMCategory left, Azure.ResourceManager.ComputeBulkActions.Models.VMCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.VMCategory (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.VMCategory? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.VMCategory left, Azure.ResourceManager.ComputeBulkActions.Models.VMCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VMDiskSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMDiskSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMDiskSecurityProfile>
    {
        public VMDiskSecurityProfile() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.SecurityEncryptionType? SecurityEncryptionType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VMDiskSecurityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VMDiskSecurityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VMDiskSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMDiskSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMDiskSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VMDiskSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMDiskSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMDiskSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMDiskSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMGalleryApplication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMGalleryApplication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMGalleryApplication>
    {
        public VMGalleryApplication(Azure.Core.ResourceIdentifier packageReferenceId) { }
        public string ConfigurationReference { get { throw null; } set { } }
        public bool? IsAutomaticUpgradeEnabled { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PackageReferenceId { get { throw null; } set { } }
        public bool? ShouldTreatFailureAsDeploymentFailure { get { throw null; } set { } }
        public string Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VMGalleryApplication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VMGalleryApplication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VMGalleryApplication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMGalleryApplication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VMGalleryApplication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VMGalleryApplication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMGalleryApplication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMGalleryApplication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VMGalleryApplication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMOperationStatus : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus CancelFailedStatusUnknown { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus Cancelling { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus left, Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus left, Azure.ResourceManager.ComputeBulkActions.Models.VMOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmSizeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VmSizeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VmSizeProfile>
    {
        public VmSizeProfile(string name) { }
        public string Name { get { throw null; } set { } }
        public int? Rank { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VmSizeProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.VmSizeProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.VmSizeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VmSizeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.VmSizeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.VmSizeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VmSizeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VmSizeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.VmSizeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.WindowsPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.WindowsPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.WindowsPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.WindowsPatchAssessmentMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.ComputeBulkActions.Models.WindowsPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.WindowsPatchAssessmentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.WindowsPatchAssessmentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.ComputeBulkActions.Models.WindowsPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVMGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVMGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsVMGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>
    {
        public WindowsVMGuestPatchAutomaticByPlatformSettings() { }
        public bool? IsBypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVMGuestPatchMode : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVMGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchMode AutomaticByOS { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchMode left, Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchMode left, Azure.ResourceManager.ComputeBulkActions.Models.WindowsVMGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WinRMListener : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.WinRMListener>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.WinRMListener>
    {
        public WinRMListener() { }
        public string CertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsProtocolType? Protocol { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.WinRMListener JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.WinRMListener PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.WinRMListener System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.WinRMListener>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.WinRMListener>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.WinRMListener System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.WinRMListener>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.WinRMListener>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.WinRMListener>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ZoneAllocationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy>
    {
        public ZoneAllocationPolicy(Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy distributionStrategy) { }
        public Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy DistributionStrategy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeBulkActions.Models.ComputeBulkActionsZonePreference> ZonePreferences { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeBulkActions.Models.ZoneAllocationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZoneDistributionStrategy : System.IEquatable<Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZoneDistributionStrategy(string value) { throw null; }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy BestEffortBalanced { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy BestEffortSingleZone { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy Prioritized { get { throw null; } }
        public static Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy StrictBalanced { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy left, Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy left, Azure.ResourceManager.ComputeBulkActions.Models.ZoneDistributionStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
}
