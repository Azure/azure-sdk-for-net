namespace Azure.ResourceManager.ApiCenter
{
    public static partial class ApiCenterExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> GetApiCenterServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterServiceResource GetApiCenterServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterServiceCollection GetApiCenterServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiCenterServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>, System.Collections.IEnumerable
    {
        protected ApiCenterServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ApiCenter.ApiCenterServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ApiCenter.ApiCenterServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetIfExists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> GetIfExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiCenterServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>
    {
        public ApiCenterServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiCenterServiceResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> Update(Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> UpdateAsync(Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerApiCenterContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerApiCenterContext() { }
        public static Azure.ResourceManager.ApiCenter.AzureResourceManagerApiCenterContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.ApiCenter.Mocking
{
    public partial class MockableApiCenterArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableApiCenterArmClient() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterServiceResource GetApiCenterServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableApiCenterResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableApiCenterResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterService(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> GetApiCenterServiceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterServiceCollection GetApiCenterServices() { throw null; }
    }
    public partial class MockableApiCenterSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableApiCenterSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ApiCenter.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiCenterProvisioningState : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiCenterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState left, Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState left, Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiCenterServicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>
    {
        public ApiCenterServicePatch() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmApiCenterModelFactory
    {
        public static Azure.ResourceManager.ApiCenter.ApiCenterServiceData ApiCenterServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState? provisioningState = default(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch ApiCenterServicePatch(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState? provisioningState = default(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState?)) { throw null; }
    }
}
