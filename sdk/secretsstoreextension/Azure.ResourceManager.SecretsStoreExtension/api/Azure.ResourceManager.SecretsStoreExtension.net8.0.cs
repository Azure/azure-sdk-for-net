namespace Azure.ResourceManager.SecretsStoreExtension
{
    public partial class AzureResourceManagerSecretsStoreExtensionContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSecretsStoreExtensionContext() { }
        public static Azure.ResourceManager.SecretsStoreExtension.AzureResourceManagerSecretsStoreExtensionContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class KeyVaultSecretProviderClassCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>, System.Collections.IEnumerable
    {
        protected KeyVaultSecretProviderClassCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureKeyVaultSecretProviderClassName, Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureKeyVaultSecretProviderClassName, Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureKeyVaultSecretProviderClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureKeyVaultSecretProviderClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> Get(string azureKeyVaultSecretProviderClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>> GetAsync(string azureKeyVaultSecretProviderClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> GetIfExists(string azureKeyVaultSecretProviderClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>> GetIfExistsAsync(string azureKeyVaultSecretProviderClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KeyVaultSecretProviderClassData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>
    {
        public KeyVaultSecretProviderClassData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretProviderClassResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KeyVaultSecretProviderClassResource() { }
        public virtual Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureKeyVaultSecretProviderClassName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SecretsStoreExtensionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> GetKeyVaultSecretProviderClass(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureKeyVaultSecretProviderClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>> GetKeyVaultSecretProviderClassAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureKeyVaultSecretProviderClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassCollection GetKeyVaultSecretProviderClasses(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> GetKeyVaultSecretProviderClasses(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> GetKeyVaultSecretProviderClassesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource GetKeyVaultSecretProviderClassResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> GetSecretSync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string secretSyncName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>> GetSecretSyncAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string secretSyncName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource GetSecretSyncResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecretsStoreExtension.SecretSyncCollection GetSecretSyncs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> GetSecretSyncs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> GetSecretSyncsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecretSyncCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>, System.Collections.IEnumerable
    {
        protected SecretSyncCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string secretSyncName, Azure.ResourceManager.SecretsStoreExtension.SecretSyncData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string secretSyncName, Azure.ResourceManager.SecretsStoreExtension.SecretSyncData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string secretSyncName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string secretSyncName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> Get(string secretSyncName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>> GetAsync(string secretSyncName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> GetIfExists(string secretSyncName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>> GetIfExistsAsync(string secretSyncName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecretSyncData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>
    {
        public SecretSyncData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.SecretSyncData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.SecretSyncData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretSyncResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecretSyncResource() { }
        public virtual Azure.ResourceManager.SecretsStoreExtension.SecretSyncData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string secretSyncName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SecretsStoreExtension.SecretSyncData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.SecretSyncData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.SecretSyncData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SecretsStoreExtension.Mocking
{
    public partial class MockableSecretsStoreExtensionArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSecretsStoreExtensionArmClient() { }
        public virtual Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource GetKeyVaultSecretProviderClassResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource GetSecretSyncResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSecretsStoreExtensionResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSecretsStoreExtensionResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> GetKeyVaultSecretProviderClass(string azureKeyVaultSecretProviderClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource>> GetKeyVaultSecretProviderClassAsync(string azureKeyVaultSecretProviderClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassCollection GetKeyVaultSecretProviderClasses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> GetSecretSync(string secretSyncName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource>> GetSecretSyncAsync(string secretSyncName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecretsStoreExtension.SecretSyncCollection GetSecretSyncs() { throw null; }
    }
    public partial class MockableSecretsStoreExtensionSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSecretsStoreExtensionSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> GetKeyVaultSecretProviderClasses(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassResource> GetKeyVaultSecretProviderClassesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> GetSecretSyncs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecretsStoreExtension.SecretSyncResource> GetSecretSyncsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SecretsStoreExtension.Models
{
    public static partial class ArmSecretsStoreExtensionModelFactory
    {
        public static Azure.ResourceManager.SecretsStoreExtension.KeyVaultSecretProviderClassData KeyVaultSecretProviderClassData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassProperties KeyVaultSecretProviderClassProperties(string keyvaultName = null, System.Guid clientId = default(System.Guid), System.Guid tenantId = default(System.Guid), string objects = null, Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState? provisioningState = default(Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncCondition SecretSyncCondition(System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), string message = null, long? observedGeneration = default(long?), string reason = null, Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncConditionStatusType status = default(Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncConditionStatusType), string type = null) { throw null; }
        public static Azure.ResourceManager.SecretsStoreExtension.SecretSyncData SecretSyncData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncProperties SecretSyncProperties(string secretProviderClassName = null, string serviceAccountName = null, Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretType kubernetesSecretType = default(Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretType), string forceSynchronization = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretObjectMapping> objectSecretMapping = null, Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncStatus status = null, Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState? provisioningState = default(Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncStatus SecretSyncStatus(System.DateTimeOffset? lastSuccessfulSyncOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncCondition> conditions = null) { throw null; }
    }
    public partial class AzureKeyVaultSecretProviderClassUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.AzureKeyVaultSecretProviderClassUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.AzureKeyVaultSecretProviderClassUpdateProperties>
    {
        public AzureKeyVaultSecretProviderClassUpdateProperties() { }
        public System.Guid? ClientId { get { throw null; } set { } }
        public string KeyvaultName { get { throw null; } set { } }
        public string Objects { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.AzureKeyVaultSecretProviderClassUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.AzureKeyVaultSecretProviderClassUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.AzureKeyVaultSecretProviderClassUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.AzureKeyVaultSecretProviderClassUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.AzureKeyVaultSecretProviderClassUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.AzureKeyVaultSecretProviderClassUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.AzureKeyVaultSecretProviderClassUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretProviderClassPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassPatch>
    {
        public KeyVaultSecretProviderClassPatch() { }
        public Azure.ResourceManager.SecretsStoreExtension.Models.AzureKeyVaultSecretProviderClassUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretProviderClassProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassProperties>
    {
        public KeyVaultSecretProviderClassProperties(string keyvaultName, System.Guid clientId, System.Guid tenantId) { }
        public System.Guid ClientId { get { throw null; } set { } }
        public string KeyvaultName { get { throw null; } set { } }
        public string Objects { get { throw null; } set { } }
        public Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.KeyVaultSecretProviderClassProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesSecretObjectMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretObjectMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretObjectMapping>
    {
        public KubernetesSecretObjectMapping(string sourcePath, string targetKey) { }
        public string SourcePath { get { throw null; } set { } }
        public string TargetKey { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretObjectMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretObjectMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretObjectMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretObjectMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretObjectMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretObjectMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretObjectMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesSecretType : System.IEquatable<Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesSecretType(string value) { throw null; }
        public static Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretType Opaque { get { throw null; } }
        public static Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretType Tls { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretType left, Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretType left, Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretsStoreExtensionProvisioningState : System.IEquatable<Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretsStoreExtensionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState left, Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState left, Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretSyncCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncCondition>
    {
        internal SecretSyncCondition() { }
        public System.DateTimeOffset? LastTransitionOn { get { throw null; } }
        public string Message { get { throw null; } }
        public long? ObservedGeneration { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncConditionStatusType Status { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretSyncConditionStatusType : System.IEquatable<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncConditionStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretSyncConditionStatusType(string value) { throw null; }
        public static Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncConditionStatusType False { get { throw null; } }
        public static Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncConditionStatusType True { get { throw null; } }
        public static Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncConditionStatusType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncConditionStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncConditionStatusType left, Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncConditionStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncConditionStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncConditionStatusType left, Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncConditionStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretSyncPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncPatch>
    {
        public SecretSyncPatch() { }
        public Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretSyncProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncProperties>
    {
        public SecretSyncProperties(string secretProviderClassName, string serviceAccountName, Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretType kubernetesSecretType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretObjectMapping> objectSecretMapping) { }
        public string ForceSynchronization { get { throw null; } set { } }
        public Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretType KubernetesSecretType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretObjectMapping> ObjectSecretMapping { get { throw null; } }
        public Azure.ResourceManager.SecretsStoreExtension.Models.SecretsStoreExtensionProvisioningState? ProvisioningState { get { throw null; } }
        public string SecretProviderClassName { get { throw null; } set { } }
        public string ServiceAccountName { get { throw null; } set { } }
        public Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretSyncStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncStatus>
    {
        internal SecretSyncStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncCondition> Conditions { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulSyncOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretSyncUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncUpdateProperties>
    {
        public SecretSyncUpdateProperties() { }
        public string ForceSynchronization { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecretsStoreExtension.Models.KubernetesSecretObjectMapping> ObjectSecretMapping { get { throw null; } }
        public string SecretProviderClassName { get { throw null; } set { } }
        public string ServiceAccountName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecretsStoreExtension.Models.SecretSyncUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
