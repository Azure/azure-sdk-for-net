namespace Azure.ResourceManager.OnlineExperimentation
{
    public static partial class OnlineExperimentationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> GetOnlineExperimentWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>> GetOnlineExperimentWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource GetOnlineExperimentWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceCollection GetOnlineExperimentWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> GetOnlineExperimentWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> GetOnlineExperimentWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineExperimentWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>, System.Collections.IEnumerable
    {
        protected OnlineExperimentWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OnlineExperimentWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>
    {
        public OnlineExperimentWorkspaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspaceProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnlineExperimentWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OnlineExperimentWorkspaceResource() { }
        public virtual Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.OnlineExperimentation.Mocking
{
    public partial class MockableOnlineExperimentationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableOnlineExperimentationArmClient() { }
        public virtual Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource GetOnlineExperimentWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableOnlineExperimentationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableOnlineExperimentationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> GetOnlineExperimentWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource>> GetOnlineExperimentWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceCollection GetOnlineExperimentWorkspaces() { throw null; }
    }
    public partial class MockableOnlineExperimentationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableOnlineExperimentationSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> GetOnlineExperimentWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceResource> GetOnlineExperimentWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.OnlineExperimentation.Models
{
    public static partial class ArmOnlineExperimentationModelFactory
    {
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku OnlineExperimentationWorkspaceSku(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName name = default(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName), Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier? tier = default(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier?)) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.OnlineExperimentWorkspaceData OnlineExperimentWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspaceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku sku = null) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspaceProperties OnlineExperimentWorkspaceProperties(string workspaceId = null, Azure.ResourceManager.OnlineExperimentation.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OnlineExperimentation.Models.ResourceProvisioningState?), Azure.Core.ResourceIdentifier logAnalyticsWorkspaceResourceId = null, Azure.Core.ResourceIdentifier logsExporterStorageAccountResourceId = null, Azure.Core.ResourceIdentifier appConfigurationResourceId = null, Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption customerManagedKeyEncryption = null, System.Uri endpoint = null) { throw null; }
    }
    public partial class CustomerManagedKeyEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>
    {
        public CustomerManagedKeyEncryption() { }
        public Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public System.Uri KeyEncryptionKeyUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyEncryptionKeyIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>
    {
        public KeyEncryptionKeyIdentity() { }
        public System.Guid? FederatedClientId { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType? IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyEncryptionKeyIdentityType : System.IEquatable<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyEncryptionKeyIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType left, Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType left, Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OnlineExperimentationWorkspaceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>
    {
        public OnlineExperimentationWorkspaceSku(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName name) { }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier? Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnlineExperimentationWorkspaceSkuName : System.IEquatable<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnlineExperimentationWorkspaceSkuName(string value) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName D0 { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName F0 { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName P0 { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName S0 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnlineExperimentationWorkspaceSkuTier : System.IEquatable<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnlineExperimentationWorkspaceSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier Developer { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier Free { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OnlineExperimentWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatch>
    {
        public OnlineExperimentWorkspacePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatchProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnlineExperimentWorkspacePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatchProperties>
    {
        public OnlineExperimentWorkspacePatchProperties() { }
        public Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption CustomerManagedKeyEncryption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogsExporterStorageAccountResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspacePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnlineExperimentWorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspaceProperties>
    {
        public OnlineExperimentWorkspaceProperties(Azure.Core.ResourceIdentifier logAnalyticsWorkspaceResourceId, Azure.Core.ResourceIdentifier logsExporterStorageAccountResourceId, Azure.Core.ResourceIdentifier appConfigurationResourceId) { }
        public Azure.Core.ResourceIdentifier AppConfigurationResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption CustomerManagedKeyEncryption { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } }
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogsExporterStorageAccountResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentWorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.OnlineExperimentation.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OnlineExperimentation.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OnlineExperimentation.Models.ResourceProvisioningState left, Azure.ResourceManager.OnlineExperimentation.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OnlineExperimentation.Models.ResourceProvisioningState left, Azure.ResourceManager.OnlineExperimentation.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
