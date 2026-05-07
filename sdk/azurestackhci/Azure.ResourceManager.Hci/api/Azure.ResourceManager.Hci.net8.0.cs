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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ObsoleteAttribute("This method is now deprecated.")]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ArcExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated.")]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ArcExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated.")]
        public virtual Azure.ResourceManager.ArmOperation Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcSettingResource> Reconcile(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ReconcileArcSettingsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcSettingResource>> ReconcileAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ReconcileArcSettingsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ClusterJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ClusterJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ClusterJobResource>, System.Collections.IEnumerable
    {
        protected ClusterJobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterJobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobsName, Azure.ResourceManager.Hci.ClusterJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterJobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobsName, Azure.ResourceManager.Hci.ClusterJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ClusterJobResource> Get(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.ClusterJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.ClusterJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ClusterJobResource>> GetAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.ClusterJobResource> GetIfExists(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.ClusterJobResource>> GetIfExistsAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.ClusterJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ClusterJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.ClusterJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ClusterJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterJobData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ClusterJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterJobData>
    {
        public ClusterJobData() { }
        public Azure.ResourceManager.Hci.Models.ClusterJobProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.ClusterJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ClusterJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ClusterJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ClusterJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterJobResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ClusterJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterJobData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterJobResource() { }
        public virtual Azure.ResourceManager.Hci.ClusterJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string jobsName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ClusterJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ClusterJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.ClusterJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ClusterJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ClusterJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ClusterJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterJobResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.ClusterJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterJobResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.ClusterJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevicePoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.DevicePoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.DevicePoolResource>, System.Collections.IEnumerable
    {
        protected DevicePoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.DevicePoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string devicePoolName, Azure.ResourceManager.Hci.DevicePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.DevicePoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string devicePoolName, Azure.ResourceManager.Hci.DevicePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource> Get(string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.DevicePoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.DevicePoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource>> GetAsync(string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.DevicePoolResource> GetIfExists(string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.DevicePoolResource>> GetIfExistsAsync(string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.DevicePoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.DevicePoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.DevicePoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.DevicePoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevicePoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.DevicePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DevicePoolData>
    {
        public DevicePoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.DevicePoolProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.DevicePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.DevicePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.DevicePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.DevicePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DevicePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DevicePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DevicePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevicePoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.DevicePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DevicePoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevicePoolResource() { }
        public virtual Azure.ResourceManager.Hci.DevicePoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ClaimDevices(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ClaimDeviceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClaimDevicesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ClaimDeviceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devicePoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReleaseDevices(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ReleaseDeviceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReleaseDevicesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ReleaseDeviceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.DevicePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.DevicePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.DevicePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.DevicePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DevicePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DevicePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DevicePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.DevicePoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.DevicePoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.DevicePoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.DevicePoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeDeviceJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.EdgeDeviceJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.EdgeDeviceJobResource>, System.Collections.IEnumerable
    {
        protected EdgeDeviceJobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeDeviceJobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobsName, Azure.ResourceManager.Hci.EdgeDeviceJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeDeviceJobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobsName, Azure.ResourceManager.Hci.EdgeDeviceJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource> Get(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.EdgeDeviceJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.EdgeDeviceJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource>> GetAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.EdgeDeviceJobResource> GetIfExists(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.EdgeDeviceJobResource>> GetIfExistsAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.EdgeDeviceJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.EdgeDeviceJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.EdgeDeviceJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.EdgeDeviceJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public abstract partial class EdgeDeviceJobData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>
    {
        internal EdgeDeviceJobData() { }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.EdgeDeviceJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.EdgeDeviceJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDeviceJobResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeDeviceJobResource() { }
        public virtual Azure.ResourceManager.Hci.EdgeDeviceJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string edgeDeviceName, string jobsName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.EdgeDeviceJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.EdgeDeviceJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeDeviceJobResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.EdgeDeviceJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeDeviceJobResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.EdgeDeviceJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.EdgeMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.EdgeMachineResource>, System.Collections.IEnumerable
    {
        protected EdgeMachineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeMachineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string edgeMachineName, Azure.ResourceManager.Hci.EdgeMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeMachineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string edgeMachineName, Azure.ResourceManager.Hci.EdgeMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource> Get(string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.EdgeMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.EdgeMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource>> GetAsync(string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.EdgeMachineResource> GetIfExists(string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.EdgeMachineResource>> GetIfExistsAsync(string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.EdgeMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.EdgeMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.EdgeMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.EdgeMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeMachineData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineData>
    {
        public EdgeMachineData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.EdgeMachineProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.EdgeMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.EdgeMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeMachineJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.EdgeMachineJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.EdgeMachineJobResource>, System.Collections.IEnumerable
    {
        protected EdgeMachineJobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeMachineJobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobsName, Azure.ResourceManager.Hci.EdgeMachineJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeMachineJobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobsName, Azure.ResourceManager.Hci.EdgeMachineJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeMachineJobResource> Get(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.EdgeMachineJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.EdgeMachineJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeMachineJobResource>> GetAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.EdgeMachineJobResource> GetIfExists(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.EdgeMachineJobResource>> GetIfExistsAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.EdgeMachineJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.EdgeMachineJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.EdgeMachineJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.EdgeMachineJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeMachineJobData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeMachineJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineJobData>
    {
        public EdgeMachineJobData() { }
        public Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.EdgeMachineJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeMachineJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeMachineJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.EdgeMachineJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeMachineJobResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeMachineJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineJobData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeMachineJobResource() { }
        public virtual Azure.ResourceManager.Hci.EdgeMachineJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string edgeMachineName, string jobsName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeMachineJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeMachineJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.EdgeMachineJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeMachineJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeMachineJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.EdgeMachineJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeMachineJobResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.EdgeMachineJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeMachineJobResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.EdgeMachineJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeMachineResource() { }
        public virtual Azure.ResourceManager.Hci.EdgeMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string edgeMachineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeMachineJobResource> GetEdgeMachineJob(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeMachineJobResource>> GetEdgeMachineJobAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeMachineJobCollection GetEdgeMachineJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.EdgeMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.EdgeMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.EdgeMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.EdgeMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Hci.Models.ClusterPattern? ClusterPattern { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ConfidentialVmProperties ConfidentialVmProperties { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus? ConnectivityStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciIdentityProvider? IdentityProvider { get { throw null; } }
        public bool? IsManagementCluster { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration IsolatedVmAttestationConfiguration { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastBillingTimestamp { get { throw null; } }
        public System.DateTimeOffset? LastSyncTimestamp { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones> LocalAvailabilityZones { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.LogCollectionProperties LogCollectionProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.NextBillingModel NextBillingModel { get { throw null; } }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the `Identity` property moving forward.")]
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RegistrationTimestamp { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.RemoteSupportProperties RemoteSupportProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterReportedProperties ReportedProperties { get { throw null; } }
        public string ResourceProviderObjectId { get { throw null; } }
        public string Ring { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ClusterSdnProperties SdnProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.SecretsLocationDetails> SecretsLocations { get { throw null; } }
        public string ServiceEndpoint { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties SoftwareAssuranceProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciStorageType? StorageType { get { throw null; } }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the `Identity` property moving forward.")]
        public System.Guid? TenantId { get { throw null; } }
        public float? TrialDaysRemaining { get { throw null; } }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the `Identity` property moving forward.")]
        public Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? TypeIdentityType { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the `Identity` property moving forward.")]
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource> ChangeRing(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ChangeRingContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource>> ChangeRingAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ChangeRingContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterOfferResource> GetByCluster(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterOfferResource> GetByClusterAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ClusterJobResource> GetClusterJob(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ClusterJobResource>> GetClusterJobAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ClusterJobCollection GetClusterJobs() { throw null; }
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
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterOffers` moving forward.")]
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.OfferResource> GetOffers(string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterOffersAsync` moving forward.")]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.OfferResource> GetOffersAsync(string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterPublisher` moving forward.")]
        public virtual Azure.Response<Azure.ResourceManager.Hci.PublisherResource> GetPublisher(string publisherName, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterPublisherAsync` moving forward.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PublisherResource>> GetPublisherAsync(string publisherName, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterPublishers` moving forward.")]
        public virtual Azure.ResourceManager.Hci.PublisherCollection GetPublishers() { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdate` moving forward.")]
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateResource> GetUpdate(string updateName, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateAsync` moving forward.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateResource>> GetUpdateAsync(string updateName, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdates` moving forward.")]
        public virtual Azure.ResourceManager.Hci.UpdateCollection GetUpdates() { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource> UpdateSecretsLocations(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource>> UpdateSecretsLocationsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation Prepare(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PrepareAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string UpdateRunName { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation CheckHealth(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CheckHealthAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CheckUpdates(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.CheckUpdatesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CheckUpdatesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.CheckUpdatesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource> GetEdgeDeviceJob(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource>> GetEdgeDeviceJobAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeDeviceJobCollection GetEdgeDeviceJobs() { throw null; }
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
        public static Azure.Pageable<Azure.ResourceManager.Hci.Models.HciKubernetesVersion> GetBySubscriptionLocationResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Models.HciKubernetesVersion> GetBySubscriptionLocationResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.ClusterJobResource GetClusterJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource> GetDevicePool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource>> GetDevicePoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.DevicePoolResource GetDevicePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.DevicePoolCollection GetDevicePools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.DevicePoolResource> GetDevicePools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.DevicePoolResource> GetDevicePoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource> GetEdgeDeviceJob(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource>> GetEdgeDeviceJobAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeDeviceJobResource GetEdgeDeviceJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeDeviceJobCollection GetEdgeDeviceJobs(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource> GetEdgeMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource>> GetEdgeMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeMachineJobResource GetEdgeMachineJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeMachineResource GetEdgeMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeMachineCollection GetEdgeMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.EdgeMachineResource> GetEdgeMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.EdgeMachineResource> GetEdgeMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterOfferResource` moving forward.")]
        public static Azure.ResourceManager.Hci.OfferResource GetOfferResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.OsImageResource> GetOsImage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string osImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OsImageResource>> GetOsImageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string osImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.OsImageResource GetOsImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.OsImageCollection GetOsImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.PlatformUpdateResource> GetPlatformUpdate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string platformUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PlatformUpdateResource>> GetPlatformUpdateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string platformUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.PlatformUpdateResource GetPlatformUpdateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.PlatformUpdateCollection GetPlatformUpdates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterPublisherResource` moving forward.")]
        public static Azure.ResourceManager.Hci.PublisherResource GetPublisherResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.UpdateContentResource> GetUpdateContent(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string updateContentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateContentResource>> GetUpdateContentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string updateContentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateContentResource GetUpdateContentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateContentCollection GetUpdateContents(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateResource` moving forward.")]
        public static Azure.ResourceManager.Hci.UpdateResource GetUpdateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateRunResource` moving forward.")]
        public static Azure.ResourceManager.Hci.UpdateRunResource GetUpdateRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateSummaryResource` moving forward.")]
        public static Azure.ResourceManager.Hci.UpdateSummaryResource GetUpdateSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource> GetValidatedSolutionRecipe(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string validatedSolutionRecipeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource>> GetValidatedSolutionRecipeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string validatedSolutionRecipeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource GetValidatedSolutionRecipeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.ValidatedSolutionRecipeCollection GetValidatedSolutionRecipes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult> Validate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult>> ValidateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterOfferCollection` moving forward.")]
    public partial class OfferCollection : Azure.ResourceManager.Hci.HciClusterOfferCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.OfferResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.OfferResource>, System.Collections.IEnumerable
    {
        protected OfferCollection() { }
        public virtual new Azure.Response<Azure.ResourceManager.Hci.OfferResource> Get(string offerName, string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.Pageable<Azure.ResourceManager.Hci.OfferResource> GetAll(string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.AsyncPageable<Azure.ResourceManager.Hci.OfferResource> GetAllAsync(string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OfferResource>> GetAsync(string offerName, string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.NullableResponse<Azure.ResourceManager.Hci.OfferResource> GetIfExists(string offerName, string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.OfferResource>> GetIfExistsAsync(string offerName, string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.OfferResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.OfferResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.OfferResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.OfferResource>.GetEnumerator() { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterOfferData` moving forward.")]
    public partial class OfferData : Azure.ResourceManager.Hci.HciClusterOfferData
    {
        public OfferData() { }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterOfferResource` moving forward.")]
    public partial class OfferResource : Azure.ResourceManager.Hci.HciClusterOfferResource
    {
        public static readonly new Azure.Core.ResourceType ResourceType;
        protected OfferResource() { }
        public virtual new Azure.ResourceManager.Hci.OfferData Data { get { throw null; } }
        public virtual new Azure.Response<Azure.ResourceManager.Hci.OfferResource> Get(string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OfferResource>> GetAsync(string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class OsImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.OsImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.OsImageResource>, System.Collections.IEnumerable
    {
        protected OsImageCollection() { }
        public virtual Azure.Response<bool> Exists(string osImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string osImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OsImageResource> Get(string osImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.OsImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.OsImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OsImageResource>> GetAsync(string osImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.OsImageResource> GetIfExists(string osImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.OsImageResource>> GetIfExistsAsync(string osImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.OsImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.OsImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.OsImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.OsImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OsImageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OsImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OsImageData>
    {
        internal OsImageData() { }
        public Azure.ResourceManager.Hci.Models.OsImageProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.OsImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OsImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OsImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.OsImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OsImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OsImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OsImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OsImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OsImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OsImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OsImageResource() { }
        public virtual Azure.ResourceManager.Hci.OsImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string osImageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OsImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OsImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.OsImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OsImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OsImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.OsImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OsImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OsImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OsImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlatformUpdateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.PlatformUpdateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.PlatformUpdateResource>, System.Collections.IEnumerable
    {
        protected PlatformUpdateCollection() { }
        public virtual Azure.Response<bool> Exists(string platformUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string platformUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.PlatformUpdateResource> Get(string platformUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.PlatformUpdateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.PlatformUpdateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PlatformUpdateResource>> GetAsync(string platformUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.PlatformUpdateResource> GetIfExists(string platformUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.PlatformUpdateResource>> GetIfExistsAsync(string platformUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.PlatformUpdateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.PlatformUpdateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.PlatformUpdateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.PlatformUpdateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlatformUpdateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PlatformUpdateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PlatformUpdateData>
    {
        internal PlatformUpdateData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.PlatformUpdateDetails> PlatformUpdateDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.PlatformUpdateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PlatformUpdateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PlatformUpdateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.PlatformUpdateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PlatformUpdateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PlatformUpdateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PlatformUpdateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlatformUpdateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PlatformUpdateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PlatformUpdateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlatformUpdateResource() { }
        public virtual Azure.ResourceManager.Hci.PlatformUpdateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string platformUpdateName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.PlatformUpdateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PlatformUpdateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.PlatformUpdateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PlatformUpdateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PlatformUpdateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.PlatformUpdateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PlatformUpdateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PlatformUpdateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PlatformUpdateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterPublisherCollection` moving forward.")]
    public partial class PublisherCollection : Azure.ResourceManager.Hci.HciClusterPublisherCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.PublisherResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.PublisherResource>, System.Collections.IEnumerable
    {
        protected PublisherCollection() { }
        public virtual new Azure.Response<Azure.ResourceManager.Hci.PublisherResource> Get(string publisherName, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.Pageable<Azure.ResourceManager.Hci.PublisherResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.AsyncPageable<Azure.ResourceManager.Hci.PublisherResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PublisherResource>> GetAsync(string publisherName, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.NullableResponse<Azure.ResourceManager.Hci.PublisherResource> GetIfExists(string publisherName, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.PublisherResource>> GetIfExistsAsync(string publisherName, System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.PublisherResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.PublisherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.PublisherResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.PublisherResource>.GetEnumerator() { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterPublisherData` moving forward.")]
    public partial class PublisherData : Azure.ResourceManager.Hci.HciClusterPublisherData
    {
        public PublisherData() { }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterPublisherResource` moving forward.")]
    public partial class PublisherResource : Azure.ResourceManager.Hci.HciClusterPublisherResource
    {
        public static readonly new Azure.Core.ResourceType ResourceType;
        protected PublisherResource() { }
        public virtual new Azure.ResourceManager.Hci.PublisherData Data { get { throw null; } }
        public virtual new Azure.Response<Azure.ResourceManager.Hci.PublisherResource> Get(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PublisherResource>> GetAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OfferResource> GetOffer(string offerName, string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OfferResource>> GetOfferAsync(string offerName, string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.Hci.OfferCollection GetOffers() { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateCollection` moving forward.")]
    public partial class UpdateCollection : Azure.ResourceManager.Hci.HciClusterUpdateCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateResource>, System.Collections.IEnumerable
    {
        protected UpdateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateName, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateName, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.Hci.UpdateResource> Get(string updateName, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.Pageable<Azure.ResourceManager.Hci.UpdateResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.AsyncPageable<Azure.ResourceManager.Hci.UpdateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateResource>> GetAsync(string updateName, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateResource> GetIfExists(string updateName, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateResource>> GetIfExistsAsync(string updateName, System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.UpdateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.UpdateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateResource>.GetEnumerator() { throw null; }
    }
    public partial class UpdateContentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateContentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateContentResource>, System.Collections.IEnumerable
    {
        protected UpdateContentCollection() { }
        public virtual Azure.Response<bool> Exists(string updateContentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateContentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateContentResource> Get(string updateContentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.UpdateContentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.UpdateContentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateContentResource>> GetAsync(string updateContentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateContentResource> GetIfExists(string updateContentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateContentResource>> GetIfExistsAsync(string updateContentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.UpdateContentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateContentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.UpdateContentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateContentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UpdateContentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateContentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateContentData>
    {
        internal UpdateContentData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.ContentPayload> UpdatePayloads { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.UpdateContentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateContentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateContentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.UpdateContentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateContentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateContentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateContentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateContentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateContentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateContentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateContentResource() { }
        public virtual Azure.ResourceManager.Hci.UpdateContentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string updateContentName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateContentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateContentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.UpdateContentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateContentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateContentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.UpdateContentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateContentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateContentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateContentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateData` moving forward.")]
    public partial class UpdateData : Azure.ResourceManager.Hci.HciClusterUpdateData
    {
        public UpdateData() { }
        [System.ObsoleteAttribute("This property is obsolete. Use base.Prerequisites with type IList<HciClusterUpdatePrerequisite> instead.")]
        public new System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.UpdatePrerequisite> Prerequisites { get { throw null; } }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateResource` moving forward.")]
    public partial class UpdateResource : Azure.ResourceManager.Hci.HciClusterUpdateResource
    {
        public static readonly new Azure.Core.ResourceType ResourceType;
        protected UpdateResource() { }
        public virtual new Azure.ResourceManager.Hci.UpdateData Data { get { throw null; } }
        public virtual new Azure.Response<Azure.ResourceManager.Hci.UpdateResource> Get(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateResource>> GetAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource> GetUpdateRun(string updateRunName, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource>> GetUpdateRunAsync(string updateRunName, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateRunCollection GetUpdateRuns() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateRunCollection` moving forward.")]
    public partial class UpdateRunCollection : Azure.ResourceManager.Hci.HciClusterUpdateRunCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>, System.Collections.IEnumerable
    {
        protected UpdateRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource> Get(string updateRunName, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.Pageable<Azure.ResourceManager.Hci.UpdateRunResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.AsyncPageable<Azure.ResourceManager.Hci.UpdateRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource>> GetAsync(string updateRunName, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateRunResource> GetIfExists(string updateRunName, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.UpdateRunResource>> GetIfExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.UpdateRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.UpdateRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>.GetEnumerator() { throw null; }
    }
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
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateRunResource` moving forward.")]
    public partial class UpdateRunResource : Azure.ResourceManager.Hci.HciClusterUpdateRunResource
    {
        public static readonly new Azure.Core.ResourceType ResourceType;
        protected UpdateRunResource() { }
        public virtual new Azure.ResourceManager.Hci.UpdateRunData Data { get { throw null; } }
        public virtual new Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource> Get(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateSummaryData` moving forward.")]
    public partial class UpdateSummaryData : Azure.ResourceManager.Hci.HciClusterUpdateSummaryData
    {
        public UpdateSummaryData() { }
        public System.DateTimeOffset? LastChecked { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is obsolete. Use base.State with type HciClusterUpdateState? instead.")]
        public new Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState? State { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdateSummaryResource` moving forward.")]
    public partial class UpdateSummaryResource : Azure.ResourceManager.Hci.HciClusterUpdateSummaryResource
    {
        public static readonly new Azure.Core.ResourceType ResourceType;
        protected UpdateSummaryResource() { }
        public virtual new Azure.ResourceManager.Hci.UpdateSummaryData Data { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateSummaryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateSummaryData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateSummaryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateSummaryData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.Hci.UpdateSummaryResource> Get(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class ValidatedSolutionRecipeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource>, System.Collections.IEnumerable
    {
        protected ValidatedSolutionRecipeCollection() { }
        public virtual Azure.Response<bool> Exists(string validatedSolutionRecipeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string validatedSolutionRecipeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource> Get(string validatedSolutionRecipeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource>> GetAsync(string validatedSolutionRecipeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource> GetIfExists(string validatedSolutionRecipeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource>> GetIfExistsAsync(string validatedSolutionRecipeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ValidatedSolutionRecipeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>
    {
        internal ValidatedSolutionRecipeData() { }
        public Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.ValidatedSolutionRecipeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ValidatedSolutionRecipeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidatedSolutionRecipeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ValidatedSolutionRecipeResource() { }
        public virtual Azure.ResourceManager.Hci.ValidatedSolutionRecipeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string validatedSolutionRecipeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.ValidatedSolutionRecipeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ValidatedSolutionRecipeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ValidatedSolutionRecipeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Mocking
{
    public partial class MockableHciArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHciArmClient() { }
        public virtual Azure.ResourceManager.Hci.ArcExtensionResource GetArcExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.ArcSettingResource GetArcSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.ClusterJobResource GetClusterJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.DevicePoolResource GetDevicePoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource> GetEdgeDeviceJob(Azure.Core.ResourceIdentifier scope, string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource>> GetEdgeDeviceJobAsync(Azure.Core.ResourceIdentifier scope, string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeDeviceJobResource GetEdgeDeviceJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeDeviceJobCollection GetEdgeDeviceJobs(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeMachineJobResource GetEdgeMachineJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeMachineResource GetEdgeMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterOfferResource` moving forward.")]
        public virtual Azure.ResourceManager.Hci.OfferResource GetOfferResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.OsImageResource GetOsImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.PlatformUpdateResource GetPlatformUpdateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterPublisherResource` moving forward.")]
        public virtual Azure.ResourceManager.Hci.PublisherResource GetPublisherResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateContentResource GetUpdateContentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateResource` moving forward.")]
        public virtual Azure.ResourceManager.Hci.UpdateResource GetUpdateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateRunResource` moving forward.")]
        public virtual Azure.ResourceManager.Hci.UpdateRunResource GetUpdateRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `GetHciClusterUpdateSummaryResource` moving forward.")]
        public virtual Azure.ResourceManager.Hci.UpdateSummaryResource GetUpdateSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource GetValidatedSolutionRecipeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHciResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource> GetDevicePool(string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource>> GetDevicePoolAsync(string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.DevicePoolCollection GetDevicePools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource> GetEdgeMachine(string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource>> GetEdgeMachineAsync(string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeMachineCollection GetEdgeMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> GetHciCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetHciClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciClusterCollection GetHciClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult> Validate(Azure.Core.AzureLocation location, Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult>> ValidateAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableHciSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Models.HciKubernetesVersion> GetBySubscriptionLocationResource(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Models.HciKubernetesVersion> GetBySubscriptionLocationResourceAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.DevicePoolResource> GetDevicePools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.DevicePoolResource> GetDevicePoolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.EdgeMachineResource> GetEdgeMachines(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.EdgeMachineResource> GetEdgeMachinesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OsImageResource> GetOsImage(Azure.Core.AzureLocation location, string osImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OsImageResource>> GetOsImageAsync(Azure.Core.AzureLocation location, string osImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.OsImageCollection GetOsImages(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.PlatformUpdateResource> GetPlatformUpdate(Azure.Core.AzureLocation location, string platformUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PlatformUpdateResource>> GetPlatformUpdateAsync(Azure.Core.AzureLocation location, string platformUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.PlatformUpdateCollection GetPlatformUpdates(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateContentResource> GetUpdateContent(Azure.Core.AzureLocation location, string updateContentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateContentResource>> GetUpdateContentAsync(Azure.Core.AzureLocation location, string updateContentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateContentCollection GetUpdateContents(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource> GetValidatedSolutionRecipe(Azure.Core.AzureLocation location, string validatedSolutionRecipeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource>> GetValidatedSolutionRecipeAsync(Azure.Core.AzureLocation location, string validatedSolutionRecipeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ValidatedSolutionRecipeCollection GetValidatedSolutionRecipes(Azure.Core.AzureLocation location) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Models
{
    public partial class ArcDefaultExtensionDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails>
    {
        internal ArcDefaultExtensionDetails() { }
        public string Category { get { throw null; } }
        public System.DateTimeOffset? ConsentOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState left, Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy left, Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy left, Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcExtensionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionPatch>
    {
        public ArcExtensionPatch() { }
        public Azure.ResourceManager.Hci.Models.ArcExtensionPatchContent ExtensionParameters { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.ArcExtensionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ArcExtensionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.ArcExtensionPatchContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ArcExtensionPatchContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcExtensionState left, Azure.ResourceManager.Hci.Models.ArcExtensionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcExtensionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcExtensionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ArcExtensionState left, Azure.ResourceManager.Hci.Models.ArcExtensionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcExtensionUpgradeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent>
    {
        public ArcExtensionUpgradeContent() { }
        public string TargetVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.ArcIdentityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ArcIdentityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.ArcPasswordCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ArcPasswordCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState left, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcSettingAggregateState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState left, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcSettingPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcSettingPatch>
    {
        public ArcSettingPatch() { }
        public System.BinaryData ConnectivityProperties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ArcSettingPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ArcSettingPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.Hci.ArcExtensionData ArcExtensionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState? aggregateState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeExtensionState> perNodeExtensionDetails, string forceUpdateTag, string publisher, string arcExtensionType, string typeHandlerVersion, bool? shouldAutoUpgradeMinorVersion, System.BinaryData settings, System.BinaryData protectedSettings, bool? enableAutomaticUpgrade) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView ArcExtensionInstanceView(string name = null, string extensionInstanceViewType = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus ArcExtensionInstanceViewStatus(string code = null, Azure.ResourceManager.Hci.Models.HciStatusLevelType? level = default(Azure.ResourceManager.Hci.Models.HciStatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcIdentityResult ArcIdentityResult(System.Guid? arcApplicationClientId = default(System.Guid?), System.Guid? arcApplicationTenantId = default(System.Guid?), System.Guid? arcServicePrincipalObjectId = default(System.Guid?), System.Guid? arcApplicationObjectId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcPasswordCredential ArcPasswordCredential(string secretText = null, string keyId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.ArcSettingData ArcSettingData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, string arcInstanceResourceGroup, System.Guid? arcApplicationClientId, System.Guid? arcApplicationTenantId, System.Guid? arcServicePrincipalObjectId, System.Guid? arcApplicationObjectId, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? aggregateState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeArcState> perNodeDetails, System.BinaryData connectivityProperties) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new overload with ArcConnectivityProperties moving forward.")]
        public static Azure.ResourceManager.Hci.ArcSettingData ArcSettingData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, string arcInstanceResourceGroup, System.Guid? arcApplicationClientId, System.Guid? arcApplicationTenantId, System.Guid? arcServicePrincipalObjectId, System.Guid? arcApplicationObjectId, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? aggregateState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeArcState> perNodeDetails, System.BinaryData connectivityProperties, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ArcDefaultExtensionDetails> defaultExtensions = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcSettingPatch ArcSettingPatch(System.Collections.Generic.IDictionary<string, string> tags = null, System.BinaryData connectivityProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.AssemblyInfoPayload AssemblyInfoPayload(string identifier = null, string hash = null, string fileName = null, string uri = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClaimDeviceContent ClaimDeviceContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> devices = null, string claimedBy = null) { throw null; }
        public static Azure.ResourceManager.Hci.ClusterJobData ClusterJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.ClusterJobProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClusterJobProperties ClusterJobProperties(string jobType = null, Azure.ResourceManager.Hci.Models.EceDeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.EceDeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciJobStatus? status = default(Azure.ResourceManager.Hci.Models.HciJobStatus?), Azure.ResourceManager.Hci.Models.JobReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClusterSdnProperties ClusterSdnProperties(Azure.ResourceManager.Hci.Models.SdnStatus? sdnStatus = default(Azure.ResourceManager.Hci.Models.SdnStatus?), string sdnDomainName = null, string sdnApiAddress = null, Azure.ResourceManager.Hci.Models.SdnIntegrationIntent? sdnIntegrationIntent = default(Azure.ResourceManager.Hci.Models.SdnIntegrationIntent?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ConfidentialVmProfile ConfidentialVmProfile(Azure.ResourceManager.Hci.Models.IgvmStatus? igvmStatus = default(Azure.ResourceManager.Hci.Models.IgvmStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.IgvmStatusDetail> statusDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ConfidentialVmProperties ConfidentialVmProperties(Azure.ResourceManager.Hci.Models.ConfidentialVmIntent? confidentialVmIntent = default(Azure.ResourceManager.Hci.Models.ConfidentialVmIntent?), Azure.ResourceManager.Hci.Models.ConfidentialVmStatus? confidentialVmStatus = default(Azure.ResourceManager.Hci.Models.ConfidentialVmStatus?), string confidentialVmStatusSummary = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ContentPayload ContentPayload(string uri = null, string hash = null, string hashAlgorithm = null, string identifier = null, string packageSizeInBytes = null, string group = null, string fileName = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork DeploymentSettingHostNetwork(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentSettingIntents> intents = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks> storageNetworks = null, Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig sanNetworksClusterNetworkConfig = null, bool? storageConnectivitySwitchless = default(bool?), bool? enableStorageAutoIP = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork DeploymentSettingInfrastructureNetwork(string subnetMask = null, string gateway = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools> ipPools = null, Azure.ResourceManager.Hci.Models.DnsServerConfig? dnsServerConfig = default(Azure.ResourceManager.Hci.Models.DnsServerConfig?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciDnsZones> dnsZones = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, bool? useDhcp = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeploymentSettingIntents DeploymentSettingIntents(string name = null, System.Collections.Generic.IEnumerable<string> trafficType = null, System.Collections.Generic.IEnumerable<string> adapter = null, bool? overrideVirtualSwitchConfiguration = default(bool?), Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides virtualSwitchConfigurationOverrides = null, bool? overrideQosPolicy = default(bool?), Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides qosPolicyOverrides = null, bool? overrideAdapterProperty = default(bool?), Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides adapterPropertyOverrides = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks DeploymentSettingStorageNetworks(string name = null, string networkAdapterName = null, string vlanId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo> storageAdapterIPInfo = null) { throw null; }
        public static Azure.ResourceManager.Hci.DevicePoolData DevicePoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.DevicePoolProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DevicePoolPatch DevicePoolPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DevicePoolProperties DevicePoolProperties(Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string cloudId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciDeviceDetail> devices = null, Azure.Core.ResourceIdentifier customLocationResourceId = null, string customLocationName = null, string managedResourceGroup = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciOperationDetail> operationDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DownloadOsJobProperties DownloadOsJobProperties(Azure.ResourceManager.Hci.Models.EceDeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.EceDeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciJobStatus? status = default(Azure.ResourceManager.Hci.Models.HciJobStatus?), Azure.ResponseError error = null, Azure.ResourceManager.Hci.Models.DownloadContent downloadRequest = null, Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EceActionStatus EceActionStatus(string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep> steps = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EceReportedProperties EceReportedProperties(Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeDeviceDisks EdgeDeviceDisks(string id = null, string sizeInBytes = null, string type = null) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeDeviceJobData EdgeDeviceJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobProperties EdgeMachineCollectLogJobProperties(Azure.ResourceManager.Hci.Models.EceDeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.EceDeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciJobStatus? status = default(Azure.ResourceManager.Hci.Models.HciJobStatus?), Azure.ResponseError error = null, System.DateTimeOffset collectionStartOn = default(System.DateTimeOffset), System.DateTimeOffset collectionEndOn = default(System.DateTimeOffset), System.DateTimeOffset? lastLogGeneratedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties EdgeMachineCollectLogJobReportedProperties(int? percentComplete = default(int?), Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.LogCollectionJobSession> logCollectionSessionDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeMachineData EdgeMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.EdgeMachineProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeMachineJobData EdgeMachineJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties EdgeMachineJobProperties(string jobType = null, Azure.ResourceManager.Hci.Models.EceDeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.EceDeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciJobStatus? status = default(Azure.ResourceManager.Hci.Models.HciJobStatus?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile EdgeMachineNetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail> nicDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail> switchDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail EdgeMachineNicDetail(string adapterName = null, string interfaceDescription = null, string componentId = null, string driverVersion = null, string ip4Address = null, string subnetMask = null, string defaultGateway = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, string defaultIsolationId = null, string macAddress = null, string slot = null, string switchName = null, string nicType = null, string vlanId = null, string nicStatus = null, Azure.ResourceManager.Hci.Models.RdmaCapability? rdmaCapability = default(Azure.ResourceManager.Hci.Models.RdmaCapability?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachinePatch EdgeMachinePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineProperties EdgeMachineProperties(Azure.ResourceManager.Hci.Models.EdgeMachineKind? edgeMachineKind = default(Azure.ResourceManager.Hci.Models.EdgeMachineKind?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string cloudId = null, Azure.Core.ResourceIdentifier arcMachineResourceGroupId = null, Azure.Core.ResourceIdentifier arcMachineResourceId = null, Azure.Core.ResourceIdentifier arcGatewayResourceId = null, Azure.ResourceManager.Hci.Models.HciSiteDetails siteDetails = null, Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails ownershipVoucherDetails = null, Azure.ResourceManager.Hci.Models.HciProvisioningDetails provisioningDetails = null, string devicePoolResourceId = null, Azure.ResourceManager.Hci.Models.EdgeMachineState? machineState = default(Azure.ResourceManager.Hci.Models.EdgeMachineState?), Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus? connectivityStatus = default(Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus?), string claimedBy = null, Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties reportedProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciOperationDetail> operationDetails = null, System.DateTimeOffset? lastSyncedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobProperties EdgeMachineRemoteSupportJobProperties(Azure.ResourceManager.Hci.Models.EceDeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.EceDeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciJobStatus? status = default(Azure.ResourceManager.Hci.Models.HciJobStatus?), Azure.ResponseError error = null, Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel accessLevel = default(Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel), System.DateTimeOffset expireOn = default(System.DateTimeOffset), Azure.ResourceManager.Hci.Models.RemoteSupportType type = default(Azure.ResourceManager.Hci.Models.RemoteSupportType), Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties EdgeMachineRemoteSupportJobReportedProperties(int? percentComplete = default(int?), Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null, Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings nodeSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.RemoteSupportSession> sessionDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings EdgeMachineRemoteSupportNodeSettings(string state = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string connectionStatus = null, string connectionErrorMessage = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties EdgeMachineReportedProperties(System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile networkProfile = null, Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile osProfile = null, Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile hardwareProfile = null, long? storagePoolableDisksCount = default(long?), Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo sbeDeploymentPackageInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> extensions = null) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `ArcExtensionInstanceViewStatus` moving forward.")]
        public static Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus ExtensionInstanceViewStatus(string code = null, Azure.ResourceManager.Hci.Models.HciStatusLevelType? level = default(Azure.ResourceManager.Hci.Models.HciStatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDevice HciArcEnabledEdgeDevice(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties HciArcEnabledEdgeDeviceProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration deviceConfiguration = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), Azure.ResourceManager.Hci.Models.HciReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciAssemblyInfo HciAssemblyInfo(string packageVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.AssemblyInfoPayload> payload = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterData HciClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, Azure.ResourceManager.Hci.Models.HciClusterStatus? status, Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus? connectivityStatus, System.Guid? cloudId, string cloudManagementEndpoint, System.Guid? aadClientId, System.Guid? aadTenantId, System.Guid? aadApplicationObjectId, System.Guid? aadServicePrincipalObjectId, Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties softwareAssuranceProperties, Azure.ResourceManager.Hci.Models.LogCollectionProperties logCollectionProperties, Azure.ResourceManager.Hci.Models.RemoteSupportProperties remoteSupportProperties, Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties desiredProperties, Azure.ResourceManager.Hci.Models.HciClusterReportedProperties reportedProperties, Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration isolatedVmAttestationConfiguration, float? trialDaysRemaining, string billingModel, System.DateTimeOffset? registrationTimestamp, System.DateTimeOffset? lastSyncTimestamp, System.DateTimeOffset? lastBillingTimestamp, string serviceEndpoint, string resourceProviderObjectId, System.Guid? principalId, System.Guid? tenantId, Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? typeIdentityType, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterData HciClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?), Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus? connectivityStatus = default(Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus?), System.Guid? cloudId = default(System.Guid?), string ring = null, string cloudManagementEndpoint = null, System.Guid? aadClientId = default(System.Guid?), System.Guid? aadTenantId = default(System.Guid?), System.Guid? aadApplicationObjectId = default(System.Guid?), System.Guid? aadServicePrincipalObjectId = default(System.Guid?), Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties softwareAssuranceProperties = null, bool? isManagementCluster = default(bool?), Azure.ResourceManager.Hci.Models.LogCollectionProperties logCollectionProperties = null, Azure.ResourceManager.Hci.Models.RemoteSupportProperties remoteSupportProperties = null, Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties desiredProperties = null, Azure.ResourceManager.Hci.Models.HciClusterReportedProperties reportedProperties = null, Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration isolatedVmAttestationConfiguration = null, float? trialDaysRemaining = default(float?), string billingModel = null, System.DateTimeOffset? registrationTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastSyncTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastBillingTimestamp = default(System.DateTimeOffset?), string serviceEndpoint = null, string resourceProviderObjectId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.SecretsLocationDetails> secretsLocations = null, Azure.ResourceManager.Hci.Models.ClusterPattern? clusterPattern = default(Azure.ResourceManager.Hci.Models.ClusterPattern?), Azure.ResourceManager.Hci.Models.ConfidentialVmProperties confidentialVmProperties = null, Azure.ResourceManager.Hci.Models.ClusterSdnProperties sdnProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones> localAvailabilityZones = null, Azure.ResourceManager.Hci.Models.HciIdentityProvider? identityProvider = default(Azure.ResourceManager.Hci.Models.HciIdentityProvider?), Azure.ResourceManager.Hci.Models.HciStorageType? storageType = default(Azure.ResourceManager.Hci.Models.HciStorageType?), Azure.ResourceManager.Hci.Models.NextBillingModel nextBillingModel = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterData HciClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, Azure.ResourceManager.Hci.Models.HciClusterStatus? status, System.Guid? cloudId, string cloudManagementEndpoint, System.Guid? aadClientId, System.Guid? aadTenantId, System.Guid? aadApplicationObjectId, System.Guid? aadServicePrincipalObjectId, Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties softwareAssuranceProperties, Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties desiredProperties, Azure.ResourceManager.Hci.Models.HciClusterReportedProperties reportedProperties, float? trialDaysRemaining, string billingModel, System.DateTimeOffset? registrationTimestamp, System.DateTimeOffset? lastSyncTimestamp, System.DateTimeOffset? lastBillingTimestamp, string serviceEndpoint, string resourceProviderObjectId, System.Guid? principalId, System.Guid? tenantId, Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? typeIdentityType, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration HciClusterDeploymentConfiguration(string version = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits> scaleUnits = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo HciClusterDeploymentInfo(Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings securitySettings = null, Azure.ResourceManager.Hci.Models.DeploymentSettingObservability observability = null, Azure.ResourceManager.Hci.Models.HciDeploymentCluster cluster = null, Azure.ResourceManager.Hci.Models.HciIdentityProvider? identityProvider = default(Azure.ResourceManager.Hci.Models.HciIdentityProvider?), Azure.ResourceManager.Hci.Models.DeploymentSettingStorage storage = null, string namingPrefix = null, string domainFqdn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork> infrastructureNetwork = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes> physicalNodes = null, Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork hostNetwork = null, Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController sdnIntegrationNetworkController = null, bool? isManagementCluster = default(bool?), string adouPath = null, string secretsLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets> secrets = null, string optionalServicesCustomLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones> localAvailabilityZones = null, Azure.ResourceManager.Hci.Models.HciAssemblyInfo assemblyInfo = null) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new overload with IEnumerable<string> arcNodeResourceIds moving forward.")]
        public static Azure.ResourceManager.Hci.HciClusterDeploymentSettingData HciClusterDeploymentSettingData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> arcNodeResourceIds, Azure.ResourceManager.Hci.Models.EceDeploymentMode? deploymentMode, Azure.ResourceManager.Hci.Models.HciClusterOperationType? operationType, Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration deploymentConfiguration, Azure.ResourceManager.Hci.Models.EceReportedProperties reportedProperties) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep HciClusterDeploymentStep(string name = null, string description = null, string fullStepIndex = null, string startOn = null, string endOn = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep> steps = null, System.Collections.Generic.IEnumerable<string> exception = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterIdentityResult HciClusterIdentityResult(System.Guid? aadClientId = default(System.Guid?), System.Guid? aadTenantId = default(System.Guid?), System.Guid? aadServicePrincipalObjectId = default(System.Guid?), System.Guid? aadApplicationObjectId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterNode HciClusterNode(string name, float? id, Azure.ResourceManager.Hci.Models.WindowsServerSubscription? windowsServerSubscription, Azure.ResourceManager.Hci.Models.ClusterNodeType? nodeType, string ehcResourceId, string manufacturer, string model, string osName, string osVersion, string osDisplayVersion, string serialNumber, float? coreCount, float? memoryInGiB, System.DateTimeOffset? lastLicensingTimestamp) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterNode HciClusterNode(string name = null, float? id = default(float?), Azure.ResourceManager.Hci.Models.WindowsServerSubscription? windowsServerSubscription = default(Azure.ResourceManager.Hci.Models.WindowsServerSubscription?), Azure.ResourceManager.Hci.Models.ClusterNodeType? nodeType = default(Azure.ResourceManager.Hci.Models.ClusterNodeType?), string ehcResourceId = null, string manufacturer = null, string model = null, string osName = null, string osVersion = null, string osDisplayVersion = null, string serialNumber = null, float? coreCount = default(float?), float? memoryInGiB = default(float?), System.DateTimeOffset? lastLicensingTimestamp = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.OemActivation? oemActivation = default(Azure.ResourceManager.Hci.Models.OemActivation?)) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterOfferData HciClusterOfferData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string publisherId = null, string content = null, string contentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciSkuMappings> skuMappings = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterPatch HciClusterPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string cloudManagementEndpoint = null, System.Guid? aadClientId = default(System.Guid?), System.Guid? aadTenantId = default(System.Guid?), Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties desiredProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterPatch HciClusterPatch(System.Collections.Generic.IDictionary<string, string> tags, string cloudManagementEndpoint, System.Guid? aadClientId, System.Guid? aadTenantId, Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties desiredProperties, System.Guid? principalId, System.Guid? tenantId, Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? managedServiceIdentityType, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterPublisherData HciClusterPublisherData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterReportedProperties HciClusterReportedProperties(string clusterName, System.Guid? clusterId, string clusterVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciClusterNode> nodes, System.DateTimeOffset? lastUpdatedOn, Azure.ResourceManager.Hci.Models.ImdsAttestationState? imdsAttestation, Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? diagnosticLevel, System.Collections.Generic.IEnumerable<string> supportedCapabilities) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterReportedProperties HciClusterReportedProperties(string clusterName, System.Guid? clusterId, string clusterVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciClusterNode> nodes, System.DateTimeOffset? lastUpdatedOn, Azure.ResourceManager.Hci.Models.ImdsAttestationState? imdsAttestation, Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? diagnosticLevel, System.Collections.Generic.IEnumerable<string> supportedCapabilities, Azure.ResourceManager.Hci.Models.ClusterNodeType? clusterType, string manufacturer, Azure.ResourceManager.Hci.Models.OemActivation? oemActivation) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterReportedProperties HciClusterReportedProperties(string clusterName = null, System.Guid? clusterId = default(System.Guid?), string clusterVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciClusterNode> nodes = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? msiExpirationTimeStamp = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.ImdsAttestationState? imdsAttestation = default(Azure.ResourceManager.Hci.Models.ImdsAttestationState?), Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? diagnosticLevel = default(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel?), System.Collections.Generic.IEnumerable<string> supportedCapabilities = null, Azure.ResourceManager.Hci.Models.ClusterNodeType? clusterType = default(Azure.ResourceManager.Hci.Models.ClusterNodeType?), string manufacturer = null, Azure.ResourceManager.Hci.Models.OemActivation? oemActivation = default(Azure.ResourceManager.Hci.Models.OemActivation?), Azure.ResourceManager.Hci.Models.HardwareClass? hardwareClass = default(Azure.ResourceManager.Hci.Models.HardwareClass?)) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterSecuritySettingData HciClusterSecuritySettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType? securedCoreComplianceAssignment = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType?), Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType? wdacComplianceAssignment = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType?), Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType? smbEncryptionForIntraClusterTrafficComplianceAssignment = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType?), Azure.ResourceManager.Hci.Models.SecurityComplianceStatus securityComplianceStatus = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterUpdateData HciClusterUpdateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.DateTimeOffset? installedOn = default(System.DateTimeOffset?), string description = null, string minSbeVersionRequired = null, Azure.ResourceManager.Hci.Models.HciUpdateState? state = default(Azure.ResourceManager.Hci.Models.HciUpdateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite> prerequisites = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> componentVersions = null, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement? rebootRequired = default(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement?), Azure.ResourceManager.Hci.Models.HciHealthState? healthState = default(Azure.ResourceManager.Hci.Models.HciHealthState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult = null, System.DateTimeOffset? healthCheckOn = default(System.DateTimeOffset?), string packagePath = null, float? packageSizeInMb = default(float?), string displayName = null, string version = null, string publisher = null, string releaseLink = null, Azure.ResourceManager.Hci.Models.HciAvailabilityType? availabilityType = default(Azure.ResourceManager.Hci.Models.HciAvailabilityType?), string packageType = null, string additionalProperties = null, float? progressPercentage = default(float?), string notifyMessage = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterUpdateRunData HciClusterUpdateRunData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.AzureLocation? location, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, System.DateTimeOffset? timeStarted, System.DateTimeOffset? lastUpdatedOn, string duration, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? state, string namePropertiesProgressName, string description, string errorMessage, string status, System.DateTimeOffset? startOn, System.DateTimeOffset? endOn, System.DateTimeOffset? lastCompletedOn, string expectedExecutionTime, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUpdateStep> steps) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterUpdateRunData HciClusterUpdateRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.DateTimeOffset? timeStarted = default(System.DateTimeOffset?), System.DateTimeOffset? lastCompletedOn = default(System.DateTimeOffset?), string duration = null, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? state = default(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState?), string name0 = null, string description = null, string errorMessage = null, string status = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), string expectedExecutionTime = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUpdateStep> steps = null, string updateRunName = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterUpdateSummaryData HciClusterUpdateSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string oemFamily = null, string currentOemVersion = null, string hardwareModel = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> packageVersions = null, string currentVersion = null, string currentSbeVersion = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastCheckedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciHealthState? healthState = default(Azure.ResourceManager.Hci.Models.HciHealthState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult = null, System.DateTimeOffset? healthCheckOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciClusterUpdateState? state = default(Azure.ResourceManager.Hci.Models.HciClusterUpdateState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciCollectLogJobProperties HciCollectLogJobProperties(Azure.ResourceManager.Hci.Models.EceDeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.EceDeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciJobStatus? status = default(Azure.ResourceManager.Hci.Models.HciJobStatus?), System.DateTimeOffset collectionStartOn = default(System.DateTimeOffset), System.DateTimeOffset collectionEndOn = default(System.DateTimeOffset), System.DateTimeOffset? lastLogGeneratedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciConfigureCvmJobProperties HciConfigureCvmJobProperties(Azure.ResourceManager.Hci.Models.EceDeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.EceDeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciJobStatus? status = default(Azure.ResourceManager.Hci.Models.HciJobStatus?), Azure.ResourceManager.Hci.Models.JobReportedProperties reportedProperties = null, Azure.ResourceManager.Hci.Models.ConfidentialVmIntent confidentialVmIntent = default(Azure.ResourceManager.Hci.Models.ConfidentialVmIntent)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciConfigureSdnIntegrationJobProperties HciConfigureSdnIntegrationJobProperties(Azure.ResourceManager.Hci.Models.EceDeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.EceDeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciJobStatus? status = default(Azure.ResourceManager.Hci.Models.HciJobStatus?), Azure.ResourceManager.Hci.Models.JobReportedProperties reportedProperties = null, Azure.ResourceManager.Hci.Models.SdnIntegrationIntent sdnIntegrationIntent = default(Azure.ResourceManager.Hci.Models.SdnIntegrationIntent), string sdnPrefix = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciDeploymentCluster HciDeploymentCluster(string name = null, string witnessType = null, string witnessPath = null, string cloudAccountName = null, string azureServiceEndpoint = null, Azure.ResourceManager.Hci.Models.HardwareClass? hardwareClass = default(Azure.ResourceManager.Hci.Models.HardwareClass?), Azure.ResourceManager.Hci.Models.ClusterPattern? clusterPattern = default(Azure.ResourceManager.Hci.Models.ClusterPattern?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile HciDeploymentHardwareProfile(long? cpuCores = default(long?), long? cpuSockets = default(long?), long? memoryCapacityInGb = default(long?), string model = null, string manufacturer = null, string serialNumber = null, string processorType = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile HciDeploymentOSProfile(string bootType = null, string assemblyVersion = null, string osType = null, string osSku = null, string osVersion = null, string buildNumber = null, string baseImageVersion = null, string imageVersion = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciDeviceDetail HciDeviceDetail(Azure.Core.ResourceIdentifier deviceResourceId = null, string claimedBy = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciDnsZones HciDnsZones(string dnsZoneName = null, System.Collections.Generic.IEnumerable<string> dnsForwarder = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides HciEdgeDeviceAdapterPropertyOverrides(string jumboPacket = null, string networkDirect = null, string networkDirectTechnology = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension HciEdgeDeviceArcExtension(string extensionName = null, Azure.ResourceManager.Hci.Models.ArcExtensionState? state = default(Azure.ResourceManager.Hci.Models.ArcExtensionState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail> errorDetails = null, Azure.Core.ResourceIdentifier extensionResourceId = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy? managedBy = default(Azure.ResourceManager.Hci.Models.ArcExtensionManagedBy?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration HciEdgeDeviceConfiguration(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail> nicDetails = null, string deviceMetadata = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciEdgeDeviceData HciEdgeDeviceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork HciEdgeDeviceHostNetwork(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents> intents = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks> storageNetworks = null, bool? storageConnectivitySwitchless = default(bool?), bool? enableStorageAutoIP = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents HciEdgeDeviceIntents(long? scope = default(long?), long? intentType = default(long?), bool? isComputeIntentSet = default(bool?), bool? isStorageIntentSet = default(bool?), bool? isOnlyStorage = default(bool?), bool? isManagementIntentSet = default(bool?), bool? isStretchIntentSet = default(bool?), bool? isOnlyStretch = default(bool?), bool? isNetworkIntentType = default(bool?), string intentName = null, System.Collections.Generic.IEnumerable<string> intentAdapters = null, bool? overrideVirtualSwitchConfiguration = default(bool?), Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides virtualSwitchConfigurationOverrides = null, bool? overrideQosPolicy = default(bool?), Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides qosPolicyOverrides = null, bool? overrideAdapterProperty = default(bool?), Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides adapterPropertyOverrides = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceJob HciEdgeDeviceJob(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties HciEdgeDeviceJobProperties(Azure.ResourceManager.Hci.Models.EceDeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.EceDeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciJobStatus? status = default(Azure.ResourceManager.Hci.Models.HciJobStatus?), string jobType = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail HciEdgeDeviceNicDetail(string adapterName = null, string interfaceDescription = null, string componentId = null, string driverVersion = null, string iPv4Address = null, string subnetMask = null, string defaultGateway = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, string defaultIsolationId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties HciEdgeDeviceProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration deviceConfiguration = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties HciEdgeDeviceReportedProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState? deviceState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> extensions) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties HciEdgeDeviceReportedProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState? deviceState = default(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> extensions = null, System.DateTimeOffset? lastSyncedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.ConfidentialVmProfile confidentialVmProfile = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo HciEdgeDeviceStorageAdapterIPInfo(string physicalNode = null, string iPv4Address = null, string subnetMask = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks HciEdgeDeviceStorageNetworks(string name = null, string networkAdapterName = null, string storageVlanId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo> storageAdapterIPInfo = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail HciEdgeDeviceSwitchDetail(string switchName = null, string switchType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension> extensions = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent HciEdgeDeviceValidateContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> edgeDeviceIds = null, string additionalInfo = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult HciEdgeDeviceValidateResult(string status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides HciEdgeDeviceVirtualSwitchConfigurationOverrides(string enableIov = null, string loadBalancingAlgorithm = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension HciEdgeSwitchExtension(string switchId = null, string extensionName = null, bool? isExtensionEnabled = default(bool?)) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `ArcExtensionInstanceView` moving forward.")]
        public static Azure.ResourceManager.Hci.Models.HciExtensionInstanceView HciExtensionInstanceView(string name, string extensionInstanceViewType, string typeHandlerVersion, Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus status) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciKubernetesVersion HciKubernetesVersion(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kubernetesVersionValue = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNetworkAdapter HciNetworkAdapter(Azure.ResourceManager.Hci.Models.IpAssignmentType ipAssignmentType = default(Azure.ResourceManager.Hci.Models.IpAssignmentType), string ipAddress = null, string adapterName = null, string macAddress = null, Azure.ResourceManager.Hci.Models.HciIPAddressRange ipAddressRange = null, string gateway = null, string subnetMask = null, System.Collections.Generic.IEnumerable<string> dnsAddressArray = null, string vlanId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNetworkProfile HciNetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciNicDetail> nicDetails, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail> switchDetails, Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork hostNetwork) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNetworkProfile HciNetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciNicDetail> nicDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail> switchDetails = null, Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork hostNetwork = null, Azure.ResourceManager.Hci.Models.SdnProperties sdnProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNicDetail HciNicDetail(string adapterName, string interfaceDescription, string componentId, string driverVersion, string ipv4Address, string subnetMask, string defaultGateway, System.Collections.Generic.IEnumerable<string> dnsServers, string defaultIsolationId, string macAddress, string slot, string switchName, string nicType, string vlanId, string nicStatus) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNicDetail HciNicDetail(string adapterName = null, string interfaceDescription = null, string componentId = null, string driverVersion = null, string iPv4Address = null, string subnetMask = null, string defaultGateway = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, string defaultIsolationId = null, string macAddress = null, string slot = null, string switchName = null, string nicType = null, string vlanId = null, string nicStatus = null, Azure.ResourceManager.Hci.Models.RdmaCapability? rdmaCapability = default(Azure.ResourceManager.Hci.Models.RdmaCapability?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciOperationDetail HciOperationDetail(string name = null, string id = null, string type = null, Azure.Core.ResourceIdentifier resourceId = null, string description = null, string status = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciOSProfile HciOSProfile(string bootType = null, string assemblyVersion = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningDetails HciProvisioningDetails(Azure.ResourceManager.Hci.Models.OsProvisionProfile osProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUserDetails> userDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciRemoteSupportJobProperties HciRemoteSupportJobProperties(Azure.ResourceManager.Hci.Models.EceDeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.EceDeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciJobStatus? status = default(Azure.ResourceManager.Hci.Models.HciJobStatus?), Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel accessLevel = default(Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel), System.DateTimeOffset expireOn = default(System.DateTimeOffset), Azure.ResourceManager.Hci.Models.RemoteSupportType type = default(Azure.ResourceManager.Hci.Models.RemoteSupportType), Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciReportedProperties HciReportedProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState? deviceState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> extensions, Azure.ResourceManager.Hci.Models.HciNetworkProfile networkProfile, Azure.ResourceManager.Hci.Models.HciOSProfile osProfile, Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo sbeDeploymentPackageInfo) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciReportedProperties HciReportedProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState? deviceState = default(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> extensions = null, System.DateTimeOffset? lastSyncedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.ConfidentialVmProfile confidentialVmProfile = null, Azure.ResourceManager.Hci.Models.HciNetworkProfile networkProfile = null, Azure.ResourceManager.Hci.Models.HciOSProfile osProfile = null, Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo sbeDeploymentPackageInfo = null, Azure.ResourceManager.Hci.Models.HciStorageProfile storageProfile = null, string hardwareProcessorType = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciSkuData HciSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string publisherId = null, string offerId = null, string content = null, string contentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciSkuMappings> skuMappings = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciSkuMappings HciSkuMappings(string catalogPlanId = null, string marketplaceSkuId = null, System.Collections.Generic.IEnumerable<string> marketplaceSkuVersions = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciStorageProfile HciStorageProfile(long? poolableDisksCount = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.EdgeDeviceDisks> disks = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciUpdateStep HciUpdateStep(string name = null, string description = null, string errorMessage = null, string status = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), string expectedExecutionTime = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUpdateStep> steps = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciUserDetails HciUserDetails(string userName = null, Azure.ResourceManager.Hci.Models.HciSecretType secretType = default(Azure.ResourceManager.Hci.Models.HciSecretType), string secretLocation = null, System.Collections.Generic.IEnumerable<string> sshPubKey = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciValidationFailureDetail HciValidationFailureDetail(string exception = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciWebProxyConfiguration HciWebProxyConfiguration(System.Uri connectionUri = null, string port = null, System.Collections.Generic.IEnumerable<System.Uri> bypassList = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.IgvmStatusDetail IgvmStatusDetail(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration IsolatedVmAttestationConfiguration(Azure.Core.ResourceIdentifier attestationResourceId = null, string relyingPartyServiceEndpoint = null, string attestationServiceEndpoint = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.JobReportedProperties JobReportedProperties(int? percentComplete = default(int?), Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LocalAvailabilityZones LocalAvailabilityZones(string localAvailabilityZoneName = null, System.Collections.Generic.IEnumerable<string> nodes = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionContentProperties LogCollectionContentProperties(System.DateTimeOffset fromDate = default(System.DateTimeOffset), System.DateTimeOffset toDate = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionError LogCollectionError(string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionJobSession LogCollectionJobSession(string startTime = null, string endTime = null, string timeCollected = null, int? logSize = default(int?), Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus? status = default(Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus?), string correlationId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionProperties LogCollectionProperties(System.DateTimeOffset? fromDate = default(System.DateTimeOffset?), System.DateTimeOffset? toDate = default(System.DateTimeOffset?), System.DateTimeOffset? lastLogGenerated = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.LogCollectionSession> logCollectionSessionDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties LogCollectionReportedProperties(int? percentComplete = default(int?), Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.LogCollectionJobSession> logCollectionSessionDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionSession LogCollectionSession(System.DateTimeOffset? logStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? logEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? timeCollected = default(System.DateTimeOffset?), long? logSize = default(long?), Azure.ResourceManager.Hci.Models.LogCollectionStatus? logCollectionStatus = default(Azure.ResourceManager.Hci.Models.LogCollectionStatus?), Azure.ResourceManager.Hci.Models.LogCollectionJobType? logCollectionJobType = default(Azure.ResourceManager.Hci.Models.LogCollectionJobType?), string correlationId = null, System.DateTimeOffset? endTimeCollected = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.LogCollectionError logCollectionError = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.NextBillingModel NextBillingModel(string billingModel = null, System.Collections.Generic.IEnumerable<string> capabilitiesEnabled = null, float? trialDaysRemaining = default(float?)) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `HciClusterOfferData` moving forward.")]
        public static Azure.ResourceManager.Hci.OfferData OfferData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisherId = null, string content = null, string contentVersion = null, string provisioningState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciSkuMappings> skuMappings = null) { throw null; }
        public static Azure.ResourceManager.Hci.OsImageData OsImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.OsImageProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OsImageProperties OsImageProperties(string validatedSolutionRecipeVersion = null, string composedImageVersion = null, string composedImageIsoUri = null, string composedImageIsoHash = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails OwnershipVoucherDetails(string ownershipVoucher = null, Azure.ResourceManager.Hci.Models.OwnerKeyType ownerKeyType = default(Azure.ResourceManager.Hci.Models.OwnerKeyType), Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails validationDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails OwnershipVoucherValidationDetails(Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus? validationStatus = default(Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus?), string serialNumber = null, string id = null, string manufacturer = null, string modelName = null, string version = null, string azureMachineId = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeArcState PerNodeArcState(string name, string arcInstance, Azure.ResourceManager.Hci.Models.NodeArcState? state) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeArcState PerNodeArcState(string name = null, string arcInstance = null, System.Guid? arcNodeServicePrincipalObjectId = default(System.Guid?), Azure.ResourceManager.Hci.Models.NodeArcState? state = default(Azure.ResourceManager.Hci.Models.NodeArcState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeExtensionState PerNodeExtensionState(string name, string extension, string typeHandlerVersion, Azure.ResourceManager.Hci.Models.NodeExtensionState? state, Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView extensionInstanceView) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `ArcExtensionInstanceView` moving forward.")]
        public static Azure.ResourceManager.Hci.Models.PerNodeExtensionState PerNodeExtensionState(string name = null, string extension = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.NodeExtensionState? state = default(Azure.ResourceManager.Hci.Models.NodeExtensionState?), Azure.ResourceManager.Hci.Models.HciExtensionInstanceView instanceView = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession PerNodeRemoteSupportSession(System.DateTimeOffset? sessionStartOn, System.DateTimeOffset? sessionEndOn, string nodeName, long? duration, Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? accessLevel) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession PerNodeRemoteSupportSession(System.DateTimeOffset? sessionStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? sessionEndOn = default(System.DateTimeOffset?), string nodeName = null, long? duration = default(long?), Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? accessLevel = default(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel?), string transcriptLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PlatformPayload PlatformPayload(string payloadUri = null, string payloadHash = null, string payloadPackageSizeInBytes = null, string payloadIdentifier = null) { throw null; }
        public static Azure.ResourceManager.Hci.PlatformUpdateData PlatformUpdateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PlatformUpdateDetails> platformUpdateDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PlatformUpdateDetails PlatformUpdateDetails(string validatedSolutionRecipeVersion = null, string platformVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PlatformPayload> platformPayloads = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ProvisioningContent ProvisioningContent(Azure.ResourceManager.Hci.Models.ProvisioningOsType target = default(Azure.ResourceManager.Hci.Models.ProvisioningOsType), Azure.ResourceManager.Hci.Models.OsProvisionProfile osProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUserDetails> userDetails = null, Azure.ResourceManager.Hci.Models.OnboardingConfiguration onboardingConfiguration = null, Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration deviceConfiguration = null, string customConfiguration = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ProvisionOsJobProperties ProvisionOsJobProperties(Azure.ResourceManager.Hci.Models.EceDeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.EceDeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciJobStatus? status = default(Azure.ResourceManager.Hci.Models.HciJobStatus?), Azure.ResponseError error = null, Azure.ResourceManager.Hci.Models.ProvisioningContent provisioningRequest = null, Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties ProvisionOsReportedProperties(int? percentComplete = default(int?), Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `HciClusterPublisherData` moving forward.")]
        public static Azure.ResourceManager.Hci.PublisherData PublisherData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ReleaseDeviceContent ReleaseDeviceContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> devices = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties RemoteSupportContentProperties(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? accessLevel = default(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.RemoteSupportType? remoteSupportType = default(Azure.ResourceManager.Hci.Models.RemoteSupportType?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings RemoteSupportJobNodeSettings(string state = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string connectionStatus = null, string connectionErrorMessage = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties RemoteSupportJobReportedProperties(int? percentComplete = default(int?), Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null, Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings nodeSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.RemoteSupportSession> sessionDetails = null) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new overload moving forward.")]
        public static Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings RemoteSupportNodeSettings(Azure.Core.ResourceIdentifier arcResourceId, string state = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string connectionStatus = null, string connectionErrorMessage = null, string transcriptLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportProperties RemoteSupportProperties(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? accessLevel, System.DateTimeOffset? expireOn, Azure.ResourceManager.Hci.Models.RemoteSupportType? remoteSupportType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings> remoteSupportNodeSettings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession> remoteSupportSessionDetails) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportProperties RemoteSupportProperties(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? accessLevel = default(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.RemoteSupportType? remoteSupportType = default(Azure.ResourceManager.Hci.Models.RemoteSupportType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings> remoteSupportNodeSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession> remoteSupportSessionDetails = null, Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState? remoteSupportProvisioningState = default(Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportSession RemoteSupportSession(string sessionId = null, System.DateTimeOffset? sessionStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? sessionEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel? accessLevel = default(Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel?), string transcriptLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig SanClusterNetworkConfig(Azure.ResourceManager.Hci.Models.SanAdapterProperties adapterProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.SanAdapterIPConfig> adapterIPConfig = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo SbeDeploymentPackageInfo(string code = null, string message = null, string sbeManifest = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SbePartnerInfo SbePartnerInfo(Azure.ResourceManager.Hci.Models.SbeDeploymentInfo sbeDeploymentInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.SbePartnerProperties> partnerProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.SbeCredentials> credentialList = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SdnProperties SdnProperties(Azure.ResourceManager.Hci.Models.SdnStatus? sdnStatus = default(Azure.ResourceManager.Hci.Models.SdnStatus?), string sdnDomainName = null, string sdnApiAddress = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent SecretsLocationsChangeContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.SecretsLocationDetails> properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SecurityComplianceStatus SecurityComplianceStatus(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? securedCoreCompliance = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus?), Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? wdacCompliance = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus?), Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? dataAtRestEncrypted = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus?), Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? dataInTransitProtected = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties SoftwareAssuranceProperties(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus? softwareAssuranceStatus, Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? softwareAssuranceIntent, System.DateTimeOffset? lastUpdatedOn) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateContentData UpdateContentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ContentPayload> updatePayloads = null) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `HciClusterUpdateData` moving forward.")]
        public static Azure.ResourceManager.Hci.UpdateData UpdateData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.AzureLocation? location, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, System.DateTimeOffset? installedOn, string description, Azure.ResourceManager.Hci.Models.HciUpdateState? state, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.UpdatePrerequisite> prerequisites, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> componentVersions, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement? rebootRequired, Azure.ResourceManager.Hci.Models.HciHealthState? healthState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult, System.DateTimeOffset? healthCheckOn, string packagePath, float? packageSizeInMb, string displayName, string version, string publisher, string releaseLink, Azure.ResourceManager.Hci.Models.HciAvailabilityType? availabilityType, string packageType, string additionalProperties, float? progressPercentage, string notifyMessage) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `HciClusterUpdateRunData` moving forward.")]
        public static Azure.ResourceManager.Hci.UpdateRunData UpdateRunData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.AzureLocation? location, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, System.DateTimeOffset? timeStarted, System.DateTimeOffset? lastUpdatedOn, string duration, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? state, string namePropertiesProgressName, string description, string errorMessage, string status, System.DateTimeOffset? startOn, System.DateTimeOffset? endOn, System.DateTimeOffset? lastCompletedOn, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUpdateStep> steps) { throw null; }
        [System.ObsoleteAttribute("This method is now deprecated. Please use the new method `HciClusterUpdateSummaryData` moving forward.")]
        public static Azure.ResourceManager.Hci.UpdateSummaryData UpdateSummaryData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.AzureLocation? location, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, string oemFamily, string currentOemVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> packageVersions, string currentVersion, System.DateTimeOffset? lastUpdatedOn, System.DateTimeOffset? lastCheckedOn, Azure.ResourceManager.Hci.Models.HciHealthState? healthState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult, System.DateTimeOffset? healthCheckOn, Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState? state) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities ValidatedSolutionRecipeCapabilities(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability> clusterCapabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability> nodeCapabilities = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability ValidatedSolutionRecipeCapability(string capabilityName = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent ValidatedSolutionRecipeComponent(string name = null, string type = null, string requiredVersion = null, long? installOrder = default(long?), System.Collections.Generic.IEnumerable<string> tags = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload> payloads = null, Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata metadata = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata ValidatedSolutionRecipeComponentMetadata(string extensionType = null, string publisher = null, bool? enableAutomaticUpgrade = default(bool?), bool? lcmUpdate = default(bool?), string catalog = null, string ring = null, string releaseTrain = null, string link = null, string name = null, string expectedHash = null, string previewSource = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload ValidatedSolutionRecipeComponentPayload(string identifier = null, string hash = null, string fileName = null, string uri = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent ValidatedSolutionRecipeContent(Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo info = null, Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent> components = null) { throw null; }
        public static Azure.ResourceManager.Hci.ValidatedSolutionRecipeData ValidatedSolutionRecipeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo ValidatedSolutionRecipeInfo(string solutionType = null, string version = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties ValidatedSolutionRecipeProperties(Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent recipeContent = null, string signature = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent ValidateOwnershipVouchersContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails> ownershipVoucherDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult ValidateOwnershipVouchersResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails> ownershipVoucherValidationDetails = null) { throw null; }
    }
    public partial class AssemblyInfoPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.AssemblyInfoPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.AssemblyInfoPayload>
    {
        internal AssemblyInfoPayload() { }
        public string FileName { get { throw null; } }
        public string Hash { get { throw null; } }
        public string Identifier { get { throw null; } }
        public string Uri { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.AssemblyInfoPayload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.AssemblyInfoPayload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.AssemblyInfoPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.AssemblyInfoPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.AssemblyInfoPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.AssemblyInfoPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.AssemblyInfoPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.AssemblyInfoPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.AssemblyInfoPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeRingContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ChangeRingContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ChangeRingContent>
    {
        public ChangeRingContent() { }
        public string TargetRing { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.ChangeRingContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ChangeRingContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ChangeRingContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ChangeRingContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ChangeRingContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ChangeRingContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ChangeRingContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ChangeRingContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ChangeRingContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckUpdatesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.CheckUpdatesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.CheckUpdatesContent>
    {
        public CheckUpdatesContent() { }
        public string UpdateName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.CheckUpdatesContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.CheckUpdatesContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.CheckUpdatesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.CheckUpdatesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.CheckUpdatesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.CheckUpdatesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.CheckUpdatesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.CheckUpdatesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.CheckUpdatesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClaimDeviceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClaimDeviceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClaimDeviceContent>
    {
        public ClaimDeviceContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> devices) { }
        public string ClaimedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Devices { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ClaimDeviceContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ClaimDeviceContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ClaimDeviceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClaimDeviceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClaimDeviceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ClaimDeviceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClaimDeviceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClaimDeviceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClaimDeviceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ClusterJobProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterJobProperties>
    {
        internal ClusterJobProperties() { }
        public Azure.ResourceManager.Hci.Models.EceDeploymentMode? DeploymentMode { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.JobReportedProperties ReportedProperties { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciJobStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ClusterJobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ClusterJobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ClusterJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ClusterJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ClusterNodeType left, Azure.ResourceManager.Hci.Models.ClusterNodeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ClusterNodeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ClusterNodeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ClusterNodeType left, Azure.ResourceManager.Hci.Models.ClusterNodeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterPattern : System.IEquatable<Azure.ResourceManager.Hci.Models.ClusterPattern>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterPattern(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClusterPattern RackAware { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ClusterPattern Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ClusterPattern other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ClusterPattern left, Azure.ResourceManager.Hci.Models.ClusterPattern right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ClusterPattern (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ClusterPattern? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ClusterPattern left, Azure.ResourceManager.Hci.Models.ClusterPattern right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterSdnProperties : Azure.ResourceManager.Hci.Models.SdnProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterSdnProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterSdnProperties>
    {
        internal ClusterSdnProperties() { }
        public Azure.ResourceManager.Hci.Models.SdnIntegrationIntent? SdnIntegrationIntent { get { throw null; } }
        protected override Azure.ResourceManager.Hci.Models.SdnProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Hci.Models.SdnProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ClusterSdnProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterSdnProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterSdnProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ClusterSdnProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterSdnProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterSdnProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterSdnProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialVmIntent : System.IEquatable<Azure.ResourceManager.Hci.Models.ConfidentialVmIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialVmIntent(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ConfidentialVmIntent Disable { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ConfidentialVmIntent Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ConfidentialVmIntent other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ConfidentialVmIntent left, Azure.ResourceManager.Hci.Models.ConfidentialVmIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ConfidentialVmIntent (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ConfidentialVmIntent? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ConfidentialVmIntent left, Azure.ResourceManager.Hci.Models.ConfidentialVmIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfidentialVmProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProfile>
    {
        internal ConfidentialVmProfile() { }
        public Azure.ResourceManager.Hci.Models.IgvmStatus? IgvmStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.IgvmStatusDetail> StatusDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ConfidentialVmProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ConfidentialVmProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ConfidentialVmProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ConfidentialVmProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfidentialVmProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProperties>
    {
        internal ConfidentialVmProperties() { }
        public Azure.ResourceManager.Hci.Models.ConfidentialVmIntent? ConfidentialVmIntent { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ConfidentialVmStatus? ConfidentialVmStatus { get { throw null; } }
        public string ConfidentialVmStatusSummary { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ConfidentialVmProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ConfidentialVmProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ConfidentialVmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ConfidentialVmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ConfidentialVmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialVmStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.ConfidentialVmStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialVmStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ConfidentialVmStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ConfidentialVmStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ConfidentialVmStatus PartiallyEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ConfidentialVmStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ConfidentialVmStatus left, Azure.ResourceManager.Hci.Models.ConfidentialVmStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ConfidentialVmStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ConfidentialVmStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ConfidentialVmStatus left, Azure.ResourceManager.Hci.Models.ConfidentialVmStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ContentPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ContentPayload>
    {
        internal ContentPayload() { }
        public string FileName { get { throw null; } }
        public string Group { get { throw null; } }
        public string Hash { get { throw null; } }
        public string HashAlgorithm { get { throw null; } }
        public string Identifier { get { throw null; } }
        public string PackageSizeInBytes { get { throw null; } }
        public string Uri { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ContentPayload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ContentPayload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ContentPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ContentPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ContentPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ContentPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ContentPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ContentPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ContentPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingAdapterPropertyOverrides : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides>
    {
        public DeploymentSettingAdapterPropertyOverrides() { }
        public string JumboPacket { get { throw null; } set { } }
        public string NetworkDirect { get { throw null; } set { } }
        public string NetworkDirectTechnology { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig SanNetworksClusterNetworkConfig { get { throw null; } set { } }
        public bool? StorageConnectivitySwitchless { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks> StorageNetworks { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingInfrastructureNetwork : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork>
    {
        public DeploymentSettingInfrastructureNetwork() { }
        public Azure.ResourceManager.Hci.Models.DnsServerConfig? DnsServerConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciDnsZones> DnsZones { get { throw null; } }
        public string Gateway { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools> IPPools { get { throw null; } }
        public string SubnetMask { get { throw null; } set { } }
        public bool? UseDhcp { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingIntents JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingIntents PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingIPPools PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingObservability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingObservability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingQosPolicyOverrides PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingStorage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorage>
    {
        public DeploymentSettingStorage() { }
        public string ConfigurationMode { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.StorageS2dConfig S2d { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.StorageSanConfig San { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciStorageType? StorageType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingStorage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingStorage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DeploymentSettingStorage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingStorage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingStorageAdapterIPInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo>
    {
        public DeploymentSettingStorageAdapterIPInfo() { }
        public string IPv4Address { get { throw null; } set { } }
        public string PhysicalNode { get { throw null; } set { } }
        public string SubnetMask { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceLogCollectionStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceLogCollectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus left, Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus left, Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevicePoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DevicePoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DevicePoolPatch>
    {
        public DevicePoolPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.DevicePoolPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DevicePoolPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DevicePoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DevicePoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DevicePoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DevicePoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DevicePoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DevicePoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DevicePoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevicePoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DevicePoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DevicePoolProperties>
    {
        public DevicePoolProperties() { }
        public string CloudId { get { throw null; } }
        public string CustomLocationName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomLocationResourceId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciDeviceDetail> Devices { get { throw null; } }
        public string ManagedResourceGroup { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciOperationDetail> OperationDetails { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.DevicePoolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DevicePoolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DevicePoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DevicePoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DevicePoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DevicePoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DevicePoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DevicePoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DevicePoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsServerConfig : System.IEquatable<Azure.ResourceManager.Hci.Models.DnsServerConfig>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsServerConfig(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DnsServerConfig UseDnsServer { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.DnsServerConfig UseForwarder { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.DnsServerConfig other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.DnsServerConfig left, Azure.ResourceManager.Hci.Models.DnsServerConfig right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.DnsServerConfig (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.DnsServerConfig? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.DnsServerConfig left, Azure.ResourceManager.Hci.Models.DnsServerConfig right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DownloadContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DownloadContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadContent>
    {
        public DownloadContent(Azure.ResourceManager.Hci.Models.ProvisioningOsType target, Azure.ResourceManager.Hci.Models.DownloadOsProfile osProfile) { }
        public Azure.ResourceManager.Hci.Models.DownloadOsProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningOsType Target { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.DownloadContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DownloadContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DownloadContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DownloadContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DownloadContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DownloadContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DownloadOsJobProperties : Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DownloadOsJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadOsJobProperties>
    {
        public DownloadOsJobProperties(Azure.ResourceManager.Hci.Models.DownloadContent downloadRequest) { }
        public Azure.ResourceManager.Hci.Models.DownloadContent DownloadRequest { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties ReportedProperties { get { throw null; } set { } }
        protected override Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DownloadOsJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DownloadOsJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DownloadOsJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DownloadOsJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadOsJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadOsJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadOsJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DownloadOsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DownloadOsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadOsProfile>
    {
        public DownloadOsProfile() { }
        public string GpgPubKey { get { throw null; } set { } }
        public string ImageHash { get { throw null; } set { } }
        public string OsImageLocation { get { throw null; } set { } }
        public string OsName { get { throw null; } set { } }
        public string OsType { get { throw null; } set { } }
        public string OsVersion { get { throw null; } set { } }
        public string VsrVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.DownloadOsProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DownloadOsProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DownloadOsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DownloadOsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DownloadOsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DownloadOsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadOsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadOsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadOsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EceActionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EceActionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceActionStatus>
    {
        internal EceActionStatus() { }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep> Steps { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.EceActionStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EceActionStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.EceDeploymentMode left, Azure.ResourceManager.Hci.Models.EceDeploymentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EceDeploymentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EceDeploymentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.EceDeploymentMode left, Azure.ResourceManager.Hci.Models.EceDeploymentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EceDeploymentSecrets : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets>
    {
        public EceDeploymentSecrets() { }
        public Azure.ResourceManager.Hci.Models.EceSecret? EceSecretName { get { throw null; } set { } }
        public System.Uri SecretLocation { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.EceDeploymentSecrets JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EceDeploymentSecrets PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.EceReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EceReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.EceSecret left, Azure.ResourceManager.Hci.Models.EceSecret right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EceSecret (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EceSecret? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.EceSecret left, Azure.ResourceManager.Hci.Models.EceSecret right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeDeviceDisks : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeDeviceDisks>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeDeviceDisks>
    {
        internal EdgeDeviceDisks() { }
        public string Id { get { throw null; } }
        public string SizeInBytes { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeDeviceDisks JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeDeviceDisks PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.EdgeDeviceDisks System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeDeviceDisks>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeDeviceDisks>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EdgeDeviceDisks System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeDeviceDisks>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeDeviceDisks>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeDeviceDisks>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeMachineCollectLogJobProperties : Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobProperties>
    {
        public EdgeMachineCollectLogJobProperties(System.DateTimeOffset collectionStartOn, System.DateTimeOffset collectionEndOn) { }
        public System.DateTimeOffset CollectionEndOn { get { throw null; } set { } }
        public System.DateTimeOffset CollectionStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastLogGeneratedOn { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties ReportedProperties { get { throw null; } }
        protected override Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeMachineCollectLogJobReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties>
    {
        internal EdgeMachineCollectLogJobReportedProperties() { }
        public Azure.ResourceManager.Hci.Models.EceActionStatus DeploymentStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.LogCollectionJobSession> LogCollectionSessionDetails { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EceActionStatus ValidationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeMachineConnectivityStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeMachineConnectivityStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus left, Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus left, Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EdgeMachineJobProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties>
    {
        internal EdgeMachineJobProperties() { }
        public Azure.ResourceManager.Hci.Models.EceDeploymentMode? DeploymentMode { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string JobId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciJobStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeMachineKind : System.IEquatable<Azure.ResourceManager.Hci.Models.EdgeMachineKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeMachineKind(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineKind Dedicated { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineKind Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.EdgeMachineKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.EdgeMachineKind left, Azure.ResourceManager.Hci.Models.EdgeMachineKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EdgeMachineKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EdgeMachineKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.EdgeMachineKind left, Azure.ResourceManager.Hci.Models.EdgeMachineKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeMachineNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile>
    {
        internal EdgeMachineNetworkProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail> NicDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail> SwitchDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeMachineNicDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail>
    {
        internal EdgeMachineNicDetail() { }
        public string AdapterName { get { throw null; } }
        public string ComponentId { get { throw null; } }
        public string DefaultGateway { get { throw null; } }
        public string DefaultIsolationId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DnsServers { get { throw null; } }
        public string DriverVersion { get { throw null; } }
        public string InterfaceDescription { get { throw null; } }
        public string Ip4Address { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string NicStatus { get { throw null; } }
        public string NicType { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.RdmaCapability? RdmaCapability { get { throw null; } }
        public string Slot { get { throw null; } }
        public string SubnetMask { get { throw null; } }
        public string SwitchName { get { throw null; } }
        public string VlanId { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeMachinePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachinePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachinePatch>
    {
        public EdgeMachinePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachinePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachinePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.EdgeMachinePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachinePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachinePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EdgeMachinePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachinePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachinePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachinePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeMachineProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineProperties>
    {
        public EdgeMachineProperties() { }
        public Azure.Core.ResourceIdentifier ArcGatewayResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ArcMachineResourceGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ArcMachineResourceId { get { throw null; } set { } }
        public string ClaimedBy { get { throw null; } }
        public string CloudId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus? ConnectivityStatus { get { throw null; } }
        public string DevicePoolResourceId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EdgeMachineKind? EdgeMachineKind { get { throw null; } set { } }
        public System.DateTimeOffset? LastSyncedOn { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EdgeMachineState? MachineState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciOperationDetail> OperationDetails { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails OwnershipVoucherDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningDetails ProvisioningDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties ReportedProperties { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciSiteDetails SiteDetails { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.EdgeMachineProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EdgeMachineProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeMachineRemoteSupportJobProperties : Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobProperties>
    {
        public EdgeMachineRemoteSupportJobProperties(Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel accessLevel, System.DateTimeOffset expireOn, Azure.ResourceManager.Hci.Models.RemoteSupportType type) { }
        public Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel AccessLevel { get { throw null; } set { } }
        public System.DateTimeOffset ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties ReportedProperties { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.RemoteSupportType Type { get { throw null; } set { } }
        protected override Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeMachineRemoteSupportJobReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties>
    {
        internal EdgeMachineRemoteSupportJobReportedProperties() { }
        public Azure.ResourceManager.Hci.Models.EceActionStatus DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings NodeSettings { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.RemoteSupportSession> SessionDetails { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EceActionStatus ValidationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeMachineRemoteSupportNodeSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings>
    {
        internal EdgeMachineRemoteSupportNodeSettings() { }
        public string ConnectionErrorMessage { get { throw null; } }
        public string ConnectionStatus { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string State { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeMachineReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties>
    {
        internal EdgeMachineReportedProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> Extensions { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile HardwareProfile { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile NetworkProfile { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile OsProfile { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo SbeDeploymentPackageInfo { get { throw null; } }
        public long? StoragePoolableDisksCount { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeMachineState : System.IEquatable<Azure.ResourceManager.Hci.Models.EdgeMachineState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeMachineState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineState Created { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineState Preparing { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineState Purposed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineState Registering { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineState Resetting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineState Transitioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineState Unpurposed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.EdgeMachineState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.EdgeMachineState left, Azure.ResourceManager.Hci.Models.EdgeMachineState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EdgeMachineState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EdgeMachineState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.EdgeMachineState left, Azure.ResourceManager.Hci.Models.EdgeMachineState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `ArcExtensionInstanceViewStatus` moving forward.")]
    public partial class ExtensionInstanceViewStatus : Azure.ResourceManager.Hci.Models.ArcExtensionInstanceViewStatus, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>
    {
        internal ExtensionInstanceViewStatus() { }
        Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `ArcExtensionUpgradeContent` moving forward.")]
    public partial class ExtensionUpgradeContent : Azure.ResourceManager.Hci.Models.ArcExtensionUpgradeContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>
    {
        public ExtensionUpgradeContent() { }
        Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HardwareClass : System.IEquatable<Azure.ResourceManager.Hci.Models.HardwareClass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HardwareClass(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HardwareClass Large { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HardwareClass Medium { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HardwareClass Small { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HardwareClass other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HardwareClass left, Azure.ResourceManager.Hci.Models.HardwareClass right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HardwareClass (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HardwareClass? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HardwareClass left, Azure.ResourceManager.Hci.Models.HardwareClass right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciArcEnabledEdgeDevice : Azure.ResourceManager.Hci.HciEdgeDeviceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDevice>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDevice>
    {
        public HciArcEnabledEdgeDevice() { }
        public Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties Properties { get { throw null; } set { } }
        protected override Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciArcEnabledEdgeDeviceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciAssemblyInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciAssemblyInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciAssemblyInfo>
    {
        public HciAssemblyInfo() { }
        public string PackageVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.AssemblyInfoPayload> Payload { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciAssemblyInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciAssemblyInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciAssemblyInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciAssemblyInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciAssemblyInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciAssemblyInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciAssemblyInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciAssemblyInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciAssemblyInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciAvailabilityType left, Azure.ResourceManager.Hci.Models.HciAvailabilityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciAvailabilityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciAvailabilityType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel left, Azure.ResourceManager.Hci.Models.HciClusterAccessLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterAccessLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel left, Azure.ResourceManager.Hci.Models.HciClusterAccessLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterCertificateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterCertificateContent>
    {
        public HciClusterCertificateContent() { }
        public System.Collections.Generic.IList<string> Certificates { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterCertificateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterCertificateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType left, Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterComplianceAssignmentType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus left, Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus left, Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus left, Azure.ResourceManager.Hci.Models.HciClusterConnectivityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterDeploymentConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration>
    {
        public HciClusterDeploymentConfiguration(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits> scaleUnits) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeploymentSettingScaleUnits> ScaleUnits { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterDeploymentConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Models.HciAssemblyInfo AssemblyInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciDeploymentCluster Cluster { get { throw null; } set { } }
        public string DomainFqdn { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork HostNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciIdentityProvider? IdentityProvider { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeploymentSettingInfrastructureNetwork> InfrastructureNetwork { get { throw null; } }
        public bool? IsManagementCluster { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones> LocalAvailabilityZones { get { throw null; } }
        public string NamingPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.DeploymentSettingObservability Observability { get { throw null; } set { } }
        public string OptionalServicesCustomLocation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeploymentSettingPhysicalNodes> PhysicalNodes { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.DeploymentSettingNetworkController SdnIntegrationNetworkController { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets> Secrets { get { throw null; } }
        public string SecretsLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings SecuritySettings { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.DeploymentSettingStorage Storage { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is no longer supported in the current API version.")]
        public string StorageConfigurationMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterDeploymentInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterDeploymentSecuritySettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterDeploymentStep PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel left, Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterIdentityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterIdentityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterNode JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterNode PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterOperationType left, Azure.ResourceManager.Hci.Models.HciClusterOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterOperationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterOperationType? (string value) { throw null; }
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
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the `Identity` property moving forward.")]
        public Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? ManagedServiceIdentityType { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the `Identity` property moving forward.")]
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the `Identity` property moving forward.")]
        public System.Guid? TenantId { get { throw null; } }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the `Identity` property moving forward.")]
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Models.HardwareClass? HardwareClass { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ImdsAttestationState? ImdsAttestation { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string Manufacturer { get { throw null; } }
        public System.DateTimeOffset? MsiExpirationTimeStamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciClusterNode> Nodes { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.OemActivation? OemActivation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedCapabilities { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `DeploymentFailed` moving forward.")]
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Failed { get { throw null; } }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `DeploymentInProgress` moving forward.")]
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotYetRegistered { get { throw null; } }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `DeploymentSuccess` moving forward.")]
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus ValidationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus ValidationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus ValidationSuccess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterStatus left, Azure.ResourceManager.Hci.Models.HciClusterStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterStatus left, Azure.ResourceManager.Hci.Models.HciClusterStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterUpdatePrerequisite : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite>
    {
        public HciClusterUpdatePrerequisite() { }
        public string PackageName { get { throw null; } set { } }
        public string UpdateType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterUpdateState left, Azure.ResourceManager.Hci.Models.HciClusterUpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterUpdateState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterUpdateState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterUpdateState left, Azure.ResourceManager.Hci.Models.HciClusterUpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciCollectLogJobProperties : Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciCollectLogJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciCollectLogJobProperties>
    {
        public HciCollectLogJobProperties(System.DateTimeOffset collectionStartOn, System.DateTimeOffset collectionEndOn) { }
        public System.DateTimeOffset CollectionEndOn { get { throw null; } set { } }
        public System.DateTimeOffset CollectionStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastLogGeneratedOn { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties ReportedProperties { get { throw null; } }
        protected override Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciCollectLogJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciCollectLogJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciCollectLogJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciCollectLogJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciCollectLogJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciCollectLogJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciCollectLogJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciConfigureCvmJobProperties : Azure.ResourceManager.Hci.Models.ClusterJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciConfigureCvmJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciConfigureCvmJobProperties>
    {
        public HciConfigureCvmJobProperties(Azure.ResourceManager.Hci.Models.ConfidentialVmIntent confidentialVmIntent) { }
        public Azure.ResourceManager.Hci.Models.ConfidentialVmIntent ConfidentialVmIntent { get { throw null; } set { } }
        protected override Azure.ResourceManager.Hci.Models.ClusterJobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Hci.Models.ClusterJobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciConfigureCvmJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciConfigureCvmJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciConfigureCvmJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciConfigureCvmJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciConfigureCvmJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciConfigureCvmJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciConfigureCvmJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciConfigureSdnIntegrationJobProperties : Azure.ResourceManager.Hci.Models.ClusterJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciConfigureSdnIntegrationJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciConfigureSdnIntegrationJobProperties>
    {
        public HciConfigureSdnIntegrationJobProperties(Azure.ResourceManager.Hci.Models.SdnIntegrationIntent sdnIntegrationIntent) { }
        public Azure.ResourceManager.Hci.Models.SdnIntegrationIntent SdnIntegrationIntent { get { throw null; } set { } }
        public string SdnPrefix { get { throw null; } set { } }
        protected override Azure.ResourceManager.Hci.Models.ClusterJobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Hci.Models.ClusterJobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciConfigureSdnIntegrationJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciConfigureSdnIntegrationJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciConfigureSdnIntegrationJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciConfigureSdnIntegrationJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciConfigureSdnIntegrationJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciConfigureSdnIntegrationJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciConfigureSdnIntegrationJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciDeploymentCluster : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>
    {
        public HciDeploymentCluster() { }
        public string AzureServiceEndpoint { get { throw null; } set { } }
        public string CloudAccountName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ClusterPattern? ClusterPattern { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HardwareClass? HardwareClass { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string WitnessPath { get { throw null; } set { } }
        public string WitnessType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.HciDeploymentCluster JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciDeploymentCluster PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciDeploymentCluster System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciDeploymentCluster System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentCluster>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciDeploymentHardwareProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile>
    {
        internal HciDeploymentHardwareProfile() { }
        public long? CpuCores { get { throw null; } }
        public long? CpuSockets { get { throw null; } }
        public string Manufacturer { get { throw null; } }
        public long? MemoryCapacityInGb { get { throw null; } }
        public string Model { get { throw null; } }
        public string ProcessorType { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentHardwareProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciDeploymentOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile>
    {
        internal HciDeploymentOSProfile() { }
        public string AssemblyVersion { get { throw null; } }
        public string BaseImageVersion { get { throw null; } }
        public string BootType { get { throw null; } }
        public string BuildNumber { get { throw null; } }
        public string ImageVersion { get { throw null; } }
        public string OsSku { get { throw null; } }
        public string OsType { get { throw null; } }
        public string OsVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeploymentOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciDeviceDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeviceDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeviceDetail>
    {
        public HciDeviceDetail() { }
        public string ClaimedBy { get { throw null; } }
        public Azure.Core.ResourceIdentifier DeviceResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.HciDeviceDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciDeviceDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciDeviceDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeviceDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDeviceDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciDeviceDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeviceDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeviceDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDeviceDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciDnsZones : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDnsZones>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDnsZones>
    {
        public HciDnsZones() { }
        public System.Collections.Generic.IList<string> DnsForwarder { get { throw null; } }
        public string DnsZoneName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.HciDnsZones JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciDnsZones PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciDnsZones System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDnsZones>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciDnsZones>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciDnsZones System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDnsZones>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDnsZones>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciDnsZones>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceAdapterPropertyOverrides : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides>
    {
        internal HciEdgeDeviceAdapterPropertyOverrides() { }
        public string JumboPacket { get { throw null; } }
        public string NetworkDirect { get { throw null; } }
        public string NetworkDirectTechnology { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceJob : Azure.ResourceManager.Hci.EdgeDeviceJobData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJob>
    {
        public HciEdgeDeviceJob(Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties properties) { }
        public Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties Properties { get { throw null; } set { } }
        protected override Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class HciEdgeDeviceJobProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties>
    {
        internal HciEdgeDeviceJobProperties() { }
        public Azure.ResourceManager.Hci.Models.EceDeploymentMode? DeploymentMode { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciJobStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciEdgeDeviceReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties>
    {
        internal HciEdgeDeviceReportedProperties() { }
        public Azure.ResourceManager.Hci.Models.ConfidentialVmProfile ConfidentialVmProfile { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciEdgeDeviceState? DeviceState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> Extensions { get { throw null; } }
        public System.DateTimeOffset? LastSyncedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState left, Azure.ResourceManager.Hci.Models.HciEdgeDeviceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciEdgeDeviceState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciEdgeDeviceState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState left, Azure.ResourceManager.Hci.Models.HciEdgeDeviceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciEdgeDeviceStorageAdapterIPInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo>
    {
        internal HciEdgeDeviceStorageAdapterIPInfo() { }
        public string IPv4Address { get { throw null; } }
        public string PhysicalNode { get { throw null; } }
        public string SubnetMask { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceValidateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeSwitchExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciHealthState left, Azure.ResourceManager.Hci.Models.HciHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciHealthState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciHealthState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciHealthState left, Azure.ResourceManager.Hci.Models.HciHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciIdentityProvider : System.IEquatable<Azure.ResourceManager.Hci.Models.HciIdentityProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciIdentityProvider(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciIdentityProvider ActiveDirectory { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciIdentityProvider LocalIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciIdentityProvider other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciIdentityProvider left, Azure.ResourceManager.Hci.Models.HciIdentityProvider right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciIdentityProvider (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciIdentityProvider? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciIdentityProvider left, Azure.ResourceManager.Hci.Models.HciIdentityProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciIPAddressRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciIPAddressRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciIPAddressRange>
    {
        public HciIPAddressRange(string startIp, string endIp) { }
        public string EndIp { get { throw null; } set { } }
        public string StartIp { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.HciIPAddressRange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciIPAddressRange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciIPAddressRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciIPAddressRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciIPAddressRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciIPAddressRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciIPAddressRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciIPAddressRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciIPAddressRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciJobStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.HciJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciJobStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciJobStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciJobStatus DeploymentFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciJobStatus DeploymentInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciJobStatus DeploymentSuccess { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciJobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciJobStatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciJobStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciJobStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciJobStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciJobStatus ValidationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciJobStatus ValidationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciJobStatus ValidationSuccess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciJobStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciJobStatus left, Azure.ResourceManager.Hci.Models.HciJobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciJobStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciJobStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciJobStatus left, Azure.ResourceManager.Hci.Models.HciJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciKubernetesVersion : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciKubernetesVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciKubernetesVersion>
    {
        internal HciKubernetesVersion() { }
        public string KubernetesVersionValue { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciKubernetesVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciKubernetesVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciKubernetesVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciKubernetesVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciKubernetesVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciKubernetesVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciKubernetesVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType left, Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Models.ManagedServiceIdentityType (Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType (Azure.ResourceManager.Models.ManagedServiceIdentityType value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType left, Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciNetworkAdapter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciNetworkAdapter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciNetworkAdapter>
    {
        public HciNetworkAdapter(Azure.ResourceManager.Hci.Models.IpAssignmentType ipAssignmentType) { }
        public string AdapterName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsAddressArray { get { throw null; } }
        public string Gateway { get { throw null; } set { } }
        public string IpAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciIPAddressRange IpAddressRange { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.IpAssignmentType IpAssignmentType { get { throw null; } set { } }
        public string MacAddress { get { throw null; } set { } }
        public string SubnetMask { get { throw null; } set { } }
        public string VlanId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.HciNetworkAdapter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciNetworkAdapter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciNetworkAdapter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciNetworkAdapter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciNetworkAdapter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciNetworkAdapter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciNetworkAdapter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciNetworkAdapter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciNetworkAdapter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciNetworkProfile>
    {
        internal HciNetworkProfile() { }
        public Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork HostNetwork { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciNicDetail> NicDetails { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SdnProperties SdnProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail> SwitchDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciNetworkProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciNetworkProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Models.RdmaCapability? RdmaCapability { get { throw null; } }
        public string Slot { get { throw null; } }
        public string SubnetMask { get { throw null; } }
        public string SwitchName { get { throw null; } }
        public string VlanId { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciNicDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciNicDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement left, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement left, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciOperationDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciOperationDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciOperationDetail>
    {
        internal HciOperationDetail() { }
        public string Description { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string Status { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciOperationDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciOperationDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciOperationDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciOperationDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciOperationDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciOperationDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciOperationDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciOperationDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciOperationDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciOSProfile>
    {
        internal HciOSProfile() { }
        public string AssemblyVersion { get { throw null; } }
        public string BootType { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciOSProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciOSProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciPackageVersionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo>
    {
        public HciPackageVersionInfo() { }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public string PackageType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.HciPackageVersionInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciPackageVersionInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciPrecheckResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciPrecheckResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.HciPrecheckResultTags JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciPrecheckResultTags PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciPrecheckResultTags System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciPrecheckResultTags System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciPrecheckResultTags>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciProvisioningDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciProvisioningDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciProvisioningDetails>
    {
        public HciProvisioningDetails(Azure.ResourceManager.Hci.Models.OsProvisionProfile osProfile) { }
        public Azure.ResourceManager.Hci.Models.OsProvisionProfile OsProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciUserDetails> UserDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciProvisioningDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciProvisioningDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciProvisioningDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciProvisioningDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciProvisioningDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciProvisioningDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciProvisioningDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciProvisioningDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciProvisioningDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciProvisioningState left, Azure.ResourceManager.Hci.Models.HciProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciProvisioningState left, Azure.ResourceManager.Hci.Models.HciProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciRemoteSupportJobProperties : Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciRemoteSupportJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciRemoteSupportJobProperties>
    {
        public HciRemoteSupportJobProperties(Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel accessLevel, System.DateTimeOffset expireOn, Azure.ResourceManager.Hci.Models.RemoteSupportType type) { }
        public Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel AccessLevel { get { throw null; } set { } }
        public System.DateTimeOffset ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties ReportedProperties { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.RemoteSupportType Type { get { throw null; } set { } }
        protected override Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciRemoteSupportJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciRemoteSupportJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciRemoteSupportJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciRemoteSupportJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciRemoteSupportJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciRemoteSupportJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciRemoteSupportJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciReportedProperties : Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>
    {
        internal HciReportedProperties() { }
        public string HardwareProcessorType { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciNetworkProfile NetworkProfile { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciOSProfile OSProfile { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo SbeDeploymentPackageInfo { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciStorageProfile StorageProfile { get { throw null; } }
        protected override Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Hci.Models.HciEdgeDeviceReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciSecretsType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciSecretsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciSecretsType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciSecretsType BackupSecrets { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciSecretsType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciSecretsType left, Azure.ResourceManager.Hci.Models.HciSecretsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciSecretsType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciSecretsType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciSecretsType left, Azure.ResourceManager.Hci.Models.HciSecretsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciSecretType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciSecretType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciSecretType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciSecretType KeyVault { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciSecretType SshPubKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciSecretType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciSecretType left, Azure.ResourceManager.Hci.Models.HciSecretType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciSecretType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciSecretType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciSecretType left, Azure.ResourceManager.Hci.Models.HciSecretType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciSiteDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciSiteDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciSiteDetails>
    {
        public HciSiteDetails(Azure.Core.ResourceIdentifier siteResourceId) { }
        public Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration DeviceConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SiteResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.HciSiteDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciSiteDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciSiteDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciSiteDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciSiteDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciSiteDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciSiteDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciSiteDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciSiteDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciSkuMappings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciSkuMappings>
    {
        public HciSkuMappings() { }
        public string CatalogPlanId { get { throw null; } set { } }
        public string MarketplaceSkuId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MarketplaceSkuVersions { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciSkuMappings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciSkuMappings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciStatusLevelType left, Azure.ResourceManager.Hci.Models.HciStatusLevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciStatusLevelType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciStatusLevelType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciStatusLevelType left, Azure.ResourceManager.Hci.Models.HciStatusLevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciStorageProfile>
    {
        internal HciStorageProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.EdgeDeviceDisks> Disks { get { throw null; } }
        public long? PoolableDisksCount { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciStorageProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciStorageProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciStorageType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciStorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciStorageType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciStorageType S2D { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciStorageType SAN { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciStorageType SANS2D { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciStorageType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciStorageType left, Azure.ResourceManager.Hci.Models.HciStorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciStorageType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciStorageType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciStorageType left, Azure.ResourceManager.Hci.Models.HciStorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciTimeConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciTimeConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciTimeConfiguration>
    {
        public HciTimeConfiguration() { }
        public string PrimaryTimeServer { get { throw null; } set { } }
        public string SecondaryTimeServer { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.HciTimeConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciTimeConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciTimeConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciTimeConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciTimeConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciTimeConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciTimeConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciTimeConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciTimeConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.Hci.Models.HciUpdateState HealthCheckExpired { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState HealthCheckFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState HealthChecking { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState InstallationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Installed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Installing { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Invalid { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState NotApplicableBecauseAnotherUpdateIsInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Obsolete { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState PendingOEMValidation { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState PreparationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Preparing { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Ready { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState ReadyToInstall { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Recalled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState ScanFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState ScanInProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciUpdateState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciUpdateState left, Azure.ResourceManager.Hci.Models.HciUpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciUpdateState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciUpdateState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciUpdateState left, Azure.ResourceManager.Hci.Models.HciUpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciUpdateStep : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>
    {
        public HciUpdateStep() { }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `EndOn` moving forward.")]
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        public string ExpectedExecutionTime { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        public System.DateTimeOffset? LastUpdatedTimeUtc { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `StartOn` moving forward.")]
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciUpdateStep> Steps { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciUpdateStep JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciUpdateStep PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciUpdateStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciUpdateStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUpdateStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUserDetails>
    {
        public HciUserDetails(string userName, Azure.ResourceManager.Hci.Models.HciSecretType secretType) { }
        public string SecretLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciSecretType SecretType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SshPubKey { get { throw null; } }
        public string UserName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.HciUserDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciUserDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciValidationFailureDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>
    {
        internal HciValidationFailureDetail() { }
        public string Exception { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciValidationFailureDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciValidationFailureDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciValidationFailureDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciValidationFailureDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVolumeType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciVolumeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVolumeType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciVolumeType Fixed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVolumeType ThinProvisioned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciVolumeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciVolumeType left, Azure.ResourceManager.Hci.Models.HciVolumeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciVolumeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciVolumeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciVolumeType left, Azure.ResourceManager.Hci.Models.HciVolumeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciWebProxyConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciWebProxyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciWebProxyConfiguration>
    {
        public HciWebProxyConfiguration() { }
        public System.Collections.Generic.IList<System.Uri> BypassList { get { throw null; } }
        public System.Uri ConnectionUri { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.HciWebProxyConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciWebProxyConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciWebProxyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciWebProxyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciWebProxyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciWebProxyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciWebProxyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciWebProxyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciWebProxyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IgvmStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.IgvmStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IgvmStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.IgvmStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.IgvmStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.IgvmStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.IgvmStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.IgvmStatus left, Azure.ResourceManager.Hci.Models.IgvmStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.IgvmStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.IgvmStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.IgvmStatus left, Azure.ResourceManager.Hci.Models.IgvmStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IgvmStatusDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IgvmStatusDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IgvmStatusDetail>
    {
        internal IgvmStatusDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.IgvmStatusDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.IgvmStatusDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.IgvmStatusDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IgvmStatusDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IgvmStatusDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.IgvmStatusDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IgvmStatusDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IgvmStatusDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IgvmStatusDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ImdsAttestationState left, Azure.ResourceManager.Hci.Models.ImdsAttestationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ImdsAttestationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ImdsAttestationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ImdsAttestationState left, Azure.ResourceManager.Hci.Models.ImdsAttestationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IpAssignmentType : System.IEquatable<Azure.ResourceManager.Hci.Models.IpAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IpAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.IpAssignmentType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.IpAssignmentType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.IpAssignmentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.IpAssignmentType left, Azure.ResourceManager.Hci.Models.IpAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.IpAssignmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.IpAssignmentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.IpAssignmentType left, Azure.ResourceManager.Hci.Models.IpAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IsolatedVmAttestationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>
    {
        internal IsolatedVmAttestationConfiguration() { }
        public Azure.Core.ResourceIdentifier AttestationResourceId { get { throw null; } }
        public string AttestationServiceEndpoint { get { throw null; } }
        public string RelyingPartyServiceEndpoint { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JobReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.JobReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.JobReportedProperties>
    {
        internal JobReportedProperties() { }
        public Azure.ResourceManager.Hci.Models.EceActionStatus DeploymentStatus { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EceActionStatus ValidationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.JobReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.JobReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.JobReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.JobReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.JobReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.JobReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.JobReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.JobReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.JobReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocalAvailabilityZones : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones>
    {
        public LocalAvailabilityZones() { }
        public string LocalAvailabilityZoneName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Nodes { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.LocalAvailabilityZones JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.LocalAvailabilityZones PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.LocalAvailabilityZones System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LocalAvailabilityZones System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogCollectionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionContent>
    {
        public LogCollectionContent() { }
        public Azure.ResourceManager.Hci.Models.LogCollectionContentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionContentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionContentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.LogCollectionError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogCollectionJobSession : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionJobSession>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionJobSession>
    {
        internal LogCollectionJobSession() { }
        public string CorrelationId { get { throw null; } }
        public string EndTime { get { throw null; } }
        public int? LogSize { get { throw null; } }
        public string StartTime { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus? Status { get { throw null; } }
        public string TimeCollected { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionJobSession JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionJobSession PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.LogCollectionJobSession System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionJobSession>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionJobSession>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionJobSession System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionJobSession>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionJobSession>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionJobSession>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.LogCollectionJobType left, Azure.ResourceManager.Hci.Models.LogCollectionJobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.LogCollectionJobType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.LogCollectionJobType? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.LogCollectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogCollectionReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties>
    {
        internal LogCollectionReportedProperties() { }
        public Azure.ResourceManager.Hci.Models.EceActionStatus DeploymentStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.LogCollectionJobSession> LogCollectionSessionDetails { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EceActionStatus ValidationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionSession JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionSession PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.LogCollectionStatus left, Azure.ResourceManager.Hci.Models.LogCollectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.LogCollectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.LogCollectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.LogCollectionStatus left, Azure.ResourceManager.Hci.Models.LogCollectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NextBillingModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NextBillingModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NextBillingModel>
    {
        internal NextBillingModel() { }
        public string BillingModel { get { throw null; } }
        public System.Collections.Generic.IList<string> CapabilitiesEnabled { get { throw null; } }
        public float? TrialDaysRemaining { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.NextBillingModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.NextBillingModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.NextBillingModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NextBillingModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NextBillingModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.NextBillingModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NextBillingModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NextBillingModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NextBillingModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.NodeArcState left, Azure.ResourceManager.Hci.Models.NodeArcState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.NodeArcState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.NodeArcState? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.NodeExtensionState left, Azure.ResourceManager.Hci.Models.NodeExtensionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.NodeExtensionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.NodeExtensionState? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.OemActivation left, Azure.ResourceManager.Hci.Models.OemActivation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OemActivation (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OemActivation? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.OemActivation left, Azure.ResourceManager.Hci.Models.OemActivation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OnboardingConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OnboardingConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OnboardingConfiguration>
    {
        public OnboardingConfiguration() { }
        public string ArcVirtualMachineId { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OnboardingResourceType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.OnboardingConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.OnboardingConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.OnboardingConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OnboardingConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OnboardingConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.OnboardingConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OnboardingConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OnboardingConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OnboardingConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnboardingResourceType : System.IEquatable<Azure.ResourceManager.Hci.Models.OnboardingResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnboardingResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OnboardingResourceType HybridComputeMachine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.OnboardingResourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.OnboardingResourceType left, Azure.ResourceManager.Hci.Models.OnboardingResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OnboardingResourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OnboardingResourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.OnboardingResourceType left, Azure.ResourceManager.Hci.Models.OnboardingResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OsImageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OsImageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OsImageProperties>
    {
        internal OsImageProperties() { }
        public string ComposedImageIsoHash { get { throw null; } }
        public string ComposedImageIsoUri { get { throw null; } }
        public string ComposedImageVersion { get { throw null; } }
        public string ValidatedSolutionRecipeVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.OsImageProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.OsImageProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.OsImageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OsImageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OsImageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.OsImageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OsImageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OsImageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OsImageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSOperationType : System.IEquatable<Azure.ResourceManager.Hci.Models.OSOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSOperationType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OSOperationType Provision { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.OSOperationType ReImage { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.OSOperationType Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.OSOperationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.OSOperationType left, Azure.ResourceManager.Hci.Models.OSOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OSOperationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OSOperationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.OSOperationType left, Azure.ResourceManager.Hci.Models.OSOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OsProvisionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OsProvisionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OsProvisionProfile>
    {
        public OsProvisionProfile() { }
        public string GpgPubKey { get { throw null; } set { } }
        public string ImageHash { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OSOperationType? OperationType { get { throw null; } set { } }
        public string OsImageLocation { get { throw null; } set { } }
        public string OsName { get { throw null; } set { } }
        public string OsType { get { throw null; } set { } }
        public string OsVersion { get { throw null; } set { } }
        public string VsrVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.OsProvisionProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.OsProvisionProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.OsProvisionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OsProvisionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OsProvisionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.OsProvisionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OsProvisionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OsProvisionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OsProvisionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OverprovisioningRatio : System.IEquatable<Azure.ResourceManager.Hci.Models.OverprovisioningRatio>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OverprovisioningRatio(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OverprovisioningRatio One { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.OverprovisioningRatio Two { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.OverprovisioningRatio Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.OverprovisioningRatio other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.OverprovisioningRatio left, Azure.ResourceManager.Hci.Models.OverprovisioningRatio right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OverprovisioningRatio (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OverprovisioningRatio? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.OverprovisioningRatio left, Azure.ResourceManager.Hci.Models.OverprovisioningRatio right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OwnerKeyType : System.IEquatable<Azure.ResourceManager.Hci.Models.OwnerKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OwnerKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OwnerKeyType MicrosoftManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.OwnerKeyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.OwnerKeyType left, Azure.ResourceManager.Hci.Models.OwnerKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OwnerKeyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OwnerKeyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.OwnerKeyType left, Azure.ResourceManager.Hci.Models.OwnerKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OwnershipVoucherDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails>
    {
        public OwnershipVoucherDetails(string ownershipVoucher, Azure.ResourceManager.Hci.Models.OwnerKeyType ownerKeyType) { }
        public Azure.ResourceManager.Hci.Models.OwnerKeyType OwnerKeyType { get { throw null; } set { } }
        public string OwnershipVoucher { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails ValidationDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OwnershipVoucherValidationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails>
    {
        internal OwnershipVoucherValidationDetails() { }
        public string AzureMachineId { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Manufacturer { get { throw null; } }
        public string ModelName { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus? ValidationStatus { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OwnershipVoucherValidationStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OwnershipVoucherValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus left, Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus left, Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PerNodeArcState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>
    {
        internal PerNodeArcState() { }
        public string ArcInstance { get { throw null; } }
        public System.Guid? ArcNodeServicePrincipalObjectId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.NodeArcState? State { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.PerNodeArcState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.PerNodeArcState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `StartOn` moving forward.")]
        public Azure.ResourceManager.Hci.Models.HciExtensionInstanceView InstanceView { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.NodeExtensionState? State { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.PerNodeExtensionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.PerNodeExtensionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string TranscriptLocation { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlatformPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PlatformPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PlatformPayload>
    {
        internal PlatformPayload() { }
        public string PayloadHash { get { throw null; } }
        public string PayloadIdentifier { get { throw null; } }
        public string PayloadPackageSizeInBytes { get { throw null; } }
        public string PayloadUri { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.PlatformPayload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.PlatformPayload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.PlatformPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PlatformPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PlatformPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PlatformPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PlatformPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PlatformPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PlatformPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlatformUpdateDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PlatformUpdateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PlatformUpdateDetails>
    {
        internal PlatformUpdateDetails() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.PlatformPayload> PlatformPayloads { get { throw null; } }
        public string PlatformVersion { get { throw null; } }
        public string ValidatedSolutionRecipeVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.PlatformUpdateDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.PlatformUpdateDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.PlatformUpdateDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PlatformUpdateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PlatformUpdateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PlatformUpdateDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PlatformUpdateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PlatformUpdateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PlatformUpdateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisioningContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisioningContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisioningContent>
    {
        public ProvisioningContent(Azure.ResourceManager.Hci.Models.ProvisioningOsType target, Azure.ResourceManager.Hci.Models.OsProvisionProfile osProfile) { }
        public string CustomConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration DeviceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OnboardingConfiguration OnboardingConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OsProvisionProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningOsType Target { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciUserDetails> UserDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ProvisioningContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ProvisioningContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ProvisioningContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisioningContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisioningContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ProvisioningContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisioningContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisioningContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisioningContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningOsType : System.IEquatable<Azure.ResourceManager.Hci.Models.ProvisioningOsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningOsType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ProvisioningOsType AzureLinux { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ProvisioningOsType HCI { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ProvisioningOsType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ProvisioningOsType left, Azure.ResourceManager.Hci.Models.ProvisioningOsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ProvisioningOsType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ProvisioningOsType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ProvisioningOsType left, Azure.ResourceManager.Hci.Models.ProvisioningOsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProvisionOsJobProperties : Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisionOsJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisionOsJobProperties>
    {
        public ProvisionOsJobProperties(Azure.ResourceManager.Hci.Models.ProvisioningContent provisioningRequest) { }
        public Azure.ResourceManager.Hci.Models.ProvisioningContent ProvisioningRequest { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties ReportedProperties { get { throw null; } set { } }
        protected override Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ProvisionOsJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisionOsJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisionOsJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ProvisionOsJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisionOsJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisionOsJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisionOsJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionOsReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties>
    {
        public ProvisionOsReportedProperties() { }
        public Azure.ResourceManager.Hci.Models.EceActionStatus DeploymentStatus { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EceActionStatus ValidationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RdmaCapability : System.IEquatable<Azure.ResourceManager.Hci.Models.RdmaCapability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RdmaCapability(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RdmaCapability Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.RdmaCapability Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.RdmaCapability other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.RdmaCapability left, Azure.ResourceManager.Hci.Models.RdmaCapability right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.RdmaCapability (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.RdmaCapability? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.RdmaCapability left, Azure.ResourceManager.Hci.Models.RdmaCapability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReconcileArcSettingsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsContent>
    {
        public ReconcileArcSettingsContent() { }
        public System.Collections.Generic.IList<string> ReconcileArcSettingsRequestClusterNodes { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ReconcileArcSettingsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ReconcileArcSettingsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ReconcileArcSettingsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ReconcileArcSettingsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReleaseDeviceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceContent>
    {
        public ReleaseDeviceContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> devices) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Devices { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ReleaseDeviceContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ReleaseDeviceContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ReleaseDeviceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ReleaseDeviceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteSupportAccessLevel : System.IEquatable<Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteSupportAccessLevel(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel Diagnostics { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel DiagnosticsAndRepair { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel left, Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel left, Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RemoteSupportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportContent>
    {
        public RemoteSupportContent() { }
        public Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportContentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteSupportJobNodeSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings>
    {
        internal RemoteSupportJobNodeSettings() { }
        public string ConnectionErrorMessage { get { throw null; } }
        public string ConnectionStatus { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string State { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteSupportJobReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties>
    {
        internal RemoteSupportJobReportedProperties() { }
        public Azure.ResourceManager.Hci.Models.EceActionStatus DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings NodeSettings { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.RemoteSupportSession> SessionDetails { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EceActionStatus ValidationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState? RemoteSupportProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession> RemoteSupportSessionDetails { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.RemoteSupportType? RemoteSupportType { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.RemoteSupportProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteSupportProvisioningState : System.IEquatable<Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteSupportProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState GrantInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState None { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState RevokeInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState left, Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState left, Azure.ResourceManager.Hci.Models.RemoteSupportProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RemoteSupportSession : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportSession>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportSession>
    {
        internal RemoteSupportSession() { }
        public Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel? AccessLevel { get { throw null; } }
        public System.DateTimeOffset? SessionEndOn { get { throw null; } }
        public string SessionId { get { throw null; } }
        public System.DateTimeOffset? SessionStartOn { get { throw null; } }
        public string TranscriptLocation { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportSession JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportSession PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.RemoteSupportSession System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportSession>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportSession>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportSession System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportSession>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportSession>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportSession>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.RemoteSupportType left, Azure.ResourceManager.Hci.Models.RemoteSupportType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.RemoteSupportType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.RemoteSupportType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.RemoteSupportType left, Azure.ResourceManager.Hci.Models.RemoteSupportType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SanAdapterIPConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SanAdapterIPConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SanAdapterIPConfig>
    {
        public SanAdapterIPConfig() { }
        public string AddressPrefix { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NetworkAdapterName { get { throw null; } set { } }
        public int? VlanId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.SanAdapterIPConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SanAdapterIPConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.SanAdapterIPConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SanAdapterIPConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SanAdapterIPConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SanAdapterIPConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SanAdapterIPConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SanAdapterIPConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SanAdapterIPConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SanAdapterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SanAdapterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SanAdapterProperties>
    {
        public SanAdapterProperties() { }
        public int? BandwidthPercentageSmb { get { throw null; } set { } }
        public int? JumboPacket { get { throw null; } set { } }
        public int? PriorityValue8021ActionCluster { get { throw null; } set { } }
        public int? PriorityValue8021ActionSmb { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.SanAdapterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SanAdapterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.SanAdapterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SanAdapterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SanAdapterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SanAdapterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SanAdapterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SanAdapterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SanAdapterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SanClusterNetworkConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig>
    {
        public SanClusterNetworkConfig() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.SanAdapterIPConfig> AdapterIPConfig { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SanAdapterProperties AdapterProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SanClusterNetworkConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SbeCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbeCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbeCredentials>
    {
        public SbeCredentials() { }
        public string EceSecretName { get { throw null; } set { } }
        public System.Uri SecretLocation { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.SbeCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SbeCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.SbeDeploymentInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SbeDeploymentInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.SbePartnerInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SbePartnerInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.SbePartnerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SbePartnerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.SbePartnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbePartnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SbePartnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SbePartnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbePartnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbePartnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SbePartnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SdnIntegrationIntent : System.IEquatable<Azure.ResourceManager.Hci.Models.SdnIntegrationIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SdnIntegrationIntent(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SdnIntegrationIntent Disable { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.SdnIntegrationIntent Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.SdnIntegrationIntent other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.SdnIntegrationIntent left, Azure.ResourceManager.Hci.Models.SdnIntegrationIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SdnIntegrationIntent (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SdnIntegrationIntent? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.SdnIntegrationIntent left, Azure.ResourceManager.Hci.Models.SdnIntegrationIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SdnProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SdnProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SdnProperties>
    {
        internal SdnProperties() { }
        public string SdnApiAddress { get { throw null; } }
        public string SdnDomainName { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SdnStatus? SdnStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.SdnProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SdnProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.SdnProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SdnProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SdnProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SdnProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SdnProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SdnProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SdnProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SdnStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.SdnStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SdnStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SdnStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.SdnStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.SdnStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.SdnStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.SdnStatus left, Azure.ResourceManager.Hci.Models.SdnStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SdnStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SdnStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.SdnStatus left, Azure.ResourceManager.Hci.Models.SdnStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretsLocationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecretsLocationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecretsLocationDetails>
    {
        public SecretsLocationDetails(Azure.ResourceManager.Hci.Models.HciSecretsType secretsType, string secretsLocation) { }
        public string SecretsLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciSecretsType SecretsType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.SecretsLocationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SecretsLocationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.SecretsLocationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecretsLocationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecretsLocationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SecretsLocationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecretsLocationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecretsLocationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecretsLocationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretsLocationsChangeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent>
    {
        public SecretsLocationsChangeContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.SecretsLocationDetails> Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityComplianceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecurityComplianceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecurityComplianceStatus>
    {
        internal SecurityComplianceStatus() { }
        public Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? DataAtRestEncrypted { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? DataInTransitProtected { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? SecuredCoreCompliance { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? WdacCompliance { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.SecurityComplianceStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SecurityComplianceStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SoftwareAssuranceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties>
    {
        public SoftwareAssuranceProperties() { }
        [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? SoftwareAssuranceIntent { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus? SoftwareAssuranceStatus { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageS2dConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageS2dConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageS2dConfig>
    {
        public StorageS2dConfig() { }
        public Azure.ResourceManager.Hci.Models.OverprovisioningRatio? OverprovisioningRatio { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciVolumeType? VolumeType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.StorageS2dConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.StorageS2dConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.StorageS2dConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageS2dConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageS2dConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.StorageS2dConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageS2dConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageS2dConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageS2dConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageSanConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageSanConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageSanConfig>
    {
        public StorageSanConfig() { }
        public string InfraPerfLunId { get { throw null; } set { } }
        public string InfraVolLunId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.StorageSanConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.StorageSanConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.StorageSanConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageSanConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.StorageSanConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.StorageSanConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageSanConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageSanConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.StorageSanConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetDeviceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration>
    {
        public TargetDeviceConfiguration() { }
        public string HostName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciNetworkAdapter> NetworkAdapters { get { throw null; } }
        public string StoragePartitionSize { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciTimeConfiguration Time { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciWebProxyConfiguration WebProxy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `HciClusterUpdatePrerequisite` moving forward.")]
    public partial class UpdatePrerequisite : Azure.ResourceManager.Hci.Models.HciClusterUpdatePrerequisite, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>
    {
        public UpdatePrerequisite() { }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.UpdateSeverity left, Azure.ResourceManager.Hci.Models.UpdateSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateSeverity (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateSeverity? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.UpdateSeverity left, Azure.ResourceManager.Hci.Models.UpdateSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState (Azure.ResourceManager.Hci.Models.HciClusterUpdateState value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterUpdateState (Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidatedSolutionRecipeCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities>
    {
        internal ValidatedSolutionRecipeCapabilities() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability> ClusterCapabilities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability> NodeCapabilities { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidatedSolutionRecipeCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability>
    {
        internal ValidatedSolutionRecipeCapability() { }
        public string CapabilityName { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidatedSolutionRecipeComponent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent>
    {
        internal ValidatedSolutionRecipeComponent() { }
        public long? InstallOrder { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload> Payloads { get { throw null; } }
        public string RequiredVersion { get { throw null; } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidatedSolutionRecipeComponentMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata>
    {
        internal ValidatedSolutionRecipeComponentMetadata() { }
        public string Catalog { get { throw null; } }
        public bool? EnableAutomaticUpgrade { get { throw null; } }
        public string ExpectedHash { get { throw null; } }
        public string ExtensionType { get { throw null; } }
        public bool? LcmUpdate { get { throw null; } }
        public string Link { get { throw null; } }
        public string Name { get { throw null; } }
        public string PreviewSource { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string ReleaseTrain { get { throw null; } }
        public string Ring { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidatedSolutionRecipeComponentPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload>
    {
        internal ValidatedSolutionRecipeComponentPayload() { }
        public string FileName { get { throw null; } }
        public string Hash { get { throw null; } }
        public string Identifier { get { throw null; } }
        public string Uri { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidatedSolutionRecipeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent>
    {
        internal ValidatedSolutionRecipeContent() { }
        public Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities Capabilities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent> Components { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo Info { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidatedSolutionRecipeInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo>
    {
        internal ValidatedSolutionRecipeInfo() { }
        public string SolutionType { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidatedSolutionRecipeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties>
    {
        internal ValidatedSolutionRecipeProperties() { }
        public Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent RecipeContent { get { throw null; } }
        public string Signature { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateOwnershipVouchersContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent>
    {
        public ValidateOwnershipVouchersContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails> ownershipVoucherDetails) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails> OwnershipVoucherDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateOwnershipVouchersResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult>
    {
        internal ValidateOwnershipVouchersResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails> OwnershipVoucherValidationDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.WindowsServerSubscription left, Azure.ResourceManager.Hci.Models.WindowsServerSubscription right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.WindowsServerSubscription (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.WindowsServerSubscription? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.WindowsServerSubscription left, Azure.ResourceManager.Hci.Models.WindowsServerSubscription right) { throw null; }
        public override string ToString() { throw null; }
    }
}
