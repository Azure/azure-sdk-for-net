namespace Azure.ResourceManager.Contoso
{
    public partial class AzureResourceManagerContosoContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContosoContext() { }
        public static Azure.ResourceManager.Contoso.AzureResourceManagerContosoContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ContosoExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource> GetEmployee(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource>> GetEmployeeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Contoso.EmployeeResource GetEmployeeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Contoso.EmployeeCollection GetEmployees(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Contoso.EmployeeResource> GetEmployees(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Contoso.EmployeeResource> GetEmployeesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EmployeeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Contoso.EmployeeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Contoso.EmployeeResource>, System.Collections.IEnumerable
    {
        protected EmployeeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Contoso.EmployeeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string employeeName, Azure.ResourceManager.Contoso.EmployeeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Contoso.EmployeeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string employeeName, Azure.ResourceManager.Contoso.EmployeeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource> Get(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Contoso.EmployeeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Contoso.EmployeeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource>> GetAsync(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Contoso.EmployeeResource> GetIfExists(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Contoso.EmployeeResource>> GetIfExistsAsync(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Contoso.EmployeeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Contoso.EmployeeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Contoso.EmployeeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Contoso.EmployeeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EmployeeData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Contoso.EmployeeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Contoso.EmployeeData>
    {
        public EmployeeData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Contoso.Models.EmployeeProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Contoso.EmployeeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Contoso.EmployeeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Contoso.EmployeeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Contoso.EmployeeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Contoso.EmployeeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Contoso.EmployeeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Contoso.EmployeeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmployeeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Contoso.EmployeeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Contoso.EmployeeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EmployeeResource() { }
        public virtual Azure.ResourceManager.Contoso.EmployeeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string employeeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Contoso.EmployeeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Contoso.EmployeeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Contoso.EmployeeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Contoso.EmployeeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Contoso.EmployeeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Contoso.EmployeeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Contoso.EmployeeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource> Update(Azure.ResourceManager.Contoso.EmployeeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource>> UpdateAsync(Azure.ResourceManager.Contoso.EmployeeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Contoso.Mocking
{
    public partial class MockableContosoArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContosoArmClient() { }
        public virtual Azure.ResourceManager.Contoso.EmployeeResource GetEmployeeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableContosoResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContosoResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource> GetEmployee(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Contoso.EmployeeResource>> GetEmployeeAsync(string employeeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Contoso.EmployeeCollection GetEmployees() { throw null; }
    }
    public partial class MockableContosoSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContosoSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Contoso.EmployeeResource> GetEmployees(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Contoso.EmployeeResource> GetEmployeesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Contoso.Models
{
    public static partial class ArmContosoModelFactory
    {
        public static Azure.ResourceManager.Contoso.EmployeeData EmployeeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Contoso.Models.EmployeeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Contoso.Models.EmployeeProperties EmployeeProperties(int? age = default(int?), string city = null, byte[] profile = null, Azure.ResourceManager.Contoso.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Contoso.Models.ProvisioningState?)) { throw null; }
    }
    public partial class EmployeeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Contoso.Models.EmployeeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Contoso.Models.EmployeeProperties>
    {
        public EmployeeProperties() { }
        public int? Age { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public byte[] Profile { get { throw null; } set { } }
        public Azure.ResourceManager.Contoso.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Contoso.Models.EmployeeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Contoso.Models.EmployeeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Contoso.Models.EmployeeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Contoso.Models.EmployeeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Contoso.Models.EmployeeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Contoso.Models.EmployeeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Contoso.Models.EmployeeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Contoso.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Contoso.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Contoso.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Contoso.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Contoso.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Contoso.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Contoso.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Contoso.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Contoso.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Contoso.Models.ProvisioningState left, Azure.ResourceManager.Contoso.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Contoso.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Contoso.Models.ProvisioningState left, Azure.ResourceManager.Contoso.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
