namespace Azure.ResourceManager.DevCenter
{
    public partial class AllowedEnvironmentTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>, System.Collections.IEnumerable
    {
        protected AllowedEnvironmentTypeCollection() { }
        public virtual Azure.Response<bool> Exists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> Get(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>> GetAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> GetIfExists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>> GetIfExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AllowedEnvironmentTypeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>
    {
        public AllowedEnvironmentTypeData() { }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AllowedEnvironmentTypeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AllowedEnvironmentTypeResource() { }
        public virtual Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string environmentTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttachedNetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected AttachedNetworkConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string attachedNetworkConnectionName, Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string attachedNetworkConnectionName, Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> Get(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>> GetAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> GetIfExists(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>> GetIfExistsAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AttachedNetworkConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>
    {
        public AttachedNetworkConnectionData() { }
        public Azure.ResourceManager.DevCenter.Models.DomainJoinType? DomainJoinType { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? HealthCheckStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkConnectionId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? NetworkConnectionLocation { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttachedNetworkConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AttachedNetworkConnectionResource() { }
        public virtual Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string attachedNetworkConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerDevCenterContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDevCenterContext() { }
        public static Azure.ResourceManager.DevCenter.AzureResourceManagerDevCenterContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DevBoxDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>, System.Collections.IEnumerable
    {
        protected DevBoxDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string devBoxDefinitionName, Azure.ResourceManager.DevCenter.DevBoxDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string devBoxDefinitionName, Azure.ResourceManager.DevCenter.DevBoxDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> Get(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> GetAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> GetIfExists(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> GetIfExistsAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevBoxDefinitionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>
    {
        public DevBoxDefinitionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ActiveImageReference { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? HibernateSupport { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails ImageValidationErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? ImageValidationStatus { get { throw null; } }
        public string OSStorageType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus? ValidationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevBoxDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevBoxDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevBoxDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevBoxDefinitionResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevBoxDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string devBoxDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevBoxDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevBoxDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterCatalogCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>, System.Collections.IEnumerable
    {
        protected DevCenterCatalogCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.DevCenter.DevCenterCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.DevCenter.DevCenterCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> Get(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> GetAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> GetIfExists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> GetIfExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterCatalogData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>
    {
        public DevCenterCatalogData() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog AdoGit { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus? AutoImageBuildEnableStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConnectionState? ConnectionState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog GitHub { get { throw null; } set { } }
        public System.DateTimeOffset? LastConnectionOn { get { throw null; } }
        public System.DateTimeOffset? LastSyncOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats LastSyncStats { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState? SyncState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType? SyncType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterCatalogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterCatalogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterCatalogEnvironmentDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource>, System.Collections.IEnumerable
    {
        protected DevCenterCatalogEnvironmentDefinitionCollection() { }
        public virtual Azure.Response<bool> Exists(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource> Get(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource>> GetAsync(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource> GetIfExists(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource>> GetIfExistsAsync(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterCatalogEnvironmentDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterCatalogEnvironmentDefinitionResource() { }
        public virtual Azure.ResourceManager.DevCenter.EnvironmentDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string catalogName, string environmentDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails> GetErrorDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails>> GetErrorDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.EnvironmentDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.EnvironmentDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterCatalogImageDefinitionBuildCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource>, System.Collections.IEnumerable
    {
        protected DevCenterCatalogImageDefinitionBuildCollection() { }
        public virtual Azure.Response<bool> Exists(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource> Get(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource>> GetAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource> GetIfExists(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource>> GetIfExistsAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterCatalogImageDefinitionBuildResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterCatalogImageDefinitionBuildResource() { }
        public virtual Azure.ResourceManager.DevCenter.ImageDefinitionBuildData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string catalogName, string imageDefinitionName, string buildName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails> GetBuildDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails>> GetBuildDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.ImageDefinitionBuildData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.ImageDefinitionBuildData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterCatalogImageDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource>, System.Collections.IEnumerable
    {
        protected DevCenterCatalogImageDefinitionCollection() { }
        public virtual Azure.Response<bool> Exists(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource> Get(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource>> GetAsync(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource> GetIfExists(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource>> GetIfExistsAsync(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterCatalogImageDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterCatalogImageDefinitionResource() { }
        public virtual Azure.ResourceManager.DevCenter.ImageDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation BuildImage(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BuildImageAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string catalogName, string imageDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource> GetDevCenterCatalogImageDefinitionBuild(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource>> GetDevCenterCatalogImageDefinitionBuildAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildCollection GetDevCenterCatalogImageDefinitionBuilds() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails> GetErrorDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails>> GetErrorDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.ImageDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.ImageDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterCatalogResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterCatalogResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Connect(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ConnectAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string catalogName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource> GetDevCenterCatalogEnvironmentDefinition(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource>> GetDevCenterCatalogEnvironmentDefinitionAsync(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionCollection GetDevCenterCatalogEnvironmentDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource> GetDevCenterCatalogImageDefinition(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource>> GetDevCenterCatalogImageDefinitionAsync(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionCollection GetDevCenterCatalogImageDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource> GetDevCenterCatalogTask(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource>> GetDevCenterCatalogTaskAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogTaskCollection GetDevCenterCatalogTasks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails> GetSyncErrorDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails>> GetSyncErrorDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Sync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SyncAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterCatalogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterCatalogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterCatalogTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource>, System.Collections.IEnumerable
    {
        protected DevCenterCatalogTaskCollection() { }
        public virtual Azure.Response<bool> Exists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource> Get(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource>> GetAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource> GetIfExists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource>> GetIfExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterCatalogTaskData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>
    {
        internal DevCenterCatalogTaskData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput> Inputs { get { throw null; } }
        public int? Timeout { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus? ValidationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterCatalogTaskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterCatalogTaskResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string catalogName, string taskName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails> GetErrorDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails>> GetErrorDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterResource>, System.Collections.IEnumerable
    {
        protected DevCenterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string devCenterName, Azure.ResourceManager.DevCenter.DevCenterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string devCenterName, Azure.ResourceManager.DevCenter.DevCenterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> Get(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> GetAsync(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterResource> GetIfExists(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterResource>> GetIfExistsAsync(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterData>
    {
        public DevCenterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus? CatalogItemSyncEnableStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption CustomerManagedKeyEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus? DevBoxProvisioningInstallAzureMonitorAgentEnableStatus { get { throw null; } set { } }
        public System.Uri DevCenterUri { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus? MicrosoftHostedNetworkEnableStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterEncryptionSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource>, System.Collections.IEnumerable
    {
        protected DevCenterEncryptionSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string encryptionSetName, Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string encryptionSetName, Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string encryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string encryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource> Get(string encryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource>> GetAsync(string encryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource> GetIfExists(string encryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource>> GetIfExistsAsync(string encryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterEncryptionSetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>
    {
        public DevCenterEncryptionSetData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus? DevboxDisksEncryptionEnableStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public System.Uri KeyEncryptionKeyUri { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterEncryptionSetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterEncryptionSetResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string encryptionSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterEnvironmentTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>, System.Collections.IEnumerable
    {
        protected DevCenterEnvironmentTypeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string environmentTypeName, Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string environmentTypeName, Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> Get(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> GetAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> GetIfExists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> GetIfExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterEnvironmentTypeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>
    {
        public DevCenterEnvironmentTypeData() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterEnvironmentTypeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterEnvironmentTypeResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string environmentTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> Update(Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> UpdateAsync(Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DevCenterExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult> CheckDevCenterNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>> CheckDevCenterNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult> Execute(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>> ExecuteAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource GetAllowedEnvironmentTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource GetAttachedNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevBoxDefinitionResource GetDevBoxDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCenter(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> GetDevCenterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource GetDevCenterCatalogEnvironmentDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource GetDevCenterCatalogImageDefinitionBuildResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource GetDevCenterCatalogImageDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCatalogResource GetDevCenterCatalogResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource GetDevCenterCatalogTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource GetDevCenterEncryptionSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource GetDevCenterEnvironmentTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterGalleryResource GetDevCenterGalleryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterImageResource GetDevCenterImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetDevCenterNetworkConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> GetDevCenterNetworkConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource GetDevCenterNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionCollection GetDevCenterNetworkConnections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetDevCenterNetworkConnections(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetDevCenterNetworkConnectionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus> GetDevCenterOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>> GetDevCenterOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterPoolResource GetDevCenterPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetDevCenterProject(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> GetDevCenterProjectAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource GetDevCenterProjectEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource GetDevCenterProjectPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectResource GetDevCenterProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectCollection GetDevCenterProjects(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetDevCenterProjects(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetDevCenterProjectsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterResource GetDevCenterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCollection GetDevCenters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCenters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCentersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterScheduleResource GetDevCenterScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetDevCenterSkusBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetDevCenterSkusBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.Models.DevCenterUsage> GetDevCenterUsagesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.DevCenterUsage> GetDevCenterUsagesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.HealthCheckStatusDetailResource GetHealthCheckStatusDetailResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ImageVersionResource GetImageVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource GetProjectAttachedNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource GetProjectCatalogEnvironmentDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource GetProjectCatalogImageDefinitionBuildResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource GetProjectCatalogImageDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectCatalogResource GetProjectCatalogResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource GetProjectDevBoxDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectImageResource GetProjectImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectImageVersionResource GetProjectImageVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DevCenterGalleryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>, System.Collections.IEnumerable
    {
        protected DevCenterGalleryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryName, Azure.ResourceManager.DevCenter.DevCenterGalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryName, Azure.ResourceManager.DevCenter.DevCenterGalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> Get(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>> GetAsync(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> GetIfExists(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>> GetIfExistsAsync(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterGalleryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>
    {
        public DevCenterGalleryData() { }
        public Azure.Core.ResourceIdentifier GalleryResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterGalleryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterGalleryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterGalleryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterGalleryResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterGalleryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string galleryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetDevCenterImage(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterImageResource>> GetDevCenterImageAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterImageCollection GetDevCenterImages() { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterGalleryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterGalleryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterGalleryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.DevCenterGalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.DevCenterGalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterImageResource>, System.Collections.IEnumerable
    {
        protected DevCenterImageCollection() { }
        public virtual Azure.Response<bool> Exists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterImageResource> Get(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterImageResource>> GetAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetIfExists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterImageResource>> GetIfExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterImageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>
    {
        public DevCenterImageData() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterArchitectureType? Architecture { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? HibernateSupport { get { throw null; } }
        public string Offer { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration RecommendedMachineConfiguration { get { throw null; } }
        public string Sku { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterImageResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string galleryName, string imageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource> GetImageVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource>> GetImageVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ImageVersionCollection GetImageVersions() { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterNetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected DevCenterNetworkConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkConnectionName, Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkConnectionName, Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> Get(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> GetAsync(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetIfExists(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> GetIfExistsAsync(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterNetworkConnectionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>
    {
        public DevCenterNetworkConnectionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevCenter.Models.DomainJoinType? DomainJoinType { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public string DomainPassword { get { throw null; } set { } }
        public string DomainUsername { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? HealthCheckStatus { get { throw null; } }
        public string NetworkingResourceGroupName { get { throw null; } set { } }
        public string OrganizationUnit { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterNetworkConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterNetworkConnectionResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.HealthCheckStatusDetailResource GetHealthCheckStatusDetail() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint> GetOutboundEnvironmentEndpoints(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint> GetOutboundEnvironmentEndpointsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RunHealthChecks(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RunHealthChecksAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterPoolResource>, System.Collections.IEnumerable
    {
        protected DevCenterPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.DevCenter.DevCenterPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.DevCenter.DevCenterPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterPoolResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterPoolResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterPoolResource> GetIfExists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> GetIfExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>
    {
        public DevCenterPoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration ActiveHoursConfiguration { get { throw null; } set { } }
        public int? DevBoxCount { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail DevBoxDefinition { get { throw null; } set { } }
        public string DevBoxDefinitionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType? DevBoxDefinitionType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus? DevBoxTunnelEnableStatus { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus? HealthStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail> HealthStatusDetails { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? LocalAdministrator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedVirtualNetworkRegions { get { throw null; } }
        public string NetworkConnectionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus? SingleSignOnStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration StopOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration StopOnNoConnect { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType? VirtualNetworkType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterPoolResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string poolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetDevCenterSchedule(string scheduleName, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetDevCenterSchedule(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetDevCenterScheduleAsync(string scheduleName, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetDevCenterScheduleAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterScheduleCollection GetDevCenterSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RunHealthChecks(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RunHealthChecksAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectResource>, System.Collections.IEnumerable
    {
        protected DevCenterProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.DevCenter.DevCenterProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.DevCenter.DevCenterProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetIfExists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> GetIfExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterProjectData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>
    {
        public DevCenterProjectData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup> AssignedGroups { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode? AzureAiServicesMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType> CatalogItemSyncTypes { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings CustomizationSettings { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings DevBoxScheduleDeleteSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DevCenterId { get { throw null; } set { } }
        public System.Uri DevCenterUri { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public int? MaxDevBoxesPerUser { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings ServerlessGpuSessionsSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode? WorkspaceStorageMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterProjectEnvironmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>, System.Collections.IEnumerable
    {
        protected DevCenterProjectEnvironmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string environmentTypeName, Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string environmentTypeName, Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> Get(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> GetAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> GetIfExists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> GetIfExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterProjectEnvironmentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>
    {
        public DevCenterProjectEnvironmentData(Azure.Core.AzureLocation location) { }
        public Azure.Core.ResourceIdentifier DeploymentTargetId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public int? EnvironmentCount { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> Roles { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments> UserRoleAssignments { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterProjectEnvironmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterProjectEnvironmentResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string environmentTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> Update(Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> UpdateAsync(Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterProjectPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource>, System.Collections.IEnumerable
    {
        protected DevCenterProjectPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectPolicyName, Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectPolicyName, Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource> Get(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource>> GetAsync(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource> GetIfExists(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource>> GetIfExistsAsync(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterProjectPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>
    {
        public DevCenterProjectPolicyData() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies ConfigurationPolicies { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy> ResourcePolicies { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterProjectPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterProjectPolicyResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string projectPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterProjectPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterProjectPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterProjectResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterProjectResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> GetAllowedEnvironmentType(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>> GetAllowedEnvironmentTypeAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeCollection GetAllowedEnvironmentTypes() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetByProject(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetByProjectAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource> GetDevCenterPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> GetDevCenterPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterPoolCollection GetDevCenterPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> GetDevCenterProjectEnvironment(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> GetDevCenterProjectEnvironmentAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentCollection GetDevCenterProjectEnvironments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject> GetInheritedSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject>> GetInheritedSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> GetProjectAttachedNetworkConnection(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>> GetProjectAttachedNetworkConnectionAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionCollection GetProjectAttachedNetworkConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogResource> GetProjectCatalog(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogResource>> GetProjectCatalogAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogCollection GetProjectCatalogs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> GetProjectDevBoxDefinition(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>> GetProjectDevBoxDefinitionAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionCollection GetProjectDevBoxDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageResource> GetProjectImage(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageResource>> GetProjectImageAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectImageCollection GetProjectImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> GetAttachedNetworkConnection(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>> GetAttachedNetworkConnectionAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.AttachedNetworkConnectionCollection GetAttachedNetworkConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> GetDevBoxDefinition(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> GetDevBoxDefinitionAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevBoxDefinitionCollection GetDevBoxDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> GetDevCenterCatalog(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> GetDevCenterCatalogAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogCollection GetDevCenterCatalogs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource> GetDevCenterEncryptionSet(string encryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource>> GetDevCenterEncryptionSetAsync(string encryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterEncryptionSetCollection GetDevCenterEncryptionSets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> GetDevCenterEnvironmentType(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> GetDevCenterEnvironmentTypeAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeCollection GetDevCenterEnvironmentTypes() { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterGalleryCollection GetDevCenterGalleries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> GetDevCenterGallery(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>> GetDevCenterGalleryAsync(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectPolicyCollection GetDevCenterProjectPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource> GetDevCenterProjectPolicy(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource>> GetDevCenterProjectPolicyAsync(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetImages(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetImagesAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>, System.Collections.IEnumerable
    {
        protected DevCenterScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.DevCenter.DevCenterScheduleData data, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.DevCenter.DevCenterScheduleData data, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scheduleName, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scheduleName, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> Get(string scheduleName, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> Get(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetAsync(string scheduleName, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetIfExists(string scheduleName, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetIfExists(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetIfExistsAsync(string scheduleName, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetIfExistsAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterScheduleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>
    {
        public DevCenterScheduleData() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency? Frequency { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType? ScheduledType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus? State { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Time { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterScheduleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterScheduleResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string poolName, string scheduleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> Get(int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetAsync(int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch patch, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch patch, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>
    {
        internal EnvironmentDefinitionData() { }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo> Parameters { get { throw null; } }
        public string TemplatePath { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus? ValidationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.EnvironmentDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.EnvironmentDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthCheckStatusDetailData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>
    {
        public HealthCheckStatusDetailData() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck> HealthChecks { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthCheckStatusDetailResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthCheckStatusDetailResource() { }
        public virtual Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkConnectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageDefinitionBuildData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>
    {
        internal ImageDefinitionBuildData() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ImageReference { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.ImageDefinitionBuildData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.ImageDefinitionBuildData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>
    {
        internal ImageDefinitionData() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ActiveImageReference { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterAutoImageBuildStatus? AutoImageBuild { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference Extends { get { throw null; } }
        public string FileUri { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ImageReference { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails ImageValidationErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? ImageValidationStatus { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild LatestBuild { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance> Tasks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance> UserTasks { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus? ValidationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.ImageDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.ImageDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ImageVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ImageVersionResource>, System.Collections.IEnumerable
    {
        protected ImageVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ImageVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ImageVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.ImageVersionResource> GetIfExists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.ImageVersionResource>> GetIfExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ImageVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ImageVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ImageVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ImageVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImageVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageVersionData>
    {
        public ImageVersionData() { }
        public bool? IsExcludedFromLatest { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public int? OSDiskImageSizeInGB { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.ImageVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.ImageVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImageVersionResource() { }
        public virtual Azure.ResourceManager.DevCenter.ImageVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string galleryName, string imageName, string versionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.ImageVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.ImageVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectAttachedNetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected ProjectAttachedNetworkConnectionCollection() { }
        public virtual Azure.Response<bool> Exists(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> Get(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>> GetAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> GetIfExists(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>> GetIfExistsAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectAttachedNetworkConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectAttachedNetworkConnectionResource() { }
        public virtual Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string attachedNetworkConnectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectCatalogCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogResource>, System.Collections.IEnumerable
    {
        protected ProjectCatalogCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectCatalogResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.DevCenter.DevCenterCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectCatalogResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.DevCenter.DevCenterCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogResource> Get(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectCatalogResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectCatalogResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogResource>> GetAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectCatalogResource> GetIfExists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectCatalogResource>> GetIfExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ProjectCatalogResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ProjectCatalogResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectCatalogEnvironmentDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource>, System.Collections.IEnumerable
    {
        protected ProjectCatalogEnvironmentDefinitionCollection() { }
        public virtual Azure.Response<bool> Exists(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource> Get(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource>> GetAsync(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource> GetIfExists(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource>> GetIfExistsAsync(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectCatalogEnvironmentDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectCatalogEnvironmentDefinitionResource() { }
        public virtual Azure.ResourceManager.DevCenter.EnvironmentDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string catalogName, string environmentDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails> GetErrorDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails>> GetErrorDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.EnvironmentDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.EnvironmentDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.EnvironmentDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectCatalogImageDefinitionBuildCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource>, System.Collections.IEnumerable
    {
        protected ProjectCatalogImageDefinitionBuildCollection() { }
        public virtual Azure.Response<bool> Exists(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource> Get(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource>> GetAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource> GetIfExists(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource>> GetIfExistsAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectCatalogImageDefinitionBuildResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectCatalogImageDefinitionBuildResource() { }
        public virtual Azure.ResourceManager.DevCenter.ImageDefinitionBuildData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string catalogName, string imageDefinitionName, string buildName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails> GetBuildDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails>> GetBuildDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.ImageDefinitionBuildData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.ImageDefinitionBuildData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionBuildData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectCatalogImageDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource>, System.Collections.IEnumerable
    {
        protected ProjectCatalogImageDefinitionCollection() { }
        public virtual Azure.Response<bool> Exists(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource> Get(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource>> GetAsync(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource> GetIfExists(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource>> GetIfExistsAsync(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectCatalogImageDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectCatalogImageDefinitionResource() { }
        public virtual Azure.ResourceManager.DevCenter.ImageDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation BuildImage(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BuildImageAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string catalogName, string imageDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails> GetErrorDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails>> GetErrorDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource> GetProjectCatalogImageDefinitionBuild(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource>> GetProjectCatalogImageDefinitionBuildAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildCollection GetProjectCatalogImageDefinitionBuilds() { throw null; }
        Azure.ResourceManager.DevCenter.ImageDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.ImageDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectCatalogResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectCatalogResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Connect(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ConnectAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string catalogName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource> GetProjectCatalogEnvironmentDefinition(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource>> GetProjectCatalogEnvironmentDefinitionAsync(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionCollection GetProjectCatalogEnvironmentDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource> GetProjectCatalogImageDefinition(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource>> GetProjectCatalogImageDefinitionAsync(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionCollection GetProjectCatalogImageDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails> GetSyncErrorDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails>> GetSyncErrorDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Sync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SyncAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterCatalogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterCatalogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectCatalogResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectCatalogResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectDevBoxDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>, System.Collections.IEnumerable
    {
        protected ProjectDevBoxDefinitionCollection() { }
        public virtual Azure.Response<bool> Exists(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> Get(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>> GetAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> GetIfExists(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>> GetIfExistsAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectDevBoxDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectDevBoxDefinitionResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevBoxDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string devBoxDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevBoxDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevBoxDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevBoxDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectImageResource>, System.Collections.IEnumerable
    {
        protected ProjectImageCollection() { }
        public virtual Azure.Response<bool> Exists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageResource> Get(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageResource>> GetAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectImageResource> GetIfExists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectImageResource>> GetIfExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ProjectImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ProjectImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectImageResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string imageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageVersionResource> GetProjectImageVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageVersionResource>> GetProjectImageVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectImageVersionCollection GetProjectImageVersions() { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectImageVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectImageVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectImageVersionResource>, System.Collections.IEnumerable
    {
        protected ProjectImageVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectImageVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectImageVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectImageVersionResource> GetIfExists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectImageVersionResource>> GetIfExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ProjectImageVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectImageVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ProjectImageVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectImageVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectImageVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectImageVersionResource() { }
        public virtual Azure.ResourceManager.DevCenter.ImageVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string imageName, string versionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.ImageVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ImageVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.ImageVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ImageVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.DevCenter.Mocking
{
    public partial class MockableDevCenterArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDevCenterArmClient() { }
        public virtual Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource GetAllowedEnvironmentTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource GetAttachedNetworkConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevBoxDefinitionResource GetDevBoxDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogEnvironmentDefinitionResource GetDevCenterCatalogEnvironmentDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionBuildResource GetDevCenterCatalogImageDefinitionBuildResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogImageDefinitionResource GetDevCenterCatalogImageDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogResource GetDevCenterCatalogResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogTaskResource GetDevCenterCatalogTaskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource GetDevCenterEncryptionSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource GetDevCenterEnvironmentTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterGalleryResource GetDevCenterGalleryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterImageResource GetDevCenterImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource GetDevCenterNetworkConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterPoolResource GetDevCenterPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource GetDevCenterProjectEnvironmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectPolicyResource GetDevCenterProjectPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectResource GetDevCenterProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterResource GetDevCenterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterScheduleResource GetDevCenterScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.HealthCheckStatusDetailResource GetHealthCheckStatusDetailResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ImageVersionResource GetImageVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource GetProjectAttachedNetworkConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource GetProjectCatalogEnvironmentDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource GetProjectCatalogImageDefinitionBuildResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource GetProjectCatalogImageDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogResource GetProjectCatalogResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource GetProjectDevBoxDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectImageResource GetProjectImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectImageVersionResource GetProjectImageVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDevCenterResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevCenterResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCenter(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> GetDevCenterAsync(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetDevCenterNetworkConnection(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> GetDevCenterNetworkConnectionAsync(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionCollection GetDevCenterNetworkConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetDevCenterProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> GetDevCenterProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectCollection GetDevCenterProjects() { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCollection GetDevCenters() { throw null; }
    }
    public partial class MockableDevCenterSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevCenterSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult> CheckDevCenterNameAvailability(Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>> CheckDevCenterNameAvailabilityAsync(Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult> Execute(Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>> ExecuteAsync(Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetDevCenterNetworkConnections(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetDevCenterNetworkConnectionsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus> GetDevCenterOperationStatus(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>> GetDevCenterOperationStatusAsync(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetDevCenterProjects(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetDevCenterProjectsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCenters(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCentersAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetDevCenterSkusBySubscription(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetDevCenterSkusBySubscriptionAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.Models.DevCenterUsage> GetDevCenterUsagesByLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.DevCenterUsage> GetDevCenterUsagesByLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevCenter.Models
{
    public static partial class ArmDevCenterModelFactory
    {
        public static Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData AllowedEnvironmentTypeData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData AllowedEnvironmentTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), string displayName = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData AttachedNetworkConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.Core.ResourceIdentifier networkConnectionId = null, Azure.Core.AzureLocation? networkConnectionLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? healthCheckStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus?), Azure.ResourceManager.DevCenter.Models.DomainJoinType? domainJoinType = default(Azure.ResourceManager.DevCenter.Models.DomainJoinType?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevBoxDefinitionData DevBoxDefinitionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference, Azure.ResourceManager.DevCenter.Models.DevCenterSku sku, string osStorageType, Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? hibernateSupport, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState, Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? imageValidationStatus, Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails imageValidationErrorDetails, Azure.ResourceManager.DevCenter.Models.DevCenterImageReference activeImageReference) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevBoxDefinitionData DevBoxDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference = null, Azure.ResourceManager.DevCenter.Models.DevCenterSku sku = null, string osStorageType = null, Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? hibernateSupport = default(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? imageValidationStatus = default(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus?), Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails imageValidationErrorDetails = null, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus? validationStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterImageReference activeImageReference = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch DevBoxDefinitionPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference = null, Azure.ResourceManager.DevCenter.Models.DevCenterSku sku = null, string osStorageType = null, Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? hibernateSupport = default(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration DevCenterActiveHoursConfiguration(Azure.ResourceManager.DevCenter.Models.DevCenterKeepAwakeEnableStatus? keepAwakeEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterKeepAwakeEnableStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterAutoStartEnableStatus? autoStartEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterAutoStartEnableStatus?), string defaultTimeZone = null, int? defaultStartTimeHour = default(int?), int? defaultEndTimeHour = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DayOfWeek> defaultDaysOfWeek = null, int? daysOfWeekLimit = default(int?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCapability DevCenterCapability(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError DevCenterCatalogConflictError(string path = null, string name = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCatalogData DevCenterCatalogData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog gitHub = null, Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog adoGit = null, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType? syncType = default(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType?), Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus? autoImageBuildEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState? syncState = default(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState?), Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats lastSyncStats = null, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConnectionState? connectionState = default(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConnectionState?), System.DateTimeOffset? lastConnectionOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSyncOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCatalogData DevCenterCatalogData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog gitHub, Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog adoGit, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState? syncState, System.DateTimeOffset? lastSyncOn) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails DevCenterCatalogErrorDetails(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails DevCenterCatalogResourceValidationErrorDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails> errors = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError DevCenterCatalogSyncError(string path = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails> errorDetails = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCatalogTaskData DevCenterCatalogTaskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput> inputs = null, int? timeout = default(int?), Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus? validationStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput DevCenterCustomizationTaskInput(string description = null, Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType? type = default(Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType?), bool? required = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance DevCenterCustomizationTaskInstance(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem> parameters = null, string displayName = null, int? timeoutInSeconds = default(int?), string condition = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterData DevCenterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState, System.Uri devCenterUri) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterData DevCenterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string displayName = null, Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption customerManagedKeyEncryption = null, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus? catalogItemSyncEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus? microsoftHostedNetworkEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus? devBoxProvisioningInstallAzureMonitorAgentEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), System.Uri devCenterUri = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem DevCenterDefinitionParametersItem(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData DevCenterEncryptionSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus? devboxDisksEncryptionEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus?), System.Uri keyEncryptionKeyUri = null, Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity keyEncryptionKeyIdentity = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch DevCenterEncryptionSetPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus? devboxDisksEncryptionEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus?), System.Uri keyEncryptionKeyUri = null, Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity keyEncryptionKeyIdentity = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail DevCenterEndpointDetail(int? port = default(int?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo DevCenterEnvironmentDefinitionParameterInfo(string id = null, string name = null, string description = null, Azure.ResourceManager.DevCenter.Models.DevCenterParameterType? type = default(Azure.ResourceManager.DevCenter.Models.DevCenterParameterType?), bool? readOnly = default(bool?), bool? required = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole DevCenterEnvironmentRole(string roleName = null, string description = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData DevCenterEnvironmentTypeData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData DevCenterEnvironmentTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch DevCenterEnvironmentTypePatch(string displayName = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState DevCenterFeatureState(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable? statusModifiable = default(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable?), Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable? valuesModifiable = default(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable?), Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus? defaultStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue> defaultValues = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterGalleryData DevCenterGalleryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.Core.ResourceIdentifier galleryResourceId = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck DevCenterHealthCheck(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? status = default(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus?), string displayName = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string errorType = null, string recommendedAction = null, string additionalDetails = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail DevCenterHealthStatusDetail(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails DevCenterImageCreationErrorDetails(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterImageData DevCenterImageData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string description, string publisher, string offer, string sku, Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration recommendedMachineConfiguration, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState, Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? hibernateSupport) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterImageData DevCenterImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string publisher = null, string offer = null, string sku = null, Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration recommendedMachineConfiguration = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? hibernateSupport = default(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport?), Azure.ResourceManager.DevCenter.Models.DevCenterArchitectureType? architecture = default(Azure.ResourceManager.DevCenter.Models.DevCenterArchitectureType?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails DevCenterImageDefinitionBuildDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus? status = default(Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails errorDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup> taskGroups = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask DevCenterImageDefinitionBuildTask(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem> parameters = null, string displayName = null, string id = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus? status = default(Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus?), System.Uri logUri = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup DevCenterImageDefinitionBuildTaskGroup(string name = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus? status = default(Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask> tasks = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem DevCenterImageDefinitionBuildTaskParametersItem(string key = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference DevCenterImageDefinitionReference(string imageDefinition = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem> parameters = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageReference DevCenterImageReference(Azure.Core.ResourceIdentifier id = null, string exactVersion = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings DevCenterInheritedProjectCatalogSettings(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable? statusModifiable = default(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable?), Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable? valuesModifiable = default(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable?), Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus? defaultStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue> defaultValues = null, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus? catalogItemSyncEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject DevCenterInheritedSettingsForProject(Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings projectCatalogSettings = null, Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus? microsoftHostedNetworkEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState azureAiServicesSettings = null, Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState devBoxScheduleDeleteSettings = null, Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState devBoxLimitsSettings = null, Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState displayNameSettings = null, Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState devBoxTunnelSettings = null, Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState serverlessGpuSessionsSettings = null, Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState userCustomizationsSettings = null, Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState workspaceStorageSettings = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild DevCenterLatestImageBuild(string name = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus? status = default(Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult DevCenterNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason? reason = default(Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData DevCenterNetworkConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier subnetId = null, string domainName = null, string organizationUnit = null, string domainUsername = null, string domainPassword = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? healthCheckStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus?), string networkingResourceGroupName = null, Azure.ResourceManager.DevCenter.Models.DomainJoinType? domainJoinType = default(Azure.ResourceManager.DevCenter.Models.DomainJoinType?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch DevCenterNetworkConnectionPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceIdentifier subnetId = null, string domainName = null, string organizationUnit = null, string domainUsername = null, string domainPassword = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus DevCenterOperationStatus(Azure.Core.ResourceIdentifier id = null, string name = null, string status = null, float? percentComplete = default(float?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Models.OperationStatusResult> operations = null, Azure.ResponseError error = null, Azure.Core.ResourceIdentifier resourceId = null, System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterPatch DevCenterPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string displayName = null, Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption customerManagedKeyEncryption = null, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus? catalogItemSyncEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus? microsoftHostedNetworkEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus? devBoxProvisioningInstallAzureMonitorAgentEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterPoolData DevCenterPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType? devBoxDefinitionType = default(Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType?), string devBoxDefinitionName = null, Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail devBoxDefinition = null, string networkConnectionName = null, Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType? licenseType = default(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType?), Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? localAdministrator = default(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus?), Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration stopOnDisconnect = null, Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration stopOnNoConnect = null, Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus? singleSignOnStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus?), string displayName = null, Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType? virtualNetworkType = default(Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType?), System.Collections.Generic.IEnumerable<string> managedVirtualNetworkRegions = null, Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration activeHoursConfiguration = null, Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus? devBoxTunnelEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus? healthStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail> healthStatusDetails = null, int? devBoxCount = default(int?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterPoolData DevCenterPoolData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string devBoxDefinitionName, string networkConnectionName, Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType? licenseType, Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? localAdministrator, Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration stopOnDisconnect, Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus? healthStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail> healthStatusDetails, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail DevCenterPoolDevBoxDefinitionDetail(Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference = null, Azure.ResourceManager.DevCenter.Models.DevCenterSku sku = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageReference activeImageReference = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch DevCenterPoolPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType? devBoxDefinitionType = default(Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType?), string devBoxDefinitionName = null, Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail devBoxDefinition = null, string networkConnectionName = null, Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType? licenseType = default(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType?), Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? localAdministrator = default(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus?), Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration stopOnDisconnect = null, Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration stopOnNoConnect = null, Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus? singleSignOnStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus?), string displayName = null, Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType? virtualNetworkType = default(Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType?), System.Collections.Generic.IEnumerable<string> managedVirtualNetworkRegions = null, Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration activeHoursConfiguration = null, Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus? devBoxTunnelEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings DevCenterProjectCustomizationSettings(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationManagedIdentity> identities = null, Azure.ResourceManager.DevCenter.Models.DevCenterUserCustomizationsEnableStatus? userCustomizationsEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterUserCustomizationsEnableStatus?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectData DevCenterProjectData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier devCenterId, string description, int? maxDevBoxesPerUser, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState, System.Uri devCenterUri) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectData DevCenterProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier devCenterId = null, string description = null, int? maxDevBoxesPerUser = default(int?), string displayName = null, Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings customizationSettings = null, Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings devBoxScheduleDeleteSettings = null, Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings serverlessGpuSessionsSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup> assignedGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType> catalogItemSyncTypes = null, Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode? azureAiServicesMode = default(Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode?), Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode? workspaceStorageMode = default(Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), System.Uri devCenterUri = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData DevCenterProjectEnvironmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier deploymentTargetId = null, string displayName = null, Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus? status = default(Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments> userRoleAssignments = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> roles = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), int? environmentCount = default(int?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData DevCenterProjectEnvironmentData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.Core.ResourceIdentifier deploymentTargetId, Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus? status, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> roles, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments> userRoleAssignments, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch DevCenterProjectEnvironmentPatch(Azure.Core.ResourceIdentifier deploymentTargetId = null, string displayName = null, Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus? status = default(Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments> userRoleAssignments = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> roles = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch DevCenterProjectPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceIdentifier devCenterId = null, string description = null, int? maxDevBoxesPerUser = default(int?), string displayName = null, Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings customizationSettings = null, Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings devBoxScheduleDeleteSettings = null, Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings serverlessGpuSessionsSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup> assignedGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType> catalogItemSyncTypes = null, Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode? azureAiServicesMode = default(Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode?), Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode? workspaceStorageMode = default(Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectPolicyData DevCenterProjectPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy> resourcePolicies = null, System.Collections.Generic.IEnumerable<string> scopes = null, Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies configurationPolicies = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange DevCenterResourceRange(int? min = default(int?), int? max = default(int?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterScheduleData DevCenterScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType? scheduledType = default(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType?), Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency? frequency = default(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency?), string time = null, string timeZone = null, Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus? state = default(Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterScheduleData DevCenterScheduleData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType? scheduledType, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency? frequency, string time, string timeZone, Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus? state, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch DevCenterSchedulePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType? scheduledType = default(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType?), Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency? frequency = default(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency?), string time = null, string timeZone = null, Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus? state = default(Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails DevCenterSkuDetails(string name = null, Azure.ResourceManager.DevCenter.Models.DevCenterSkuTier? tier = default(Azure.ResourceManager.DevCenter.Models.DevCenterSkuTier?), string size = null, string family = null, int? capacity = default(int?), Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterCapability> capabilities = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails DevCenterSyncErrorDetails(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails operationError = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError> conflicts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError> errors = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats DevCenterSyncStats(int? added = default(int?), int? updated = default(int?), int? unchanged = default(int?), int? removed = default(int?), int? validationErrors = default(int?), int? synchronizationErrors = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType> syncedCatalogItemTypes = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate DevCenterTrackedResourceUpdate(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUsage DevCenterUsage(long? currentValue, long? limit, Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit? unit, Azure.ResourceManager.DevCenter.Models.DevCenterUsageName name) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUsage DevCenterUsage(long? currentValue = default(long?), long? limit = default(long?), Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit? unit = default(Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit?), Azure.ResourceManager.DevCenter.Models.DevCenterUsageName name = null, string id = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUsageName DevCenterUsageName(string localizedValue = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments DevCenterUserRoleAssignments(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> roles = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.EndpointDependency EndpointDependency(string domainName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail> endpointDetails = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.EnvironmentDefinitionData EnvironmentDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo> parameters = null, string templatePath = null, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus? validationStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData HealthCheckStatusDetailData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck> healthChecks = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.ImageDefinitionBuildData ImageDefinitionBuildData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus? status = default(Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails errorDetails = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.ImageDefinitionData ImageDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference = null, string fileUri = null, Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild latestBuild = null, Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? imageValidationStatus = default(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus?), Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails imageValidationErrorDetails = null, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus? validationStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterImageReference activeImageReference = null, Azure.ResourceManager.DevCenter.Models.DevCenterAutoImageBuildStatus? autoImageBuild = default(Azure.ResourceManager.DevCenter.Models.DevCenterAutoImageBuildStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance> tasks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance> userTasks = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference extends = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails ImageValidationErrorDetails(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.ImageVersionData ImageVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string namePropertiesName = null, System.DateTimeOffset? publishedOn = default(System.DateTimeOffset?), bool? isExcludedFromLatest = default(bool?), int? osDiskImageSizeInGB = default(int?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint OutboundEnvironmentEndpoint(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.EndpointDependency> endpoints = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration RecommendedMachineConfiguration(Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange memory = null, Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange vCpus = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureAiServicesMode : System.IEquatable<Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureAiServicesMode(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode AutoDeploy { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode Disabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode left, Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode left, Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DayOfWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
    public partial class DevBoxDefinitionPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>
    {
        public DevBoxDefinitionPatch() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? HibernateSupport { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ImageReference { get { throw null; } set { } }
        public string OSStorageType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSku Sku { get { throw null; } set { } }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterActiveHoursConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration>
    {
        public DevCenterActiveHoursConfiguration() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterAutoStartEnableStatus? AutoStartEnableStatus { get { throw null; } set { } }
        public int? DaysOfWeekLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DayOfWeek> DefaultDaysOfWeek { get { throw null; } }
        public int? DefaultEndTimeHour { get { throw null; } set { } }
        public int? DefaultStartTimeHour { get { throw null; } set { } }
        public string DefaultTimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterKeepAwakeEnableStatus? KeepAwakeEnableStatus { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterArchitectureType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterArchitectureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterArchitectureType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterArchitectureType Arm64 { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterArchitectureType X64 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterArchitectureType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterArchitectureType left, Azure.ResourceManager.DevCenter.Models.DevCenterArchitectureType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterArchitectureType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterArchitectureType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterArchitectureType left, Azure.ResourceManager.DevCenter.Models.DevCenterArchitectureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterAssignedGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup>
    {
        public DevCenterAssignedGroup() { }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroupScope? Scope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterAssignedGroupScope : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroupScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterAssignedGroupScope(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroupScope DevBox { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroupScope other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroupScope left, Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroupScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroupScope (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroupScope? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroupScope left, Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroupScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterAutoImageBuildStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterAutoImageBuildStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterAutoImageBuildStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterAutoImageBuildStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterAutoImageBuildStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterAutoImageBuildStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterAutoImageBuildStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterAutoImageBuildStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterAutoImageBuildStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterAutoImageBuildStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterAutoImageBuildStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterAutoImageBuildStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterAutoStartEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterAutoStartEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterAutoStartEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterAutoStartEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterAutoStartEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterAutoStartEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterAutoStartEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterAutoStartEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterAutoStartEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterAutoStartEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterAutoStartEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterAutoStartEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterCancelOnConnectEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterCancelOnConnectEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterCancelOnConnectEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCancelOnConnectEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCancelOnConnectEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterCancelOnConnectEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterCancelOnConnectEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterCancelOnConnectEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCancelOnConnectEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCancelOnConnectEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterCancelOnConnectEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterCancelOnConnectEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>
    {
        public DevCenterCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterCatalogAutoImageBuildEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterCatalogAutoImageBuildEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterCatalogConflictError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError>
    {
        internal DevCenterCatalogConflictError() { }
        public string Name { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterCatalogConnectionState : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterCatalogConnectionState(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConnectionState Connected { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConnectionState Disconnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConnectionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConnectionState left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConnectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConnectionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConnectionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConnectionState left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterCatalogErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails>
    {
        internal DevCenterCatalogErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterCatalogItemSyncEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterCatalogItemSyncEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterCatalogItemType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterCatalogItemType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType EnvironmentDefinition { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType ImageDefinition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterCatalogPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>
    {
        public DevCenterCatalogPatch() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog AdoGit { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogAutoImageBuildEnableStatus? AutoImageBuildEnableStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog GitHub { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType? SyncType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterCatalogResourceValidationErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails>
    {
        internal DevCenterCatalogResourceValidationErrorDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails> Errors { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterCatalogResourceValidationStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterCatalogResourceValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogResourceValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterCatalogSyncError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError>
    {
        internal DevCenterCatalogSyncError() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails> ErrorDetails { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterCatalogSyncState : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterCatalogSyncState(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState Failed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState InProgress { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterCatalogSyncType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterCatalogSyncType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType Manual { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterCmkIdentityType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterCmkIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterCmkIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCmkIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCmkIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterCmkIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterCmkIdentityType left, Azure.ResourceManager.DevCenter.Models.DevCenterCmkIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCmkIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCmkIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterCmkIdentityType left, Azure.ResourceManager.DevCenter.Models.DevCenterCmkIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterConfigurationPolicies : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies>
    {
        public DevCenterConfigurationPolicies() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState AzureAiServicesFeatureStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState DevBoxLimitsFeatureStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState DevBoxScheduleDeleteFeatureStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState DevBoxTunnelFeatureStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState DisplayNameFeatureStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState ProjectCatalogFeatureStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState ServerlessGpuSessionsFeatureStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState UserCustomizationsFeatureStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState WorkspaceStorageFeatureStatus { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterCustomerManagedKeyEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption>
    {
        public DevCenterCustomerManagedKeyEncryption() { }
        public Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public string KeyEncryptionKeyUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterCustomizationTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput>
    {
        internal DevCenterCustomizationTaskInput() { }
        public string Description { get { throw null; } }
        public bool? Required { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterCustomizationTaskInputType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterCustomizationTaskInputType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType Boolean { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType Number { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType left, Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType left, Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterCustomizationTaskInstance : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance>
    {
        internal DevCenterCustomizationTaskInstance() { }
        public string Condition { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem> Parameters { get { throw null; } }
        public int? TimeoutInSeconds { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCustomizationTaskInstance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterDefaultValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue>
    {
        public DevCenterDefaultValue() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterDefinitionParametersItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem>
    {
        internal DevCenterDefinitionParametersItem() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterDevBoxDeleteMode : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxDeleteMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterDevBoxDeleteMode(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxDeleteMode Auto { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxDeleteMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxDeleteMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxDeleteMode left, Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxDeleteMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxDeleteMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxDeleteMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxDeleteMode left, Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxDeleteMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterDevboxDisksEncryptionEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterDevboxDisksEncryptionEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterDevBoxScheduleDeleteSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings>
    {
        public DevCenterDevBoxScheduleDeleteSettings() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCancelOnConnectEnableStatus? CancelOnConnectEnableStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxDeleteMode? DeleteMode { get { throw null; } set { } }
        public System.TimeSpan? GracePeriod { get { throw null; } set { } }
        public System.TimeSpan? InactiveThreshold { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterDevBoxTunnelEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterDevBoxTunnelEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterEncryptionSetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch>
    {
        public DevCenterEncryptionSetPatch() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterDevboxDisksEncryptionEnableStatus? DevboxDisksEncryptionEnableStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public System.Uri KeyEncryptionKeyUri { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterEndpointDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail>
    {
        internal DevCenterEndpointDetail() { }
        public int? Port { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterEnvironmentDefinitionParameterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo>
    {
        internal DevCenterEnvironmentDefinitionParameterInfo() { }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? ReadOnly { get { throw null; } }
        public bool? Required { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterParameterType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentDefinitionParameterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterEnvironmentRole : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole>
    {
        public DevCenterEnvironmentRole() { }
        public string Description { get { throw null; } }
        public string RoleName { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterEnvironmentTypePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch>
    {
        public DevCenterEnvironmentTypePatch() { }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterFeatureState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState>
    {
        public DevCenterFeatureState() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus? DefaultStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue> DefaultValues { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable? StatusModifiable { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable? ValuesModifiable { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterFeatureStateModifiable : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterFeatureStateModifiable(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable Modifiable { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable NotModifiable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable left, Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable left, Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterFeatureStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterFeatureStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus AutoDeploy { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterGitCatalog : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>
    {
        public DevCenterGitCatalog() { }
        public string Branch { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string SecretIdentifier { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterHealthCheck : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck>
    {
        public DevCenterHealthCheck() { }
        public string AdditionalDetails { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string ErrorType { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterHealthCheckStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterHealthCheckStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus Informational { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus Passed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus Running { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterHealthStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterHealthStatusDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail>
    {
        internal DevCenterHealthStatusDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterHibernateSupport : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterHibernateSupport(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport left, Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport left, Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterImageCreationErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails>
    {
        internal DevCenterImageCreationErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterImageDefinitionBuildDetails : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails>
    {
        internal DevCenterImageDefinitionBuildDetails() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageCreationErrorDetails ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ImageReference { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup> TaskGroups { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterImageDefinitionBuildStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterImageDefinitionBuildStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus Running { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus TimedOut { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus ValidationFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterImageDefinitionBuildTask : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask>
    {
        internal DevCenterImageDefinitionBuildTask() { }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Uri LogUri { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem> Parameters { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterImageDefinitionBuildTaskGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup>
    {
        internal DevCenterImageDefinitionBuildTaskGroup() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTask> Tasks { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterImageDefinitionBuildTaskParametersItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem>
    {
        internal DevCenterImageDefinitionBuildTaskParametersItem() { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildTaskParametersItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterImageDefinitionReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference>
    {
        internal DevCenterImageDefinitionReference() { }
        public string ImageDefinition { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterDefinitionParametersItem> Parameters { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterImageReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>
    {
        public DevCenterImageReference() { }
        public string ExactVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterImageReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterImageReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterInheritedProjectCatalogSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings>
    {
        internal DevCenterInheritedProjectCatalogSettings() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus? CatalogItemSyncEnableStatus { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStatus? DefaultStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterDefaultValue> DefaultValues { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable? StatusModifiable { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureStateModifiable? ValuesModifiable { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterInheritedSettingsForProject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject>
    {
        internal DevCenterInheritedSettingsForProject() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState AzureAiServicesSettings { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState DevBoxLimitsSettings { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState DevBoxScheduleDeleteSettings { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState DevBoxTunnelSettings { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState DisplayNameSettings { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus? MicrosoftHostedNetworkEnableStatus { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterInheritedProjectCatalogSettings ProjectCatalogSettings { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState ServerlessGpuSessionsSettings { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState UserCustomizationsSettings { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterFeatureState WorkspaceStorageSettings { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterInheritedSettingsForProject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterInstallAzureMonitorAgentEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterInstallAzureMonitorAgentEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterKeepAwakeEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterKeepAwakeEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterKeepAwakeEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterKeepAwakeEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterKeepAwakeEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterKeepAwakeEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterKeepAwakeEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterKeepAwakeEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterKeepAwakeEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterKeepAwakeEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterKeepAwakeEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterKeepAwakeEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterKeyEncryptionKeyIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity>
    {
        public DevCenterKeyEncryptionKeyIdentity() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCmkIdentityType? Type { get { throw null; } set { } }
        public string UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterKeyEncryptionKeyIdentityType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterKeyEncryptionKeyIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentityType DelegatedResourceIdentity { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentityType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentityType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentityType left, Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentityType left, Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterLatestImageBuild : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild>
    {
        internal DevCenterLatestImageBuild() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageDefinitionBuildStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterLatestImageBuild>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterLicenseType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType WindowsClient { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType left, Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType left, Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterMicrosoftHostedNetworkEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterMicrosoftHostedNetworkEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent>
    {
        public DevCenterNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>
    {
        internal DevCenterNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterNameUnavailableReason : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason left, Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason left, Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterNetworkConnectionPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch>
    {
        public DevCenterNetworkConnectionPatch() { }
        public string DomainName { get { throw null; } set { } }
        public string DomainPassword { get { throw null; } set { } }
        public string DomainUsername { get { throw null; } set { } }
        public string OrganizationUnit { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterOperationStatus : Azure.ResourceManager.Models.OperationStatusResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>
    {
        internal DevCenterOperationStatus() { }
        public System.BinaryData Properties { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.OperationStatusResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.OperationStatusResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterParameterType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterParameterType Boolean { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterParameterType Integer { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterParameterType Number { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterParameterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterParameterType left, Azure.ResourceManager.DevCenter.Models.DevCenterParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterParameterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterParameterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterParameterType left, Azure.ResourceManager.DevCenter.Models.DevCenterParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>
    {
        public DevCenterPatch() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemSyncEnableStatus? CatalogItemSyncEnableStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCustomerManagedKeyEncryption CustomerManagedKeyEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterInstallAzureMonitorAgentEnableStatus? DevBoxProvisioningInstallAzureMonitorAgentEnableStatus { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterMicrosoftHostedNetworkEnableStatus? MicrosoftHostedNetworkEnableStatus { get { throw null; } set { } }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterPolicyAction : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterPolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterPolicyAction(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterPolicyAction Allow { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterPolicyAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterPolicyAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterPolicyAction left, Azure.ResourceManager.DevCenter.Models.DevCenterPolicyAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterPolicyAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterPolicyAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterPolicyAction left, Azure.ResourceManager.DevCenter.Models.DevCenterPolicyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterPoolDevBoxDefinitionDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail>
    {
        public DevCenterPoolDevBoxDefinitionDetail() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ActiveImageReference { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterPoolDevBoxDefinitionType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterPoolDevBoxDefinitionType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType Reference { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType Value { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType left, Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType left, Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterPoolPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>
    {
        public DevCenterPoolPatch() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterActiveHoursConfiguration ActiveHoursConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionDetail DevBoxDefinition { get { throw null; } set { } }
        public string DevBoxDefinitionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterPoolDevBoxDefinitionType? DevBoxDefinitionType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxTunnelEnableStatus? DevBoxTunnelEnableStatus { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? LocalAdministrator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedVirtualNetworkRegions { get { throw null; } }
        public string NetworkConnectionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus? SingleSignOnStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration StopOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration StopOnNoConnect { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType? VirtualNetworkType { get { throw null; } set { } }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterProjectCustomizationIdentityType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterProjectCustomizationIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationIdentityType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationIdentityType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationIdentityType left, Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationIdentityType left, Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterProjectCustomizationManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationManagedIdentity>
    {
        public DevCenterProjectCustomizationManagedIdentity() { }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationIdentityType? IdentityType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationManagedIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationManagedIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterProjectCustomizationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings>
    {
        public DevCenterProjectCustomizationSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationManagedIdentity> Identities { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterUserCustomizationsEnableStatus? UserCustomizationsEnableStatus { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterProjectEnvironmentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch>
    {
        public DevCenterProjectEnvironmentPatch() { }
        public Azure.Core.ResourceIdentifier DeploymentTargetId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> Roles { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments> UserRoleAssignments { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterProjectPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>
    {
        public DevCenterProjectPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterAssignedGroup> AssignedGroups { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode? AzureAiServicesMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType> CatalogItemSyncTypes { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProjectCustomizationSettings CustomizationSettings { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterDevBoxScheduleDeleteSettings DevBoxScheduleDeleteSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DevCenterId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public int? MaxDevBoxesPerUser { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings ServerlessGpuSessionsSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode? WorkspaceStorageMode { get { throw null; } set { } }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterProjectPolicyPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPolicyPatch>
    {
        public DevCenterProjectPolicyPatch() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterConfigurationPolicies ConfigurationPolicies { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy> ResourcePolicies { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterProjectPolicyPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterProjectPolicyPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectPolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectPolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterProvisioningState : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState MovingResources { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState RolloutInProgress { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState StorageProvisioningFailed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState TransientFailure { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Updated { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState left, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState left, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterResourcePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy>
    {
        public DevCenterResourcePolicy() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterPolicyAction? Action { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string Resources { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterResourceType? ResourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourcePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterResourceRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange>
    {
        public DevCenterResourceRange() { }
        public int? Max { get { throw null; } }
        public int? Min { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterResourceType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterResourceType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterResourceType AttachedNetworks { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterResourceType Images { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterResourceType Skus { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterResourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterResourceType left, Azure.ResourceManager.DevCenter.Models.DevCenterResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterResourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterResourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterResourceType left, Azure.ResourceManager.DevCenter.Models.DevCenterResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterScheduledFrequency : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterScheduledFrequency(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency Daily { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterScheduledType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterScheduledType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType StopDevBox { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterScheduleEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterScheduleEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterSchedulePatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch>
    {
        public DevCenterSchedulePatch() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency? Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType? ScheduledType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus? State { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterScopedNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent>
    {
        public DevCenterScopedNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterScopedNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterServerlessGpuSessionsMode : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterServerlessGpuSessionsMode(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsMode AutoDeploy { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsMode Disabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsMode left, Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsMode left, Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterServerlessGpuSessionsSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings>
    {
        public DevCenterServerlessGpuSessionsSettings() { }
        public int? MaxConcurrentSessionsPerProject { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsMode? ServerlessGpuSessionsMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterServerlessGpuSessionsSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterSingleSignOnStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterSingleSignOnStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterSingleSignOnStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSku>
    {
        public DevCenterSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterSkuDetails : Azure.ResourceManager.DevCenter.Models.DevCenterSku, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails>
    {
        public DevCenterSkuDetails(string name) : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.DevCenter.Models.DevCenterSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DevCenterSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class DevCenterStopOnNoConnectConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration>
    {
        public DevCenterStopOnNoConnectConfiguration() { }
        public int? GracePeriodMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectEnableStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterStopOnNoConnectEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterStopOnNoConnectEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterStopOnNoConnectEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterSyncErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails>
    {
        internal DevCenterSyncErrorDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogConflictError> Conflicts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncError> Errors { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogErrorDetails OperationError { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterSyncStats : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats>
    {
        internal DevCenterSyncStats() { }
        public int? Added { get { throw null; } }
        public int? Removed { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogItemType> SyncedCatalogItemTypes { get { throw null; } }
        public int? SynchronizationErrors { get { throw null; } }
        public int? Unchanged { get { throw null; } }
        public int? Updated { get { throw null; } }
        public int? ValidationErrors { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSyncStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterTrackedResourceUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate>
    {
        public DevCenterTrackedResourceUpdate() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsage>
    {
        internal DevCenterUsage() { }
        public long? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterUsageName Name { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit? Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterUsageName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsageName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsageName>
    {
        internal DevCenterUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterUsageName JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterUsageName PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterUsageName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsageName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsageName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterUsageName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsageName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsageName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUsageName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterUsageUnit : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit left, Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit left, Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterUserCustomizationsEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterUserCustomizationsEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterUserCustomizationsEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUserCustomizationsEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUserCustomizationsEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterUserCustomizationsEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterUserCustomizationsEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterUserCustomizationsEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterUserCustomizationsEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterUserCustomizationsEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterUserCustomizationsEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterUserCustomizationsEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterUserRoleAssignments : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>
    {
        public DevCenterUserRoleAssignments() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> Roles { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterVirtualNetworkType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterVirtualNetworkType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType Managed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType Unmanaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType left, Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType left, Azure.ResourceManager.DevCenter.Models.DevCenterVirtualNetworkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterWorkspaceStorageMode : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterWorkspaceStorageMode(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode AutoDeploy { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode Disabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode left, Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode left, Azure.ResourceManager.DevCenter.Models.DevCenterWorkspaceStorageMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainJoinType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DomainJoinType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainJoinType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DomainJoinType AadJoin { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DomainJoinType HybridAadJoin { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DomainJoinType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DomainJoinType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DomainJoinType left, Azure.ResourceManager.DevCenter.Models.DomainJoinType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DomainJoinType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DomainJoinType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DomainJoinType left, Azure.ResourceManager.DevCenter.Models.DomainJoinType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>
    {
        internal EndpointDependency() { }
        public string Description { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail> EndpointDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.EndpointDependency JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.EndpointDependency PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.EndpointDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.EndpointDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentTypeEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentTypeEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus left, Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus left, Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageValidationErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails>
    {
        internal ImageValidationErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageValidationStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.ImageValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationStatus TimedOut { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus left, Azure.ResourceManager.DevCenter.Models.ImageValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.ImageValidationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus left, Azure.ResourceManager.DevCenter.Models.ImageValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyEncryptionKeyIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>
    {
        public KeyEncryptionKeyIdentity() { }
        public System.Guid? DelegatedIdentityClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterKeyEncryptionKeyIdentityType? IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocalAdminStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.LocalAdminStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalAdminStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.LocalAdminStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.LocalAdminStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus left, Azure.ResourceManager.DevCenter.Models.LocalAdminStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.LocalAdminStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus left, Azure.ResourceManager.DevCenter.Models.LocalAdminStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutboundEnvironmentEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>
    {
        internal OutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.EndpointDependency> Endpoints { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendedMachineConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>
    {
        public RecommendedMachineConfiguration() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange Memory { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange VCpus { get { throw null; } }
        protected virtual Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StopOnDisconnectConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration>
    {
        public StopOnDisconnectConfiguration() { }
        public int? GracePeriodMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StopOnDisconnectEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StopOnDisconnectEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus left, Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus left, Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
