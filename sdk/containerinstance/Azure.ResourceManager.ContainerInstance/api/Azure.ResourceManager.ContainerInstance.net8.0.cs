namespace Azure.ResourceManager.ContainerInstance
{
    public partial class AzureResourceManagerContainerInstanceContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContainerInstanceContext() { }
        public static Azure.ResourceManager.ContainerInstance.AzureResourceManagerContainerInstanceContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ContainerGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>, System.Collections.IEnumerable
    {
        protected ContainerGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string containerGroupName, Azure.ResourceManager.ContainerInstance.ContainerGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string containerGroupName, Azure.ResourceManager.ContainerInstance.ContainerGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> Get(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> GetAsync(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetIfExists(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> GetIfExistsAsync(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ContainerGroupData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer> containers) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ContainerGroupData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer> containers, Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType osType) { }
        public string ConfidentialComputeCcePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType ContainerGroupOSType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState? ContainerGroupProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer> Containers { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics DiagnosticsLogAnalytics { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration DnsConfig { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties EncryptionProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec> Extensions { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControlLevels IdentityAcls { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential> ImageRegistryCredentials { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent> InitContainers { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress IPAddress { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType OSType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy? RestartPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSecretReference> SecretReferences { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku? Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId> SubnetIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume> Volumes { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.ContainerGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.ContainerGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>, System.Collections.IEnumerable
    {
        protected ContainerGroupProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string containerGroupProfileName, Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string containerGroupProfileName, Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string containerGroupProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string containerGroupProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> Get(string containerGroupProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>> GetAsync(string containerGroupProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> GetIfExists(string containerGroupProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>> GetIfExistsAsync(string containerGroupProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerGroupProfileData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>
    {
        public ContainerGroupProfileData(Azure.Core.AzureLocation location) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ContainerGroupProfileData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer> containers, Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType osType) { }
        public string ConfidentialComputeCcePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer> Containers { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics DiagnosticsLogAnalytics { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties EncryptionProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec> Extensions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential> ImageRegistryCredentials { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent> InitContainers { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress IPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority? Priority { get { throw null; } set { } }
        public System.Collections.Generic.IList<long> RegisteredRevisions { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy? RestartPolicy { get { throw null; } set { } }
        public long? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition SecurityContext { get { throw null; } set { } }
        public System.DateTimeOffset? ShutdownGracePeriod { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku? Sku { get { throw null; } set { } }
        public System.DateTimeOffset? TimeToLive { get { throw null; } set { } }
        public bool? UseKrypton { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume> Volumes { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupProfileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerGroupProfileResource() { }
        public virtual Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerGroupProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource> GetContainerGroupProfileRevision(string revisionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource>> GetContainerGroupProfileRevisionAsync(string revisionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionCollection GetContainerGroupProfileRevisions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> Update(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>> UpdateAsync(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerGroupProfileRevisionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource>, System.Collections.IEnumerable
    {
        protected ContainerGroupProfileRevisionCollection() { }
        public virtual Azure.Response<bool> Exists(string revisionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string revisionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource> Get(string revisionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource>> GetAsync(string revisionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource> GetIfExists(string revisionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource>> GetIfExistsAsync(string revisionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerGroupProfileRevisionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerGroupProfileRevisionResource() { }
        public virtual Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerGroupProfileName, string revisionNumber) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerGroupResource() { }
        public virtual Azure.ResourceManager.ContainerInstance.ContainerGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult> AttachContainer(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult>> AttachContainerAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult> ExecuteContainerCommand(string containerName, Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult>> ExecuteContainerCommandAsync(string containerName, Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerLogs> GetContainerLogs(string containerName, int? tail = default(int?), bool? timestamps = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerLogs>> GetContainerLogsAsync(string containerName, int? tail = default(int?), bool? timestamps = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerInstance.ContainerGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.ContainerGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.ContainerGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> Update(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> UpdateAsync(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ContainerInstanceExtensions
    {
        public static Azure.ResourceManager.ArmOperation DeleteSubnetServiceAssociationLink(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string virtualNetworkName, string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteSubnetServiceAssociationLinkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string virtualNetworkName, string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.CachedImages> GetCachedImagesWithLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.CachedImages> GetCachedImagesWithLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities> GetCapabilitiesWithLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities> GetCapabilitiesWithLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> GetContainerGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> GetContainerGroupProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string containerGroupProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>> GetContainerGroupProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string containerGroupProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource GetContainerGroupProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource GetContainerGroupProfileRevisionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.ContainerGroupProfileCollection GetContainerGroupProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> GetContainerGroupProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> GetContainerGroupProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.ContainerGroupResource GetContainerGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.ContainerGroupCollection GetContainerGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource> GetNGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ngroupsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource>> GetNGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ngroupsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.NGroupResource GetNGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.NGroupCollection GetNGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.NGroupResource> GetNGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.NGroupResource> GetNGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage> GetUsagesWithLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage> GetUsagesWithLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerInstance.NGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.NGroupResource>, System.Collections.IEnumerable
    {
        protected NGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.NGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ngroupsName, Azure.ResourceManager.ContainerInstance.NGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.NGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ngroupsName, Azure.ResourceManager.ContainerInstance.NGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ngroupsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ngroupsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource> Get(string ngroupsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.NGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.NGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource>> GetAsync(string ngroupsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerInstance.NGroupResource> GetIfExists(string ngroupsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerInstance.NGroupResource>> GetIfExistsAsync(string ngroupsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerInstance.NGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerInstance.NGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerInstance.NGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.NGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.NGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.NGroupData>
    {
        public NGroupData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfileStub> ContainerGroupProfiles { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupElasticProfile ElasticProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public int? PlacementFaultDomainCount { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateProfile UpdateProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.NGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.NGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.NGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.NGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.NGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.NGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.NGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.NGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.NGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NGroupResource() { }
        public virtual Azure.ResourceManager.ContainerInstance.NGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ngroupsName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerInstance.NGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.NGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.NGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.NGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.NGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.NGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.NGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.NGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerInstance.Models.NGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.NGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerInstance.Models.NGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerInstance.Mocking
{
    public partial class MockableContainerInstanceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerInstanceArmClient() { }
        public virtual Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource GetContainerGroupProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerInstance.ContainerGroupProfileRevisionResource GetContainerGroupProfileRevisionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerInstance.ContainerGroupResource GetContainerGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerInstance.NGroupResource GetNGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableContainerInstanceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerInstanceResourceGroupResource() { }
        public virtual Azure.ResourceManager.ArmOperation DeleteSubnetServiceAssociationLink(Azure.WaitUntil waitUntil, string virtualNetworkName, string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteSubnetServiceAssociationLinkAsync(Azure.WaitUntil waitUntil, string virtualNetworkName, string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroup(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> GetContainerGroupAsync(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> GetContainerGroupProfile(string containerGroupProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource>> GetContainerGroupProfileAsync(string containerGroupProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerInstance.ContainerGroupProfileCollection GetContainerGroupProfiles() { throw null; }
        public virtual Azure.ResourceManager.ContainerInstance.ContainerGroupCollection GetContainerGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource> GetNGroup(string ngroupsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.NGroupResource>> GetNGroupAsync(string ngroupsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerInstance.NGroupCollection GetNGroups() { throw null; }
    }
    public partial class MockableContainerInstanceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerInstanceSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.CachedImages> GetCachedImagesWithLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.CachedImages> GetCachedImagesWithLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities> GetCapabilitiesWithLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities> GetCapabilitiesWithLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> GetContainerGroupProfiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.ContainerGroupProfileResource> GetContainerGroupProfilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.NGroupResource> GetNGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.NGroupResource> GetNGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage> GetUsagesWithLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage> GetUsagesWithLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ApplicationGateway : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGateway>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGateway>
    {
        public ApplicationGateway() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ApplicationGatewayBackendAddressPool> BackendAddressPools { get { throw null; } }
        public string Resource { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ApplicationGateway System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGateway>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGateway>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ApplicationGateway System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGateway>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGateway>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGateway>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationGatewayBackendAddressPool : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGatewayBackendAddressPool>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGatewayBackendAddressPool>
    {
        public ApplicationGatewayBackendAddressPool() { }
        public string Resource { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ApplicationGatewayBackendAddressPool System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGatewayBackendAddressPool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGatewayBackendAddressPool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ApplicationGatewayBackendAddressPool System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGatewayBackendAddressPool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGatewayBackendAddressPool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ApplicationGatewayBackendAddressPool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmContainerInstanceModelFactory
    {
        public static Azure.ResourceManager.ContainerInstance.Models.CachedImages CachedImages(string osType = null, string image = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult ContainerAttachResult(System.Uri webSocketUri = null, string password = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities ContainerCapabilities(string resourceType = null, string osType = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string ipAddressType = null, string gpu = null, Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities capabilities = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerEvent ContainerEvent(int? count = default(int?), System.DateTimeOffset? firstTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastTimestamp = default(System.DateTimeOffset?), string name = null, string message = null, string eventType = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult ContainerExecResult(System.Uri webSocketUri = null, string password = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.ContainerGroupData ContainerGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState? containerGroupProvisioningState = default(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSecretReference> secretReferences = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer> containers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential> imageRegistryCredentials = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy? restartPolicy = default(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy?), Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress ipAddress = null, Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType containerGroupOSType = default(Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume> volumes = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView instanceView = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics diagnosticsLogAnalytics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId> subnetIds = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration dnsConfig = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku? sku = default(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku?), Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties encryptionProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent> initContainers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec> extensions = null, string confidentialComputeCcePolicy = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority? priority = default(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority?), Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControlLevels identityAcls = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ContainerInstance.ContainerGroupData ContainerGroupData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<string> zones, Azure.ResourceManager.Models.ManagedServiceIdentity identity, string provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer> containers, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential> imageRegistryCredentials, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy? restartPolicy, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress ipAddress, Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType osType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume> volumes, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView instanceView, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics diagnosticsLogAnalytics, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId> subnetIds, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration dnsConfig, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku? sku, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties encryptionProperties, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent> initContainers, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec> extensions, string confidentialComputeCcePolicy, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority? priority) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView ContainerGroupInstanceView(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> events = null, string state = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress ContainerGroupIPAddress(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort> ports = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType addressType = default(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType), System.Net.IPAddress ip = null, string dnsNameLabel = null, Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy?), string fqdn = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch ContainerGroupPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.ContainerGroupProfileData ContainerGroupProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku? sku = default(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku?), Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties encryptionProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer> containers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent> initContainers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec> extensions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential> imageRegistryCredentials = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy? restartPolicy = default(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy?), System.DateTimeOffset? shutdownGracePeriod = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress ipAddress = null, System.DateTimeOffset? timeToLive = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType? osType = default(Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume> volumes = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics diagnosticsLogAnalytics = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority? priority = default(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority?), string confidentialComputeCcePolicy = null, Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition securityContext = null, long? revision = default(long?), System.Collections.Generic.IEnumerable<long> registeredRevisions = null, bool? useKrypton = default(bool?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer ContainerInstanceContainer(string name = null, string image = null, System.Collections.Generic.IEnumerable<string> command = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerPort> ports = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable> environmentVariables = null, Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView instanceView = null, Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements resources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount> volumeMounts = null, Azure.ResourceManager.ContainerInstance.Models.ContainerProbe livenessProbe = null, Azure.ResourceManager.ContainerInstance.Models.ContainerProbe readinessProbe = null, Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition securityContext = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage ContainerInstanceUsage(string id = null, string unit = null, int? currentValue = default(int?), int? limit = default(int?), Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName name = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName ContainerInstanceUsageName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView ContainerInstanceView(int? restartCount = default(int?), Azure.ResourceManager.ContainerInstance.Models.ContainerState currentState = null, Azure.ResourceManager.ContainerInstance.Models.ContainerState previousState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> events = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerLogs ContainerLogs(string content = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerState ContainerState(string state = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), int? exitCode = default(int?), System.DateTimeOffset? finishOn = default(System.DateTimeOffset?), string detailStatus = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities ContainerSupportedCapabilities(float? maxMemoryInGB = default(float?), float? maxCpu = default(float?), float? maxGpuCount = default(float?)) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent InitContainerDefinitionContent(string name = null, string image = null, System.Collections.Generic.IEnumerable<string> command = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable> environmentVariables = null, Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView instanceView = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount> volumeMounts = null, Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition securityContext = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView InitContainerPropertiesDefinitionInstanceView(int? restartCount = default(int?), Azure.ResourceManager.ContainerInstance.Models.ContainerState currentState = null, Azure.ResourceManager.ContainerInstance.Models.ContainerState previousState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> events = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.NGroupData NGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupElasticProfile elasticProfile = null, int? placementFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfileStub> containerGroupProfiles = null, Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState?), Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateProfile updateProfile = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.NGroupPatch NGroupPatch(Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupElasticProfile elasticProfile = null, int? placementFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfileStub> containerGroupProfiles = null, Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState?), Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateProfile updateProfile = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoGeneratedDomainNameLabelScope : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoGeneratedDomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope NoReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope TenantReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope Unsecure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum AzureFileShareAccessTier
    {
        Cool = 0,
        Hot = 1,
        Premium = 2,
        TransactionOptimized = 3,
    }
    public enum AzureFileShareAccessType
    {
        Shared = 0,
        Exclusive = 1,
    }
    public partial class CachedImages : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.CachedImages>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.CachedImages>
    {
        internal CachedImages() { }
        public string Image { get { throw null; } }
        public string OSType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.CachedImages System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.CachedImages>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.CachedImages>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.CachedImages System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.CachedImages>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.CachedImages>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.CachedImages>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerAttachResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult>
    {
        internal ContainerAttachResult() { }
        public string Password { get { throw null; } }
        public System.Uri WebSocketUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities>
    {
        internal ContainerCapabilities() { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities Capabilities { get { throw null; } }
        public string Gpu { get { throw null; } }
        public string IPAddressType { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string OSType { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerEnvironmentVariable : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable>
    {
        public ContainerEnvironmentVariable(string name) { }
        public string Name { get { throw null; } set { } }
        public string SecureValue { get { throw null; } set { } }
        public string SecureValueReference { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent>
    {
        internal ContainerEvent() { }
        public int? Count { get { throw null; } }
        public string EventType { get { throw null; } }
        public System.DateTimeOffset? FirstTimestamp { get { throw null; } }
        public System.DateTimeOffset? LastTimestamp { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerExecContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent>
    {
        public ContainerExecContent() { }
        public string Command { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerExecRequestTerminalSize TerminalSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerExecRequestTerminalSize : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecRequestTerminalSize>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecRequestTerminalSize>
    {
        public ContainerExecRequestTerminalSize() { }
        public int? Cols { get { throw null; } set { } }
        public int? Rows { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerExecRequestTerminalSize System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecRequestTerminalSize>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecRequestTerminalSize>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerExecRequestTerminalSize System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecRequestTerminalSize>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecRequestTerminalSize>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecRequestTerminalSize>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerExecResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult>
    {
        internal ContainerExecResult() { }
        public string Password { get { throw null; } }
        public System.Uri WebSocketUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGpuResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGpuResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGpuResourceInfo>
    {
        public ContainerGpuResourceInfo(int count, Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku sku) { }
        public int Count { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku Sku { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGpuResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGpuResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGpuResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGpuResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGpuResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGpuResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGpuResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGpuSku : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGpuSku(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku K80 { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku P100 { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku V100 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku left, Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku left, Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerGroupDnsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration>
    {
        public ContainerGroupDnsConfiguration(System.Collections.Generic.IEnumerable<string> nameServers) { }
        public System.Collections.Generic.IList<string> NameServers { get { throw null; } }
        public string Options { get { throw null; } set { } }
        public string SearchDomains { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupElasticProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupElasticProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupElasticProfile>
    {
        public ContainerGroupElasticProfile() { }
        public int? DesiredCount { get { throw null; } set { } }
        public string GuidNamingPrefix { get { throw null; } set { } }
        public bool? MaintainDesiredCount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupElasticProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupElasticProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupElasticProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupElasticProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupElasticProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupElasticProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupElasticProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupEncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties>
    {
        public ContainerGroupEncryptionProperties(System.Uri vaultBaseUri, string keyName, string keyVersion) { }
        public string Identity { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public System.Uri VaultBaseUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupFileShare : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShare>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShare>
    {
        public ContainerGroupFileShare() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShareProperties Properties { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShare System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShare>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShare>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShare System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShare>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShare>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShare>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupFileShareProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShareProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShareProperties>
    {
        public ContainerGroupFileShareProperties() { }
        public Azure.ResourceManager.ContainerInstance.Models.AzureFileShareAccessTier? ShareAccessTier { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.AzureFileShareAccessType? ShareAccessType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShareProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShareProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShareProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShareProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShareProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShareProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShareProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupIdentityAccessControl : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControl>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControl>
    {
        public ContainerGroupIdentityAccessControl() { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessLevel? Access { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Identity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControl System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControl System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupIdentityAccessControlLevels : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControlLevels>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControlLevels>
    {
        public ContainerGroupIdentityAccessControlLevels() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControl> Acls { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessLevel? DefaultAccess { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControlLevels System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControlLevels>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControlLevels>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControlLevels System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControlLevels>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControlLevels>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessControlLevels>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupIdentityAccessLevel : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupIdentityAccessLevel(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessLevel All { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessLevel System { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessLevel User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessLevel left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessLevel left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIdentityAccessLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerGroupImageRegistryCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential>
    {
        public ContainerGroupImageRegistryCredential(string server) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release.", false)]
        public ContainerGroupImageRegistryCredential(string server, string username) { }
        public string Identity { get { throw null; } set { } }
        public System.Uri IdentityUri { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PasswordReference { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView>
    {
        internal ContainerGroupInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> Events { get { throw null; } }
        public string State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupIPAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress>
    {
        public ContainerGroupIPAddress(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort> ports, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType addressType) { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType AddressType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public string DnsNameLabel { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DnsNameLabelReusePolicy is deprecated, use AutoGeneratedDnsNameLabelScope instead", false)]
        public Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope? DnsNameLabelReusePolicy { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Net.IPAddress IP { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort> Ports { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupIPAddressType : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupIPAddressType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType Private { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerGroupLogAnalytics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics>
    {
        public ContainerGroupLogAnalytics(string workspaceId, string workspaceKey) { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType? LogType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string WorkspaceId { get { throw null; } set { } }
        public string WorkspaceKey { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WorkspaceResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupLogAnalyticsLogType : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupLogAnalyticsLogType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType ContainerInsights { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType ContainerInstanceLogs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerGroupNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProfile>
    {
        public ContainerGroupNetworkProfile() { }
        public Azure.ResourceManager.ContainerInstance.Models.ApplicationGateway ApplicationGateway { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.LoadBalancerBackendAddressPool> LoadBalancerBackendAddressPools { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupNetworkProtocol : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupNetworkProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerGroupPatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch>
    {
        public ContainerGroupPatch(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupPort : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort>
    {
        public ContainerGroupPort(int port) { }
        public int Port { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol? Protocol { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupPriority : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupPriority(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority Regular { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerGroupProfilePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfilePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfilePatch>
    {
        public ContainerGroupProfilePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfilePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfilePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfilePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfilePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfilePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfilePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfilePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupProfileStub : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfileStub>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfileStub>
    {
        public ContainerGroupProfileStub() { }
        public Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupProperties ContainerGroupProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public int? Revision { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupFileShare> StorageFileShares { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfileStub System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfileStub>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfileStub>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfileStub System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfileStub>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfileStub>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfileStub>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState NotAccessible { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState PreProvisioned { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState Repairing { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupRestartPolicy : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupRestartPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy Always { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy Never { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy OnFailure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerGroupSecretReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSecretReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSecretReference>
    {
        public ContainerGroupSecretReference(string name, Azure.Core.ResourceIdentifier identity, System.Uri secretReferenceUri) { }
        public Azure.Core.ResourceIdentifier Identity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Uri SecretReferenceUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSecretReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSecretReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSecretReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSecretReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSecretReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSecretReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSecretReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupSku : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupSku(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku Confidential { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku Dedicated { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerGroupSubnetId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId>
    {
        public ContainerGroupSubnetId(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerHttpGet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGet>
    {
        public ContainerHttpGet(int port) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpHeader> HttpHeaders { get { throw null; } }
        public string Path { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme? Scheme { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerHttpGetScheme : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerHttpGetScheme(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme Http { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme Https { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme left, Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme left, Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerHttpHeader : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpHeader>
    {
        public ContainerHttpHeader() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerHttpHeader System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerHttpHeader System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerInstanceAzureFileVolume : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceAzureFileVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceAzureFileVolume>
    {
        public ContainerInstanceAzureFileVolume(string shareName, string storageAccountName) { }
        public bool? IsReadOnly { get { throw null; } set { } }
        public string ShareName { get { throw null; } set { } }
        public string StorageAccountKey { get { throw null; } set { } }
        public string StorageAccountKeyReference { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceAzureFileVolume System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceAzureFileVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceAzureFileVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceAzureFileVolume System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceAzureFileVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceAzureFileVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceAzureFileVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerInstanceContainer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ContainerInstanceContainer(string name, string image, Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements resources) { }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable> EnvironmentVariables { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerProbe LivenessProbe { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerPort> Ports { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerProbe ReadinessProbe { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements Resources { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition SecurityContext { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount> VolumeMounts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerInstanceGitRepoVolume : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceGitRepoVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceGitRepoVolume>
    {
        public ContainerInstanceGitRepoVolume(string repository) { }
        public string Directory { get { throw null; } set { } }
        public string Repository { get { throw null; } set { } }
        public string Revision { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceGitRepoVolume System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceGitRepoVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceGitRepoVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceGitRepoVolume System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceGitRepoVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceGitRepoVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceGitRepoVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerInstanceOperatingSystemType : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerInstanceOperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType Linux { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType left, Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType left, Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerInstanceUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage>
    {
        internal ContainerInstanceUsage() { }
        public int? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerInstanceUsageName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName>
    {
        internal ContainerInstanceUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView>
    {
        internal ContainerInstanceView() { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerState CurrentState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> Events { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerState PreviousState { get { throw null; } }
        public int? RestartCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerLogs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerLogs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerLogs>
    {
        internal ContainerLogs() { }
        public string Content { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerLogs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerLogs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerLogs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerLogs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerLogs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerLogs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerLogs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerNetworkProtocol : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerNetworkProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol left, Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol left, Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerPort : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerPort>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerPort>
    {
        public ContainerPort(int port) { }
        public int Port { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol? Protocol { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerPort System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerPort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerPort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerPort System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerPort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerPort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerPort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerProbe : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerProbe>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerProbe>
    {
        public ContainerProbe() { }
        public System.Collections.Generic.IList<string> ExecCommand { get { throw null; } }
        public int? FailureThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGet HttpGet { get { throw null; } set { } }
        public int? InitialDelayInSeconds { get { throw null; } set { } }
        public int? PeriodInSeconds { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerProbe System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerProbe>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerProbe>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerProbe System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerProbe>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerProbe>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerProbe>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerResourceLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceLimits>
    {
        public ContainerResourceLimits() { }
        public double? Cpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGpuResourceInfo Gpu { get { throw null; } set { } }
        public double? MemoryInGB { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerResourceLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerResourceLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerResourceRequestsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequestsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequestsContent>
    {
        public ContainerResourceRequestsContent(double memoryInGB, double cpu) { }
        public double Cpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGpuResourceInfo Gpu { get { throw null; } set { } }
        public double MemoryInGB { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequestsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequestsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequestsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequestsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequestsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequestsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequestsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerResourceRequirements : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements>
    {
        public ContainerResourceRequirements(Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequestsContent requests) { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerResourceLimits Limits { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequestsContent Requests { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerSecurityContextCapabilitiesDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextCapabilitiesDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextCapabilitiesDefinition>
    {
        public ContainerSecurityContextCapabilitiesDefinition() { }
        public System.Collections.Generic.IList<string> Add { get { throw null; } }
        public System.Collections.Generic.IList<string> Drop { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextCapabilitiesDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextCapabilitiesDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextCapabilitiesDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextCapabilitiesDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextCapabilitiesDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextCapabilitiesDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextCapabilitiesDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerSecurityContextDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition>
    {
        public ContainerSecurityContextDefinition() { }
        public bool? AllowPrivilegeEscalation { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextCapabilitiesDefinition Capabilities { get { throw null; } set { } }
        public bool? IsPrivileged { get { throw null; } set { } }
        public int? RunAsGroup { get { throw null; } set { } }
        public int? RunAsUser { get { throw null; } set { } }
        public string SeccompProfile { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerState>
    {
        internal ContainerState() { }
        public string DetailStatus { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public System.DateTimeOffset? FinishOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerSupportedCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities>
    {
        internal ContainerSupportedCapabilities() { }
        public float? MaxCpu { get { throw null; } }
        public float? MaxGpuCount { get { throw null; } }
        public float? MaxMemoryInGB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerVolume : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume>
    {
        public ContainerVolume(string name) { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceAzureFileVolume AzureFile { get { throw null; } set { } }
        public System.BinaryData EmptyDir { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceGitRepoVolume GitRepo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Secret { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> SecretReference { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerVolume System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerVolume System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerVolumeMount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount>
    {
        public ContainerVolumeMount(string name, string mountPath) { }
        public bool? IsReadOnly { get { throw null; } set { } }
        public string MountPath { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentExtensionSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec>
    {
        public DeploymentExtensionSpec(string name) { }
        public string ExtensionType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsNameLabelReusePolicy : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsNameLabelReusePolicy(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy NoReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy TenantReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy Unsecure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy left, Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy left, Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InitContainerDefinitionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent>
    {
        public InitContainerDefinitionContent(string name) { }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable> EnvironmentVariables { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView InstanceView { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition SecurityContext { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount> VolumeMounts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InitContainerPropertiesDefinitionInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView>
    {
        internal InitContainerPropertiesDefinitionInstanceView() { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerState CurrentState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> Events { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerState PreviousState { get { throw null; } }
        public int? RestartCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadBalancerBackendAddressPool : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.LoadBalancerBackendAddressPool>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.LoadBalancerBackendAddressPool>
    {
        public LoadBalancerBackendAddressPool() { }
        public string Resource { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.LoadBalancerBackendAddressPool System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.LoadBalancerBackendAddressPool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.LoadBalancerBackendAddressPool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.LoadBalancerBackendAddressPool System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.LoadBalancerBackendAddressPool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.LoadBalancerBackendAddressPool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.LoadBalancerBackendAddressPool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NGroupContainerGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupProperties>
    {
        public NGroupContainerGroupProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyContainer> Containers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId> SubnetIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyVolume> Volumes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NGroupContainerGroupPropertyContainer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyContainer>
    {
        public NGroupContainerGroupPropertyContainer() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount> NGroupCGPropertyContainerVolumeMounts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NGroupContainerGroupPropertyVolume : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyVolume>
    {
        public NGroupContainerGroupPropertyVolume(string name) { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceAzureFileVolume AzureFile { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyVolume System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyVolume System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupContainerGroupPropertyVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupPatch>
    {
        public NGroupPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupProfileStub> ContainerGroupProfiles { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupElasticProfile ElasticProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public int? PlacementFaultDomainCount { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateProfile UpdateProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.NGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.NGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NGroupProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NGroupProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState left, Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState left, Azure.ResourceManager.ContainerInstance.Models.NGroupProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NGroupRollingUpdateProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupRollingUpdateProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupRollingUpdateProfile>
    {
        public NGroupRollingUpdateProfile() { }
        public bool? InPlaceUpdate { get { throw null; } set { } }
        public int? MaxBatchPercent { get { throw null; } set { } }
        public int? MaxUnhealthyPercent { get { throw null; } set { } }
        public string PauseTimeBetweenBatches { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.NGroupRollingUpdateProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupRollingUpdateProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupRollingUpdateProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.NGroupRollingUpdateProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupRollingUpdateProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupRollingUpdateProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupRollingUpdateProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NGroupUpdateMode : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NGroupUpdateMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateMode Manual { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateMode Rolling { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateMode left, Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateMode left, Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NGroupUpdateProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateProfile>
    {
        public NGroupUpdateProfile() { }
        public Azure.ResourceManager.ContainerInstance.Models.NGroupRollingUpdateProfile RollingUpdateProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateMode? UpdateMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerInstance.Models.NGroupUpdateProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
