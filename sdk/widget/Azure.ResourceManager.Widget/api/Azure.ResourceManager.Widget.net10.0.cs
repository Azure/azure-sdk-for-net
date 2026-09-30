namespace Azure.ResourceManager.Widget
{
    public partial class AzureResourceManagerWidgetContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerWidgetContext() { }
        public static Azure.ResourceManager.Widget.AzureResourceManagerWidgetContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EmployeeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Widget.EmployeeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Widget.EmployeeResource>, System.Collections.IEnumerable
    {
        protected EmployeeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Widget.EmployeeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string employeeName, Azure.ResourceManager.Widget.EmployeeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Widget.EmployeeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string employeeName, Azure.ResourceManager.Widget.EmployeeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Widget.EmployeeResource> Get(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Widget.EmployeeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Widget.EmployeeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Widget.EmployeeResource>> GetAsync(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Widget.EmployeeResource> GetIfExists(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Widget.EmployeeResource>> GetIfExistsAsync(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Widget.EmployeeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Widget.EmployeeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Widget.EmployeeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Widget.EmployeeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EmployeeData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Widget.EmployeeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Widget.EmployeeData>
    {
        public EmployeeData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Widget.Models.EmployeeProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Widget.EmployeeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Widget.EmployeeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Widget.EmployeeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Widget.EmployeeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Widget.EmployeeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Widget.EmployeeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Widget.EmployeeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmployeeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Widget.EmployeeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Widget.EmployeeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EmployeeResource() { }
        public virtual Azure.ResourceManager.Widget.EmployeeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Widget.EmployeeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Widget.EmployeeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string employeeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Widget.EmployeeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Widget.EmployeeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Widget.EmployeeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Widget.EmployeeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Widget.EmployeeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Widget.EmployeeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Widget.EmployeeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Widget.EmployeeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Widget.EmployeeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Widget.EmployeeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Widget.EmployeeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Widget.EmployeeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Widget.EmployeeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Widget.EmployeeResource> Update(Azure.ResourceManager.Widget.EmployeeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Widget.EmployeeResource>> UpdateAsync(Azure.ResourceManager.Widget.EmployeeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class WidgetExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Widget.EmployeeResource> GetEmployee(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Widget.EmployeeResource>> GetEmployeeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Widget.EmployeeResource GetEmployeeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Widget.EmployeeCollection GetEmployees(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Widget.EmployeeResource> GetEmployees(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Widget.EmployeeResource> GetEmployeesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Widget.Mocking
{
    public partial class MockableWidgetArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableWidgetArmClient() { }
        public virtual Azure.ResourceManager.Widget.EmployeeResource GetEmployeeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableWidgetResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWidgetResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Widget.EmployeeResource> GetEmployee(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Widget.EmployeeResource>> GetEmployeeAsync(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Widget.EmployeeCollection GetEmployees() { throw null; }
    }
    public partial class MockableWidgetSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWidgetSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Widget.EmployeeResource> GetEmployees(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Widget.EmployeeResource> GetEmployeesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Widget.Models
{
    public static partial class ArmWidgetModelFactory
    {
        public static Azure.ResourceManager.Widget.EmployeeData EmployeeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Widget.Models.EmployeeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Widget.Models.EmployeeProperties EmployeeProperties(int? age = default(int?), string city = null, System.BinaryData profile = null, Azure.ResourceManager.Widget.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Widget.Models.ProvisioningState?)) { throw null; }
    }
    public partial class EmployeeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Widget.Models.EmployeeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Widget.Models.EmployeeProperties>
    {
        public EmployeeProperties() { }
        public int? Age { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public System.BinaryData Profile { get { throw null; } set { } }
        public Azure.ResourceManager.Widget.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Widget.Models.EmployeeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Widget.Models.EmployeeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Widget.Models.EmployeeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Widget.Models.EmployeeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Widget.Models.EmployeeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Widget.Models.EmployeeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Widget.Models.EmployeeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Widget.Models.EmployeeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Widget.Models.EmployeeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Widget.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Widget.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Widget.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Widget.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Widget.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Widget.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Widget.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Widget.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Widget.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Widget.Models.ProvisioningState left, Azure.ResourceManager.Widget.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Widget.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Widget.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Widget.Models.ProvisioningState left, Azure.ResourceManager.Widget.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
