namespace Azure.ResourceManager.VerifiedId
{
    public partial class AzureResourceManagerVerifiedIdContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerVerifiedIdContext() { }
        public static Azure.ResourceManager.VerifiedId.AzureResourceManagerVerifiedIdContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class VerifiedIdAuthorityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>, System.Collections.IEnumerable
    {
        protected VerifiedIdAuthorityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorityName, Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorityName, Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> Get(string authorityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>> GetAsync(string authorityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> GetIfExists(string authorityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>> GetIfExistsAsync(string authorityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VerifiedIdAuthorityData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>
    {
        public VerifiedIdAuthorityData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState? AuthorityProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VerifiedIdAuthorityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VerifiedIdAuthorityResource() { }
        public virtual Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string authorityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> Update(Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>> UpdateAsync(Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class VerifiedIdExtensions
    {
        public static Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityCollection GetVerifiedIdAuthorities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> GetVerifiedIdAuthorities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> GetVerifiedIdAuthoritiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> GetVerifiedIdAuthority(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string authorityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>> GetVerifiedIdAuthorityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string authorityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource GetVerifiedIdAuthorityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.VerifiedId.Mocking
{
    public partial class MockableVerifiedIdArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableVerifiedIdArmClient() { }
        public virtual Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource GetVerifiedIdAuthorityResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableVerifiedIdResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableVerifiedIdResourceGroupResource() { }
        public virtual Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityCollection GetVerifiedIdAuthorities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> GetVerifiedIdAuthority(string authorityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource>> GetVerifiedIdAuthorityAsync(string authorityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableVerifiedIdSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableVerifiedIdSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> GetVerifiedIdAuthorities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityResource> GetVerifiedIdAuthoritiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.VerifiedId.Models
{
    public static partial class ArmVerifiedIdModelFactory
    {
        public static Azure.ResourceManager.VerifiedId.VerifiedIdAuthorityData VerifiedIdAuthorityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState? authorityProvisioningState = default(Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch VerifiedIdAuthorityPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
    }
    public partial class VerifiedIdAuthorityPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch>
    {
        public VerifiedIdAuthorityPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VerifiedIdAuthorityProvisioningState : System.IEquatable<Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VerifiedIdAuthorityProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState left, Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState left, Azure.ResourceManager.VerifiedId.Models.VerifiedIdAuthorityProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
