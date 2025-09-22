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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus? ValidationStatus { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DevCenter.Models.CatalogConnectionState? ConnectionState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog GitHub { get { throw null; } set { } }
        public System.DateTimeOffset? LastConnectionOn { get { throw null; } }
        public System.DateTimeOffset? LastSyncOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.CatalogSyncStats LastSyncStats { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState? SyncState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.CatalogSyncType? SyncType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterCatalogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterCatalogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevcenterCatalogEnvironmentDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource>, System.Collections.IEnumerable
    {
        protected DevcenterCatalogEnvironmentDefinitionCollection() { }
        public virtual Azure.Response<bool> Exists(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource> Get(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource>> GetAsync(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource> GetIfExists(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource>> GetIfExistsAsync(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevcenterCatalogEnvironmentDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevcenterCatalogEnvironmentDefinitionResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string catalogName, string environmentDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails> GetErrorDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails>> GetErrorDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevcenterCatalogImageDefinitionBuildCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource>, System.Collections.IEnumerable
    {
        protected DevcenterCatalogImageDefinitionBuildCollection() { }
        public virtual Azure.Response<bool> Exists(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource> Get(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource>> GetAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource> GetIfExists(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource>> GetIfExistsAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevcenterCatalogImageDefinitionBuildResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevcenterCatalogImageDefinitionBuildResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string catalogName, string imageDefinitionName, string buildName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails> GetBuildDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails>> GetBuildDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevcenterCatalogImageDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource>, System.Collections.IEnumerable
    {
        protected DevcenterCatalogImageDefinitionCollection() { }
        public virtual Azure.Response<bool> Exists(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource> Get(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource>> GetAsync(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource> GetIfExists(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource>> GetIfExistsAsync(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevcenterCatalogImageDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevcenterCatalogImageDefinitionResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation BuildImage(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BuildImageAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string catalogName, string imageDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource> GetDevcenterCatalogImageDefinitionBuild(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource>> GetDevcenterCatalogImageDefinitionBuildAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildCollection GetDevcenterCatalogImageDefinitionBuilds() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails> GetErrorDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails>> GetErrorDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterCatalogResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterCatalogResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Connect(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ConnectAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string catalogName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource> GetDevcenterCatalogEnvironmentDefinition(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource>> GetDevcenterCatalogEnvironmentDefinitionAsync(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionCollection GetDevcenterCatalogEnvironmentDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource> GetDevcenterCatalogImageDefinition(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource>> GetDevcenterCatalogImageDefinitionAsync(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionCollection GetDevcenterCatalogImageDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource> GetDevCenterCustomizationTask(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource>> GetDevCenterCustomizationTaskAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskCollection GetDevCenterCustomizationTasks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails> GetSyncErrorDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails>> GetSyncErrorDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DevCenterCustomizationTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource>, System.Collections.IEnumerable
    {
        protected DevCenterCustomizationTaskCollection() { }
        public virtual Azure.Response<bool> Exists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource> Get(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource>> GetAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource> GetIfExists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource>> GetIfExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterCustomizationTaskData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>
    {
        public DevCenterCustomizationTaskData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DevCenter.Models.CustomizationTaskInput> Inputs { get { throw null; } }
        public int? Timeout { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus? ValidationStatus { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterCustomizationTaskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterCustomizationTaskResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string catalogName, string taskName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails> GetErrorDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails>> GetErrorDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterData>
    {
        public DevCenterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus? CatalogItemSyncEnableStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryption CustomerManagedKeyEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.InstallAzureMonitorAgentEnableStatus? DevBoxProvisioningInstallAzureMonitorAgentEnableStatus { get { throw null; } set { } }
        public System.Uri DevCenterUri { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus? MicrosoftHostedNetworkEnableStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DevCenter.Models.DevboxDisksEncryptionEnableStatus? DevboxDisksEncryptionEnableStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public System.Uri KeyEncryptionKeyUri { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class DevCenterEnvironmentDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>
    {
        public DevCenterEnvironmentDefinitionData() { }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionContent> Parameters { get { throw null; } }
        public string TemplatePath { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus? ValidationStatus { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult> ExecuteCheckScopedNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DevCenter.Models.CheckScopedNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>> ExecuteCheckScopedNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DevCenter.Models.CheckScopedNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource GetAllowedEnvironmentTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource GetAttachedNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevBoxDefinitionResource GetDevBoxDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCenter(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> GetDevCenterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource GetDevcenterCatalogEnvironmentDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource GetDevcenterCatalogImageDefinitionBuildResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource GetDevcenterCatalogImageDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCatalogResource GetDevCenterCatalogResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource GetDevCenterCustomizationTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource GetDevCenterProjectCatalogResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource GetDevCenterProjectEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource GetProjectDevBoxDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectImageResource GetProjectImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectImageVersionResource GetProjectImageVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectPolicyResource GetProjectPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public string Description { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? HibernateSupport { get { throw null; } }
        public string Offer { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration RecommendedMachineConfiguration { get { throw null; } }
        public string Sku { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterImageDefinitionBuildData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>
    {
        public DevCenterImageDefinitionBuildData() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ImageReference { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterImageDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>
    {
        public DevCenterImageDefinitionData() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ActiveImageReference { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.AutoImageBuildStatus? AutoImageBuild { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageDefinitionReference Extends { get { throw null; } set { } }
        public System.Uri FileUri { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails ImageValidationErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? ImageValidationStatus { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.LatestImageBuild LatestBuild { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInstance> Tasks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInstance> UserTasks { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus? ValidationStatus { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DevCenter.Models.ActiveHoursConfiguration ActiveHoursConfiguration { get { throw null; } set { } }
        public int? DevBoxCount { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.PoolDevBox DevBoxDefinition { get { throw null; } set { } }
        public string DevBoxDefinitionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.PoolDevBoxDefinitionType? DevBoxDefinitionType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevBoxTunnelEnableStatus? DevBoxTunnelEnableStatus { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus? HealthStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail> HealthStatusDetails { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? LocalAdministrator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedVirtualNetworkRegions { get { throw null; } }
        public string NetworkConnectionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.PoolUpdateSingleSignOnStatus? SingleSignOnStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration StopOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.StopOnNoConnectConfiguration StopOnNoConnect { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.VirtualNetworkType? VirtualNetworkType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetDevCenterSchedule(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetDevCenterScheduleAsync(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DevCenterProjectCatalogCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource>, System.Collections.IEnumerable
    {
        protected DevCenterProjectCatalogCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.DevCenter.DevCenterCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.DevCenter.DevCenterCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource> Get(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource>> GetAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource> GetIfExists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource>> GetIfExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterProjectCatalogResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterProjectCatalogResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Connect(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ConnectAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string catalogName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource> GetProjectCatalogEnvironmentDefinition(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource>> GetProjectCatalogEnvironmentDefinitionAsync(string environmentDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionCollection GetProjectCatalogEnvironmentDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource> GetProjectCatalogImageDefinition(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource>> GetProjectCatalogImageDefinitionAsync(string imageDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionCollection GetProjectCatalogImageDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails> GetSyncErrorDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails>> GetSyncErrorDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Sync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SyncAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterCatalogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterCatalogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterCatalogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode? AzureAiServicesMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.CatalogItemType> CatalogItemSyncTypes { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ProjectCustomizationSettings CustomizationSettings { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevBoxAutoDeleteSettings DevBoxAutoDeleteSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DevCenterId { get { throw null; } set { } }
        public System.Uri DevCenterUri { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public int? MaxDevBoxesPerUser { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsSettings ServerlessGpuSessionsSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.WorkspaceStorageMode? WorkspaceStorageMode { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource> GetDevCenterPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> GetDevCenterPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterPoolCollection GetDevCenterPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource> GetDevCenterProjectCatalog(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource>> GetDevCenterProjectCatalogAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectCatalogCollection GetDevCenterProjectCatalogs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> GetDevCenterProjectEnvironment(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> GetDevCenterProjectEnvironmentAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentCollection GetDevCenterProjectEnvironments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.InheritedSettingsForProject> GetInheritedSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.InheritedSettingsForProject>> GetInheritedSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> GetProjectAttachedNetworkConnection(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>> GetProjectAttachedNetworkConnectionAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionCollection GetProjectAttachedNetworkConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> GetProjectDevBoxDefinition(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>> GetProjectDevBoxDefinitionAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionCollection GetProjectDevBoxDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageResource> GetProjectImage(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectImageResource>> GetProjectImageAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectImageCollection GetProjectImages() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetImages(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetImagesAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterImageData> GetImagesByDevCenter(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterImageData> GetImagesByDevCenterAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectPolicyCollection GetProjectPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectPolicyResource> GetProjectPolicy(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectPolicyResource>> GetProjectPolicyAsync(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<bool> Exists(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> Get(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetAsync(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetIfExists(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetIfExistsAsync(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterScheduleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>
    {
        public DevCenterScheduleData() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency? Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType? ScheduledType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus? State { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> Get(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch patch, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch patch, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthCheckStatusDetailData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData>
    {
        public HealthCheckStatusDetailData() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck> HealthChecks { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class ProjectCatalogEnvironmentDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectCatalogEnvironmentDefinitionResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string catalogName, string environmentDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails> GetErrorDetailsProjectCatalogEnvironmentDefinition(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails>> GetErrorDetailsProjectCatalogEnvironmentDefinitionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ProjectCatalogImageDefinitionBuildResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectCatalogImageDefinitionBuildResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string catalogName, string imageDefinitionName, string buildName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails> GetBuildDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails>> GetBuildDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ProjectCatalogImageDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectCatalogImageDefinitionResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation BuildImage(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BuildImageAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string catalogName, string imageDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails> GetErrorDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails>> GetErrorDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource> GetProjectCatalogImageDefinitionBuild(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource>> GetProjectCatalogImageDefinitionBuildAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildCollection GetProjectCatalogImageDefinitionBuilds() { throw null; }
        Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ProjectPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectPolicyResource>, System.Collections.IEnumerable
    {
        protected ProjectPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectPolicyName, Azure.ResourceManager.DevCenter.ProjectPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectPolicyName, Azure.ResourceManager.DevCenter.ProjectPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectPolicyResource> Get(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectPolicyResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectPolicyResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectPolicyResource>> GetAsync(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectPolicyResource> GetIfExists(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectPolicyResource>> GetIfExistsAsync(string projectPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ProjectPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ProjectPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>
    {
        public ProjectPolicyData() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.ProjectPolicyUpdateResourcePolicy> ResourcePolicies { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.ProjectPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.ProjectPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectPolicyResource() { }
        public virtual Azure.ResourceManager.DevCenter.ProjectPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string projectPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevCenter.ProjectPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.ProjectPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.ProjectPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.ProjectPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.ProjectPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.DevCenter.DevcenterCatalogEnvironmentDefinitionResource GetDevcenterCatalogEnvironmentDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionBuildResource GetDevcenterCatalogImageDefinitionBuildResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevcenterCatalogImageDefinitionResource GetDevcenterCatalogImageDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogResource GetDevCenterCatalogResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskResource GetDevCenterCustomizationTaskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterEncryptionSetResource GetDevCenterEncryptionSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource GetDevCenterEnvironmentTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterGalleryResource GetDevCenterGalleryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterImageResource GetDevCenterImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource GetDevCenterNetworkConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterPoolResource GetDevCenterPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectCatalogResource GetDevCenterProjectCatalogResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource GetDevCenterProjectEnvironmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectResource GetDevCenterProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterResource GetDevCenterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterScheduleResource GetDevCenterScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.HealthCheckStatusDetailResource GetHealthCheckStatusDetailResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ImageVersionResource GetImageVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource GetProjectAttachedNetworkConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogEnvironmentDefinitionResource GetProjectCatalogEnvironmentDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionBuildResource GetProjectCatalogImageDefinitionBuildResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectCatalogImageDefinitionResource GetProjectCatalogImageDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource GetProjectDevBoxDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectImageResource GetProjectImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectImageVersionResource GetProjectImageVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectPolicyResource GetProjectPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult> ExecuteCheckScopedNameAvailability(Azure.ResourceManager.DevCenter.Models.CheckScopedNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>> ExecuteCheckScopedNameAvailabilityAsync(Azure.ResourceManager.DevCenter.Models.CheckScopedNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ActiveHoursConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ActiveHoursConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ActiveHoursConfiguration>
    {
        public ActiveHoursConfiguration() { }
        public Azure.ResourceManager.DevCenter.Models.AutoStartEnableStatus? AutoStartEnableStatus { get { throw null; } set { } }
        public int? DaysOfWeekLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DayOfWeek> DefaultDaysOfWeek { get { throw null; } }
        public int? DefaultEndTimeHour { get { throw null; } set { } }
        public int? DefaultStartTimeHour { get { throw null; } set { } }
        public string DefaultTimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.KeepAwakeEnableStatus? KeepAwakeEnableStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ActiveHoursConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ActiveHoursConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ActiveHoursConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ActiveHoursConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ActiveHoursConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ActiveHoursConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ActiveHoursConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmDevCenterModelFactory
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData AllowedEnvironmentTypeData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData AllowedEnvironmentTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), string displayName = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData AttachedNetworkConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.Core.ResourceIdentifier networkConnectionId = null, Azure.Core.AzureLocation? networkConnectionLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? healthCheckStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus?), Azure.ResourceManager.DevCenter.Models.DomainJoinType? domainJoinType = default(Azure.ResourceManager.DevCenter.Models.DomainJoinType?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CatalogConflictError CatalogConflictError(string path = null, string name = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails CatalogErrorDetails(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails CatalogResourceValidationErrorDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails> errors = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CatalogSyncError CatalogSyncError(string path = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails> errorDetails = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails CatalogSyncErrorDetails(Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails operationError = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.CatalogConflictError> conflicts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.CatalogSyncError> errors = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CatalogSyncStats CatalogSyncStats(int? added = default(int?), int? updated = default(int?), int? unchanged = default(int?), int? removed = default(int?), int? validationErrors = default(int?), int? synchronizationErrors = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.CatalogItemType> syncedCatalogItemTypes = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CustomizationTaskInput CustomizationTaskInput(string description = null, Azure.ResourceManager.DevCenter.Models.CustomizationTaskInputType? inputType = default(Azure.ResourceManager.DevCenter.Models.CustomizationTaskInputType?), bool? isRequired = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DevCenter.DevBoxDefinitionData DevBoxDefinitionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference = null, Azure.ResourceManager.DevCenter.Models.DevCenterSku sku = null, string osStorageType = null, Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? hibernateSupport = default(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? imageValidationStatus = default(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus?), Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails imageValidationErrorDetails = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageReference activeImageReference = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevBoxDefinitionData DevBoxDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference = null, Azure.ResourceManager.DevCenter.Models.DevCenterSku sku = null, string osStorageType = null, Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? hibernateSupport = default(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? imageValidationStatus = default(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus?), Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails imageValidationErrorDetails = null, Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus? validationStatus = default(Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterImageReference activeImageReference = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCapability DevCenterCapability(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCatalogData DevCenterCatalogData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog gitHub = null, Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog adoGit = null, Azure.ResourceManager.DevCenter.Models.CatalogSyncType? syncType = default(Azure.ResourceManager.DevCenter.Models.CatalogSyncType?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState? syncState = default(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState?), Azure.ResourceManager.DevCenter.Models.CatalogSyncStats lastSyncStats = null, Azure.ResourceManager.DevCenter.Models.CatalogConnectionState? connectionState = default(Azure.ResourceManager.DevCenter.Models.CatalogConnectionState?), System.DateTimeOffset? lastConnectionOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSyncOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DevCenter.DevCenterCatalogData DevCenterCatalogData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog gitHub, Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog adoGit, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState? syncState, System.DateTimeOffset? lastSyncOn) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCustomizationTaskData DevCenterCustomizationTaskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DevCenter.Models.CustomizationTaskInput> inputs = null, int? timeout = default(int?), Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus? validationStatus = default(Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterData DevCenterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryption customerManagedKeyEncryption = null, string displayName = null, Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus? catalogItemSyncEnableStatus = default(Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus?), Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus? microsoftHostedNetworkEnableStatus = default(Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus?), Azure.ResourceManager.DevCenter.Models.InstallAzureMonitorAgentEnableStatus? devBoxProvisioningInstallAzureMonitorAgentEnableStatus = default(Azure.ResourceManager.DevCenter.Models.InstallAzureMonitorAgentEnableStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), System.Uri devCenterUri = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DevCenter.DevCenterData DevCenterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), System.Uri devCenterUri = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterEncryptionSetData DevCenterEncryptionSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.DevCenter.Models.DevboxDisksEncryptionEnableStatus? devboxDisksEncryptionEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevboxDisksEncryptionEnableStatus?), System.Uri keyEncryptionKeyUri = null, Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity keyEncryptionKeyIdentity = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail DevCenterEndpointDetail(int? port = default(int?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterEnvironmentDefinitionData DevCenterEnvironmentDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionContent> parameters = null, string templatePath = null, Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus? validationStatus = default(Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole DevCenterEnvironmentRole(string roleName = null, string description = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData DevCenterEnvironmentTypeData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData DevCenterEnvironmentTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, string displayName = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterGalleryData DevCenterGalleryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.Core.ResourceIdentifier galleryResourceId = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck DevCenterHealthCheck(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? status = default(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus?), string displayName = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string errorType = null, string recommendedAction = null, string additionalDetails = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail DevCenterHealthStatusDetail(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterImageData DevCenterImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string publisher = null, string offer = null, string sku = null, Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration recommendedMachineConfiguration = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? hibernateSupport = default(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterImageDefinitionBuildData DevCenterImageDefinitionBuildData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference = null, Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus? status = default(Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails errorDetails = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterImageDefinitionData DevCenterImageDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference = null, System.Uri fileUri = null, Azure.ResourceManager.DevCenter.Models.LatestImageBuild latestBuild = null, Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? imageValidationStatus = default(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus?), Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails imageValidationErrorDetails = null, Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus? validationStatus = default(Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterImageReference activeImageReference = null, Azure.ResourceManager.DevCenter.Models.AutoImageBuildStatus? autoImageBuild = default(Azure.ResourceManager.DevCenter.Models.AutoImageBuildStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInstance> tasks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInstance> userTasks = null, Azure.ResourceManager.DevCenter.Models.ImageDefinitionReference extends = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageReference DevCenterImageReference(Azure.Core.ResourceIdentifier id = null, string exactVersion = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult DevCenterNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason? reason = default(Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData DevCenterNetworkConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier subnetId = null, string domainName = null, string organizationUnit = null, string domainUsername = null, string domainPassword = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? healthCheckStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus?), string networkingResourceGroupName = null, Azure.ResourceManager.DevCenter.Models.DomainJoinType? domainJoinType = default(Azure.ResourceManager.DevCenter.Models.DomainJoinType?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus DevCenterOperationStatus(Azure.Core.ResourceIdentifier id, string name, string status, float? percentComplete = default(float?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Models.OperationStatusResult> operations = null, Azure.ResponseError error = null, Azure.Core.ResourceIdentifier resourceId = null, System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus DevCenterOperationStatus(Azure.Core.ResourceIdentifier id = null, string name = null, string status = null, float? percentComplete = default(float?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Models.OperationStatusResult> operations = null, Azure.ResponseError error = null, System.BinaryData properties = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterPoolData DevCenterPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevCenter.Models.PoolDevBoxDefinitionType? devBoxDefinitionType = default(Azure.ResourceManager.DevCenter.Models.PoolDevBoxDefinitionType?), string devBoxDefinitionName = null, Azure.ResourceManager.DevCenter.Models.PoolDevBox devBoxDefinition = null, string networkConnectionName = null, Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType? licenseType = default(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType?), Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? localAdministrator = default(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus?), Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration stopOnDisconnect = null, Azure.ResourceManager.DevCenter.Models.StopOnNoConnectConfiguration stopOnNoConnect = null, Azure.ResourceManager.DevCenter.Models.PoolUpdateSingleSignOnStatus? singleSignOnStatus = default(Azure.ResourceManager.DevCenter.Models.PoolUpdateSingleSignOnStatus?), string displayName = null, Azure.ResourceManager.DevCenter.Models.VirtualNetworkType? virtualNetworkType = default(Azure.ResourceManager.DevCenter.Models.VirtualNetworkType?), System.Collections.Generic.IEnumerable<string> managedVirtualNetworkRegions = null, Azure.ResourceManager.DevCenter.Models.ActiveHoursConfiguration activeHoursConfiguration = null, Azure.ResourceManager.DevCenter.Models.DevBoxTunnelEnableStatus? devBoxTunnelEnableStatus = default(Azure.ResourceManager.DevCenter.Models.DevBoxTunnelEnableStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus? healthStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail> healthStatusDetails = null, int? devBoxCount = default(int?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DevCenter.DevCenterPoolData DevCenterPoolData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string devBoxDefinitionName = null, string networkConnectionName = null, Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType? licenseType = default(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType?), Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? localAdministrator = default(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus?), Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration stopOnDisconnect = null, Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus? healthStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail> healthStatusDetails = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DevCenter.DevCenterProjectData DevCenterProjectData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier devCenterId = null, string description = null, int? maxDevBoxesPerUser = default(int?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), System.Uri devCenterUri = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectData DevCenterProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.Core.ResourceIdentifier devCenterId = null, string description = null, int? maxDevBoxesPerUser = default(int?), string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.CatalogItemType> catalogItemSyncTypes = null, Azure.ResourceManager.DevCenter.Models.ProjectCustomizationSettings customizationSettings = null, Azure.ResourceManager.DevCenter.Models.DevBoxAutoDeleteSettings devBoxAutoDeleteSettings = null, Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode? azureAiServicesMode = default(Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode?), Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsSettings serverlessGpuSessionsSettings = null, Azure.ResourceManager.DevCenter.Models.WorkspaceStorageMode? workspaceStorageMode = default(Azure.ResourceManager.DevCenter.Models.WorkspaceStorageMode?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), System.Uri devCenterUri = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData DevCenterProjectEnvironmentData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.Core.ResourceIdentifier deploymentTargetId = null, Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus? status = default(Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> roles = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments> userRoleAssignments = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData DevCenterProjectEnvironmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.Core.ResourceIdentifier deploymentTargetId = null, string displayName = null, Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus? status = default(Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> roles = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments> userRoleAssignments = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), int? environmentCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange DevCenterResourceRange(int? min = default(int?), int? max = default(int?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterScheduleData DevCenterScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType? scheduledType = default(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType?), Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency? frequency = default(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency?), string time = null, string timeZone = null, Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus? state = default(Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails DevCenterSkuDetails(string name = null, Azure.ResourceManager.DevCenter.Models.DevCenterSkuTier? tier = default(Azure.ResourceManager.DevCenter.Models.DevCenterSkuTier?), string size = null, string family = null, int? capacity = default(int?), Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterCapability> capabilities = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUsage DevCenterUsage(long? currentValue, long? limit, Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit? unit, Azure.ResourceManager.DevCenter.Models.DevCenterUsageName name) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUsage DevCenterUsage(long? currentValue = default(long?), long? limit = default(long?), Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit? unit = default(Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit?), Azure.ResourceManager.DevCenter.Models.DevCenterUsageName name = null, Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUsageName DevCenterUsageName(string localizedValue = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.EndpointDependency EndpointDependency(string domainName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail> endpointDetails = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionContent EnvironmentDefinitionContent(System.Guid? id = default(System.Guid?), string name = null, string description = null, Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType? parameterType = default(Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType?), bool? isReadOnly = default(bool?), bool? isRequired = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData HealthCheckStatusDetailData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck> healthChecks = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails ImageCreationErrorDetails(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails ImageDefinitionBuildDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference = null, Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus? status = default(Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails errorDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskGroup> taskGroups = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTask ImageDefinitionBuildTask(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskParametersItem> parameters = null, string displayName = null, string id = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus? status = default(Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus?), System.Uri logUri = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskGroup ImageDefinitionBuildTaskGroup(string name = null, Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus? status = default(Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTask> tasks = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskParametersItem ImageDefinitionBuildTaskParametersItem(string key = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails ImageValidationErrorDetails(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.ImageVersionData ImageVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string namePropertiesName = null, System.DateTimeOffset? publishedOn = default(System.DateTimeOffset?), bool? isExcludedFromLatest = default(bool?), int? osDiskImageSizeInGB = default(int?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.InheritedSettingsForProject InheritedSettingsForProject(Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus? catalogItemSyncEnableStatus = default(Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus?), Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus? microsoftHostedNetworkEnableStatus = default(Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.LatestImageBuild LatestImageBuild(string name = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus? status = default(Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint OutboundEnvironmentEndpoint(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.EndpointDependency> endpoints = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.PoolDevBox PoolDevBox(Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference = null, Azure.ResourceManager.DevCenter.Models.DevCenterSku sku = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageReference activeImageReference = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectPolicyData ProjectPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.ProjectPolicyUpdateResourcePolicy> resourcePolicies = null, System.Collections.Generic.IEnumerable<string> scopes = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration RecommendedMachineConfiguration(Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange memory = null, Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange vCpus = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoImageBuildStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.AutoImageBuildStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoImageBuildStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.AutoImageBuildStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.AutoImageBuildStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.AutoImageBuildStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.AutoImageBuildStatus left, Azure.ResourceManager.DevCenter.Models.AutoImageBuildStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.AutoImageBuildStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.AutoImageBuildStatus left, Azure.ResourceManager.DevCenter.Models.AutoImageBuildStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoStartEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.AutoStartEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoStartEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.AutoStartEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.AutoStartEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.AutoStartEnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.AutoStartEnableStatus left, Azure.ResourceManager.DevCenter.Models.AutoStartEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.AutoStartEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.AutoStartEnableStatus left, Azure.ResourceManager.DevCenter.Models.AutoStartEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode left, Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode left, Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CatalogConflictError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogConflictError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogConflictError>
    {
        internal CatalogConflictError() { }
        public string Name { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CatalogConflictError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogConflictError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogConflictError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CatalogConflictError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogConflictError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogConflictError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogConflictError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CatalogConnectionState : System.IEquatable<Azure.ResourceManager.DevCenter.Models.CatalogConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CatalogConnectionState(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CatalogConnectionState Connected { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.CatalogConnectionState Disconnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.CatalogConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.CatalogConnectionState left, Azure.ResourceManager.DevCenter.Models.CatalogConnectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.CatalogConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.CatalogConnectionState left, Azure.ResourceManager.DevCenter.Models.CatalogConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CatalogErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails>
    {
        internal CatalogErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CatalogItemSyncEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CatalogItemSyncEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus left, Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus left, Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CatalogItemType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.CatalogItemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CatalogItemType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CatalogItemType EnvironmentDefinition { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.CatalogItemType ImageDefinition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.CatalogItemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.CatalogItemType left, Azure.ResourceManager.DevCenter.Models.CatalogItemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.CatalogItemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.CatalogItemType left, Azure.ResourceManager.DevCenter.Models.CatalogItemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CatalogResourceValidationErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails>
    {
        internal CatalogResourceValidationErrorDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails> Errors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CatalogResourceValidationStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CatalogResourceValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus left, Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus left, Azure.ResourceManager.DevCenter.Models.CatalogResourceValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CatalogSyncError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncError>
    {
        internal CatalogSyncError() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails> ErrorDetails { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CatalogSyncError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CatalogSyncError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CatalogSyncErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails>
    {
        internal CatalogSyncErrorDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.CatalogConflictError> Conflicts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.CatalogSyncError> Errors { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.CatalogErrorDetails OperationError { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CatalogSyncStats : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncStats>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncStats>
    {
        internal CatalogSyncStats() { }
        public int? Added { get { throw null; } }
        public int? Removed { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.CatalogItemType> SyncedCatalogItemTypes { get { throw null; } }
        public int? SynchronizationErrors { get { throw null; } }
        public int? Unchanged { get { throw null; } }
        public int? Updated { get { throw null; } }
        public int? ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CatalogSyncStats System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CatalogSyncStats System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CatalogSyncStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CatalogSyncType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.CatalogSyncType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CatalogSyncType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CatalogSyncType Manual { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.CatalogSyncType Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.CatalogSyncType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.CatalogSyncType left, Azure.ResourceManager.DevCenter.Models.CatalogSyncType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.CatalogSyncType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.CatalogSyncType left, Azure.ResourceManager.DevCenter.Models.CatalogSyncType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckScopedNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CheckScopedNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CheckScopedNameAvailabilityContent>
    {
        public CheckScopedNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CheckScopedNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CheckScopedNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CheckScopedNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CheckScopedNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CheckScopedNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CheckScopedNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CheckScopedNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CmkIdentityType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.CmkIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CmkIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CmkIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.CmkIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.CmkIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.CmkIdentityType left, Azure.ResourceManager.DevCenter.Models.CmkIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.CmkIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.CmkIdentityType left, Azure.ResourceManager.DevCenter.Models.CmkIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomerManagedKeyEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryption>
    {
        public CustomerManagedKeyEncryption() { }
        public Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public System.Uri KeyEncryptionKeyUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomerManagedKeyEncryptionKeyIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryptionKeyIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryptionKeyIdentity>
    {
        public CustomerManagedKeyEncryptionKeyIdentity() { }
        public System.Guid? DelegatedIdentityClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.IdentityType? IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryptionKeyIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryptionKeyIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryptionKeyIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryptionKeyIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryptionKeyIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryptionKeyIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomerManagedKeyEncryptionKeyIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomizationTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInput>
    {
        internal CustomizationTaskInput() { }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.CustomizationTaskInputType? InputType { get { throw null; } }
        public bool? IsRequired { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CustomizationTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CustomizationTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomizationTaskInputType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomizationTaskInputType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.CustomizationTaskInputType Boolean { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.CustomizationTaskInputType Number { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.CustomizationTaskInputType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.CustomizationTaskInputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.CustomizationTaskInputType left, Azure.ResourceManager.DevCenter.Models.CustomizationTaskInputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.CustomizationTaskInputType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.CustomizationTaskInputType left, Azure.ResourceManager.DevCenter.Models.CustomizationTaskInputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomizationTaskInstance : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInstance>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInstance>
    {
        public CustomizationTaskInstance(string name) { }
        public string Condition { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DefinitionParametersItem> Parameters { get { throw null; } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CustomizationTaskInstance System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInstance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInstance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.CustomizationTaskInstance System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInstance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInstance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.CustomizationTaskInstance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DefinitionParametersItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DefinitionParametersItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DefinitionParametersItem>
    {
        public DefinitionParametersItem(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DefinitionParametersItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DefinitionParametersItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DefinitionParametersItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DefinitionParametersItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DefinitionParametersItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DefinitionParametersItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DefinitionParametersItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevBoxAutoDeleteSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevBoxAutoDeleteSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevBoxAutoDeleteSettings>
    {
        public DevBoxAutoDeleteSettings() { }
        public Azure.ResourceManager.DevCenter.Models.DevBoxDeleteMode? DeleteMode { get { throw null; } set { } }
        public string GracePeriod { get { throw null; } set { } }
        public string InactiveThreshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevBoxAutoDeleteSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevBoxAutoDeleteSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevBoxAutoDeleteSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevBoxAutoDeleteSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevBoxAutoDeleteSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevBoxAutoDeleteSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevBoxAutoDeleteSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevBoxDefinitionPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>
    {
        public DevBoxDefinitionPatch() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? HibernateSupport { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ImageReference { get { throw null; } set { } }
        public string OSStorageType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevBoxDeleteMode : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevBoxDeleteMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevBoxDeleteMode(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevBoxDeleteMode Auto { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevBoxDeleteMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevBoxDeleteMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevBoxDeleteMode left, Azure.ResourceManager.DevCenter.Models.DevBoxDeleteMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevBoxDeleteMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevBoxDeleteMode left, Azure.ResourceManager.DevCenter.Models.DevBoxDeleteMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevboxDisksEncryptionEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevboxDisksEncryptionEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevboxDisksEncryptionEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevboxDisksEncryptionEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevboxDisksEncryptionEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevboxDisksEncryptionEnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevboxDisksEncryptionEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevboxDisksEncryptionEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevboxDisksEncryptionEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevboxDisksEncryptionEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevboxDisksEncryptionEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevBoxTunnelEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevBoxTunnelEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevBoxTunnelEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevBoxTunnelEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevBoxTunnelEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevBoxTunnelEnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevBoxTunnelEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevBoxTunnelEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevBoxTunnelEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevBoxTunnelEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevBoxTunnelEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>
    {
        internal DevCenterCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterCatalogPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>
    {
        public DevCenterCatalogPatch() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog AdoGit { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog GitHub { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.CatalogSyncType? SyncType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterEncryptionSetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEncryptionSetPatch>
    {
        public DevCenterEncryptionSetPatch() { }
        public Azure.ResourceManager.DevCenter.Models.DevboxDisksEncryptionEnableStatus? DevboxDisksEncryptionEnableStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public System.Uri KeyEncryptionKeyUri { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterEnvironmentRole : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole>
    {
        public DevCenterEnvironmentRole() { }
        public string Description { get { throw null; } }
        public string RoleName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterGitCatalog : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>
    {
        public DevCenterGitCatalog() { }
        public string Branch { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string SecretIdentifier { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterHealthCheck : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck>
    {
        internal DevCenterHealthCheck() { }
        public string AdditionalDetails { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string ErrorType { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterHealthStatusDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail>
    {
        internal DevCenterHealthStatusDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport left, Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport left, Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterImageReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>
    {
        public DevCenterImageReference() { }
        public string ExactVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterLicenseType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType WindowsClient { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType left, Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType left, Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent>
    {
        public DevCenterNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason left, Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason (string value) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>
    {
        public DevCenterPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterPoolPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>
    {
        public DevCenterPoolPatch() { }
        public Azure.ResourceManager.DevCenter.Models.ActiveHoursConfiguration ActiveHoursConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.PoolDevBox DevBoxDefinition { get { throw null; } set { } }
        public string DevBoxDefinitionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.PoolDevBoxDefinitionType? DevBoxDefinitionType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevBoxTunnelEnableStatus? DevBoxTunnelEnableStatus { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? LocalAdministrator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedVirtualNetworkRegions { get { throw null; } }
        public string NetworkConnectionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.PoolUpdateSingleSignOnStatus? SingleSignOnStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration StopOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.StopOnNoConnectConfiguration StopOnNoConnect { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.VirtualNetworkType? VirtualNetworkType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterProjectPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>
    {
        public DevCenterProjectPatch() { }
        public Azure.ResourceManager.DevCenter.Models.AzureAiServicesMode? AzureAiServicesMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.CatalogItemType> CatalogItemSyncTypes { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ProjectCustomizationSettings CustomizationSettings { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevBoxAutoDeleteSettings DevBoxAutoDeleteSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DevCenterId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public int? MaxDevBoxesPerUser { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsSettings ServerlessGpuSessionsSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.WorkspaceStorageMode? WorkspaceStorageMode { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState left, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState left, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterResourceRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange>
    {
        internal DevCenterResourceRange() { }
        public int? Max { get { throw null; } }
        public int? Min { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterResourceType left, Azure.ResourceManager.DevCenter.Models.DevCenterResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterResourceType (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus (string value) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterSku>
    {
        public DevCenterSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSkuTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class DevCenterTrackedResourceUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate>
    {
        public DevCenterTrackedResourceUpdate() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterUsageName Name { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit? Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit left, Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit left, Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterUserRoleAssignments : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>
    {
        public DevCenterUserRoleAssignments() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> Roles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DomainJoinType left, Azure.ResourceManager.DevCenter.Models.DomainJoinType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DomainJoinType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DomainJoinType left, Azure.ResourceManager.DevCenter.Models.DomainJoinType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>
    {
        internal EndpointDependency() { }
        public string Description { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail> EndpointDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.EndpointDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.EndpointDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.EndpointDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnvironmentDefinitionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionContent>
    {
        internal EnvironmentDefinitionContent() { }
        public string Description { get { throw null; } }
        public System.Guid? Id { get { throw null; } }
        public bool? IsReadOnly { get { throw null; } }
        public bool? IsRequired { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType? ParameterType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentDefinitionParameterType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentDefinitionParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType Boolean { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType Integer { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType Number { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType left, Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType left, Azure.ResourceManager.DevCenter.Models.EnvironmentDefinitionParameterType right) { throw null; }
        public override string ToString() { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus left, Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus left, Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.IdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.IdentityType DelegatedResourceIdentity { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.IdentityType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.IdentityType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.IdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.IdentityType left, Azure.ResourceManager.DevCenter.Models.IdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.IdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.IdentityType left, Azure.ResourceManager.DevCenter.Models.IdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageCreationErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails>
    {
        internal ImageCreationErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageDefinitionBuildDetails : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails>
    {
        public ImageDefinitionBuildDetails() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageCreationErrorDetails ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ImageReference { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskGroup> TaskGroups { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageDefinitionBuildStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageDefinitionBuildStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus Running { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus TimedOut { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus ValidationFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus left, Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus left, Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageDefinitionBuildTask : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTask>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTask>
    {
        internal ImageDefinitionBuildTask() { }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Uri LogUri { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskParametersItem> Parameters { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTask System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTask System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageDefinitionBuildTaskGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskGroup>
    {
        internal ImageDefinitionBuildTaskGroup() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTask> Tasks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageDefinitionBuildTaskParametersItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskParametersItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskParametersItem>
    {
        internal ImageDefinitionBuildTaskParametersItem() { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskParametersItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskParametersItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskParametersItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskParametersItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskParametersItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskParametersItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildTaskParametersItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageDefinitionReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionReference>
    {
        public ImageDefinitionReference(string imageDefinition) { }
        public string ImageDefinition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.DefinitionParametersItem> Parameters { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ImageDefinitionReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ImageDefinitionReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageDefinitionReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageValidationErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails>
    {
        internal ImageValidationErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus left, Azure.ResourceManager.DevCenter.Models.ImageValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.ImageValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus left, Azure.ResourceManager.DevCenter.Models.ImageValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InheritedSettingsForProject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.InheritedSettingsForProject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.InheritedSettingsForProject>
    {
        internal InheritedSettingsForProject() { }
        public Azure.ResourceManager.DevCenter.Models.CatalogItemSyncEnableStatus? CatalogItemSyncEnableStatus { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus? MicrosoftHostedNetworkEnableStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.InheritedSettingsForProject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.InheritedSettingsForProject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.InheritedSettingsForProject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.InheritedSettingsForProject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.InheritedSettingsForProject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.InheritedSettingsForProject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.InheritedSettingsForProject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstallAzureMonitorAgentEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.InstallAzureMonitorAgentEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstallAzureMonitorAgentEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.InstallAzureMonitorAgentEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.InstallAzureMonitorAgentEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.InstallAzureMonitorAgentEnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.InstallAzureMonitorAgentEnableStatus left, Azure.ResourceManager.DevCenter.Models.InstallAzureMonitorAgentEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.InstallAzureMonitorAgentEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.InstallAzureMonitorAgentEnableStatus left, Azure.ResourceManager.DevCenter.Models.InstallAzureMonitorAgentEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeepAwakeEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.KeepAwakeEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeepAwakeEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.KeepAwakeEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.KeepAwakeEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.KeepAwakeEnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.KeepAwakeEnableStatus left, Azure.ResourceManager.DevCenter.Models.KeepAwakeEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.KeepAwakeEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.KeepAwakeEnableStatus left, Azure.ResourceManager.DevCenter.Models.KeepAwakeEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyEncryptionKeyIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>
    {
        public KeyEncryptionKeyIdentity() { }
        public Azure.ResourceManager.DevCenter.Models.CmkIdentityType? CmkIdentityType { get { throw null; } set { } }
        public string UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.KeyEncryptionKeyIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LatestImageBuild : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.LatestImageBuild>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.LatestImageBuild>
    {
        public LatestImageBuild() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageDefinitionBuildStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.LatestImageBuild System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.LatestImageBuild>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.LatestImageBuild>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.LatestImageBuild System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.LatestImageBuild>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.LatestImageBuild>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.LatestImageBuild>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus left, Azure.ResourceManager.DevCenter.Models.LocalAdminStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.LocalAdminStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus left, Azure.ResourceManager.DevCenter.Models.LocalAdminStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MicrosoftHostedNetworkEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MicrosoftHostedNetworkEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus left, Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus left, Azure.ResourceManager.DevCenter.Models.MicrosoftHostedNetworkEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutboundEnvironmentEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>
    {
        internal OutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.EndpointDependency> Endpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyAction : System.IEquatable<Azure.ResourceManager.DevCenter.Models.PolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyAction(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.PolicyAction Allow { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.PolicyAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.PolicyAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.PolicyAction left, Azure.ResourceManager.DevCenter.Models.PolicyAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.PolicyAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.PolicyAction left, Azure.ResourceManager.DevCenter.Models.PolicyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PoolDevBox : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.PoolDevBox>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.PoolDevBox>
    {
        public PoolDevBox() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ActiveImageReference { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSku Sku { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.PoolDevBox System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.PoolDevBox>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.PoolDevBox>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.PoolDevBox System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.PoolDevBox>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.PoolDevBox>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.PoolDevBox>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PoolDevBoxDefinitionType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.PoolDevBoxDefinitionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PoolDevBoxDefinitionType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.PoolDevBoxDefinitionType Reference { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.PoolDevBoxDefinitionType Value { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.PoolDevBoxDefinitionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.PoolDevBoxDefinitionType left, Azure.ResourceManager.DevCenter.Models.PoolDevBoxDefinitionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.PoolDevBoxDefinitionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.PoolDevBoxDefinitionType left, Azure.ResourceManager.DevCenter.Models.PoolDevBoxDefinitionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PoolUpdateSingleSignOnStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.PoolUpdateSingleSignOnStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PoolUpdateSingleSignOnStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.PoolUpdateSingleSignOnStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.PoolUpdateSingleSignOnStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.PoolUpdateSingleSignOnStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.PoolUpdateSingleSignOnStatus left, Azure.ResourceManager.DevCenter.Models.PoolUpdateSingleSignOnStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.PoolUpdateSingleSignOnStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.PoolUpdateSingleSignOnStatus left, Azure.ResourceManager.DevCenter.Models.PoolUpdateSingleSignOnStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectCustomizationIdentityType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectCustomizationIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ProjectCustomizationIdentityType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ProjectCustomizationIdentityType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.ProjectCustomizationIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.ProjectCustomizationIdentityType left, Azure.ResourceManager.DevCenter.Models.ProjectCustomizationIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.ProjectCustomizationIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.ProjectCustomizationIdentityType left, Azure.ResourceManager.DevCenter.Models.ProjectCustomizationIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProjectCustomizationManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationManagedIdentity>
    {
        public ProjectCustomizationManagedIdentity() { }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.ProjectCustomizationIdentityType? IdentityType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ProjectCustomizationManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ProjectCustomizationManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectCustomizationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationSettings>
    {
        public ProjectCustomizationSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationManagedIdentity> Identities { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.UserCustomizationsEnableStatus? UserCustomizationsEnableStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ProjectCustomizationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ProjectCustomizationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectCustomizationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectPolicyPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyPatch>
    {
        public ProjectPolicyPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevCenter.Models.ProjectPolicyUpdateResourcePolicy> ResourcePolicies { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ProjectPolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ProjectPolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectPolicyUpdateResourcePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyUpdateResourcePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyUpdateResourcePolicy>
    {
        public ProjectPolicyUpdateResourcePolicy() { }
        public Azure.ResourceManager.DevCenter.Models.PolicyAction? Action { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string Resources { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterResourceType? ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ProjectPolicyUpdateResourcePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyUpdateResourcePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyUpdateResourcePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ProjectPolicyUpdateResourcePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyUpdateResourcePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyUpdateResourcePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ProjectPolicyUpdateResourcePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendedMachineConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>
    {
        internal RecommendedMachineConfiguration() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange Memory { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange VCpus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerlessGpuSessionsMode : System.IEquatable<Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerlessGpuSessionsMode(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsMode AutoDeploy { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsMode Disabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsMode left, Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsMode left, Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerlessGpuSessionsSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsSettings>
    {
        public ServerlessGpuSessionsSettings() { }
        public int? MaxConcurrentSessionsPerProject { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsMode? ServerlessGpuSessionsMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.ServerlessGpuSessionsSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StopOnDisconnectConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration>
    {
        public StopOnDisconnectConfiguration() { }
        public int? GracePeriodMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus left, Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus left, Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StopOnNoConnectConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.StopOnNoConnectConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.StopOnNoConnectConfiguration>
    {
        public StopOnNoConnectConfiguration() { }
        public int? GracePeriodMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.StopOnNoConnectEnableStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.StopOnNoConnectConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.StopOnNoConnectConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevCenter.Models.StopOnNoConnectConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevCenter.Models.StopOnNoConnectConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.StopOnNoConnectConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.StopOnNoConnectConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevCenter.Models.StopOnNoConnectConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StopOnNoConnectEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.StopOnNoConnectEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StopOnNoConnectEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.StopOnNoConnectEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.StopOnNoConnectEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.StopOnNoConnectEnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.StopOnNoConnectEnableStatus left, Azure.ResourceManager.DevCenter.Models.StopOnNoConnectEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.StopOnNoConnectEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.StopOnNoConnectEnableStatus left, Azure.ResourceManager.DevCenter.Models.StopOnNoConnectEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserCustomizationsEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.UserCustomizationsEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserCustomizationsEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.UserCustomizationsEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.UserCustomizationsEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.UserCustomizationsEnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.UserCustomizationsEnableStatus left, Azure.ResourceManager.DevCenter.Models.UserCustomizationsEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.UserCustomizationsEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.UserCustomizationsEnableStatus left, Azure.ResourceManager.DevCenter.Models.UserCustomizationsEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualNetworkType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.VirtualNetworkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualNetworkType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.VirtualNetworkType Managed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.VirtualNetworkType Unmanaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.VirtualNetworkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.VirtualNetworkType left, Azure.ResourceManager.DevCenter.Models.VirtualNetworkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.VirtualNetworkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.VirtualNetworkType left, Azure.ResourceManager.DevCenter.Models.VirtualNetworkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspaceStorageMode : System.IEquatable<Azure.ResourceManager.DevCenter.Models.WorkspaceStorageMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspaceStorageMode(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.WorkspaceStorageMode AutoDeploy { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.WorkspaceStorageMode Disabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.WorkspaceStorageMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.WorkspaceStorageMode left, Azure.ResourceManager.DevCenter.Models.WorkspaceStorageMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.WorkspaceStorageMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.WorkspaceStorageMode left, Azure.ResourceManager.DevCenter.Models.WorkspaceStorageMode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
