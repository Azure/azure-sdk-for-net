namespace Azure.ResourceManager.KeyVault
{
    public partial class AzureResourceManagerKeyVaultContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerKeyVaultContext() { }
        public static Azure.ResourceManager.KeyVault.AzureResourceManagerKeyVaultContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DeletedKeyVaultCollection : Azure.ResourceManager.ArmCollection
    {
        protected DeletedKeyVaultCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> Get(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource>> GetAsync(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> GetIfExists(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource>> GetIfExistsAsync(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedKeyVaultData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>
    {
        internal DeletedKeyVaultData() { }
        public Azure.ResourceManager.KeyVault.Models.DeletedKeyVaultProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.DeletedKeyVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.DeletedKeyVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeletedKeyVaultResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedKeyVaultResource() { }
        public virtual Azure.ResourceManager.KeyVault.DeletedKeyVaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeDeleted(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeDeletedAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.KeyVault.DeletedKeyVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.DeletedKeyVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedKeyVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeletedManagedHsmCollection : Azure.ResourceManager.ArmCollection
    {
        protected DeletedManagedHsmCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> Get(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource>> GetAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetIfExists(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource>> GetIfExistsAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedManagedHsmData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>
    {
        internal DeletedManagedHsmData() { }
        public Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.DeletedManagedHsmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.DeletedManagedHsmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeletedManagedHsmResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedManagedHsmResource() { }
        public virtual Azure.ResourceManager.KeyVault.DeletedManagedHsmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeDeleted(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeDeletedAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.KeyVault.DeletedManagedHsmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.DeletedManagedHsmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.DeletedManagedHsmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.KeyVaultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.KeyVaultResource>, System.Collections.IEnumerable
    {
        protected KeyVaultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.KeyVaultResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.KeyVaultResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KeyVault.KeyVaultResource> GetIfExists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KeyVault.KeyVaultResource>> GetIfExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.KeyVaultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.KeyVaultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.KeyVaultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.KeyVaultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KeyVaultData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultData>
    {
        public KeyVaultData(Azure.Core.AzureLocation location, Azure.ResourceManager.KeyVault.Models.KeyVaultProperties properties) { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.KeyVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.KeyVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class KeyVaultExtensions
    {
        public static Azure.Response<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult> CheckKeyVaultNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult>> CheckKeyVaultNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult> CheckManagedHsmNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult>> CheckManagedHsmNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> GetDeletedKeyVault(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource>> GetDeletedKeyVaultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedKeyVaultResource GetDeletedKeyVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedKeyVaultCollection GetDeletedKeyVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> GetDeletedKeyVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> GetDeletedKeyVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsm(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource>> GetDeletedManagedHsmAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedManagedHsmResource GetDeletedManagedHsmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedManagedHsmCollection GetDeletedManagedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsmsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> GetKeyVault(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> GetKeyVaultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource GetKeyVaultPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.KeyVaultResource GetKeyVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.KeyVaultCollection GetKeyVaults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.KeyVaultResource> GetKeyVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.KeyVaultResource> GetKeyVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.KeyVaultSecretResource GetKeyVaultSecretResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsm(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> GetManagedHsmAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource GetManagedHsmPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsmResource GetManagedHsmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsmCollection GetManagedHsms(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsmsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyVaultPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected KeyVaultPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KeyVaultPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>
    {
        public KeyVaultPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KeyVaultPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyVaultResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KeyVaultResource() { }
        public virtual Azure.ResourceManager.KeyVault.KeyVaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource> GetKeyVaultPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource>> GetKeyVaultPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionCollection GetKeyVaultPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultSecretResource> GetKeyVaultSecret(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultSecretResource>> GetKeyVaultSecretAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.KeyVaultSecretCollection GetKeyVaultSecrets() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.KeyVault.KeyVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.KeyVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> Update(Azure.ResourceManager.KeyVault.Models.KeyVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters> UpdateAccessPolicy(Azure.ResourceManager.KeyVault.Models.AccessPolicyUpdateKind operationKind, Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters keyVaultAccessPolicyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters>> UpdateAccessPolicyAsync(Azure.ResourceManager.KeyVault.Models.AccessPolicyUpdateKind operationKind, Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters keyVaultAccessPolicyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> UpdateAsync(Azure.ResourceManager.KeyVault.Models.KeyVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyVaultSecretCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.KeyVaultSecretResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.KeyVaultSecretResource>, System.Collections.IEnumerable
    {
        protected KeyVaultSecretCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultSecretResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string secretName, Azure.ResourceManager.KeyVault.Models.KeyVaultSecretCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.KeyVaultSecretResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string secretName, Azure.ResourceManager.KeyVault.Models.KeyVaultSecretCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultSecretResource> Get(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.KeyVaultSecretResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.KeyVaultSecretResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultSecretResource>> GetAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KeyVault.KeyVaultSecretResource> GetIfExists(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KeyVault.KeyVaultSecretResource>> GetIfExistsAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.KeyVaultSecretResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.KeyVaultSecretResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.KeyVaultSecretResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.KeyVaultSecretResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KeyVaultSecretData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>
    {
        public KeyVaultSecretData(Azure.ResourceManager.KeyVault.Models.SecretProperties properties) { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.SecretProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.KeyVaultSecretData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.KeyVaultSecretData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KeyVaultSecretResource() { }
        public virtual Azure.ResourceManager.KeyVault.KeyVaultSecretData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string secretName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultSecretResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultSecretResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.KeyVault.KeyVaultSecretData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.KeyVaultSecretData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.KeyVaultSecretData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultSecretResource> Update(Azure.ResourceManager.KeyVault.Models.KeyVaultSecretPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultSecretResource>> UpdateAsync(Azure.ResourceManager.KeyVault.Models.KeyVaultSecretPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedHsmCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmResource>, System.Collections.IEnumerable
    {
        protected ManagedHsmCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.KeyVault.ManagedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.KeyVault.ManagedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KeyVault.ManagedHsmResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.ManagedHsmResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.ManagedHsmResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedHsmData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.ManagedHsmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmData>
    {
        public ManagedHsmData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.ManagedHsmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.ManagedHsmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.ManagedHsmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.ManagedHsmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedHsmPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected ManagedHsmPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedHsmPrivateEndpointConnectionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>
    {
        public ManagedHsmPrivateEndpointConnectionData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedHsmPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedHsmPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedHsmResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.ManagedHsmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedHsmResource() { }
        public virtual Azure.ResourceManager.KeyVault.ManagedHsmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource> GetManagedHsmPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource>> GetManagedHsmPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionCollection GetManagedHsmPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData> GetMHSMPrivateLinkResourcesByManagedHsmResource(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData> GetMHSMPrivateLinkResourcesByManagedHsmResourceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion> GetMHSMRegionsByResource(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion> GetMHSMRegionsByResourceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.KeyVault.ManagedHsmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.ManagedHsmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.ManagedHsmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.ManagedHsmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.ManagedHsmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.ManagedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KeyVault.ManagedHsmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KeyVault.ManagedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.KeyVault.Mocking
{
    public partial class MockableKeyVaultArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableKeyVaultArmClient() { }
        public virtual Azure.ResourceManager.KeyVault.DeletedKeyVaultResource GetDeletedKeyVaultResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.DeletedManagedHsmResource GetDeletedManagedHsmResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionResource GetKeyVaultPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.KeyVaultResource GetKeyVaultResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.KeyVaultSecretResource GetKeyVaultSecretResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionResource GetManagedHsmPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.ManagedHsmResource GetManagedHsmResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableKeyVaultResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableKeyVaultResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource> GetKeyVault(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.KeyVaultResource>> GetKeyVaultAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.KeyVaultCollection GetKeyVaults() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsm(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsmResource>> GetManagedHsmAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.ManagedHsmCollection GetManagedHsms() { throw null; }
    }
    public partial class MockableKeyVaultSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableKeyVaultSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult> CheckKeyVaultNameAvailability(Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult>> CheckKeyVaultNameAvailabilityAsync(Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult> CheckManagedHsmNameAvailability(Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult>> CheckManagedHsmNameAvailabilityAsync(Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> GetDeletedKeyVault(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource>> GetDeletedKeyVaultAsync(Azure.Core.AzureLocation location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.DeletedKeyVaultCollection GetDeletedKeyVaults() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> GetDeletedKeyVaults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.DeletedKeyVaultResource> GetDeletedKeyVaultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsm(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource>> GetDeletedManagedHsmAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.DeletedManagedHsmCollection GetDeletedManagedHsms() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsms(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.DeletedManagedHsmResource> GetDeletedManagedHsmsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.KeyVaultResource> GetKeyVaults(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.KeyVaultResource> GetKeyVaultsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsms(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.ManagedHsmResource> GetManagedHsmsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.KeyVault.Models
{
    public enum AccessPolicyUpdateKind
    {
        Add = 0,
        Replace = 1,
        Remove = 2,
    }
    public static partial class ArmKeyVaultModelFactory
    {
        public static Azure.ResourceManager.KeyVault.DeletedKeyVaultData DeletedKeyVaultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.KeyVault.Models.DeletedKeyVaultProperties properties = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.DeletedKeyVaultProperties DeletedKeyVaultProperties(Azure.Core.ResourceIdentifier vaultId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledPurgeOn = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, bool? purgeProtectionEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedManagedHsmData DeletedManagedHsmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties properties = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties DeletedManagedHsmProperties(Azure.Core.ResourceIdentifier managedHsmId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledPurgeOn = default(System.DateTimeOffset?), bool? purgeProtectionEnabled = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters KeyVaultAccessPolicyParameters(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy> accessPolicies = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent KeyVaultCreateOrUpdateContent(Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.KeyVault.Models.KeyVaultProperties properties = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.KeyVaultData KeyVaultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.KeyVault.Models.KeyVaultProperties properties = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent KeyVaultNameAvailabilityContent(string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType)) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult KeyVaultNameAvailabilityResult(bool? nameAvailable = default(bool?), Azure.ResourceManager.KeyVault.Models.KeyVaultNameUnavailableReason? reason = default(Azure.ResourceManager.KeyVault.Models.KeyVaultNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData KeyVaultPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.KeyVault.KeyVaultPrivateEndpointConnectionData KeyVaultPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ETag? etag, Azure.Core.ResourceIdentifier privateEndpointId, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState connectionState, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState? provisioningState, Azure.Core.AzureLocation? location, System.Collections.Generic.IReadOnlyDictionary<string, string> tags) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionItemData KeyVaultPrivateEndpointConnectionItemData(string id = null, Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData KeyVaultPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData KeyVaultPrivateLinkResourceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string groupId, System.Collections.Generic.IEnumerable<string> requiredMembers, System.Collections.Generic.IEnumerable<string> requiredZoneNames, Azure.Core.AzureLocation? location, System.Collections.Generic.IReadOnlyDictionary<string, string> tags) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultProperties KeyVaultProperties(System.Guid tenantId = default(System.Guid), Azure.ResourceManager.KeyVault.Models.KeyVaultSku sku = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy> accessPolicies = null, System.Uri vaultUri = null, string hsmPoolResourceId = null, bool? enabledForDeployment = default(bool?), bool? enabledForDiskEncryption = default(bool?), bool? enabledForTemplateDeployment = default(bool?), bool? enableSoftDelete = default(bool?), int? softDeleteRetentionInDays = default(int?), bool? enableRbacAuthorization = default(bool?), Azure.ResourceManager.KeyVault.Models.KeyVaultCreateMode? createMode = default(Azure.ResourceManager.KeyVault.Models.KeyVaultCreateMode?), bool? enablePurgeProtection = default(bool?), Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet networkRuleSet = null, Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState? provisioningState = default(Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionItemData> privateEndpointConnections = null, string publicNetworkAccess = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultSecretCreateOrUpdateContent KeyVaultSecretCreateOrUpdateContent(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.KeyVault.Models.SecretProperties properties = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.KeyVaultSecretData KeyVaultSecretData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.KeyVault.Models.SecretProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.KeyVault.ManagedHsmData ManagedHsmData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties properties, Azure.ResourceManager.KeyVault.Models.ManagedHsmSku sku) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsmData ManagedHsmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties properties = null, Azure.ResourceManager.KeyVault.Models.ManagedHsmSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion ManagedHsmGeoReplicatedRegion(string name = null, Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState? provisioningState = default(Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState?), bool? isPrimary = default(bool?)) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult ManagedHsmNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.KeyVault.Models.ManagedHsmNameUnavailableReason? reason = default(Azure.ResourceManager.KeyVault.Models.ManagedHsmNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData ManagedHsmPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.KeyVault.Models.ManagedHsmSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData ManagedHsmPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, Azure.Core.ResourceIdentifier privateEndpointId, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState privateLinkServiceConnectionState, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState? provisioningState, Azure.ResourceManager.KeyVault.Models.ManagedHsmSku sku) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData ManagedHsmPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, Azure.Core.ResourceIdentifier privateEndpointId, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState privateLinkServiceConnectionState, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState? provisioningState, Azure.ResourceManager.KeyVault.Models.ManagedHsmSku sku, Azure.ResourceManager.Models.ManagedServiceIdentity identity) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionItemData ManagedHsmPrivateEndpointConnectionItemData(Azure.Core.ResourceIdentifier id = null, Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData ManagedHsmPrivateLinkResourceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string groupId, System.Collections.Generic.IEnumerable<string> requiredMembers, System.Collections.Generic.IEnumerable<string> requiredZoneNames, Azure.ResourceManager.KeyVault.Models.ManagedHsmSku sku) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData ManagedHsmPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, Azure.ResourceManager.KeyVault.Models.ManagedHsmSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties ManagedHsmProperties(System.Guid? tenantId = default(System.Guid?), System.Collections.Generic.IEnumerable<string> initialAdminObjectIds = null, System.Uri hsmUri = null, bool? enableSoftDelete = default(bool?), int? softDeleteRetentionInDays = default(int?), bool? enablePurgeProtection = default(bool?), Azure.ResourceManager.KeyVault.Models.ManagedHsmCreateMode? createMode = default(Azure.ResourceManager.KeyVault.Models.ManagedHsmCreateMode?), string statusMessage = null, Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState? provisioningState = default(Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState?), Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleSet networkRuleSet = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion> regions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionItemData> privateEndpointConnections = null, Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess?), System.DateTimeOffset? scheduledPurgeOn = default(System.DateTimeOffset?), Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainProperties securityDomainProperties = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainProperties ManagedHSMSecurityDomainProperties(Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus? activationStatus = default(Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus?), string activationStatusMessage = null) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.SecretAttributes SecretAttributes(bool? enabled = default(bool?), System.DateTimeOffset? notBefore = default(System.DateTimeOffset?), System.DateTimeOffset? expires = default(System.DateTimeOffset?), System.DateTimeOffset? created = default(System.DateTimeOffset?), System.DateTimeOffset? updated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.SecretBaseAttributes SecretBaseAttributes(bool? enabled = default(bool?), System.DateTimeOffset? notBefore = default(System.DateTimeOffset?), System.DateTimeOffset? expires = default(System.DateTimeOffset?), System.DateTimeOffset? created = default(System.DateTimeOffset?), System.DateTimeOffset? updated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.SecretProperties SecretProperties(string value = null, string contentType = null, Azure.ResourceManager.KeyVault.Models.SecretAttributes attributes = null, System.Uri secretUri = null, string secretUriWithVersion = null) { throw null; }
    }
    public partial class DeletedKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.DeletedKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.DeletedKeyVaultProperties>
    {
        internal DeletedKeyVaultProperties() { }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use DeletedOn.", false)]
        public System.DateTimeOffset? DeletionOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public bool? PurgeProtectionEnabled { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public Azure.Core.ResourceIdentifier VaultId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.DeletedKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.DeletedKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.DeletedKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.DeletedKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.DeletedKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.DeletedKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.DeletedKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeletedManagedHsmProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties>
    {
        internal DeletedManagedHsmProperties() { }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use DeletedOn.", false)]
        public System.DateTimeOffset? DeletionOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagedHsmId { get { throw null; } }
        public bool? PurgeProtectionEnabled { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityAccessCertificatePermission : System.IEquatable<Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityAccessCertificatePermission(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Create { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission DeleteIssuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission GetIssuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Import { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission ListIssuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission ManageContacts { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission ManageIssuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission SetIssuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityAccessKeyPermission : System.IEquatable<Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityAccessKeyPermission(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Create { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Decrypt { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Encrypt { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Getrotationpolicy { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Import { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Release { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Rotate { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Setrotationpolicy { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Sign { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission UnwrapKey { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Update { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission Verify { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission WrapKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IdentityAccessPermissions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions>
    {
        public IdentityAccessPermissions() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.IdentityAccessCertificatePermission> Certificates { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.IdentityAccessKeyPermission> Keys { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission> Secrets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission> Storage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityAccessSecretPermission : System.IEquatable<Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityAccessSecretPermission(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission Set { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessSecretPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityAccessStoragePermission : System.IEquatable<Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityAccessStoragePermission(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission DeleteSas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission GetSas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission ListSas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission RegenerateKey { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Set { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission SetSas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission left, Azure.ResourceManager.KeyVault.Models.IdentityAccessStoragePermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultAccessPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy>
    {
        public KeyVaultAccessPolicy(System.Guid tenantId, string objectId, Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions permissions) { }
        public System.Guid? ApplicationId { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.IdentityAccessPermissions Permissions { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultAccessPolicyParameters : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters>
    {
        public KeyVaultAccessPolicyParameters(Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyProperties properties) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy> AccessPolicies { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultAccessPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyProperties>
    {
        public KeyVaultAccessPolicyProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy> accessPolicies) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy> AccessPolicies { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultActionsRequiredMessage : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultActionsRequiredMessage(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage left, Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage left, Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum KeyVaultCreateMode
    {
        Default = 0,
        Recover = 1,
    }
    public partial class KeyVaultCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent>
    {
        public KeyVaultCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.KeyVault.Models.KeyVaultProperties properties) { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultIPRule>
    {
        public KeyVaultIPRule(string addressRange) { }
        public string AddressRange { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent>
    {
        public KeyVaultNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult>
    {
        internal KeyVaultNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum KeyVaultNameUnavailableReason
    {
        AccountNameInvalid = 0,
        AlreadyExists = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultNetworkRuleAction : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultNetworkRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction Allow { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction left, Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction left, Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultNetworkRuleBypassOption : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultNetworkRuleBypassOption(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption AzureServices { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption left, Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption left, Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultNetworkRuleSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet>
    {
        public KeyVaultNetworkRuleSet() { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleBypassOption? Bypass { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyVaultIPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyVaultVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatch>
    {
        public KeyVaultPatch() { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum KeyVaultPatchMode
    {
        Default = 0,
        Recover = 1,
    }
    public partial class KeyVaultPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatchProperties>
    {
        public KeyVaultPatchProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPatchMode? CreateMode { get { throw null; } set { } }
        public bool? EnabledForDeployment { get { throw null; } set { } }
        public bool? EnabledForDiskEncryption { get { throw null; } set { } }
        public bool? EnabledForTemplateDeployment { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableRbacAuthorization { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultSku Sku { get { throw null; } set { } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultPrivateEndpointConnectionItemData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionItemData>
    {
        internal KeyVaultPrivateEndpointConnectionItemData() { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState ConnectionState { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData>
    {
        public KeyVaultPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState>
    {
        public KeyVaultPrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultActionsRequiredMessage? ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultProperties>
    {
        public KeyVaultProperties(System.Guid tenantId, Azure.ResourceManager.KeyVault.Models.KeyVaultSku sku) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyVaultAccessPolicy> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultCreateMode? CreateMode { get { throw null; } set { } }
        public bool? EnabledForDeployment { get { throw null; } set { } }
        public bool? EnabledForDiskEncryption { get { throw null; } set { } }
        public bool? EnabledForTemplateDeployment { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableRbacAuthorization { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public string HsmPoolResourceId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.KeyVaultPrivateEndpointConnectionItemData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultSku Sku { get { throw null; } set { } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        public System.Uri VaultUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState RegisteringDns { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState left, Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState left, Azure.ResourceManager.KeyVault.Models.KeyVaultProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultSecretCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretCreateOrUpdateContent>
    {
        public KeyVaultSecretCreateOrUpdateContent(Azure.ResourceManager.KeyVault.Models.SecretProperties properties) { }
        public Azure.ResourceManager.KeyVault.Models.SecretProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultSecretCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultSecretCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretPatch>
    {
        public KeyVaultSecretPatch() { }
        public Azure.ResourceManager.KeyVault.Models.SecretPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultSecretPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultSecretPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSecretPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSku>
    {
        public KeyVaultSku(Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily family, Azure.ResourceManager.KeyVault.Models.KeyVaultSkuName name) { }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily Family { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.KeyVaultSkuName Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultSkuFamily : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultSkuFamily(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily A { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily left, Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily left, Azure.ResourceManager.KeyVault.Models.KeyVaultSkuFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum KeyVaultSkuName
    {
        Standard = 0,
        Premium = 1,
    }
    public partial class KeyVaultVirtualNetworkRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultVirtualNetworkRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultVirtualNetworkRule>
    {
        public KeyVaultVirtualNetworkRule(string id) { }
        public string Id { get { throw null; } set { } }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultVirtualNetworkRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultVirtualNetworkRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.KeyVaultVirtualNetworkRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.KeyVaultVirtualNetworkRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultVirtualNetworkRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultVirtualNetworkRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.KeyVaultVirtualNetworkRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmActionsRequiredMessage : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmActionsRequiredMessage(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage left, Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage left, Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ManagedHsmCreateMode
    {
        Default = 0,
        Recover = 1,
    }
    public partial class ManagedHsmGeoReplicatedRegion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion>
    {
        public ManagedHsmGeoReplicatedRegion() { }
        public bool? IsPrimary { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmGeoReplicatedRegionProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmGeoReplicatedRegionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState Cleanup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState Preprovisioning { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState left, Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState left, Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedHsmIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmIPRule>
    {
        public ManagedHsmIPRule(string addressRange) { }
        public string AddressRange { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedHsmNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityContent>
    {
        public ManagedHsmNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedHsmNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult>
    {
        internal ManagedHsmNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmNameUnavailableReason : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmNameUnavailableReason AccountNameInvalid { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmNameUnavailableReason AlreadyExists { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmNameUnavailableReason left, Azure.ResourceManager.KeyVault.Models.ManagedHsmNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmNameUnavailableReason left, Azure.ResourceManager.KeyVault.Models.ManagedHsmNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmNetworkRuleAction : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmNetworkRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction Allow { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction left, Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction left, Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmNetworkRuleBypassOption : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmNetworkRuleBypassOption(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption AzureServices { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption left, Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption left, Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedHsmNetworkRuleSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleSet>
    {
        public ManagedHsmNetworkRuleSet() { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleBypassOption? Bypass { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.ManagedHsmIPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.ManagedHsmServiceTagRule> ServiceTags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.ManagedHsmVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedHsmPrivateEndpointConnectionItemData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionItemData>
    {
        internal ManagedHsmPrivateEndpointConnectionItemData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedHsmPrivateLinkResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData>
    {
        public ManagedHsmPrivateLinkResourceData(Azure.Core.AzureLocation location) { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedHsmPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState>
    {
        public ManagedHsmPrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmActionsRequiredMessage? ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedHsmProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties>
    {
        public ManagedHsmProperties() { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmCreateMode? CreateMode { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public System.Uri HsmUri { get { throw null; } }
        public System.Collections.Generic.IList<string> InitialAdminObjectIds { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateEndpointConnectionItemData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.ManagedHsmGeoReplicatedRegion> Regions { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainProperties SecurityDomainProperties { get { throw null; } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        public string StatusMessage { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Activated { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Restoring { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState SecurityDomainRestore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState left, Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState left, Azure.ResourceManager.KeyVault.Models.ManagedHsmProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess left, Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess left, Azure.ResourceManager.KeyVault.Models.ManagedHsmPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHSMSecurityDomainActivationStatus : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHSMSecurityDomainActivationStatus(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus Active { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus NotActivated { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus left, Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus left, Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedHSMSecurityDomainProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainProperties>
    {
        internal ManagedHSMSecurityDomainProperties() { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainActivationStatus? ActivationStatus { get { throw null; } }
        public string ActivationStatusMessage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHSMSecurityDomainProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedHsmServiceTagRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmServiceTagRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmServiceTagRule>
    {
        public ManagedHsmServiceTagRule(string tag) { }
        public string Tag { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmServiceTagRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmServiceTagRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmServiceTagRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmServiceTagRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmServiceTagRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmServiceTagRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmServiceTagRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedHsmSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmSku>
    {
        public ManagedHsmSku(Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily family, Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuName name) { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily Family { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuName Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmSkuFamily : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmSkuFamily(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily B { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily C { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily left, Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily left, Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ManagedHsmSkuName
    {
        StandardB1 = 0,
        CustomB32 = 1,
        CustomB6 = 2,
        CustomC42 = 3,
        CustomC10 = 4,
    }
    public partial class ManagedHsmVirtualNetworkRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmVirtualNetworkRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmVirtualNetworkRule>
    {
        public ManagedHsmVirtualNetworkRule(Azure.Core.ResourceIdentifier subnetId) { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmVirtualNetworkRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmVirtualNetworkRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmVirtualNetworkRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.ManagedHsmVirtualNetworkRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmVirtualNetworkRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmVirtualNetworkRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.ManagedHsmVirtualNetworkRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretAttributes : Azure.ResourceManager.KeyVault.Models.SecretBaseAttributes, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.SecretAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretAttributes>
    {
        public SecretAttributes() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.SecretAttributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.SecretAttributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.SecretAttributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.SecretAttributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretAttributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretAttributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretAttributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretBaseAttributes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.SecretBaseAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretBaseAttributes>
    {
        public SecretBaseAttributes() { }
        public System.DateTimeOffset? Created { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? Expires { get { throw null; } set { } }
        public System.DateTimeOffset? NotBefore { get { throw null; } set { } }
        public System.DateTimeOffset? Updated { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.SecretBaseAttributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.SecretBaseAttributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.SecretBaseAttributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.SecretBaseAttributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretBaseAttributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretBaseAttributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretBaseAttributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.SecretPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretPatchProperties>
    {
        public SecretPatchProperties() { }
        public Azure.ResourceManager.KeyVault.Models.SecretAttributes Attributes { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.SecretPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.SecretPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.SecretPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.SecretPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.SecretProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretProperties>
    {
        public SecretProperties() { }
        public Azure.ResourceManager.KeyVault.Models.SecretAttributes Attributes { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public System.Uri SecretUri { get { throw null; } }
        public string SecretUriWithVersion { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.SecretProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.SecretProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KeyVault.Models.SecretProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KeyVault.Models.SecretProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KeyVault.Models.SecretProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
