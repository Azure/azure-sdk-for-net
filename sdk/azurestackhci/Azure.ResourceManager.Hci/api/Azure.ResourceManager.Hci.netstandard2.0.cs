namespace Azure.ResourceManager.Hci
{
    public partial class ArcExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>, System.Collections.IEnumerable
    {
        protected ArcExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.ArcExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.ArcExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.ArcExtensionResource> GetIfExists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.ArcExtensionResource>> GetIfExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.ArcExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.ArcExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArcExtensionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcExtensionData>
    {
        public ArcExtensionData() { }
        public Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState? AggregateState { get { throw null; } }
        public string ArcExtensionType { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy? ManagedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.PerNodeExtensionState> PerNodeExtensionDetails { get { throw null; } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? ShouldAutoUpgradeMinorVersion { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ArcExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ArcExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcExtensionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcExtensionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArcExtensionResource() { }
        public virtual Azure.ResourceManager.Hci.ArcExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.ArcExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ArcExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer work in all API versions.", false)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.ArcExtensionData data1, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ArcExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method no longer work in all API versions.", false)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ArcExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated.")]
        public virtual Azure.ResourceManager.ArmOperation Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated.")]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArcSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>, System.Collections.IEnumerable
    {
        protected ArcSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string arcSettingName, Azure.ResourceManager.Hci.ArcSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string arcSettingName, Azure.ResourceManager.Hci.ArcSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> Get(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.ArcSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.ArcSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.ArcSettingResource> GetIfExists(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.ArcSettingResource>> GetIfExistsAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.ArcSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.ArcSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArcSettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcSettingData>
    {
        public ArcSettingData() { }
        public Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? AggregateState { get { throw null; } }
        public System.Guid? ArcApplicationClientId { get { throw null; } set { } }
        public System.Guid? ArcApplicationObjectId { get { throw null; } set { } }
        public System.Guid? ArcApplicationTenantId { get { throw null; } set { } }
        public string ArcInstanceResourceGroup { get { throw null; } set { } }
        public System.Guid? ArcServicePrincipalObjectId { get { throw null; } set { } }
        public System.BinaryData ConnectivityProperties { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails> DefaultExtensions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.PerNodeArcState> PerNodeDetails { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ArcSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ArcSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcSettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcSettingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArcSettingResource() { }
        public virtual Azure.ResourceManager.Hci.ArcSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> ConsentAndInstallDefaultExtensions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> ConsentAndInstallDefaultExtensionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.ArcIdentityResult> CreateIdentity(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.ArcIdentityResult>> CreateIdentityAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Models.ArcPasswordCredential> GeneratePassword(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>> GeneratePasswordAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource> GetArcExtension(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource>> GetArcExtensionAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ArcExtensionCollection GetArcExtensions() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InitializeDisableProcess(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InitializeDisableProcessAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.ArcSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ArcSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ArcSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ArcSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> Update(Azure.ResourceManager.Hci.Models.ArcSettingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> UpdateAsync(Azure.ResourceManager.Hci.Models.ArcSettingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerHciContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHciContext() { }
        public static Azure.ResourceManager.Hci.AzureResourceManagerHciContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class HciClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterResource>, System.Collections.IEnumerable
    {
        protected HciClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Hci.HciClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Hci.HciClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterData>
    {
        public HciClusterData(Azure.Core.AzureLocation location) { }
        public System.Guid? AadApplicationObjectId { get { throw null; } set { } }
        public System.Guid? AadClientId { get { throw null; } set { } }
        public System.Guid? AadServicePrincipalObjectId { get { throw null; } set { } }
        public System.Guid? AadTenantId { get { throw null; } set { } }
        public string BillingModel { get { throw null; } }
        public System.Guid? CloudId { get { throw null; } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus? ConnectivityStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration IsolatedVmAttestationConfiguration { get { throw null; } }
        public System.DateTimeOffset? LastBillingTimestamp { get { throw null; } }
        public System.DateTimeOffset? LastSyncTimestamp { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.LogCollectionProperties LogCollectionProperties { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RegistrationTimestamp { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.RemoteSupportProperties RemoteSupportProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterReportedProperties ReportedProperties { get { throw null; } }
        public string ResourceProviderObjectId { get { throw null; } }
        public string ServiceEndpoint { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties SoftwareAssuranceProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public float? TrialDaysRemaining { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? TypeIdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterDeploymentSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource>, System.Collections.IEnumerable
    {
        protected HciClusterDeploymentSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentSettingsName, Azure.ResourceManager.Hci.HciClusterDeploymentSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentSettingsName, Azure.ResourceManager.Hci.HciClusterDeploymentSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource> Get(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource>> GetAsync(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource> GetIfExists(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource>> GetIfExistsAsync(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciClusterDeploymentSettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>
    {
        public HciClusterDeploymentSettingData() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ArcNodeResourceIds { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration DeploymentConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.EceDeploymentMode? DeploymentMode { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterOperationType? OperationType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EceReportedProperties ReportedProperties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterDeploymentSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterDeploymentSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterDeploymentSettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciClusterDeploymentSettingResource() { }
        public virtual Azure.ResourceManager.Hci.HciClusterDeploymentSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string deploymentSettingsName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.HciClusterDeploymentSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterDeploymentSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterDeploymentSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciClusterDeploymentSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciClusterDeploymentSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciClusterOfferCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterOfferResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterOfferResource>, System.Collections.IEnumerable
    {
        protected HciClusterOfferCollection() { }
        public virtual Azure.Response<bool> Exists(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterOfferResource> Get(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterOfferResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterOfferResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterOfferResource>> GetAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterOfferResource> GetIfExists(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterOfferResource>> GetIfExistsAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciClusterOfferResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterOfferResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciClusterOfferResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterOfferResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciClusterOfferData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterOfferData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterOfferData>
    {
        public HciClusterOfferData() { }
        public string Content { get { throw null; } set { } }
        public string ContentVersion { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciSkuMappings> SkuMappings { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterOfferData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterOfferData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterOfferData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterOfferData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterOfferData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterOfferData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterOfferData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterOfferResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterOfferData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterOfferData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciClusterOfferResource() { }
        public virtual Azure.ResourceManager.Hci.HciClusterOfferData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName, string offerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterOfferResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterOfferResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciSkuResource> GetHciSku(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciSkuResource>> GetHciSkuAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciSkuCollection GetHciSkus() { throw null; }
        Azure.ResourceManager.Hci.HciClusterOfferData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterOfferData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterOfferData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterOfferData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterOfferData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterOfferData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterOfferData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterPublisherCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterPublisherResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterPublisherResource>, System.Collections.IEnumerable
    {
        protected HciClusterPublisherCollection() { }
        public virtual Azure.Response<bool> Exists(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterPublisherResource> Get(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterPublisherResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterPublisherResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterPublisherResource>> GetAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterPublisherResource> GetIfExists(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterPublisherResource>> GetIfExistsAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciClusterPublisherResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterPublisherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciClusterPublisherResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterPublisherResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciClusterPublisherData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterPublisherData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterPublisherData>
    {
        public HciClusterPublisherData() { }
        public string ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterPublisherData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterPublisherData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterPublisherData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterPublisherData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterPublisherData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterPublisherData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterPublisherData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterPublisherResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterPublisherData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterPublisherData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciClusterPublisherResource() { }
        public virtual Azure.ResourceManager.Hci.HciClusterPublisherData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterPublisherResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterPublisherResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterOfferResource> GetHciClusterOffer(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterOfferResource>> GetHciClusterOfferAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterOfferCollection GetHciClusterOffers() { throw null; }
        Azure.ResourceManager.Hci.HciClusterPublisherData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterPublisherData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterPublisherData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterPublisherData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterPublisherData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterPublisherData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterPublisherData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciClusterResource() { }
        public virtual Azure.ResourceManager.Hci.HciClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource> ConfigureRemoteSupport(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.RemoteSupportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource>> ConfigureRemoteSupportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.RemoteSupportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult> CreateIdentity(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>> CreateIdentityAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource> ExtendSoftwareAssuranceBenefit(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource>> ExtendSoftwareAssuranceBenefitAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> GetArcSetting(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetArcSettingAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ArcSettingCollection GetArcSettings() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource> GetHciClusterDeploymentSetting(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource>> GetHciClusterDeploymentSettingAsync(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterDeploymentSettingCollection GetHciClusterDeploymentSettings() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterOfferResource> GetHciClusterOffers(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterOfferResource> GetHciClusterOffersAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterPublisherResource> GetHciClusterPublisher(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterPublisherResource>> GetHciClusterPublisherAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterPublisherCollection GetHciClusterPublishers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource> GetHciClusterSecuritySetting(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource>> GetHciClusterSecuritySettingAsync(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterSecuritySettingCollection GetHciClusterSecuritySettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateResource> GetHciClusterUpdate(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateResource>> GetHciClusterUpdateAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterUpdateCollection GetHciClusterUpdates() { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterUpdateSummaryResource GetHciClusterUpdateSummary() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterOffers` moving forward.")]
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.OfferResource> GetOffers(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterOffersAsync` moving forward.")]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.OfferResource> GetOffersAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterPublisher` moving forward.")]
        public virtual Azure.Response<Azure.ResourceManager.Hci.PublisherResource> GetPublisher(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterPublisherAsync` moving forward.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PublisherResource>> GetPublisherAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterPublishers` moving forward.")]
        public virtual Azure.ResourceManager.Hci.PublisherCollection GetPublishers() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdate` moving forward.")]
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateResource> GetUpdate(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateAsync` moving forward.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateResource>> GetUpdateAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdates` moving forward.")]
        public virtual Azure.ResourceManager.Hci.UpdateCollection GetUpdates() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateSummary` moving forward.")]
        public virtual Azure.ResourceManager.Hci.UpdateSummaryResource GetUpdateSummary() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.HciClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource> TriggerLogCollection(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.LogCollectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource>> TriggerLogCollectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.LogCollectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> Update(Azure.ResourceManager.Hci.Models.HciClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> UpdateAsync(Azure.ResourceManager.Hci.Models.HciClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UploadCertificate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciClusterCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UploadCertificateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciClusterCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciClusterSecuritySettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource>, System.Collections.IEnumerable
    {
        protected HciClusterSecuritySettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string securitySettingsName, Azure.ResourceManager.Hci.HciClusterSecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string securitySettingsName, Azure.ResourceManager.Hci.HciClusterSecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource> Get(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource>> GetAsync(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource> GetIfExists(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource>> GetIfExistsAsync(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciClusterSecuritySettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>
    {
        public HciClusterSecuritySettingData() { }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType? SecuredCoreComplianceAssignment { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.SecurityComplianceStatus SecurityComplianceStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType? SmbEncryptionForIntraClusterTrafficComplianceAssignment { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType? WdacComplianceAssignment { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterSecuritySettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterSecuritySettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterSecuritySettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciClusterSecuritySettingResource() { }
        public virtual Azure.ResourceManager.Hci.HciClusterSecuritySettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string securitySettingsName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.HciClusterSecuritySettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterSecuritySettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterSecuritySettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciClusterSecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterSecuritySettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciClusterSecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciClusterUpdateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterUpdateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterUpdateResource>, System.Collections.IEnumerable
    {
        protected HciClusterUpdateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterUpdateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateName, Azure.ResourceManager.Hci.HciClusterUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterUpdateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateName, Azure.ResourceManager.Hci.HciClusterUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateResource> Get(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterUpdateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterUpdateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateResource>> GetAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterUpdateResource> GetIfExists(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterUpdateResource>> GetIfExistsAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciClusterUpdateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterUpdateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciClusterUpdateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterUpdateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciClusterUpdateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateData>
    {
        public HciClusterUpdateData() { }
        public string AdditionalProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciAvailabilityType? AvailabilityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> ComponentVersions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? HealthCheckOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPrecheckResult> HealthCheckResult { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciHealthState? HealthState { get { throw null; } set { } }
        public System.DateTimeOffset? InstalledOn { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string MinSbeVersionRequired { get { throw null; } set { } }
        public string NotifyMessage { get { throw null; } set { } }
        public string PackagePath { get { throw null; } set { } }
        public float? PackageSizeInMb { get { throw null; } set { } }
        public string PackageType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite> Prerequisites { get { throw null; } }
        public float? ProgressPercentage { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement? RebootRequired { get { throw null; } set { } }
        public string ReleaseLink { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciUpdateState? State { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterUpdateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterUpdateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterUpdateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciClusterUpdateResource() { }
        public virtual Azure.ResourceManager.Hci.HciClusterUpdateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string updateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateRunResource> GetHciClusterUpdateRun(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateRunResource>> GetHciClusterUpdateRunAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterUpdateRunCollection GetHciClusterUpdateRuns() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Post(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PostAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.HciClusterUpdateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterUpdateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterUpdateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciClusterUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterUpdateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciClusterUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciClusterUpdateRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterUpdateRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterUpdateRunResource>, System.Collections.IEnumerable
    {
        protected HciClusterUpdateRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterUpdateRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.Hci.HciClusterUpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterUpdateRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.Hci.HciClusterUpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateRunResource> Get(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterUpdateRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterUpdateRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateRunResource>> GetAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterUpdateRunResource> GetIfExists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.HciClusterUpdateRunResource>> GetIfExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciClusterUpdateRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterUpdateRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciClusterUpdateRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterUpdateRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciClusterUpdateRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>
    {
        public HciClusterUpdateRunData() { }
        public string Description { get { throw null; } set { } }
        public string Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        public string ExpectedExecutionTime { get { throw null; } set { } }
        public System.DateTimeOffset? LastCompletedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string NamePropertiesProgressName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? State { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciUpdateStep> Steps { get { throw null; } }
        public System.DateTimeOffset? TimeStarted { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterUpdateRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterUpdateRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterUpdateRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciClusterUpdateRunResource() { }
        public virtual Azure.ResourceManager.Hci.HciClusterUpdateRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string updateName, string updateRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.HciClusterUpdateRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterUpdateRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterUpdateRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciClusterUpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterUpdateRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciClusterUpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciClusterUpdateSummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>
    {
        public HciClusterUpdateSummaryData() { }
        public string CurrentOemVersion { get { throw null; } set { } }
        public string CurrentSbeVersion { get { throw null; } set { } }
        public string CurrentVersion { get { throw null; } set { } }
        public string HardwareModel { get { throw null; } set { } }
        public System.DateTimeOffset? HealthCheckOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPrecheckResult> HealthCheckResult { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciHealthState? HealthState { get { throw null; } set { } }
        public System.DateTimeOffset? LastCheckedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string OemFamily { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> PackageVersions { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterUpdateState? State { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterUpdateSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterUpdateSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterUpdateSummaryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciClusterUpdateSummaryResource() { }
        public virtual Azure.ResourceManager.Hci.HciClusterUpdateSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterUpdateSummaryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciClusterUpdateSummaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterUpdateSummaryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciClusterUpdateSummaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterUpdateSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.HciClusterUpdateSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciClusterUpdateSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciClusterUpdateSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciEdgeDeviceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciEdgeDeviceResource>, System.Collections.IEnumerable
    {
        protected HciEdgeDeviceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciEdgeDeviceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string edgeDeviceName, Azure.ResourceManager.Hci.HciEdgeDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciEdgeDeviceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string edgeDeviceName, Azure.ResourceManager.Hci.HciEdgeDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciEdgeDeviceResource> Get(string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciEdgeDeviceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciEdgeDeviceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciEdgeDeviceResource>> GetAsync(string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.HciEdgeDeviceResource> GetIfExists(string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.HciEdgeDeviceResource>> GetIfExistsAsync(string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciEdgeDeviceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciEdgeDeviceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciEdgeDeviceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciEdgeDeviceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public abstract partial class HciEdgeDeviceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>
    {
        protected HciEdgeDeviceData() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciEdgeDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciEdgeDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciEdgeDeviceResource() { }
        public virtual Azure.ResourceManager.Hci.HciEdgeDeviceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string edgeDeviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciEdgeDeviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciEdgeDeviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.HciEdgeDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciEdgeDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciEdgeDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciEdgeDeviceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciEdgeDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciEdgeDeviceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciEdgeDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult> Validate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult>> ValidateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HciExtensions
    {
        public static Azure.ResourceManager.Hci.ArcExtensionResource GetArcExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.ArcSettingResource GetArcSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> GetHciCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetHciClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource GetHciClusterDeploymentSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterOfferResource GetHciClusterOfferResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterPublisherResource GetHciClusterPublisherResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterResource GetHciClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterCollection GetHciClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterSecuritySettingResource GetHciClusterSecuritySettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterUpdateResource GetHciClusterUpdateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterUpdateRunResource GetHciClusterUpdateRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterUpdateSummaryResource GetHciClusterUpdateSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.HciEdgeDeviceResource> GetHciEdgeDevice(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciEdgeDeviceResource>> GetHciEdgeDeviceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciEdgeDeviceResource GetHciEdgeDeviceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciEdgeDeviceCollection GetHciEdgeDevices(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Hci.HciSkuResource GetHciSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterOfferResource` moving forward.")]
        public static Azure.ResourceManager.Hci.OfferResource GetOfferResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterPublisherResource` moving forward.")]
        public static Azure.ResourceManager.Hci.PublisherResource GetPublisherResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateResource` moving forward.")]
        public static Azure.ResourceManager.Hci.UpdateResource GetUpdateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateRunResource` moving forward.")]
        public static Azure.ResourceManager.Hci.UpdateRunResource GetUpdateRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateSummaryResource` moving forward.")]
        public static Azure.ResourceManager.Hci.UpdateSummaryResource GetUpdateSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HciSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciSkuResource>, System.Collections.IEnumerable
    {
        protected HciSkuCollection() { }
        public virtual Azure.Response<bool> Exists(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciSkuResource> Get(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciSkuResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciSkuResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciSkuResource>> GetAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.HciSkuResource> GetIfExists(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.HciSkuResource>> GetIfExistsAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciSkuData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>
    {
        public HciSkuData() { }
        public string Content { get { throw null; } set { } }
        public string ContentVersion { get { throw null; } set { } }
        public string OfferId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciSkuMappings> SkuMappings { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciSkuResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciSkuResource() { }
        public virtual Azure.ResourceManager.Hci.HciSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName, string offerName, string skuName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciSkuResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciSkuResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.HciSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterOfferCollection` moving forward.")]
    public partial class OfferCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.OfferResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.OfferResource>, System.Collections.IEnumerable
    {
        protected OfferCollection() { }
        public virtual Azure.Response<bool> Exists(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OfferResource> Get(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.OfferResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.OfferResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OfferResource>> GetAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.OfferResource> GetIfExists(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.OfferResource>> GetIfExistsAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.OfferResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.OfferResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.OfferResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.OfferResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterOfferData` moving forward.")]
    public partial class OfferData : Azure.ResourceManager.Models.ResourceData
    {
        public OfferData() { }
        public string Content { get { throw null; } set { } }
        public string ContentVersion { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciSkuMappings> SkuMappings { get { throw null; } }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterOfferResource` moving forward.")]
    public partial class OfferResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OfferResource() { }
        public virtual Azure.ResourceManager.Hci.OfferData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName, string offerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OfferResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OfferResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciSkuResource> GetHciSku(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciSkuResource>> GetHciSkuAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciSkuCollection GetHciSkus() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterPublisherCollection` moving forward.")]
    public partial class PublisherCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.PublisherResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.PublisherResource>, System.Collections.IEnumerable
    {
        protected PublisherCollection() { }
        public virtual Azure.Response<bool> Exists(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.PublisherResource> Get(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.PublisherResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.PublisherResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PublisherResource>> GetAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.PublisherResource> GetIfExists(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.PublisherResource>> GetIfExistsAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.PublisherResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.PublisherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.PublisherResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.PublisherResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterPublisherData` moving forward.")]
    public partial class PublisherData : Azure.ResourceManager.Models.ResourceData
    {
        public PublisherData() { }
        public string ProvisioningState { get { throw null; } }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterPublisherResource` moving forward.")]
    public partial class PublisherResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PublisherResource() { }
        public virtual Azure.ResourceManager.Hci.PublisherData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.PublisherResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PublisherResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OfferResource> GetOffer(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OfferResource>> GetOfferAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.OfferCollection GetOffers() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateCollection` moving forward.")]
    public partial class UpdateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateResource>, System.Collections.IEnumerable
    {
        protected UpdateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateName, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateName, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateResource> Get(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.UpdateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.UpdateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateResource>> GetAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateResource> GetIfExists(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateResource>> GetIfExistsAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.UpdateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.UpdateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateData` moving forward.")]
    public partial class UpdateData : Azure.ResourceManager.Models.ResourceData
    {
        public UpdateData() { }
        public string AdditionalProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciAvailabilityType? AvailabilityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> ComponentVersions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? HealthCheckOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPrecheckResult> HealthCheckResult { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciHealthState? HealthState { get { throw null; } set { } }
        public System.DateTimeOffset? InstalledOn { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string NotifyMessage { get { throw null; } set { } }
        public string PackagePath { get { throw null; } set { } }
        public float? PackageSizeInMb { get { throw null; } set { } }
        public string PackageType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.UpdatePrerequisite> Prerequisites { get { throw null; } }
        public float? ProgressPercentage { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement? RebootRequired { get { throw null; } set { } }
        public string ReleaseLink { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciUpdateState? State { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateResource` moving forward.")]
    public partial class UpdateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateResource() { }
        public virtual Azure.ResourceManager.Hci.UpdateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string updateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource> GetUpdateRun(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource>> GetUpdateRunAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateRunCollection GetUpdateRuns() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Post(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PostAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateRunCollection` moving forward.")]
    public partial class UpdateRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>, System.Collections.IEnumerable
    {
        protected UpdateRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource> Get(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.UpdateRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.UpdateRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource>> GetAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateRunResource> GetIfExists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateRunResource>> GetIfExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.UpdateRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.UpdateRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateRunData` moving forward.")]
    public partial class UpdateRunData : Azure.ResourceManager.Models.ResourceData
    {
        public UpdateRunData() { }
        public string Description { get { throw null; } set { } }
        public string Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTimeUtc { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string NamePropertiesProgressName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? State { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciUpdateStep> Steps { get { throw null; } }
        public System.DateTimeOffset? TimeStarted { get { throw null; } set { } }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateRunResource` moving forward.")]
    public partial class UpdateRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateRunResource() { }
        public virtual Azure.ResourceManager.Hci.UpdateRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string updateName, string updateRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateSummaryData` moving forward.")]
    public partial class UpdateSummaryData : Azure.ResourceManager.Models.ResourceData
    {
        public UpdateSummaryData() { }
        public string CurrentVersion { get { throw null; } set { } }
        public string HardwareModel { get { throw null; } set { } }
        public System.DateTimeOffset? HealthCheckOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPrecheckResult> HealthCheckResult { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciHealthState? HealthState { get { throw null; } set { } }
        public System.DateTimeOffset? LastChecked { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string OemFamily { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> PackageVersions { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState? State { get { throw null; } set { } }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateSummaryResource` moving forward.")]
    public partial class UpdateSummaryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateSummaryResource() { }
        public virtual Azure.ResourceManager.Hci.UpdateSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateSummaryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateSummaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateSummaryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateSummaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Mocking
{
    public partial class MockableHciArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHciArmClient() { }
        public virtual Azure.ResourceManager.Hci.ArcExtensionResource GetArcExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.ArcSettingResource GetArcSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterDeploymentSettingResource GetHciClusterDeploymentSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterOfferResource GetHciClusterOfferResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterPublisherResource GetHciClusterPublisherResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterResource GetHciClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterSecuritySettingResource GetHciClusterSecuritySettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterUpdateResource GetHciClusterUpdateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterUpdateRunResource GetHciClusterUpdateRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterUpdateSummaryResource GetHciClusterUpdateSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciEdgeDeviceResource> GetHciEdgeDevice(Azure.Core.ResourceIdentifier scope, string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciEdgeDeviceResource>> GetHciEdgeDeviceAsync(Azure.Core.ResourceIdentifier scope, string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciEdgeDeviceResource GetHciEdgeDeviceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciEdgeDeviceCollection GetHciEdgeDevices(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciSkuResource GetHciSkuResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterOfferResource` moving forward.")]
        public virtual Azure.ResourceManager.Hci.OfferResource GetOfferResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterPublisherResource` moving forward.")]
        public virtual Azure.ResourceManager.Hci.PublisherResource GetPublisherResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateResource` moving forward.")]
        public virtual Azure.ResourceManager.Hci.UpdateResource GetUpdateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateRunResource` moving forward.")]
        public virtual Azure.ResourceManager.Hci.UpdateRunResource GetUpdateRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateSummaryResource` moving forward.")]
        public virtual Azure.ResourceManager.Hci.UpdateSummaryResource GetUpdateSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHciResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> GetHciCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetHciClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterCollection GetHciClusters() { throw null; }
    }
    public partial class MockableHciSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Models
{
    public partial class ArcDefaultExtensionDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails>
    {
        internal ArcDefaultExtensionDetails() { }
        public string Category { get { throw null; } }
        public System.DateTimeOffset? ConsentOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcExtensionAggregateState : System.IEquatable<Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcExtensionAggregateState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Updating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState UpgradeFailedRollbackSucceeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState left, Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState left, Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcExtensionInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView>
    {
        internal ArcExtensionInstanceView() { }
        public string ExtensionInstanceViewType { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus Status { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcExtensionInstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus>
    {
        internal ArcExtensionInstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciStatusLevelType? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcExtensionManagedBy : System.IEquatable<Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcExtensionManagedBy(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy Azure { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy left, Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy left, Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcExtensionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatch>
    {
        public ArcExtensionPatch() { }
        public Azure.ResourceManager.Hci.Models.ArcExtensionPatchContent ExtensionParameters { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcExtensionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcExtensionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcExtensionPatchContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatchContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatchContent>
    {
        public ArcExtensionPatchContent() { }
        public bool? IsAutomaticUpgradeEnabled { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcExtensionPatchContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatchContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatchContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcExtensionPatchContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatchContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatchContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatchContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcExtensionState : System.IEquatable<Azure.ResourceManager.Hci.Models.ArcExtensionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcExtensionState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ArcExtensionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcExtensionState left, Azure.ResourceManager.Hci.Models.ArcExtensionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcExtensionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ArcExtensionState left, Azure.ResourceManager.Hci.Models.ArcExtensionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcExtensionUpgradeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent>
    {
        public ArcExtensionUpgradeContent() { }
        public string TargetVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcIdentityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>
    {
        internal ArcIdentityResult() { }
        public System.Guid? ArcApplicationClientId { get { throw null; } }
        public System.Guid? ArcApplicationObjectId { get { throw null; } }
        public System.Guid? ArcApplicationTenantId { get { throw null; } }
        public System.Guid? ArcServicePrincipalObjectId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcIdentityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcIdentityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcIdentityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcPasswordCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>
    {
        internal ArcPasswordCredential() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string KeyId { get { throw null; } }
        public string SecretText { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcPasswordCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcPasswordCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcSettingAggregateState : System.IEquatable<Azure.ResourceManager.Hci.Models.ArcSettingAggregateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcSettingAggregateState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState DisableInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState left, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcSettingAggregateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState left, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcSettingPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>
    {
        public ArcSettingPatch() { }
        public System.BinaryData ConnectivityProperties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcSettingPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcSettingPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmHciModelFactory
    {
        public static Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails ArcDefaultExtensionDetails(string category = null, System.DateTimeOffset? consentOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.ArcExtensionData ArcExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState? aggregateState = default(Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeExtensionState> perNodeExtensionDetails = null, Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy? managedBy = default(Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy?), string forceUpdateTag = null, string publisher = null, string arcExtensionType = null, string typeHandlerVersion = null, bool? shouldAutoUpgradeMinorVersion = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, bool? enableAutomaticUpgrade = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Hci.ArcExtensionData ArcExtensionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState? aggregateState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeExtensionState> perNodeExtensionDetails, string forceUpdateTag, string publisher, string arcExtensionType, string typeHandlerVersion, bool? shouldAutoUpgradeMinorVersion, System.BinaryData settings, System.BinaryData protectedSettings, bool? enableAutomaticUpgrade) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView ArcExtensionInstanceView(string name = null, string extensionInstanceViewType = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus ArcExtensionInstanceViewStatus(string code = null, Azure.ResourceManager.Hci.Models.HciStatusLevelType? level = default(Azure.ResourceManager.Hci.Models.HciStatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcIdentityResult ArcIdentityResult(System.Guid? arcApplicationClientId = default(System.Guid?), System.Guid? arcApplicationTenantId = default(System.Guid?), System.Guid? arcServicePrincipalObjectId = default(System.Guid?), System.Guid? arcApplicationObjectId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcPasswordCredential ArcPasswordCredential(string secretText = null, string keyId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Hci.ArcSettingData ArcSettingData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, string arcInstanceResourceGroup, System.Guid? arcApplicationClientId, System.Guid? arcApplicationTenantId, System.Guid? arcServicePrincipalObjectId, System.Guid? arcApplicationObjectId, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? aggregateState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeArcState> perNodeDetails, System.BinaryData connectivityProperties) { throw null; }
        public static Azure.ResourceManager.Hci.ArcSettingData ArcSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string arcInstanceResourceGroup = null, System.Guid? arcApplicationClientId = default(System.Guid?), System.Guid? arcApplicationTenantId = default(System.Guid?), System.Guid? arcServicePrincipalObjectId = default(System.Guid?), System.Guid? arcApplicationObjectId = default(System.Guid?), Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? aggregateState = default(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeArcState> perNodeDetails = null, System.BinaryData connectivityProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails> defaultExtensions = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EceActionStatus EceActionStatus(string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep> steps = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EceReportedProperties EceReportedProperties(Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `ArcExtensionInstanceViewStatus` moving forward.")]
        public static Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus ExtensionInstanceViewStatus(string code = null, Azure.ResourceManager.Hci.Models.HciStatusLevelType? level = default(Azure.ResourceManager.Hci.Models.HciStatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDevice HciArcEnabledEdgeDevice(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties HciArcEnabledEdgeDeviceProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration deviceConfiguration = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), Azure.ResourceManager.Hci.Models.HciReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterData HciClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?), Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus? connectivityStatus = default(Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus?), System.Guid? cloudId = default(System.Guid?), string cloudManagementEndpoint = null, System.Guid? aadClientId = default(System.Guid?), System.Guid? aadTenantId = default(System.Guid?), System.Guid? aadApplicationObjectId = default(System.Guid?), System.Guid? aadServicePrincipalObjectId = default(System.Guid?), Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties softwareAssuranceProperties = null, Azure.ResourceManager.Hci.Models.LogCollectionProperties logCollectionProperties = null, Azure.ResourceManager.Hci.Models.RemoteSupportProperties remoteSupportProperties = null, Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties desiredProperties = null, Azure.ResourceManager.Hci.Models.HciClusterReportedProperties reportedProperties = null, Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration isolatedVmAttestationConfiguration = null, float? trialDaysRemaining = default(float?), string billingModel = null, System.DateTimeOffset? registrationTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastSyncTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastBillingTimestamp = default(System.DateTimeOffset?), string serviceEndpoint = null, string resourceProviderObjectId = null, System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? typeIdentityType = default(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Hci.HciClusterData HciClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, Azure.ResourceManager.Hci.Models.HciClusterStatus? status, System.Guid? cloudId, string cloudManagementEndpoint, System.Guid? aadClientId, System.Guid? aadTenantId, System.Guid? aadApplicationObjectId, System.Guid? aadServicePrincipalObjectId, Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties softwareAssuranceProperties, Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties desiredProperties, Azure.ResourceManager.Hci.Models.HciClusterReportedProperties reportedProperties, float? trialDaysRemaining, string billingModel, System.DateTimeOffset? registrationTimestamp, System.DateTimeOffset? lastSyncTimestamp, System.DateTimeOffset? lastBillingTimestamp, string serviceEndpoint, string resourceProviderObjectId, System.Guid? principalId, System.Guid? tenantId, Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? typeIdentityType, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterDeploymentSettingData HciClusterDeploymentSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> arcNodeResourceIds = null, Azure.ResourceManager.Hci.Models.EceDeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.EceDeploymentMode?), Azure.ResourceManager.Hci.Models.HciClusterOperationType? operationType = default(Azure.ResourceManager.Hci.Models.HciClusterOperationType?), Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration deploymentConfiguration = null, Azure.ResourceManager.Hci.Models.EceReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep HciClusterDeploymentStep(string name = null, string description = null, string fullStepIndex = null, string startOn = null, string endOn = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep> steps = null, System.Collections.Generic.IEnumerable<string> exception = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterIdentityResult HciClusterIdentityResult(System.Guid? aadClientId = default(System.Guid?), System.Guid? aadTenantId = default(System.Guid?), System.Guid? aadServicePrincipalObjectId = default(System.Guid?), System.Guid? aadApplicationObjectId = default(System.Guid?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Hci.Models.HciClusterNode HciClusterNode(string name, float? id, Azure.ResourceManager.Hci.Models.WindowsServerSubscription? windowsServerSubscription, Azure.ResourceManager.Hci.Models.ClusterNodeType? nodeType, string ehcResourceId, string manufacturer, string model, string osName, string osVersion, string osDisplayVersion, string serialNumber, float? coreCount, float? memoryInGiB, System.DateTimeOffset? lastLicensingTimestamp) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterNode HciClusterNode(string name = null, float? id = default(float?), Azure.ResourceManager.Hci.Models.WindowsServerSubscription? windowsServerSubscription = default(Azure.ResourceManager.Hci.Models.WindowsServerSubscription?), Azure.ResourceManager.Hci.Models.ClusterNodeType? nodeType = default(Azure.ResourceManager.Hci.Models.ClusterNodeType?), string ehcResourceId = null, string manufacturer = null, string model = null, string osName = null, string osVersion = null, string osDisplayVersion = null, string serialNumber = null, float? coreCount = default(float?), float? memoryInGiB = default(float?), System.DateTimeOffset? lastLicensingTimestamp = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.OemActivation? oemActivation = default(Azure.ResourceManager.Hci.Models.OemActivation?)) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterOfferData HciClusterOfferData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string publisherId = null, string content = null, string contentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciSkuMappings> skuMappings = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterPatch HciClusterPatch(System.Collections.Generic.IDictionary<string, string> tags = null, string cloudManagementEndpoint = null, System.Guid? aadClientId = default(System.Guid?), System.Guid? aadTenantId = default(System.Guid?), Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties desiredProperties = null, System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? managedServiceIdentityType = default(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterPublisherData HciClusterPublisherData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Hci.Models.HciClusterReportedProperties HciClusterReportedProperties(string clusterName, System.Guid? clusterId, string clusterVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciClusterNode> nodes, System.DateTimeOffset? lastUpdatedOn, Azure.ResourceManager.Hci.Models.ImdsAttestationState? imdsAttestation, Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? diagnosticLevel, System.Collections.Generic.IEnumerable<string> supportedCapabilities) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterReportedProperties HciClusterReportedProperties(string clusterName = null, System.Guid? clusterId = default(System.Guid?), string clusterVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciClusterNode> nodes = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.ImdsAttestationState? imdsAttestation = default(Azure.ResourceManager.Hci.Models.ImdsAttestationState?), Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? diagnosticLevel = default(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel?), System.Collections.Generic.IEnumerable<string> supportedCapabilities = null, Azure.ResourceManager.Hci.Models.ClusterNodeType? clusterType = default(Azure.ResourceManager.Hci.Models.ClusterNodeType?), string manufacturer = null, Azure.ResourceManager.Hci.Models.OemActivation? oemActivation = default(Azure.ResourceManager.Hci.Models.OemActivation?)) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterSecuritySettingData HciClusterSecuritySettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType? securedCoreComplianceAssignment = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType?), Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType? wdacComplianceAssignment = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType?), Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType? smbEncryptionForIntraClusterTrafficComplianceAssignment = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType?), Azure.ResourceManager.Hci.Models.SecurityComplianceStatus securityComplianceStatus = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterUpdateData HciClusterUpdateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.DateTimeOffset? installedOn = default(System.DateTimeOffset?), string description = null, string minSbeVersionRequired = null, Azure.ResourceManager.Hci.Models.HciUpdateState? state = default(Azure.ResourceManager.Hci.Models.HciUpdateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite> prerequisites = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> componentVersions = null, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement? rebootRequired = default(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement?), Azure.ResourceManager.Hci.Models.HciHealthState? healthState = default(Azure.ResourceManager.Hci.Models.HciHealthState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult = null, System.DateTimeOffset? healthCheckOn = default(System.DateTimeOffset?), string packagePath = null, float? packageSizeInMb = default(float?), string displayName = null, string version = null, string publisher = null, string releaseLink = null, Azure.ResourceManager.Hci.Models.HciAvailabilityType? availabilityType = default(Azure.ResourceManager.Hci.Models.HciAvailabilityType?), string packageType = null, string additionalProperties = null, float? progressPercentage = default(float?), string notifyMessage = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterUpdateRunData HciClusterUpdateRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.DateTimeOffset? timeStarted = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), string duration = null, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? state = default(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState?), string namePropertiesProgressName = null, string description = null, string errorMessage = null, string status = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastCompletedOn = default(System.DateTimeOffset?), string expectedExecutionTime = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUpdateStep> steps = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterUpdateSummaryData HciClusterUpdateSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string oemFamily = null, string currentOemVersion = null, string hardwareModel = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> packageVersions = null, string currentVersion = null, string currentSbeVersion = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastCheckedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciHealthState? healthState = default(Azure.ResourceManager.Hci.Models.HciHealthState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult = null, System.DateTimeOffset? healthCheckOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciClusterUpdateState? state = default(Azure.ResourceManager.Hci.Models.HciClusterUpdateState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides HciEdgeDeviceAdapterPropertyOverrides(string jumboPacket = null, string networkDirect = null, string networkDirectTechnology = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension HciEdgeDeviceArcExtension(string extensionName = null, Azure.ResourceManager.Hci.Models.ArcExtensionState? state = default(Azure.ResourceManager.Hci.Models.ArcExtensionState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail> errorDetails = null, Azure.Core.ResourceIdentifier extensionResourceId = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy? managedBy = default(Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy?)) { throw null; }
        public static Azure.ResourceManager.Hci.HciEdgeDeviceData HciEdgeDeviceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork HciEdgeDeviceHostNetwork(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents> intents = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks> storageNetworks = null, bool? storageConnectivitySwitchless = default(bool?), bool? enableStorageAutoIP = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents HciEdgeDeviceIntents(long? scope = default(long?), long? intentType = default(long?), bool? isComputeIntentSet = default(bool?), bool? isStorageIntentSet = default(bool?), bool? isOnlyStorage = default(bool?), bool? isManagementIntentSet = default(bool?), bool? isStretchIntentSet = default(bool?), bool? isOnlyStretch = default(bool?), bool? isNetworkIntentType = default(bool?), string intentName = null, System.Collections.Generic.IEnumerable<string> intentAdapters = null, bool? overrideVirtualSwitchConfiguration = default(bool?), Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides virtualSwitchConfigurationOverrides = null, bool? overrideQosPolicy = default(bool?), Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides qosPolicyOverrides = null, bool? overrideAdapterProperty = default(bool?), Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides adapterPropertyOverrides = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties HciEdgeDeviceProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration deviceConfiguration = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties HciEdgeDeviceReportedProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState? deviceState = default(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> extensions = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo HciEdgeDeviceStorageAdapterIPInfo(string physicalNode = null, string ipv4Address = null, string subnetMask = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks HciEdgeDeviceStorageNetworks(string name = null, string networkAdapterName = null, string storageVlanId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo> storageAdapterIPInfo = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail HciEdgeDeviceSwitchDetail(string switchName = null, string switchType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension> extensions = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult HciEdgeDeviceValidateResult(string status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides HciEdgeDeviceVirtualSwitchConfigurationOverrides(string enableIov = null, string loadBalancingAlgorithm = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension HciEdgeSwitchExtension(string switchId = null, string extensionName = null, bool? isExtensionEnabled = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `ArcExtensionInstanceView` moving forward.")]
        public static Azure.ResourceManager.Hci.Models.HciExtensionInstanceView HciExtensionInstanceView(string name = null, string extensionInstanceViewType = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNetworkProfile HciNetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciNicDetail> nicDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail> switchDetails = null, Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork hostNetwork = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNicDetail HciNicDetail(string adapterName = null, string interfaceDescription = null, string componentId = null, string driverVersion = null, string ipv4Address = null, string subnetMask = null, string defaultGateway = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, string defaultIsolationId = null, string macAddress = null, string slot = null, string switchName = null, string nicType = null, string vlanId = null, string nicStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciOSProfile HciOSProfile(string bootType = null, string assemblyVersion = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciReportedProperties HciReportedProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState? deviceState = default(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> extensions = null, Azure.ResourceManager.Hci.Models.HciNetworkProfile networkProfile = null, Azure.ResourceManager.Hci.Models.HciOSProfile osProfile = null, Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo sbeDeploymentPackageInfo = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciSkuData HciSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string publisherId = null, string offerId = null, string content = null, string contentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciSkuMappings> skuMappings = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciValidationFailureDetail HciValidationFailureDetail(string exception = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration IsolatedVmAttestationConfiguration(Azure.Core.ResourceIdentifier attestationResourceId = null, string relyingPartyServiceEndpoint = null, string attestationServiceEndpoint = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionError LogCollectionError(string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionProperties LogCollectionProperties(System.DateTimeOffset? fromDate = default(System.DateTimeOffset?), System.DateTimeOffset? toDate = default(System.DateTimeOffset?), System.DateTimeOffset? lastLogGenerated = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.LogCollectionSession> logCollectionSessionDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionSession LogCollectionSession(System.DateTimeOffset? logStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? logEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? timeCollected = default(System.DateTimeOffset?), long? logSize = default(long?), Azure.ResourceManager.Hci.Models.LogCollectionStatus? logCollectionStatus = default(Azure.ResourceManager.Hci.Models.LogCollectionStatus?), Azure.ResourceManager.Hci.Models.LogCollectionJobType? logCollectionJobType = default(Azure.ResourceManager.Hci.Models.LogCollectionJobType?), string correlationId = null, System.DateTimeOffset? endTimeCollected = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.LogCollectionError logCollectionError = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `HciClusterOfferData` moving forward.")]
        public static Azure.ResourceManager.Hci.OfferData OfferData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string publisherId = null, string content = null, string contentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciSkuMappings> skuMappings = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Hci.Models.PerNodeArcState PerNodeArcState(string name, string arcInstance, Azure.ResourceManager.Hci.Models.NodeArcState? state) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeArcState PerNodeArcState(string name = null, string arcInstance = null, System.Guid? arcNodeServicePrincipalObjectId = default(System.Guid?), Azure.ResourceManager.Hci.Models.NodeArcState? state = default(Azure.ResourceManager.Hci.Models.NodeArcState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeExtensionState PerNodeExtensionState(string name = null, string extension = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.NodeExtensionState? state = default(Azure.ResourceManager.Hci.Models.NodeExtensionState?), Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView extensionInstanceView = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `ArcExtensionInstanceView` moving forward.")]
        public static Azure.ResourceManager.Hci.Models.PerNodeExtensionState PerNodeExtensionState(string name = null, string extension = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.NodeExtensionState? state = default(Azure.ResourceManager.Hci.Models.NodeExtensionState?), Azure.ResourceManager.Hci.Models.HciExtensionInstanceView instanceView = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession PerNodeRemoteSupportSession(System.DateTimeOffset? sessionStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? sessionEndOn = default(System.DateTimeOffset?), string nodeName = null, long? duration = default(long?), Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? accessLevel = default(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `HciClusterPublisherData` moving forward.")]
        public static Azure.ResourceManager.Hci.PublisherData PublisherData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties RemoteSupportContentProperties(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? accessLevel = default(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.RemoteSupportType? remoteSupportType = default(Azure.ResourceManager.Hci.Models.RemoteSupportType?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings RemoteSupportNodeSettings(Azure.Core.ResourceIdentifier arcResourceId = null, string state = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string connectionStatus = null, string connectionErrorMessage = null, string transcriptLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportProperties RemoteSupportProperties(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? accessLevel = default(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.RemoteSupportType? remoteSupportType = default(Azure.ResourceManager.Hci.Models.RemoteSupportType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings> remoteSupportNodeSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession> remoteSupportSessionDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo SbeDeploymentPackageInfo(string code = null, string message = null, string sbeManifest = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SecurityComplianceStatus SecurityComplianceStatus(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? securedCoreCompliance = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus?), Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? wdacCompliance = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus?), Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? dataAtRestEncrypted = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus?), Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? dataInTransitProtected = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties SoftwareAssuranceProperties(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus? softwareAssuranceStatus = default(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus?), Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? softwareAssuranceIntent = default(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `HciClusterUpdateData` moving forward.")]
        public static Azure.ResourceManager.Hci.UpdateData UpdateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.DateTimeOffset? installedOn = default(System.DateTimeOffset?), string description = null, Azure.ResourceManager.Hci.Models.HciUpdateState? state = default(Azure.ResourceManager.Hci.Models.HciUpdateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.UpdatePrerequisite> prerequisites = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> componentVersions = null, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement? rebootRequired = default(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement?), Azure.ResourceManager.Hci.Models.HciHealthState? healthState = default(Azure.ResourceManager.Hci.Models.HciHealthState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult = null, System.DateTimeOffset? healthCheckOn = default(System.DateTimeOffset?), string packagePath = null, float? packageSizeInMb = default(float?), string displayName = null, string version = null, string publisher = null, string releaseLink = null, Azure.ResourceManager.Hci.Models.HciAvailabilityType? availabilityType = default(Azure.ResourceManager.Hci.Models.HciAvailabilityType?), string packageType = null, string additionalProperties = null, float? progressPercentage = default(float?), string notifyMessage = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `HciClusterUpdateRunData` moving forward.")]
        public static Azure.ResourceManager.Hci.UpdateRunData UpdateRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.DateTimeOffset? timeStarted = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), string duration = null, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? state = default(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState?), string namePropertiesProgressName = null, string description = null, string errorMessage = null, string status = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedTimeUtc = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUpdateStep> steps = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `HciClusterUpdateSummaryData` moving forward.")]
        public static Azure.ResourceManager.Hci.UpdateSummaryData UpdateSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string oemFamily = null, string hardwareModel = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> packageVersions = null, string currentVersion = null, System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?), System.DateTimeOffset? lastChecked = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciHealthState? healthState = default(Azure.ResourceManager.Hci.Models.HciHealthState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult = null, System.DateTimeOffset? healthCheckOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState? state = default(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterNodeType : System.IEquatable<Azure.ResourceManager.Hci.Models.ClusterNodeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterNodeType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClusterNodeType FirstParty { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ClusterNodeType ThirdParty { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ClusterNodeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ClusterNodeType left, Azure.ResourceManager.Hci.Models.ClusterNodeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ClusterNodeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ClusterNodeType left, Azure.ResourceManager.Hci.Models.ClusterNodeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentSettingAdapterPropertyOverrides : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides>
    {
        public DeploymentSettingAdapterPropertyOverrides() { }
        public string JumboPacket { get { throw null; } set { } }
        public string NetworkDirect { get { throw null; } set { } }
        public string NetworkDirectTechnology { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingHostNetwork : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork>
    {
        public DeploymentSettingHostNetwork() { }
        public bool? EnableStorageAutoIP { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeploymentSettingIntents> Intents { get { throw null; } }
        public bool? StorageConnectivitySwitchless { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks> StorageNetworks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingInfrastructureNetwork : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork>
    {
        public DeploymentSettingInfrastructureNetwork() { }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public string Gateway { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools> IPPools { get { throw null; } }
        public string SubnetMask { get { throw null; } set { } }
        public bool? UseDhcp { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingIntents : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIntents>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIntents>
    {
        public DeploymentSettingIntents() { }
        public System.Collections.Generic.IList<string> Adapter { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides AdapterPropertyOverrides { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? OverrideAdapterProperty { get { throw null; } set { } }
        public bool? OverrideQosPolicy { get { throw null; } set { } }
        public bool? OverrideVirtualSwitchConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides QosPolicyOverrides { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TrafficType { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides VirtualSwitchConfigurationOverrides { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingIntents System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIntents>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIntents>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingIntents System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIntents>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIntents>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIntents>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingIPPools : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools>
    {
        public DeploymentSettingIPPools() { }
        public string EndingAddress { get { throw null; } set { } }
        public string StartingAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingNetworkController : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController>
    {
        public DeploymentSettingNetworkController() { }
        public string MacAddressPoolStart { get { throw null; } set { } }
        public string MacAddressPoolStop { get { throw null; } set { } }
        public bool? NetworkVirtualizationEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingObservability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingObservability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingObservability>
    {
        public DeploymentSettingObservability() { }
        public bool? IsEpisodicDataUploadEnabled { get { throw null; } set { } }
        public bool? IsEULocation { get { throw null; } set { } }
        public bool? IsStreamingDataClientEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingObservability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingObservability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingObservability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingObservability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingObservability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingObservability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingObservability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingPhysicalNodes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes>
    {
        public DeploymentSettingPhysicalNodes() { }
        public string IPv4Address { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingQosPolicyOverrides : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides>
    {
        public DeploymentSettingQosPolicyOverrides() { }
        public string BandwidthPercentageSmb { get { throw null; } set { } }
        public string PriorityValue8021ActionCluster { get { throw null; } set { } }
        public string PriorityValue8021ActionSmb { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingScaleUnits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits>
    {
        public DeploymentSettingScaleUnits(Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo deploymentData) { }
        public Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo DeploymentData { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.SbePartnerInfo SbePartnerInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingStorageAdapterIPInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo>
    {
        public DeploymentSettingStorageAdapterIPInfo() { }
        public string IPv4Address { get { throw null; } set { } }
        public string PhysicalNode { get { throw null; } set { } }
        public string SubnetMask { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingStorageNetworks : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks>
    {
        public DeploymentSettingStorageNetworks() { }
        public string Name { get { throw null; } set { } }
        public string NetworkAdapterName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo> StorageAdapterIPInfo { get { throw null; } }
        public string VlanId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingVirtualSwitchConfigurationOverrides : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides>
    {
        public DeploymentSettingVirtualSwitchConfigurationOverrides() { }
        public string EnableIov { get { throw null; } set { } }
        public string LoadBalancingAlgorithm { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EceActionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EceActionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceActionStatus>
    {
        internal EceActionStatus() { }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep> Steps { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EceActionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EceActionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EceActionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EceActionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceActionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceActionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceActionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EceDeploymentMode : System.IEquatable<Azure.ResourceManager.Hci.Models.EceDeploymentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EceDeploymentMode(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EceDeploymentMode Deploy { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EceDeploymentMode Validate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.EceDeploymentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.EceDeploymentMode left, Azure.ResourceManager.Hci.Models.EceDeploymentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EceDeploymentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.EceDeploymentMode left, Azure.ResourceManager.Hci.Models.EceDeploymentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EceDeploymentSecrets : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets>
    {
        public EceDeploymentSecrets() { }
        public Azure.ResourceManager.Hci.Models.EceSecret? EceSecretName { get { throw null; } set { } }
        public System.Uri SecretLocation { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EceDeploymentSecrets System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EceDeploymentSecrets System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EceReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EceReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceReportedProperties>
    {
        internal EceReportedProperties() { }
        public Azure.ResourceManager.Hci.Models.EceActionStatus DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EceActionStatus ValidationStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EceReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EceReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EceReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EceReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EceSecret : System.IEquatable<Azure.ResourceManager.Hci.Models.EceSecret>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EceSecret(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EceSecret AzureStackLcmUserCredential { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EceSecret DefaultArbApplication { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EceSecret LocalAdminCredential { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EceSecret WitnessStorageKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.EceSecret other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.EceSecret left, Azure.ResourceManager.Hci.Models.EceSecret right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EceSecret (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.EceSecret left, Azure.ResourceManager.Hci.Models.EceSecret right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `ArcExtensionInstanceViewStatus` moving forward.")]
    public partial class ExtensionInstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>
    {
        internal ExtensionInstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciStatusLevelType? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `ArcExtensionUpgradeContent` moving forward.")]
    public partial class ExtensionUpgradeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>
    {
        public ExtensionUpgradeContent() { }
        public string TargetVersion { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciArcEnabledEdgeDevice : Azure.ResourceManager.Hci.HciEdgeDeviceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDevice>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDevice>
    {
        public HciArcEnabledEdgeDevice() { }
        public Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDevice System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDevice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDevice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDevice System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDevice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDevice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDevice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciArcEnabledEdgeDeviceProperties : Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties>
    {
        public HciArcEnabledEdgeDeviceProperties() { }
        public Azure.ResourceManager.Hci.Models.HciReportedProperties ReportedProperties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciAvailabilityType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciAvailabilityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciAvailabilityType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciAvailabilityType Local { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciAvailabilityType Notify { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciAvailabilityType Online { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciAvailabilityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciAvailabilityType left, Azure.ResourceManager.Hci.Models.HciAvailabilityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciAvailabilityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciAvailabilityType left, Azure.ResourceManager.Hci.Models.HciAvailabilityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterAccessLevel : System.IEquatable<Azure.ResourceManager.Hci.Models.HciClusterAccessLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterAccessLevel(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterAccessLevel Diagnostics { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterAccessLevel DiagnosticsAndRepair { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel left, Azure.ResourceManager.Hci.Models.HciClusterAccessLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterAccessLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel left, Azure.ResourceManager.Hci.Models.HciClusterAccessLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterCertificateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>
    {
        public HciClusterCertificateContent() { }
        public System.Collections.Generic.IList<string> Certificates { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterCertificateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterCertificateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterComplianceAssignmentType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterComplianceAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType ApplyAndAutoCorrect { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType Audit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType left, Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType left, Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterComplianceStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterComplianceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus Compliant { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus NonCompliant { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus left, Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus left, Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterConnectivityStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterConnectivityStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus NotConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus NotYetRegistered { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus PartiallyConnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus left, Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus left, Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterDeploymentConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration>
    {
        public HciClusterDeploymentConfiguration(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits> scaleUnits) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits> ScaleUnits { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterDeploymentInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo>
    {
        public HciClusterDeploymentInfo() { }
        public string AdouPath { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciDeploymentCluster Cluster { get { throw null; } set { } }
        public string DomainFqdn { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork HostNetwork { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork> InfrastructureNetwork { get { throw null; } }
        public string NamingPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.DeploymentSettingObservability Observability { get { throw null; } set { } }
        public string OptionalServicesCustomLocation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes> PhysicalNodes { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController SdnIntegrationNetworkController { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets> Secrets { get { throw null; } }
        public string SecretsLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings SecuritySettings { get { throw null; } set { } }
        public string StorageConfigurationMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterDeploymentSecuritySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings>
    {
        public HciClusterDeploymentSecuritySettings() { }
        public bool? AreBitlockerDataVolumesEnabled { get { throw null; } set { } }
        public bool? IsBitlockerBootVolumeEnabled { get { throw null; } set { } }
        public bool? IsCredentialGuardEnforced { get { throw null; } set { } }
        public bool? IsDriftControlEnforced { get { throw null; } set { } }
        public bool? IsDrtmProtectionEnabled { get { throw null; } set { } }
        public bool? IsHvciProtectionEnabled { get { throw null; } set { } }
        public bool? IsSideChannelMitigationEnforced { get { throw null; } set { } }
        public bool? IsSmbClusterEncryptionEnabled { get { throw null; } set { } }
        public bool? IsSmbSigningEnforced { get { throw null; } set { } }
        public bool? IsWdacEnforced { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterDeploymentStep : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep>
    {
        internal HciClusterDeploymentStep() { }
        public string Description { get { throw null; } }
        public string EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Exception { get { throw null; } }
        public string FullStepIndex { get { throw null; } }
        public string Name { get { throw null; } }
        public string StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep> Steps { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterDesiredProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>
    {
        public HciClusterDesiredProperties() { }
        public Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? DiagnosticLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterDiagnosticLevel : System.IEquatable<Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterDiagnosticLevel(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel Basic { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel Enhanced { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel left, Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel left, Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterIdentityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>
    {
        internal HciClusterIdentityResult() { }
        public System.Guid? AadApplicationObjectId { get { throw null; } }
        public System.Guid? AadClientId { get { throw null; } }
        public System.Guid? AadServicePrincipalObjectId { get { throw null; } }
        public System.Guid? AadTenantId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterIdentityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterIdentityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterNode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterNode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterNode>
    {
        internal HciClusterNode() { }
        public float? CoreCount { get { throw null; } }
        public string EhcResourceId { get { throw null; } }
        public float? Id { get { throw null; } }
        public System.DateTimeOffset? LastLicensingTimestamp { get { throw null; } }
        public string Manufacturer { get { throw null; } }
        public float? MemoryInGiB { get { throw null; } }
        public string Model { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ClusterNodeType? NodeType { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.OemActivation? OemActivation { get { throw null; } }
        public string OSDisplayVersion { get { throw null; } }
        public string OSName { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterNode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterNode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterNode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterNode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterNode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterNode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterNode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterOperationType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciClusterOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterOperationType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterOperationType ClusterProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterOperationType ClusterUpgrade { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterOperationType left, Azure.ResourceManager.Hci.Models.HciClusterOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterOperationType left, Azure.ResourceManager.Hci.Models.HciClusterOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>
    {
        public HciClusterPatch() { }
        public System.Guid? AadClientId { get { throw null; } set { } }
        public System.Guid? AadTenantId { get { throw null; } set { } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? ManagedServiceIdentityType { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciClusterReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>
    {
        internal HciClusterReportedProperties() { }
        public System.Guid? ClusterId { get { throw null; } }
        public string ClusterName { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ClusterNodeType? ClusterType { get { throw null; } }
        public string ClusterVersion { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? DiagnosticLevel { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ImdsAttestationState? ImdsAttestation { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string Manufacturer { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciClusterNode> Nodes { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.OemActivation? OemActivation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedCapabilities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.HciClusterStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus ConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus DeploymentFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus DeploymentInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus DeploymentSuccess { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotYetRegistered { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus ValidationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus ValidationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus ValidationSuccess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterStatus left, Azure.ResourceManager.Hci.Models.HciClusterStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterStatus left, Azure.ResourceManager.Hci.Models.HciClusterStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterUpdatePrerequisite : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite>
    {
        public HciClusterUpdatePrerequisite() { }
        public string PackageName { get { throw null; } set { } }
        public string UpdateType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterUpdateState : System.IEquatable<Azure.ResourceManager.Hci.Models.HciClusterUpdateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterUpdateState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterUpdateState AppliedSuccessfully { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterUpdateState NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterUpdateState PreparationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterUpdateState PreparationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterUpdateState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterUpdateState UpdateAvailable { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterUpdateState UpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterUpdateState UpdateInProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterUpdateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterUpdateState left, Azure.ResourceManager.Hci.Models.HciClusterUpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterUpdateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterUpdateState left, Azure.ResourceManager.Hci.Models.HciClusterUpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciDeploymentCluster : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>
    {
        public HciDeploymentCluster() { }
        public string AzureServiceEndpoint { get { throw null; } set { } }
        public string CloudAccountName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string WitnessPath { get { throw null; } set { } }
        public string WitnessType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciDeploymentCluster System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciDeploymentCluster System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceAdapterPropertyOverrides : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides>
    {
        internal HciEdgeDeviceAdapterPropertyOverrides() { }
        public string JumboPacket { get { throw null; } }
        public string NetworkDirect { get { throw null; } }
        public string NetworkDirectTechnology { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceArcExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension>
    {
        internal HciEdgeDeviceArcExtension() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail> ErrorDetails { get { throw null; } }
        public string ExtensionName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ExtensionResourceId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy? ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ArcExtensionState? State { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration>
    {
        public HciEdgeDeviceConfiguration() { }
        public string DeviceMetadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail> NicDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceHostNetwork : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork>
    {
        internal HciEdgeDeviceHostNetwork() { }
        public bool? EnableStorageAutoIP { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents> Intents { get { throw null; } }
        public bool? StorageConnectivitySwitchless { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks> StorageNetworks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceIntents : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents>
    {
        internal HciEdgeDeviceIntents() { }
        public Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides AdapterPropertyOverrides { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IntentAdapters { get { throw null; } }
        public string IntentName { get { throw null; } }
        public long? IntentType { get { throw null; } }
        public bool? IsComputeIntentSet { get { throw null; } }
        public bool? IsManagementIntentSet { get { throw null; } }
        public bool? IsNetworkIntentType { get { throw null; } }
        public bool? IsOnlyStorage { get { throw null; } }
        public bool? IsOnlyStretch { get { throw null; } }
        public bool? IsStorageIntentSet { get { throw null; } }
        public bool? IsStretchIntentSet { get { throw null; } }
        public bool? OverrideAdapterProperty { get { throw null; } }
        public bool? OverrideQosPolicy { get { throw null; } }
        public bool? OverrideVirtualSwitchConfiguration { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides QosPolicyOverrides { get { throw null; } }
        public long? Scope { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides VirtualSwitchConfigurationOverrides { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceNicDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail>
    {
        public HciEdgeDeviceNicDetail() { }
        public string AdapterName { get { throw null; } set { } }
        public string ComponentId { get { throw null; } set { } }
        public string DefaultGateway { get { throw null; } set { } }
        public string DefaultIsolationId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public string DriverVersion { get { throw null; } set { } }
        public string InterfaceDescription { get { throw null; } set { } }
        public string IPv4Address { get { throw null; } set { } }
        public string SubnetMask { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>
    {
        public HciEdgeDeviceProperties() { }
        public Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration DeviceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties>
    {
        internal HciEdgeDeviceReportedProperties() { }
        public Azure.ResourceManager.Hci.Models.HciEdgeDeviceState? DeviceState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> Extensions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciEdgeDeviceState : System.IEquatable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciEdgeDeviceState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceState Draining { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceState InMaintenance { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceState Processing { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceState Repairing { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceState Resuming { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState left, Azure.ResourceManager.Hci.Models.HciEdgeDeviceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciEdgeDeviceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState left, Azure.ResourceManager.Hci.Models.HciEdgeDeviceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciEdgeDeviceStorageAdapterIPInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo>
    {
        internal HciEdgeDeviceStorageAdapterIPInfo() { }
        public string IPv4Address { get { throw null; } }
        public string PhysicalNode { get { throw null; } }
        public string SubnetMask { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceStorageNetworks : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks>
    {
        internal HciEdgeDeviceStorageNetworks() { }
        public string Name { get { throw null; } }
        public string NetworkAdapterName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo> StorageAdapterIPInfo { get { throw null; } }
        public string StorageVlanId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceSwitchDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail>
    {
        internal HciEdgeDeviceSwitchDetail() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension> Extensions { get { throw null; } }
        public string SwitchName { get { throw null; } }
        public string SwitchType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceValidateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent>
    {
        public HciEdgeDeviceValidateContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> edgeDeviceIds) { }
        public string AdditionalInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> EdgeDeviceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceValidateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult>
    {
        internal HciEdgeDeviceValidateResult() { }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceVirtualSwitchConfigurationOverrides : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides>
    {
        internal HciEdgeDeviceVirtualSwitchConfigurationOverrides() { }
        public string EnableIov { get { throw null; } }
        public string LoadBalancingAlgorithm { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeSwitchExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension>
    {
        internal HciEdgeSwitchExtension() { }
        public string ExtensionName { get { throw null; } }
        public bool? IsExtensionEnabled { get { throw null; } }
        public string SwitchId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `ArcExtensionInstanceView` moving forward.")]
    public partial class HciExtensionInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>
    {
        internal HciExtensionInstanceView() { }
        public string ExtensionInstanceViewType { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus Status { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
        Azure.ResourceManager.Hci.Models.HciExtensionInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciExtensionInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciHealthState : System.IEquatable<Azure.ResourceManager.Hci.Models.HciHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciHealthState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Failure { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Success { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciHealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciHealthState left, Azure.ResourceManager.Hci.Models.HciHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciHealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciHealthState left, Azure.ResourceManager.Hci.Models.HciHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType left, Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType left, Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciNetworkProfile>
    {
        internal HciNetworkProfile() { }
        public Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork HostNetwork { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciNicDetail> NicDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail> SwitchDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciNicDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciNicDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciNicDetail>
    {
        internal HciNicDetail() { }
        public string AdapterName { get { throw null; } }
        public string ComponentId { get { throw null; } }
        public string DefaultGateway { get { throw null; } }
        public string DefaultIsolationId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DnsServers { get { throw null; } }
        public string DriverVersion { get { throw null; } }
        public string InterfaceDescription { get { throw null; } }
        public string IPv4Address { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string NicStatus { get { throw null; } }
        public string NicType { get { throw null; } }
        public string Slot { get { throw null; } }
        public string SubnetMask { get { throw null; } }
        public string SwitchName { get { throw null; } }
        public string VlanId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciNicDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciNicDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciNicDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciNicDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciNicDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciNicDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciNicDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciNodeRebootRequirement : System.IEquatable<Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciNodeRebootRequirement(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement False { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement True { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement left, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement left, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciOSProfile>
    {
        internal HciOSProfile() { }
        public string AssemblyVersion { get { throw null; } }
        public string BootType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciPackageVersionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>
    {
        public HciPackageVersionInfo() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public string PackageType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciPackageVersionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciPackageVersionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciPrecheckResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>
    {
        public HciPrecheckResult() { }
        public string AdditionalData { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string HealthCheckSource { get { throw null; } set { } }
        public System.BinaryData HealthCheckTags { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Remediation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.UpdateSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciPrecheckResultTags Tags { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceName { get { throw null; } set { } }
        public string TargetResourceType { get { throw null; } set { } }
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciPrecheckResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciPrecheckResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciPrecheckResultTags : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>
    {
        public HciPrecheckResultTags() { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciPrecheckResultTags System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciPrecheckResultTags System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciProvisioningState : System.IEquatable<Azure.ResourceManager.Hci.Models.HciProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState DisableInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciProvisioningState left, Azure.ResourceManager.Hci.Models.HciProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciProvisioningState left, Azure.ResourceManager.Hci.Models.HciProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciReportedProperties : Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>
    {
        internal HciReportedProperties() { }
        public Azure.ResourceManager.Hci.Models.HciNetworkProfile NetworkProfile { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciOSProfile OSProfile { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo SbeDeploymentPackageInfo { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciSkuMappings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>
    {
        public HciSkuMappings() { }
        public string CatalogPlanId { get { throw null; } set { } }
        public string MarketplaceSkuId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MarketplaceSkuVersions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciSkuMappings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciSkuMappings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciStatusLevelType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciStatusLevelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciStatusLevelType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciStatusLevelType Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciStatusLevelType Info { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciStatusLevelType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciStatusLevelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciStatusLevelType left, Azure.ResourceManager.Hci.Models.HciStatusLevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciStatusLevelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciStatusLevelType left, Azure.ResourceManager.Hci.Models.HciStatusLevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciUpdateState : System.IEquatable<Azure.ResourceManager.Hci.Models.HciUpdateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciUpdateState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState AdditionalContentRequired { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState DownloadFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Downloading { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState HasPrerequisite { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState HealthCheckFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState HealthChecking { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState InstallationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Installed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Installing { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Invalid { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState NotApplicableBecauseAnotherUpdateIsInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Obsolete { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState PreparationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Preparing { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Ready { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState ReadyToInstall { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Recalled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState ScanFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState ScanInProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciUpdateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciUpdateState left, Azure.ResourceManager.Hci.Models.HciUpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciUpdateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciUpdateState left, Azure.ResourceManager.Hci.Models.HciUpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciUpdateStep : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>
    {
        public HciUpdateStep() { }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `EndOn` moving forward.")]
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        public string ExpectedExecutionTime { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        public System.DateTimeOffset? LastUpdatedTimeUtc { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `StartOn` moving forward.")]
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciUpdateStep> Steps { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciUpdateStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciUpdateStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciValidationFailureDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>
    {
        internal HciValidationFailureDetail() { }
        public string Exception { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciValidationFailureDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciValidationFailureDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImdsAttestationState : System.IEquatable<Azure.ResourceManager.Hci.Models.ImdsAttestationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImdsAttestationState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ImdsAttestationState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ImdsAttestationState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ImdsAttestationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ImdsAttestationState left, Azure.ResourceManager.Hci.Models.ImdsAttestationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ImdsAttestationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ImdsAttestationState left, Azure.ResourceManager.Hci.Models.ImdsAttestationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IsolatedVmAttestationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>
    {
        internal IsolatedVmAttestationConfiguration() { }
        public Azure.Core.ResourceIdentifier AttestationResourceId { get { throw null; } }
        public string AttestationServiceEndpoint { get { throw null; } }
        public string RelyingPartyServiceEndpoint { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogCollectionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionContent>
    {
        public LogCollectionContent() { }
        public Azure.ResourceManager.Hci.Models.LogCollectionContentProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogCollectionContentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionContentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionContentProperties>
    {
        public LogCollectionContentProperties(System.DateTimeOffset fromDate, System.DateTimeOffset toDate) { }
        public System.DateTimeOffset FromDate { get { throw null; } }
        public System.DateTimeOffset ToDate { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionContentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionContentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionContentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionContentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionContentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionContentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionContentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogCollectionError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionError>
    {
        internal LogCollectionError() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogCollectionJobType : System.IEquatable<Azure.ResourceManager.Hci.Models.LogCollectionJobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogCollectionJobType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionJobType OnDemand { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.LogCollectionJobType Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.LogCollectionJobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.LogCollectionJobType left, Azure.ResourceManager.Hci.Models.LogCollectionJobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.LogCollectionJobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.LogCollectionJobType left, Azure.ResourceManager.Hci.Models.LogCollectionJobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogCollectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionProperties>
    {
        public LogCollectionProperties() { }
        public System.DateTimeOffset? FromDate { get { throw null; } }
        public System.DateTimeOffset? LastLogGenerated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.LogCollectionSession> LogCollectionSessionDetails { get { throw null; } }
        public System.DateTimeOffset? ToDate { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogCollectionSession : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionSession>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionSession>
    {
        internal LogCollectionSession() { }
        public string CorrelationId { get { throw null; } }
        public System.DateTimeOffset? EndTimeCollected { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.LogCollectionError LogCollectionError { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.LogCollectionJobType? LogCollectionJobType { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.LogCollectionStatus? LogCollectionStatus { get { throw null; } }
        public System.DateTimeOffset? LogEndOn { get { throw null; } }
        public long? LogSize { get { throw null; } }
        public System.DateTimeOffset? LogStartOn { get { throw null; } }
        public System.DateTimeOffset? TimeCollected { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionSession System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionSession>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionSession>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionSession System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionSession>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionSession>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionSession>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogCollectionStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.LogCollectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogCollectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.LogCollectionStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.LogCollectionStatus None { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.LogCollectionStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.LogCollectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.LogCollectionStatus left, Azure.ResourceManager.Hci.Models.LogCollectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.LogCollectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.LogCollectionStatus left, Azure.ResourceManager.Hci.Models.LogCollectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeArcState : System.IEquatable<Azure.ResourceManager.Hci.Models.NodeArcState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeArcState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState DisableInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.NodeArcState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.NodeArcState left, Azure.ResourceManager.Hci.Models.NodeArcState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.NodeArcState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.NodeArcState left, Azure.ResourceManager.Hci.Models.NodeArcState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeExtensionState : System.IEquatable<Azure.ResourceManager.Hci.Models.NodeExtensionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeExtensionState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.NodeExtensionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.NodeExtensionState left, Azure.ResourceManager.Hci.Models.NodeExtensionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.NodeExtensionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.NodeExtensionState left, Azure.ResourceManager.Hci.Models.NodeExtensionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OemActivation : System.IEquatable<Azure.ResourceManager.Hci.Models.OemActivation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OemActivation(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OemActivation Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.OemActivation Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.OemActivation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.OemActivation left, Azure.ResourceManager.Hci.Models.OemActivation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OemActivation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.OemActivation left, Azure.ResourceManager.Hci.Models.OemActivation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PerNodeArcState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>
    {
        internal PerNodeArcState() { }
        public string ArcInstance { get { throw null; } }
        public System.Guid? ArcNodeServicePrincipalObjectId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.NodeArcState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PerNodeArcState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PerNodeArcState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PerNodeExtensionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>
    {
        internal PerNodeExtensionState() { }
        public string Extension { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView ExtensionInstanceView { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `StartOn` moving forward.")]
        public Azure.ResourceManager.Hci.Models.HciExtensionInstanceView InstanceView { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.NodeExtensionState? State { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PerNodeExtensionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PerNodeExtensionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeExtensionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PerNodeRemoteSupportSession : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession>
    {
        internal PerNodeRemoteSupportSession() { }
        public Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? AccessLevel { get { throw null; } }
        public long? Duration { get { throw null; } }
        public string NodeName { get { throw null; } }
        public System.DateTimeOffset? SessionEndOn { get { throw null; } }
        public System.DateTimeOffset? SessionStartOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteSupportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportContent>
    {
        public RemoteSupportContent() { }
        public Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteSupportContentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties>
    {
        public RemoteSupportContentProperties() { }
        public Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? AccessLevel { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.RemoteSupportType? RemoteSupportType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteSupportNodeSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings>
    {
        internal RemoteSupportNodeSettings() { }
        public Azure.Core.ResourceIdentifier ArcResourceId { get { throw null; } }
        public string ConnectionErrorMessage { get { throw null; } }
        public string ConnectionStatus { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string State { get { throw null; } }
        public string TranscriptLocation { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteSupportProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportProperties>
    {
        public RemoteSupportProperties() { }
        public Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? AccessLevel { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings> RemoteSupportNodeSettings { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession> RemoteSupportSessionDetails { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.RemoteSupportType? RemoteSupportType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteSupportType : System.IEquatable<Azure.ResourceManager.Hci.Models.RemoteSupportType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteSupportType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportType Enable { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportType Revoke { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.RemoteSupportType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.RemoteSupportType left, Azure.ResourceManager.Hci.Models.RemoteSupportType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.RemoteSupportType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.RemoteSupportType left, Azure.ResourceManager.Hci.Models.RemoteSupportType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SbeCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbeCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbeCredentials>
    {
        public SbeCredentials() { }
        public string EceSecretName { get { throw null; } set { } }
        public System.Uri SecretLocation { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SbeCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbeCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbeCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SbeCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbeCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbeCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbeCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SbeDeploymentInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbeDeploymentInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbeDeploymentInfo>
    {
        public SbeDeploymentInfo() { }
        public string Family { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.DateTimeOffset? SbeManifestCreationOn { get { throw null; } set { } }
        public string SbeManifestSource { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SbeDeploymentInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbeDeploymentInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbeDeploymentInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SbeDeploymentInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbeDeploymentInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbeDeploymentInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbeDeploymentInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SbeDeploymentPackageInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo>
    {
        internal SbeDeploymentPackageInfo() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string SbeManifest { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SbePartnerInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbePartnerInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbePartnerInfo>
    {
        public SbePartnerInfo() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.SbeCredentials> CredentialList { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.SbePartnerProperties> PartnerProperties { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SbeDeploymentInfo SbeDeploymentInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SbePartnerInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbePartnerInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbePartnerInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SbePartnerInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbePartnerInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbePartnerInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbePartnerInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SbePartnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbePartnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbePartnerProperties>
    {
        public SbePartnerProperties() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SbePartnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbePartnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbePartnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SbePartnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbePartnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbePartnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbePartnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityComplianceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecurityComplianceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecurityComplianceStatus>
    {
        internal SecurityComplianceStatus() { }
        public Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? DataAtRestEncrypted { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? DataInTransitProtected { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? SecuredCoreCompliance { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? WdacCompliance { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SecurityComplianceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecurityComplianceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecurityComplianceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SecurityComplianceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecurityComplianceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecurityComplianceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecurityComplianceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SoftwareAssuranceChangeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>
    {
        public SoftwareAssuranceChangeContent() { }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? SoftwareAssuranceIntent { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SoftwareAssuranceIntent : System.IEquatable<Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SoftwareAssuranceIntent(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent Disable { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SoftwareAssuranceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>
    {
        public SoftwareAssuranceProperties() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? SoftwareAssuranceIntent { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus? SoftwareAssuranceStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SoftwareAssuranceStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SoftwareAssuranceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdatePrerequisite` moving forward.")]
    public partial class UpdatePrerequisite : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>
    {
        public UpdatePrerequisite() { }
        public string PackageName { get { throw null; } set { } }
        public string UpdateType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.Hci.Models.UpdatePrerequisite System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.UpdatePrerequisite System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateRunPropertiesState : System.IEquatable<Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateRunPropertiesState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateSeverity : System.IEquatable<Azure.ResourceManager.Hci.Models.UpdateSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateSeverity(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.UpdateSeverity Critical { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSeverity Hidden { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSeverity Informational { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.UpdateSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.UpdateSeverity left, Azure.ResourceManager.Hci.Models.UpdateSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.UpdateSeverity left, Azure.ResourceManager.Hci.Models.UpdateSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateState` moving forward.")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateSummariesPropertiesState : System.IEquatable<Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateSummariesPropertiesState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState AppliedSuccessfully { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState PreparationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState PreparationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState UpdateAvailable { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState UpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState UpdateInProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsServerSubscription : System.IEquatable<Azure.ResourceManager.Hci.Models.WindowsServerSubscription>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsServerSubscription(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.WindowsServerSubscription Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.WindowsServerSubscription Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.WindowsServerSubscription other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.WindowsServerSubscription left, Azure.ResourceManager.Hci.Models.WindowsServerSubscription right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.WindowsServerSubscription (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.WindowsServerSubscription left, Azure.ResourceManager.Hci.Models.WindowsServerSubscription right) { throw null; }
        public override string ToString() { throw null; }
    }
}
