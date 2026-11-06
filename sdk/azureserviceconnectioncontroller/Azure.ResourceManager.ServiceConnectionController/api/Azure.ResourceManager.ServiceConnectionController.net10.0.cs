namespace Azure.ResourceManager.ServiceConnectionController
{
    public partial class AzureResourceManagerServiceConnectionControllerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerServiceConnectionControllerContext() { }
        public static Azure.ResourceManager.ServiceConnectionController.AzureResourceManagerServiceConnectionControllerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class AzureServiceConnectionControllerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>, System.Collections.IEnumerable
    {
        protected AzureServiceConnectionControllerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureServiceConnectionControllerName, Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureServiceConnectionControllerName, Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureServiceConnectionControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureServiceConnectionControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> Get(string azureServiceConnectionControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>> GetAsync(string azureServiceConnectionControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> GetIfExists(string azureServiceConnectionControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>> GetIfExistsAsync(string azureServiceConnectionControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureServiceConnectionControllerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>
    {
        public AzureServiceConnectionControllerData(Azure.Core.AzureLocation location) { }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureServiceConnectionControllerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureServiceConnectionControllerResource() { }
        public virtual Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureServiceConnectionControllerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> Update(Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>> UpdateAsync(Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ServiceConnectionControllerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> GetAzureServiceConnectionController(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureServiceConnectionControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>> GetAzureServiceConnectionControllerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureServiceConnectionControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource GetAzureServiceConnectionControllerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerCollection GetAzureServiceConnectionControllers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> GetAzureServiceConnectionControllers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> GetAzureServiceConnectionControllersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceConnectionController.Mocking
{
    public partial class MockableServiceConnectionControllerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceConnectionControllerArmClient() { }
        public virtual Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource GetAzureServiceConnectionControllerResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableServiceConnectionControllerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceConnectionControllerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> GetAzureServiceConnectionController(string azureServiceConnectionControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource>> GetAzureServiceConnectionControllerAsync(string azureServiceConnectionControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerCollection GetAzureServiceConnectionControllers() { throw null; }
    }
    public partial class MockableServiceConnectionControllerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceConnectionControllerSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> GetAzureServiceConnectionControllers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerResource> GetAzureServiceConnectionControllersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceConnectionController.Models
{
    public static partial class ArmServiceConnectionControllerModelFactory
    {
        public static Azure.ResourceManager.ServiceConnectionController.AzureServiceConnectionControllerData AzureServiceConnectionControllerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties properties = null, string managedBy = null) { throw null; }
        public static Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch AzureServiceConnectionControllerPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties AzureServiceConnectionControllerProperties(Azure.Core.ResourceIdentifier subnetId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration> ipConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties> providerConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource> managedOnBehalfOfMoboBrokerResources = null, Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState? provisioningState = default(Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState?), Azure.Core.ResourceIdentifier udr = null) { throw null; }
        public static Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration IPConfiguration(System.Net.IPAddress privateIPv4Address = null, Azure.ResourceManager.ServiceConnectionController.Models.IPAllocationMethod? ipAllocationMethod = default(Azure.ResourceManager.ServiceConnectionController.Models.IPAllocationMethod?)) { throw null; }
        public static Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource MoboBrokerResource(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties ProviderConnectionProperties(string name = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration ipConfiguration = null, Azure.Core.ResourceIdentifier privateEndpointResourceGroup = null, Azure.Core.ResourceIdentifier sourceResourceId = null) { throw null; }
    }
    public partial class AzureServiceConnectionControllerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch>
    {
        public AzureServiceConnectionControllerPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureServiceConnectionControllerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties>
    {
        public AzureServiceConnectionControllerProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration> IPConfigurations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties> ProviderConnections { get { throw null; } }
        public Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Udr { get { throw null; } }
        protected virtual Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureServiceConnectionControllerProvisioningState : System.IEquatable<Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureServiceConnectionControllerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState left, Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState left, Azure.ResourceManager.ServiceConnectionController.Models.AzureServiceConnectionControllerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAllocationMethod : System.IEquatable<Azure.ResourceManager.ServiceConnectionController.Models.IPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.ServiceConnectionController.Models.IPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceConnectionController.Models.IPAllocationMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceConnectionController.Models.IPAllocationMethod left, Azure.ResourceManager.ServiceConnectionController.Models.IPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceConnectionController.Models.IPAllocationMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceConnectionController.Models.IPAllocationMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceConnectionController.Models.IPAllocationMethod left, Azure.ResourceManager.ServiceConnectionController.Models.IPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration>
    {
        public IPConfiguration() { }
        public Azure.ResourceManager.ServiceConnectionController.Models.IPAllocationMethod? IPAllocationMethod { get { throw null; } set { } }
        public System.Net.IPAddress PrivateIPv4Address { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoboBrokerResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource>
    {
        internal MoboBrokerResource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.MoboBrokerResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties>
    {
        public ProviderConnectionProperties() { }
        public Azure.ResourceManager.ServiceConnectionController.Models.IPConfiguration IPConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointResourceGroup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceConnectionController.Models.ProviderConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
