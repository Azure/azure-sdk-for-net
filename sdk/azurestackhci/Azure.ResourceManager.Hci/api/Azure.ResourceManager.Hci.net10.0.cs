namespace Azure.ResourceManager.Hci
{
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
        public string ArcApplicationClientId { get { throw null; } set { } }
        public string ArcApplicationObjectId { get { throw null; } set { } }
        public string ArcApplicationTenantId { get { throw null; } set { } }
        public string ArcInstanceResourceGroup { get { throw null; } set { } }
        public string ArcServicePrincipalObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ArcConnectivityProperties ConnectivityProperties { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.DefaultExtensionDetails> DefaultExtensions { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.ArcIdentityResponse> CreateIdentity(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.ArcIdentityResponse>> CreateIdentityAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Models.PasswordCredential> GeneratePassword(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Models.PasswordCredential>> GeneratePasswordAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ExtensionResource> GetExtension(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ExtensionResource>> GetExtensionAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ExtensionCollection GetExtensions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InitializeDisableProcess(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InitializeDisableProcessAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcSettingResource> Reconcile(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ReconcileArcSettingsRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcSettingResource>> ReconcileAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ReconcileArcSettingsRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ClusterResource>, System.Collections.IEnumerable
    {
        protected ClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Hci.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Hci.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.ClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.ClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.ClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.ClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.ClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.ClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterData>
    {
        public ClusterData(Azure.Core.AzureLocation location) { }
        public string AadApplicationObjectId { get { throw null; } set { } }
        public string AadClientId { get { throw null; } set { } }
        public string AadServicePrincipalObjectId { get { throw null; } set { } }
        public string AadTenantId { get { throw null; } set { } }
        public string BillingModel { get { throw null; } }
        public string CloudId { get { throw null; } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ClusterPattern? ClusterPattern { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ConfidentialVmProperties ConfidentialVmProperties { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ConnectivityStatus? ConnectivityStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.IdentityProvider? IdentityProvider { get { throw null; } }
        public bool? IsManagementCluster { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration IsolatedVmAttestationConfiguration { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastBillingTimestamp { get { throw null; } }
        public System.DateTimeOffset? LastSyncTimestamp { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones> LocalAvailabilityZones { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.LogCollectionProperties LogCollectionProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RegistrationTimestamp { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.RemoteSupportProperties RemoteSupportProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ClusterReportedProperties ReportedProperties { get { throw null; } }
        public string ResourceProviderObjectId { get { throw null; } }
        public string Ring { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ClusterSdnProperties SdnProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.SecretsLocationDetails> SecretsLocations { get { throw null; } }
        public string ServiceEndpoint { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties SoftwareAssuranceProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.Status? Status { get { throw null; } }
        public float? TrialDaysRemaining { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.ClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterResource() { }
        public virtual Azure.ResourceManager.Hci.ClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterResource> ChangeRing(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ChangeRingRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterResource>> ChangeRingAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ChangeRingRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterResource> ConfigureRemoteSupport(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.RemoteSupportRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterResource>> ConfigureRemoteSupportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.RemoteSupportRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.ClusterIdentityResponse> CreateIdentity(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.ClusterIdentityResponse>> CreateIdentityAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterResource> ExtendSoftwareAssuranceBenefit(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterResource>> ExtendSoftwareAssuranceBenefitAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> GetArcSetting(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetArcSettingAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ArcSettingCollection GetArcSettings() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.OfferResource> GetByCluster(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.OfferResource> GetByClusterAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ClusterJobResource> GetClusterJob(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ClusterJobResource>> GetClusterJobAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ClusterJobCollection GetClusterJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.DeploymentSettingResource> GetDeploymentSetting(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.DeploymentSettingResource>> GetDeploymentSettingAsync(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.DeploymentSettingCollection GetDeploymentSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.PublisherResource> GetPublisher(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PublisherResource>> GetPublisherAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.PublisherCollection GetPublishers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.SecuritySettingResource> GetSecuritySetting(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.SecuritySettingResource>> GetSecuritySettingAsync(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.SecuritySettingCollection GetSecuritySettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateResource> GetUpdate(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateResource>> GetUpdateAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateCollection GetUpdates() { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateSummariesResource GetUpdateSummaries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.ClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterResource> TriggerLogCollection(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.LogCollectionRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterResource>> TriggerLogCollectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.LogCollectionRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ClusterResource> Update(Azure.ResourceManager.Hci.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ClusterResource>> UpdateAsync(Azure.ResourceManager.Hci.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterResource> UpdateSecretsLocations(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ClusterResource>> UpdateSecretsLocationsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UploadCertificate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.UploadCertificateRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UploadCertificateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.UploadCertificateRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.DeploymentSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.DeploymentSettingResource>, System.Collections.IEnumerable
    {
        protected DeploymentSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.DeploymentSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentSettingsName, Azure.ResourceManager.Hci.DeploymentSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.DeploymentSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentSettingsName, Azure.ResourceManager.Hci.DeploymentSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.DeploymentSettingResource> Get(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.DeploymentSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.DeploymentSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.DeploymentSettingResource>> GetAsync(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.DeploymentSettingResource> GetIfExists(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.DeploymentSettingResource>> GetIfExistsAsync(string deploymentSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.DeploymentSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.DeploymentSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.DeploymentSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.DeploymentSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentSettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.DeploymentSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DeploymentSettingData>
    {
        public DeploymentSettingData() { }
        public System.Collections.Generic.IList<string> ArcNodeResourceIds { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.DeploymentConfiguration DeploymentConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.DeploymentMode DeploymentMode { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OperationType? OperationType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EceReportedProperties ReportedProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.DeploymentSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.DeploymentSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.DeploymentSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.DeploymentSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DeploymentSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DeploymentSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DeploymentSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.DeploymentSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DeploymentSettingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentSettingResource() { }
        public virtual Azure.ResourceManager.Hci.DeploymentSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string deploymentSettingsName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.DeploymentSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.DeploymentSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.DeploymentSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.DeploymentSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.DeploymentSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.DeploymentSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DeploymentSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DeploymentSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.DeploymentSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.DeploymentSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.DeploymentSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.DeploymentSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.DeploymentSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation ClaimDevices(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ClaimDeviceRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClaimDevicesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ClaimDeviceRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devicePoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReleaseDevices(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReleaseDevicesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class EdgeDeviceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.EdgeDeviceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.EdgeDeviceResource>, System.Collections.IEnumerable
    {
        protected EdgeDeviceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeDeviceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string edgeDeviceName, Azure.ResourceManager.Hci.EdgeDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeDeviceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string edgeDeviceName, Azure.ResourceManager.Hci.EdgeDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceResource> Get(string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.EdgeDeviceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.EdgeDeviceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceResource>> GetAsync(string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.EdgeDeviceResource> GetIfExists(string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.EdgeDeviceResource>> GetIfExistsAsync(string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.EdgeDeviceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.EdgeDeviceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.EdgeDeviceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.EdgeDeviceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public abstract partial class EdgeDeviceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceData>
    {
        internal EdgeDeviceData() { }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.EdgeDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.EdgeDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class EdgeDeviceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeDeviceResource() { }
        public virtual Azure.ResourceManager.Hci.EdgeDeviceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string edgeDeviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource> GetEdgeDeviceJob(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource>> GetEdgeDeviceJobAsync(string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeDeviceJobCollection GetEdgeDeviceJobs() { throw null; }
        Azure.ResourceManager.Hci.EdgeDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.EdgeDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.EdgeDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.EdgeDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeDeviceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.EdgeDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.EdgeDeviceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.EdgeDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.ValidateResponse> Validate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ValidateRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.ValidateResponse>> ValidateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ValidateRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ExtensionResource>, System.Collections.IEnumerable
    {
        protected ExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Hci.ExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Hci.ExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ExtensionResource> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.ExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.ExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ExtensionResource>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.ExtensionResource> GetIfExists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.ExtensionResource>> GetIfExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.ExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.ExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExtensionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ExtensionData>
    {
        public ExtensionData() { }
        public Azure.ResourceManager.Hci.Models.ExtensionAggregateState? AggregateState { get { throw null; } }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ExtensionManagedBy? ManagedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.PerNodeExtensionState> PerNodeExtensionDetails { get { throw null; } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.ExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ExtensionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtensionResource() { }
        public virtual Azure.ResourceManager.Hci.ExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.ExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.ExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.ExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.ExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ExtensionUpgradeParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ExtensionUpgradeParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HciExtensions
    {
        public static Azure.ResourceManager.Hci.ArcSettingResource GetArcSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Models.KubernetesVersion> GetBySubscriptionLocationResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Models.KubernetesVersion> GetBySubscriptionLocationResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.ClusterResource> GetCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ClusterResource>> GetClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.ClusterJobResource GetClusterJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.ClusterResource GetClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.ClusterCollection GetClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.ClusterResource> GetClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.ClusterResource> GetClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.DeploymentSettingResource GetDeploymentSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource> GetDevicePool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource>> GetDevicePoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.DevicePoolResource GetDevicePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.DevicePoolCollection GetDevicePools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.DevicePoolResource> GetDevicePools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.DevicePoolResource> GetDevicePoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceResource> GetEdgeDevice(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceResource>> GetEdgeDeviceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource> GetEdgeDeviceJob(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource>> GetEdgeDeviceJobAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeDeviceJobResource GetEdgeDeviceJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeDeviceJobCollection GetEdgeDeviceJobs(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeDeviceResource GetEdgeDeviceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeDeviceCollection GetEdgeDevices(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource> GetEdgeMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource>> GetEdgeMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeMachineJobResource GetEdgeMachineJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeMachineResource GetEdgeMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeMachineCollection GetEdgeMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.EdgeMachineResource> GetEdgeMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.EdgeMachineResource> GetEdgeMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.ExtensionResource GetExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.OfferResource GetOfferResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.OsImageResource> GetOsImage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string osImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OsImageResource>> GetOsImageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string osImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.OsImageResource GetOsImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.OsImageCollection GetOsImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.PlatformUpdateResource> GetPlatformUpdate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string platformUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PlatformUpdateResource>> GetPlatformUpdateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string platformUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.PlatformUpdateResource GetPlatformUpdateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.PlatformUpdateCollection GetPlatformUpdates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.Hci.PublisherResource GetPublisherResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.SecuritySettingResource GetSecuritySettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.SkuResource GetSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.UpdateContentResource> GetUpdateContent(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string updateContentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateContentResource>> GetUpdateContentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string updateContentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateContentResource GetUpdateContentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateContentCollection GetUpdateContents(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateResource GetUpdateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateRunResource GetUpdateRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateSummariesResource GetUpdateSummariesResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource> GetValidatedSolutionRecipe(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string validatedSolutionRecipeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource>> GetValidatedSolutionRecipeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string validatedSolutionRecipeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource GetValidatedSolutionRecipeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.ValidatedSolutionRecipeCollection GetValidatedSolutionRecipes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse> Validate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse>> ValidateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciSkuData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>
    {
        internal HciSkuData() { }
        public string Content { get { throw null; } }
        public string ContentVersion { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string PublisherId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.SkuMappings> SkuMappings { get { throw null; } }
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
    public partial class OfferData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OfferData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OfferData>
    {
        internal OfferData() { }
        public string Content { get { throw null; } }
        public string ContentVersion { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string PublisherId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.SkuMappings> SkuMappings { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.OfferData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OfferData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OfferData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.OfferData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OfferData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OfferData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OfferData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OfferResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OfferData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OfferData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OfferResource() { }
        public virtual Azure.ResourceManager.Hci.OfferData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName, string offerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OfferResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OfferResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.SkuResource> GetSku(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.SkuResource>> GetSkuAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.SkuCollection GetSkus() { throw null; }
        Azure.ResourceManager.Hci.OfferData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OfferData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.OfferData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.OfferData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OfferData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OfferData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.OfferData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PublisherData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PublisherData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PublisherData>
    {
        internal PublisherData() { }
        public string ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.PublisherData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PublisherData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PublisherData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.PublisherData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PublisherData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PublisherData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PublisherData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublisherResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PublisherData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PublisherData>
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
        Azure.ResourceManager.Hci.PublisherData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PublisherData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.PublisherData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.PublisherData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PublisherData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PublisherData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.PublisherData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecuritySettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.SecuritySettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.SecuritySettingResource>, System.Collections.IEnumerable
    {
        protected SecuritySettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.SecuritySettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string securitySettingsName, Azure.ResourceManager.Hci.SecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.SecuritySettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string securitySettingsName, Azure.ResourceManager.Hci.SecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.SecuritySettingResource> Get(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.SecuritySettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.SecuritySettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.SecuritySettingResource>> GetAsync(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.SecuritySettingResource> GetIfExists(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.SecuritySettingResource>> GetIfExistsAsync(string securitySettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.SecuritySettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.SecuritySettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.SecuritySettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.SecuritySettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecuritySettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.SecuritySettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.SecuritySettingData>
    {
        public SecuritySettingData() { }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ComplianceAssignmentType? SecuredCoreComplianceAssignment { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.SecurityComplianceStatus SecurityComplianceStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ComplianceAssignmentType? SmbEncryptionForIntraClusterTrafficComplianceAssignment { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ComplianceAssignmentType? WdacComplianceAssignment { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.SecuritySettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.SecuritySettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.SecuritySettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.SecuritySettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.SecuritySettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.SecuritySettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.SecuritySettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecuritySettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.SecuritySettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.SecuritySettingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecuritySettingResource() { }
        public virtual Azure.ResourceManager.Hci.SecuritySettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string securitySettingsName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.SecuritySettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.SecuritySettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.SecuritySettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.SecuritySettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.SecuritySettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.SecuritySettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.SecuritySettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.SecuritySettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.SecuritySettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.SecuritySettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.SecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.SecuritySettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.SecuritySettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.SkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.SkuResource>, System.Collections.IEnumerable
    {
        protected SkuCollection() { }
        public virtual Azure.Response<bool> Exists(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.SkuResource> Get(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.SkuResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.SkuResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.SkuResource>> GetAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.SkuResource> GetIfExists(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.SkuResource>> GetIfExistsAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.SkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.SkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.SkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.SkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SkuResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SkuResource() { }
        public virtual Azure.ResourceManager.Hci.HciSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName, string offerName, string skuName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.SkuResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.SkuResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.HciSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.HciSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.HciSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.HciSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
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
    public partial class UpdateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateData>
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
        public string Location { get { throw null; } set { } }
        public string MinSbeVersionRequired { get { throw null; } set { } }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.UpdateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.UpdateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateData>
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
        public virtual Azure.ResourceManager.ArmOperation Prepare(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PrepareAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.UpdateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.UpdateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
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
    public partial class UpdateRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateRunData>
    {
        public UpdateRunData() { }
        public string Description { get { throw null; } set { } }
        public string Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        public string ExpectedExecutionTime { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTimeUtc { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public new string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? State { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciUpdateStep> Steps { get { throw null; } }
        public System.DateTimeOffset? TimeStarted { get { throw null; } set { } }
        public string UpdateRunName { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.UpdateRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.UpdateRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateRunData>
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
        Azure.ResourceManager.Hci.UpdateRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.UpdateRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UpdateSummariesData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateSummariesData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateSummariesData>
    {
        public UpdateSummariesData() { }
        public string CurrentOemVersion { get { throw null; } set { } }
        public string CurrentSbeVersion { get { throw null; } set { } }
        public string CurrentVersion { get { throw null; } set { } }
        public string HardwareModel { get { throw null; } set { } }
        public System.DateTimeOffset? HealthCheckOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPrecheckResult> HealthCheckResult { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciHealthState? HealthState { get { throw null; } set { } }
        public System.DateTimeOffset? LastChecked { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public string OemFamily { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> PackageVersions { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState? State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.UpdateSummariesData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateSummariesData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateSummariesData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.UpdateSummariesData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateSummariesData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateSummariesData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateSummariesData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateSummariesResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateSummariesData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateSummariesData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateSummariesResource() { }
        public virtual Azure.ResourceManager.Hci.UpdateSummariesData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation CheckHealth(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CheckHealthAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CheckUpdates(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.CheckUpdatesRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CheckUpdatesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.CheckUpdatesRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateSummariesResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateSummariesData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateSummariesResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateSummariesData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateSummariesResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateSummariesResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.UpdateSummariesData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateSummariesData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.UpdateSummariesData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.UpdateSummariesData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateSummariesData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateSummariesData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.UpdateSummariesData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.Hci.ArcSettingResource GetArcSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.ClusterJobResource GetClusterJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.ClusterResource GetClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.DeploymentSettingResource GetDeploymentSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.DevicePoolResource GetDevicePoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceResource> GetEdgeDevice(Azure.Core.ResourceIdentifier scope, string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceResource>> GetEdgeDeviceAsync(Azure.Core.ResourceIdentifier scope, string edgeDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource> GetEdgeDeviceJob(Azure.Core.ResourceIdentifier scope, string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeDeviceJobResource>> GetEdgeDeviceJobAsync(Azure.Core.ResourceIdentifier scope, string jobsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeDeviceJobResource GetEdgeDeviceJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeDeviceJobCollection GetEdgeDeviceJobs(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeDeviceResource GetEdgeDeviceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeDeviceCollection GetEdgeDevices(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeMachineJobResource GetEdgeMachineJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeMachineResource GetEdgeMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.ExtensionResource GetExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.OfferResource GetOfferResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.OsImageResource GetOsImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.PlatformUpdateResource GetPlatformUpdateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.PublisherResource GetPublisherResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.SecuritySettingResource GetSecuritySettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.SkuResource GetSkuResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateContentResource GetUpdateContentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateResource GetUpdateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateRunResource GetUpdateRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateSummariesResource GetUpdateSummariesResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.ValidatedSolutionRecipeResource GetValidatedSolutionRecipeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHciResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ClusterResource> GetCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ClusterResource>> GetClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ClusterCollection GetClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource> GetDevicePool(string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.DevicePoolResource>> GetDevicePoolAsync(string devicePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.DevicePoolCollection GetDevicePools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource> GetEdgeMachine(string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.EdgeMachineResource>> GetEdgeMachineAsync(string edgeMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.EdgeMachineCollection GetEdgeMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse> Validate(Azure.Core.AzureLocation location, Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse>> ValidateAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableHciSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Models.KubernetesVersion> GetBySubscriptionLocationResource(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Models.KubernetesVersion> GetBySubscriptionLocationResourceAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.ClusterResource> GetClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.ClusterResource> GetClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.DevicePoolResource> GetDevicePools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.DevicePoolResource> GetDevicePoolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.EdgeMachineResource> GetEdgeMachines(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.EdgeMachineResource> GetEdgeMachinesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ArcConnectivityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcConnectivityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcConnectivityProperties>
    {
        public ArcConnectivityProperties() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.ServiceConfiguration> ServiceConfigurations { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ArcConnectivityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ArcConnectivityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ArcConnectivityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcConnectivityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcConnectivityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcConnectivityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcConnectivityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcConnectivityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcConnectivityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcExtensionInstanceView : Azure.ResourceManager.Hci.Models.HciExtensionInstanceView
    {
        public ArcExtensionInstanceView() { }
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
    public partial class ArcIdentityResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcIdentityResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcIdentityResponse>
    {
        internal ArcIdentityResponse() { }
        public string ArcApplicationClientId { get { throw null; } }
        public string ArcApplicationObjectId { get { throw null; } }
        public string ArcApplicationTenantId { get { throw null; } }
        public string ArcServicePrincipalObjectId { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ArcIdentityResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ArcIdentityResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ArcIdentityResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcIdentityResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ArcIdentityResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ArcIdentityResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcIdentityResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcIdentityResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ArcIdentityResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Models.ArcConnectivityProperties ConnectivityProperties { get { throw null; } set { } }
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
        public static Azure.ResourceManager.Hci.Models.ArcConnectivityProperties ArcConnectivityProperties(bool? enabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ServiceConfiguration> serviceConfigurations = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcIdentityResponse ArcIdentityResponse(string arcApplicationClientId = null, string arcApplicationTenantId = null, string arcServicePrincipalObjectId = null, string arcApplicationObjectId = null) { throw null; }
        public static Azure.ResourceManager.Hci.ArcSettingData ArcSettingData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, string arcInstanceResourceGroup, System.Guid? arcApplicationClientId, System.Guid? arcApplicationTenantId, System.Guid? arcServicePrincipalObjectId, System.Guid? arcApplicationObjectId, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? aggregateState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeArcState> perNodeDetails, System.BinaryData connectivityProperties) { throw null; }
        public static Azure.ResourceManager.Hci.ArcSettingData ArcSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string arcInstanceResourceGroup = null, string arcApplicationClientId = null, string arcApplicationTenantId = null, string arcServicePrincipalObjectId = null, string arcApplicationObjectId = null, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? aggregateState = default(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeArcState> perNodeDetails = null, Azure.ResourceManager.Hci.Models.ArcConnectivityProperties connectivityProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DefaultExtensionDetails> defaultExtensions = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcSettingPatch ArcSettingPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Hci.Models.ArcConnectivityProperties connectivityProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.AssemblyInfo AssemblyInfo(string packageVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.AssemblyInfoPayload> payload = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.AssemblyInfoPayload AssemblyInfoPayload(string identifier = null, string hash = null, string fileName = null, string uri = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClaimDeviceRequest ClaimDeviceRequest(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> devices = null, string claimedBy = null) { throw null; }
        public static Azure.ResourceManager.Hci.ClusterData ClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), Azure.ResourceManager.Hci.Models.Status? status = default(Azure.ResourceManager.Hci.Models.Status?), Azure.ResourceManager.Hci.Models.ConnectivityStatus? connectivityStatus = default(Azure.ResourceManager.Hci.Models.ConnectivityStatus?), string cloudId = null, string ring = null, string cloudManagementEndpoint = null, string aadClientId = null, string aadTenantId = null, string aadApplicationObjectId = null, string aadServicePrincipalObjectId = null, Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties softwareAssuranceProperties = null, bool? isManagementCluster = default(bool?), Azure.ResourceManager.Hci.Models.LogCollectionProperties logCollectionProperties = null, Azure.ResourceManager.Hci.Models.RemoteSupportProperties remoteSupportProperties = null, Azure.ResourceManager.Hci.Models.ClusterDesiredProperties desiredProperties = null, Azure.ResourceManager.Hci.Models.ClusterReportedProperties reportedProperties = null, Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration isolatedVmAttestationConfiguration = null, float? trialDaysRemaining = default(float?), string billingModel = null, System.DateTimeOffset? registrationTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastSyncTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastBillingTimestamp = default(System.DateTimeOffset?), string serviceEndpoint = null, string resourceProviderObjectId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.SecretsLocationDetails> secretsLocations = null, Azure.ResourceManager.Hci.Models.ClusterPattern? clusterPattern = default(Azure.ResourceManager.Hci.Models.ClusterPattern?), Azure.ResourceManager.Hci.Models.ConfidentialVmProperties confidentialVmProperties = null, Azure.ResourceManager.Hci.Models.ClusterSdnProperties sdnProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones> localAvailabilityZones = null, Azure.ResourceManager.Hci.Models.IdentityProvider? identityProvider = default(Azure.ResourceManager.Hci.Models.IdentityProvider?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClusterIdentityResponse ClusterIdentityResponse(string aadClientId = null, string aadTenantId = null, string aadServicePrincipalObjectId = null, string aadApplicationObjectId = null) { throw null; }
        public static Azure.ResourceManager.Hci.ClusterJobData ClusterJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.ClusterJobProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClusterJobProperties ClusterJobProperties(string jobType = null, Azure.ResourceManager.Hci.Models.DeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.DeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.JobStatus? status = default(Azure.ResourceManager.Hci.Models.JobStatus?), Azure.ResourceManager.Hci.Models.JobReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClusterNode ClusterNode(string name = null, float? id = default(float?), Azure.ResourceManager.Hci.Models.WindowsServerSubscription? windowsServerSubscription = default(Azure.ResourceManager.Hci.Models.WindowsServerSubscription?), Azure.ResourceManager.Hci.Models.ClusterNodeType? nodeType = default(Azure.ResourceManager.Hci.Models.ClusterNodeType?), string ehcResourceId = null, string manufacturer = null, string model = null, string osName = null, string osVersion = null, string osDisplayVersion = null, string serialNumber = null, float? coreCount = default(float?), float? memoryInGiB = default(float?), System.DateTimeOffset? lastLicensingTimestamp = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.OemActivation? oemActivation = default(Azure.ResourceManager.Hci.Models.OemActivation?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClusterPatch ClusterPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string cloudManagementEndpoint = null, string aadClientId = null, string aadTenantId = null, Azure.ResourceManager.Hci.Models.ClusterDesiredProperties desiredProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClusterReportedProperties ClusterReportedProperties(string clusterName = null, string clusterId = null, string clusterVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ClusterNode> nodes = null, System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?), System.DateTimeOffset? msiExpirationTimeStamp = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.ImdsAttestation? imdsAttestation = default(Azure.ResourceManager.Hci.Models.ImdsAttestation?), Azure.ResourceManager.Hci.Models.DiagnosticLevel? diagnosticLevel = default(Azure.ResourceManager.Hci.Models.DiagnosticLevel?), System.Collections.Generic.IEnumerable<string> supportedCapabilities = null, Azure.ResourceManager.Hci.Models.ClusterNodeType? clusterType = default(Azure.ResourceManager.Hci.Models.ClusterNodeType?), string manufacturer = null, Azure.ResourceManager.Hci.Models.OemActivation? oemActivation = default(Azure.ResourceManager.Hci.Models.OemActivation?), Azure.ResourceManager.Hci.Models.HardwareClass? hardwareClass = default(Azure.ResourceManager.Hci.Models.HardwareClass?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClusterSdnProperties ClusterSdnProperties(Azure.ResourceManager.Hci.Models.SdnStatus? sdnStatus = default(Azure.ResourceManager.Hci.Models.SdnStatus?), string sdnDomainName = null, string sdnApiAddress = null, Azure.ResourceManager.Hci.Models.SdnIntegrationIntent? sdnIntegrationIntent = default(Azure.ResourceManager.Hci.Models.SdnIntegrationIntent?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ConfidentialVmProfile ConfidentialVmProfile(Azure.ResourceManager.Hci.Models.IgvmStatus? igvmStatus = default(Azure.ResourceManager.Hci.Models.IgvmStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.IgvmStatusDetail> statusDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ConfidentialVmProperties ConfidentialVmProperties(Azure.ResourceManager.Hci.Models.ConfidentialVmIntent? confidentialVmIntent = default(Azure.ResourceManager.Hci.Models.ConfidentialVmIntent?), Azure.ResourceManager.Hci.Models.ConfidentialVmStatus? confidentialVmStatus = default(Azure.ResourceManager.Hci.Models.ConfidentialVmStatus?), string confidentialVmStatusSummary = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ContentPayload ContentPayload(string uri = null, string hash = null, string hashAlgorithm = null, string identifier = null, string packageSizeInBytes = null, string group = null, string fileName = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DefaultExtensionDetails DefaultExtensionDetails(string category = null, System.DateTimeOffset? consentOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeploymentCluster DeploymentCluster(string name = null, string witnessType = null, string witnessPath = null, string cloudAccountName = null, string azureServiceEndpoint = null, Azure.ResourceManager.Hci.Models.HardwareClass? hardwareClass = default(Azure.ResourceManager.Hci.Models.HardwareClass?), Azure.ResourceManager.Hci.Models.ClusterPattern? clusterPattern = default(Azure.ResourceManager.Hci.Models.ClusterPattern?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeploymentConfiguration DeploymentConfiguration(string version = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ScaleUnits> scaleUnits = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeploymentData DeploymentData(Azure.ResourceManager.Hci.Models.DeploymentSecuritySettings securitySettings = null, Azure.ResourceManager.Hci.Models.Observability observability = null, Azure.ResourceManager.Hci.Models.DeploymentCluster cluster = null, Azure.ResourceManager.Hci.Models.IdentityProvider? identityProvider = default(Azure.ResourceManager.Hci.Models.IdentityProvider?), string storageConfigurationMode = null, string namingPrefix = null, string domainFqdn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.InfrastructureNetwork> infrastructureNetwork = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PhysicalNodes> physicalNodes = null, Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork hostNetwork = null, Azure.ResourceManager.Hci.Models.NetworkController sdnIntegrationNetworkController = null, bool? isManagementCluster = default(bool?), string adouPath = null, string secretsLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets> secrets = null, string optionalServicesCustomLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones> localAvailabilityZones = null, Azure.ResourceManager.Hci.Models.AssemblyInfo assemblyInfo = null) { throw null; }
        public static Azure.ResourceManager.Hci.DeploymentSettingData DeploymentSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.Collections.Generic.IEnumerable<string> arcNodeResourceIds = null, Azure.ResourceManager.Hci.Models.DeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.DeploymentMode?), Azure.ResourceManager.Hci.Models.OperationType? operationType = default(Azure.ResourceManager.Hci.Models.OperationType?), Azure.ResourceManager.Hci.Models.DeploymentConfiguration deploymentConfiguration = null, Azure.ResourceManager.Hci.Models.EceReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork DeploymentSettingHostNetwork(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentSettingIntents> intents = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks> storageNetworks = null, bool? storageConnectivitySwitchless = default(bool?), bool? enableStorageAutoIp = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeploymentSettingIntents DeploymentSettingIntents(string name = null, System.Collections.Generic.IEnumerable<string> trafficType = null, System.Collections.Generic.IEnumerable<string> adapter = null, bool? overrideVirtualSwitchConfiguration = default(bool?), Azure.ResourceManager.Hci.Models.DeploymentSettingVirtualSwitchConfigurationOverrides virtualSwitchConfigurationOverrides = null, bool? overrideQosPolicy = default(bool?), Azure.ResourceManager.Hci.Models.QosPolicyOverrides qosPolicyOverrides = null, bool? overrideAdapterProperty = default(bool?), Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides adapterPropertyOverrides = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeploymentSettingStorageNetworks DeploymentSettingStorageNetworks(string name = null, string networkAdapterName = null, string vlanId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo> storageAdapterIPInfo = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeploymentStep DeploymentStep(string name = null, string description = null, string fullStepIndex = null, string startTimeUtc = null, string endTimeUtc = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentStep> steps = null, System.Collections.Generic.IEnumerable<string> exception = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeviceDetail DeviceDetail(Azure.Core.ResourceIdentifier deviceResourceId = null, string claimedBy = null) { throw null; }
        public static Azure.ResourceManager.Hci.DevicePoolData DevicePoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.DevicePoolProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DevicePoolPatch DevicePoolPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DevicePoolProperties DevicePoolProperties(Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string cloudId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeviceDetail> devices = null, Azure.Core.ResourceIdentifier customLocationResourceId = null, string customLocationName = null, string managedResourceGroup = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.OperationDetail> operationDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DnsZones DnsZones(string dnsZoneName = null, System.Collections.Generic.IEnumerable<string> dnsForwarder = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DownloadOsJobProperties DownloadOsJobProperties(Azure.ResourceManager.Hci.Models.DeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.DeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.JobStatus? status = default(Azure.ResourceManager.Hci.Models.JobStatus?), Azure.ResponseError error = null, Azure.ResourceManager.Hci.Models.DownloadRequest downloadRequest = null, Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EceActionStatus EceActionStatus(string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DeploymentStep> steps = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EceReportedProperties EceReportedProperties(Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeDeviceData EdgeDeviceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeDeviceJobData EdgeDeviceJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeDeviceProperties EdgeDeviceProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration deviceConfiguration = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobProperties EdgeMachineCollectLogJobProperties(Azure.ResourceManager.Hci.Models.DeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.DeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.JobStatus? status = default(Azure.ResourceManager.Hci.Models.JobStatus?), Azure.ResponseError error = null, System.DateTimeOffset fromDate = default(System.DateTimeOffset), System.DateTimeOffset toDate = default(System.DateTimeOffset), System.DateTimeOffset? lastLogGenerated = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties EdgeMachineCollectLogJobReportedProperties(int? percentComplete = default(int?), Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.LogCollectionJobSession> logCollectionSessionDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeMachineData EdgeMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.EdgeMachineProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Hci.EdgeMachineJobData EdgeMachineJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties EdgeMachineJobProperties(string jobType = null, Azure.ResourceManager.Hci.Models.DeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.DeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.JobStatus? status = default(Azure.ResourceManager.Hci.Models.JobStatus?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile EdgeMachineNetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail> nicDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail> switchDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineNicDetail EdgeMachineNicDetail(string adapterName = null, string interfaceDescription = null, string componentId = null, string driverVersion = null, string ip4Address = null, string subnetMask = null, string defaultGateway = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, string defaultIsolationId = null, string macAddress = null, string slot = null, string switchName = null, string nicType = null, string vlanId = null, string nicStatus = null, Azure.ResourceManager.Hci.Models.RdmaCapability? rdmaCapability = default(Azure.ResourceManager.Hci.Models.RdmaCapability?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachinePatch EdgeMachinePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineProperties EdgeMachineProperties(Azure.ResourceManager.Hci.Models.EdgeMachineKind? edgeMachineKind = default(Azure.ResourceManager.Hci.Models.EdgeMachineKind?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string cloudId = null, Azure.Core.ResourceIdentifier arcMachineResourceGroupId = null, Azure.Core.ResourceIdentifier arcMachineResourceId = null, Azure.Core.ResourceIdentifier arcGatewayResourceId = null, Azure.ResourceManager.Hci.Models.SiteDetails siteDetails = null, Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails ownershipVoucherDetails = null, Azure.ResourceManager.Hci.Models.ProvisioningDetails provisioningDetails = null, string devicePoolResourceId = null, Azure.ResourceManager.Hci.Models.EdgeMachineState? machineState = default(Azure.ResourceManager.Hci.Models.EdgeMachineState?), Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus? connectivityStatus = default(Azure.ResourceManager.Hci.Models.EdgeMachineConnectivityStatus?), string claimedBy = null, Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties reportedProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.OperationDetail> operationDetails = null, System.DateTimeOffset? lastSyncTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobProperties EdgeMachineRemoteSupportJobProperties(Azure.ResourceManager.Hci.Models.DeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.DeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.JobStatus? status = default(Azure.ResourceManager.Hci.Models.JobStatus?), Azure.ResponseError error = null, Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel accessLevel = default(Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel), System.DateTimeOffset expirationTimestamp = default(System.DateTimeOffset), Azure.ResourceManager.Hci.Models.RemoteSupportType type = default(Azure.ResourceManager.Hci.Models.RemoteSupportType), Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportJobReportedProperties EdgeMachineRemoteSupportJobReportedProperties(int? percentComplete = default(int?), Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null, Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings nodeSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.RemoteSupportSession> sessionDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineRemoteSupportNodeSettings EdgeMachineRemoteSupportNodeSettings(string state = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string connectionStatus = null, string connectionErrorMessage = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties EdgeMachineReportedProperties(System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile networkProfile = null, Azure.ResourceManager.Hci.Models.OsProfile osProfile = null, Azure.ResourceManager.Hci.Models.HardwareProfile hardwareProfile = null, long? storagePoolableDisksCount = default(long?), Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo sbeDeploymentPackageInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> extensions = null) { throw null; }
        public static Azure.ResourceManager.Hci.ExtensionData ExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), Azure.ResourceManager.Hci.Models.ExtensionAggregateState? aggregateState = default(Azure.ResourceManager.Hci.Models.ExtensionAggregateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeExtensionState> perNodeExtensionDetails = null, Azure.ResourceManager.Hci.Models.ExtensionManagedBy? managedBy = default(Azure.ResourceManager.Hci.Models.ExtensionManagedBy?), string forceUpdateTag = null, string publisher = null, string type = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, bool? enableAutomaticUpgrade = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus ExtensionInstanceViewStatus(string code = null, Azure.ResourceManager.Hci.Models.StatusLevelTypes? level = default(Azure.ResourceManager.Hci.Models.StatusLevelTypes?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HardwareProfile HardwareProfile(long? cpuCores = default(long?), long? cpuSockets = default(long?), long? memoryCapacityInGb = default(long?), string model = null, string manufacturer = null, string serialNumber = null, string processorType = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciCollectLogJobProperties HciCollectLogJobProperties(Azure.ResourceManager.Hci.Models.DeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.DeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.JobStatus? status = default(Azure.ResourceManager.Hci.Models.JobStatus?), System.DateTimeOffset fromDate = default(System.DateTimeOffset), System.DateTimeOffset toDate = default(System.DateTimeOffset), System.DateTimeOffset? lastLogGenerated = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciConfigureCvmJobProperties HciConfigureCvmJobProperties(Azure.ResourceManager.Hci.Models.DeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.DeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.JobStatus? status = default(Azure.ResourceManager.Hci.Models.JobStatus?), Azure.ResourceManager.Hci.Models.JobReportedProperties reportedProperties = null, Azure.ResourceManager.Hci.Models.ConfidentialVmIntent confidentialVmIntent = default(Azure.ResourceManager.Hci.Models.ConfidentialVmIntent)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciConfigureSdnIntegrationJobProperties HciConfigureSdnIntegrationJobProperties(Azure.ResourceManager.Hci.Models.DeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.DeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.JobStatus? status = default(Azure.ResourceManager.Hci.Models.JobStatus?), Azure.ResourceManager.Hci.Models.JobReportedProperties reportedProperties = null, Azure.ResourceManager.Hci.Models.SdnIntegrationIntent sdnIntegrationIntent = default(Azure.ResourceManager.Hci.Models.SdnIntegrationIntent), string sdnPrefix = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDevice HciEdgeDevice(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides HciEdgeDeviceAdapterPropertyOverrides(string jumboPacket = null, string networkDirect = null, string networkDirectTechnology = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension HciEdgeDeviceArcExtension(string extensionName = null, Azure.ResourceManager.Hci.Models.ArcExtensionState? state = default(Azure.ResourceManager.Hci.Models.ArcExtensionState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciValidationFailureDetail> errorDetails = null, Azure.Core.ResourceIdentifier extensionResourceId = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.ExtensionManagedBy? managedBy = default(Azure.ResourceManager.Hci.Models.ExtensionManagedBy?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration HciEdgeDeviceConfiguration(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail> nicDetails = null, string deviceMetadata = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork HciEdgeDeviceHostNetwork(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents> intents = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks> storageNetworks = null, bool? storageConnectivitySwitchless = default(bool?), bool? enableStorageAutoIp = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceIntents HciEdgeDeviceIntents(long? scope = default(long?), long? intentType = default(long?), bool? isComputeIntentSet = default(bool?), bool? isStorageIntentSet = default(bool?), bool? isOnlyStorage = default(bool?), bool? isManagementIntentSet = default(bool?), bool? isStretchIntentSet = default(bool?), bool? isOnlyStretch = default(bool?), bool? isNetworkIntentType = default(bool?), string intentName = null, System.Collections.Generic.IEnumerable<string> intentAdapters = null, bool? overrideVirtualSwitchConfiguration = default(bool?), Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides virtualSwitchConfigurationOverrides = null, bool? overrideQosPolicy = default(bool?), Azure.ResourceManager.Hci.Models.QosPolicyOverrides qosPolicyOverrides = null, bool? overrideAdapterProperty = default(bool?), Azure.ResourceManager.Hci.Models.HciEdgeDeviceAdapterPropertyOverrides adapterPropertyOverrides = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceJob HciEdgeDeviceJob(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties HciEdgeDeviceJobProperties(Azure.ResourceManager.Hci.Models.DeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.DeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.JobStatus? status = default(Azure.ResourceManager.Hci.Models.JobStatus?), string jobType = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceNicDetail HciEdgeDeviceNicDetail(string adapterName = null, string interfaceDescription = null, string componentId = null, string driverVersion = null, string ip4Address = null, string subnetMask = null, string defaultGateway = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, string defaultIsolationId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties HciEdgeDeviceProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration deviceConfiguration, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties HciEdgeDeviceProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration deviceConfiguration = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), Azure.ResourceManager.Hci.Models.HciReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo HciEdgeDeviceStorageAdapterIPInfo(string physicalNode = null, string ipv4Address = null, string subnetMask = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageNetworks HciEdgeDeviceStorageNetworks(string name = null, string networkAdapterName = null, string storageVlanId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceStorageAdapterIPInfo> storageAdapterIPInfo = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail HciEdgeDeviceSwitchDetail(string switchName = null, string switchType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.SwitchExtension> extensions = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciEdgeDeviceVirtualSwitchConfigurationOverrides HciEdgeDeviceVirtualSwitchConfigurationOverrides(string enableIov = null, string loadBalancingAlgorithm = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciExtensionInstanceView HciExtensionInstanceView(string name = null, string type = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNetworkProfile HciNetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciNicDetail> nicDetails, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail> switchDetails, Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork hostNetwork) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNetworkProfile HciNetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciNicDetail> nicDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceSwitchDetail> switchDetails = null, Azure.ResourceManager.Hci.Models.HciEdgeDeviceHostNetwork hostNetwork = null, Azure.ResourceManager.Hci.Models.SdnProperties sdnProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNicDetail HciNicDetail(string adapterName, string interfaceDescription, string componentId, string driverVersion, string ipv4Address, string subnetMask, string defaultGateway, System.Collections.Generic.IEnumerable<string> dnsServers, string defaultIsolationId, string macAddress, string slot, string switchName, string nicType, string vlanId, string nicStatus) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNicDetail HciNicDetail(string adapterName = null, string interfaceDescription = null, string componentId = null, string driverVersion = null, string ip4Address = null, string subnetMask = null, string defaultGateway = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, string defaultIsolationId = null, string macAddress = null, string slot = null, string switchName = null, string nicType = null, string vlanId = null, string nicStatus = null, Azure.ResourceManager.Hci.Models.RdmaCapability? rdmaCapability = default(Azure.ResourceManager.Hci.Models.RdmaCapability?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciOSProfile HciOSProfile(string bootType = null, string assemblyVersion = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciRemoteSupportJobProperties HciRemoteSupportJobProperties(Azure.ResourceManager.Hci.Models.DeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.DeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.JobStatus? status = default(Azure.ResourceManager.Hci.Models.JobStatus?), Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel accessLevel = default(Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel), System.DateTimeOffset expirationTimestamp = default(System.DateTimeOffset), Azure.ResourceManager.Hci.Models.RemoteSupportType type = default(Azure.ResourceManager.Hci.Models.RemoteSupportType), Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciReportedProperties HciReportedProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState? deviceState = default(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState?), Azure.ResourceManager.Hci.Models.ExtensionProfile extensionProfile = null, System.DateTimeOffset? lastSyncTimestamp = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.ConfidentialVmProfile confidentialVmProfile = null, Azure.ResourceManager.Hci.Models.HciNetworkProfile networkProfile = null, Azure.ResourceManager.Hci.Models.HciOSProfile osProfile = null, Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo sbeDeploymentPackageInfo = null, long? storagePoolableDisksCount = default(long?), string hardwareProcessorType = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciReportedProperties HciReportedProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState? deviceState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> extensions, Azure.ResourceManager.Hci.Models.HciNetworkProfile networkProfile, Azure.ResourceManager.Hci.Models.HciOSProfile osProfile, Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo sbeDeploymentPackageInfo) { throw null; }
        public static Azure.ResourceManager.Hci.HciSkuData HciSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string publisherId = null, string offerId = null, string content = null, string contentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.SkuMappings> skuMappings = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciUpdateStep HciUpdateStep(string name = null, string description = null, string errorMessage = null, string status = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedTimeUtc = default(System.DateTimeOffset?), string expectedExecutionTime = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUpdateStep> steps = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciValidationFailureDetail HciValidationFailureDetail(string exception = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.IgvmStatusDetail IgvmStatusDetail(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.InfrastructureNetwork InfrastructureNetwork(string subnetMask = null, string gateway = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.IpPools> ipPools = null, Azure.ResourceManager.Hci.Models.DnsServerConfig? dnsServerConfig = default(Azure.ResourceManager.Hci.Models.DnsServerConfig?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DnsZones> dnsZones = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, bool? useDhcp = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.IsolatedVmAttestationConfiguration IsolatedVmAttestationConfiguration(Azure.Core.ResourceIdentifier attestationResourceId = null, string relyingPartyServiceEndpoint = null, string attestationServiceEndpoint = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.JobReportedProperties JobReportedProperties(int? percentComplete = default(int?), Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.KubernetesVersion KubernetesVersion(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kubernetesVersionValue = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LocalAvailabilityZones LocalAvailabilityZones(string localAvailabilityZoneName = null, System.Collections.Generic.IEnumerable<string> nodes = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionError LogCollectionError(string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionJobSession LogCollectionJobSession(string startTime = null, string endTime = null, string timeCollected = null, int? logSize = default(int?), Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus? status = default(Azure.ResourceManager.Hci.Models.DeviceLogCollectionStatus?), string correlationId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionProperties LogCollectionProperties(System.DateTimeOffset? fromDate = default(System.DateTimeOffset?), System.DateTimeOffset? toDate = default(System.DateTimeOffset?), System.DateTimeOffset? lastLogGenerated = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.LogCollectionSession> logCollectionSessionDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties LogCollectionReportedProperties(int? percentComplete = default(int?), Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.LogCollectionJobSession> logCollectionSessionDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionRequestProperties LogCollectionRequestProperties(System.DateTimeOffset fromDate = default(System.DateTimeOffset), System.DateTimeOffset toDate = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.LogCollectionSession LogCollectionSession(System.DateTimeOffset? logStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? logEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? timeCollected = default(System.DateTimeOffset?), long? logSize = default(long?), Azure.ResourceManager.Hci.Models.LogCollectionStatus? logCollectionStatus = default(Azure.ResourceManager.Hci.Models.LogCollectionStatus?), Azure.ResourceManager.Hci.Models.LogCollectionJobType? logCollectionJobType = default(Azure.ResourceManager.Hci.Models.LogCollectionJobType?), string correlationId = null, System.DateTimeOffset? endTimeCollected = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.LogCollectionError logCollectionError = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.NetworkAdapter NetworkAdapter(Azure.ResourceManager.Hci.Models.IpAssignmentType ipAssignmentType = default(Azure.ResourceManager.Hci.Models.IpAssignmentType), string ipAddress = null, string adapterName = null, string macAddress = null, Azure.ResourceManager.Hci.Models.IpAddressRange ipAddressRange = null, string gateway = null, string subnetMask = null, System.Collections.Generic.IEnumerable<string> dnsAddressArray = null, string vlanId = null) { throw null; }
        public static Azure.ResourceManager.Hci.OfferData OfferData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string publisherId = null, string content = null, string contentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.SkuMappings> skuMappings = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OperationDetail OperationDetail(string name = null, string id = null, string type = null, Azure.Core.ResourceIdentifier resourceId = null, string description = null, string status = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Hci.OsImageData OsImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.OsImageProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OsImageProperties OsImageProperties(string validatedSolutionRecipeVersion = null, string composedImageVersion = null, string composedImageIsoUri = null, string composedImageIsoHash = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OsProfile OsProfile(string bootType = null, string assemblyVersion = null, string osType = null, string osSku = null, string osVersion = null, string buildNumber = null, string baseImageVersion = null, string imageVersion = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails OwnershipVoucherValidationDetails(Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus? validationStatus = default(Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationStatus?), string serialNumber = null, string id = null, string manufacturer = null, string modelName = null, string version = null, string azureMachineId = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PasswordCredential PasswordCredential(string secretText = null, string keyId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeArcState PerNodeArcState(string name, string arcInstance, Azure.ResourceManager.Hci.Models.NodeArcState? state) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeArcState PerNodeArcState(string name = null, string arcInstance = null, string arcNodeServicePrincipalObjectId = null, Azure.ResourceManager.Hci.Models.NodeArcState? state = default(Azure.ResourceManager.Hci.Models.NodeArcState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeExtensionState PerNodeExtensionState(string name, string extension, string typeHandlerVersion, Azure.ResourceManager.Hci.Models.NodeExtensionState? state, Azure.ResourceManager.Hci.Models.ArcExtensionInstanceView extensionInstanceView) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeExtensionState PerNodeExtensionState(string name = null, string extension = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.NodeExtensionState? state = default(Azure.ResourceManager.Hci.Models.NodeExtensionState?), Azure.ResourceManager.Hci.Models.HciExtensionInstanceView instanceView = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession PerNodeRemoteSupportSession(System.DateTimeOffset? sessionStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? sessionEndOn = default(System.DateTimeOffset?), string nodeName = null, long? duration = default(long?), Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? accessLevel = default(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PlatformPayload PlatformPayload(string payloadUri = null, string payloadHash = null, string payloadPackageSizeInBytes = null, string payloadIdentifier = null) { throw null; }
        public static Azure.ResourceManager.Hci.PlatformUpdateData PlatformUpdateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PlatformUpdateDetails> platformUpdateDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PlatformUpdateDetails PlatformUpdateDetails(string validatedSolutionRecipeVersion = null, string platformVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PlatformPayload> platformPayloads = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ProvisioningDetails ProvisioningDetails(Azure.ResourceManager.Hci.Models.OsProvisionProfile osProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.UserDetails> userDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ProvisioningRequest ProvisioningRequest(Azure.ResourceManager.Hci.Models.ProvisioningOsType target = default(Azure.ResourceManager.Hci.Models.ProvisioningOsType), Azure.ResourceManager.Hci.Models.OsProvisionProfile osProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.UserDetails> userDetails = null, Azure.ResourceManager.Hci.Models.OnboardingConfiguration onboardingConfiguration = null, Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration deviceConfiguration = null, string customConfiguration = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ProvisionOsJobProperties ProvisionOsJobProperties(Azure.ResourceManager.Hci.Models.DeploymentMode? deploymentMode = default(Azure.ResourceManager.Hci.Models.DeploymentMode?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string jobId = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.JobStatus? status = default(Azure.ResourceManager.Hci.Models.JobStatus?), Azure.ResponseError error = null, Azure.ResourceManager.Hci.Models.ProvisioningRequest provisioningRequest = null, Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties reportedProperties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ProvisionOsReportedProperties ProvisionOsReportedProperties(int? percentComplete = default(int?), Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.PublisherData PublisherData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest ReleaseDeviceRequest(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> devices = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings RemoteSupportJobNodeSettings(string state = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string connectionStatus = null, string connectionErrorMessage = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportJobReportedProperties RemoteSupportJobReportedProperties(int? percentComplete = default(int?), Azure.ResourceManager.Hci.Models.EceActionStatus validationStatus = null, Azure.ResourceManager.Hci.Models.EceActionStatus deploymentStatus = null, Azure.ResourceManager.Hci.Models.RemoteSupportJobNodeSettings nodeSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.RemoteSupportSession> sessionDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings RemoteSupportNodeSettings(string arcResourceId = null, string state = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string connectionStatus = null, string connectionErrorMessage = null, string transcriptLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportProperties RemoteSupportProperties(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? accessLevel = default(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel?), System.DateTimeOffset? expirationTimeStamp = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.RemoteSupportType? remoteSupportType = default(Azure.ResourceManager.Hci.Models.RemoteSupportType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings> remoteSupportNodeSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeRemoteSupportSession> remoteSupportSessionDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportRequestProperties RemoteSupportRequestProperties(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? accessLevel = default(Azure.ResourceManager.Hci.Models.HciClusterAccessLevel?), System.DateTimeOffset? expirationTimeStamp = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.RemoteSupportType? remoteSupportType = default(Azure.ResourceManager.Hci.Models.RemoteSupportType?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.RemoteSupportSession RemoteSupportSession(string sessionId = null, System.DateTimeOffset? sessionStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? sessionEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel? accessLevel = default(Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel?), string transcriptLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ReportedProperties ReportedProperties(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState? deviceState = default(Azure.ResourceManager.Hci.Models.HciEdgeDeviceState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> extensions = null, System.DateTimeOffset? lastSyncTimestamp = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.ConfidentialVmProfile confidentialVmProfile = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo SbeDeploymentPackageInfo(string code = null, string message = null, string sbeManifest = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SbePartnerInfo SbePartnerInfo(Azure.ResourceManager.Hci.Models.SbeDeploymentInfo sbeDeploymentInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.SbePartnerProperties> partnerProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.SbeCredentials> credentialList = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SdnProperties SdnProperties(Azure.ResourceManager.Hci.Models.SdnStatus? sdnStatus = default(Azure.ResourceManager.Hci.Models.SdnStatus?), string sdnDomainName = null, string sdnApiAddress = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest SecretsLocationsChangeRequest(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.SecretsLocationDetails> properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SecurityComplianceStatus SecurityComplianceStatus(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? securedCoreCompliance = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus?), Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? wdacCompliance = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus?), Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? dataAtRestEncrypted = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus?), Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? dataInTransitProtected = default(Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus?), System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.SecuritySettingData SecuritySettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.ComplianceAssignmentType? securedCoreComplianceAssignment = default(Azure.ResourceManager.Hci.Models.ComplianceAssignmentType?), Azure.ResourceManager.Hci.Models.ComplianceAssignmentType? wdacComplianceAssignment = default(Azure.ResourceManager.Hci.Models.ComplianceAssignmentType?), Azure.ResourceManager.Hci.Models.ComplianceAssignmentType? smbEncryptionForIntraClusterTrafficComplianceAssignment = default(Azure.ResourceManager.Hci.Models.ComplianceAssignmentType?), Azure.ResourceManager.Hci.Models.SecurityComplianceStatus securityComplianceStatus = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SkuMappings SkuMappings(string catalogPlanId = null, string marketplaceSkuId = null, System.Collections.Generic.IEnumerable<string> marketplaceSkuVersions = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties SoftwareAssuranceProperties(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus? softwareAssuranceStatus = default(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus?), Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? softwareAssuranceIntent = default(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent?), System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SwitchExtension SwitchExtension(string switchId = null, string extensionName = null, bool? extensionEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateContentData UpdateContentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ContentPayload> updatePayloads = null) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateData UpdateData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.AzureLocation? location, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, System.DateTimeOffset? installedOn, string description, Azure.ResourceManager.Hci.Models.HciUpdateState? state, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.UpdatePrerequisite> prerequisites, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> componentVersions, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement? rebootRequired, Azure.ResourceManager.Hci.Models.HciHealthState? healthState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult, System.DateTimeOffset? healthCheckOn, string packagePath, float? packageSizeInMb, string displayName, string version, string publisher, string releaseLink, Azure.ResourceManager.Hci.Models.HciAvailabilityType? availabilityType, string packageType, string additionalProperties, float? progressPercentage, string notifyMessage) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateData UpdateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.DateTimeOffset? installedOn = default(System.DateTimeOffset?), string description = null, string minSbeVersionRequired = null, Azure.ResourceManager.Hci.Models.HciUpdateState? state = default(Azure.ResourceManager.Hci.Models.HciUpdateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.UpdatePrerequisite> prerequisites = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> componentVersions = null, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement? rebootRequired = default(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement?), Azure.ResourceManager.Hci.Models.HciHealthState? healthState = default(Azure.ResourceManager.Hci.Models.HciHealthState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult = null, System.DateTimeOffset? healthCheckOn = default(System.DateTimeOffset?), string packagePath = null, float? packageSizeInMb = default(float?), string displayName = null, string version = null, string publisher = null, string releaseLink = null, Azure.ResourceManager.Hci.Models.HciAvailabilityType? availabilityType = default(Azure.ResourceManager.Hci.Models.HciAvailabilityType?), string packageType = null, string additionalProperties = null, float? progressPercentage = default(float?), string notifyMessage = null, string location = null) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateRunData UpdateRunData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.AzureLocation? location, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, System.DateTimeOffset? timeStarted, System.DateTimeOffset? lastUpdatedOn, string duration, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? state, string namePropertiesProgressName, string description, string errorMessage, string status, System.DateTimeOffset? startTimeUtc, System.DateTimeOffset? endTimeUtc, System.DateTimeOffset? lastUpdatedTimeUtc, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUpdateStep> steps) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateRunData UpdateRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.DateTimeOffset? timeStarted = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), string duration = null, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? state = default(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState?), string name0 = null, string description = null, string errorMessage = null, string status = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedTimeUtc = default(System.DateTimeOffset?), string expectedExecutionTime = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUpdateStep> steps = null, string updateRunName = null, string location = null) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateSummariesData UpdateSummariesData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string oemFamily = null, string currentOemVersion = null, string hardwareModel = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> packageVersions = null, string currentVersion = null, string currentSbeVersion = null, System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?), System.DateTimeOffset? lastChecked = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciHealthState? healthState = default(Azure.ResourceManager.Hci.Models.HciHealthState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult = null, System.DateTimeOffset? healthCheckOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState? state = default(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState?), string location = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.UserDetails UserDetails(string userName = null, Azure.ResourceManager.Hci.Models.SecretType secretType = default(Azure.ResourceManager.Hci.Models.SecretType), string secretLocation = null, System.Collections.Generic.IEnumerable<string> sshPubKey = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities ValidatedSolutionRecipeCapabilities(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability> clusterCapabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability> nodeCapabilities = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapability ValidatedSolutionRecipeCapability(string capabilityName = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent ValidatedSolutionRecipeComponent(string name = null, string type = null, string requiredVersion = null, long? installOrder = default(long?), System.Collections.Generic.IEnumerable<string> tags = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload> payloads = null, Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata metadata = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentMetadata ValidatedSolutionRecipeComponentMetadata(string extensionType = null, string publisher = null, bool? enableAutomaticUpgrade = default(bool?), bool? lcmUpdate = default(bool?), string catalog = null, string ring = null, string releaseTrain = null, string link = null, string name = null, string expectedHash = null, string previewSource = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponentPayload ValidatedSolutionRecipeComponentPayload(string identifier = null, string hash = null, string fileName = null, string uri = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent ValidatedSolutionRecipeContent(Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo info = null, Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeCapabilities capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeComponent> components = null) { throw null; }
        public static Azure.ResourceManager.Hci.ValidatedSolutionRecipeData ValidatedSolutionRecipeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeInfo ValidatedSolutionRecipeInfo(string solutionType = null, string version = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeProperties ValidatedSolutionRecipeProperties(Azure.ResourceManager.Hci.Models.ValidatedSolutionRecipeContent recipeContent = null, string signature = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest ValidateOwnershipVouchersRequest(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails> ownershipVoucherDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse ValidateOwnershipVouchersResponse(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails> ownershipVoucherValidationDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidateRequest ValidateRequest(System.Collections.Generic.IEnumerable<string> edgeDeviceIds = null, string additionalInfo = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ValidateResponse ValidateResponse(string status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.WebProxyConfiguration WebProxyConfiguration(System.Uri connectionUri = null, string port = null, System.Collections.Generic.IEnumerable<System.Uri> bypassList = null) { throw null; }
    }
    public partial class AssemblyInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.AssemblyInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.AssemblyInfo>
    {
        public AssemblyInfo() { }
        public string PackageVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.AssemblyInfoPayload> Payload { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.AssemblyInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.AssemblyInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.AssemblyInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.AssemblyInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.AssemblyInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.AssemblyInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.AssemblyInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.AssemblyInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.AssemblyInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ChangeRingRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ChangeRingRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ChangeRingRequest>
    {
        public ChangeRingRequest() { }
        public string TargetRing { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.ChangeRingRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ChangeRingRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ChangeRingRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ChangeRingRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ChangeRingRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ChangeRingRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ChangeRingRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ChangeRingRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ChangeRingRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckUpdatesRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.CheckUpdatesRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.CheckUpdatesRequest>
    {
        public CheckUpdatesRequest() { }
        public string UpdateName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.CheckUpdatesRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.CheckUpdatesRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.CheckUpdatesRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.CheckUpdatesRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.CheckUpdatesRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.CheckUpdatesRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.CheckUpdatesRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.CheckUpdatesRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.CheckUpdatesRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClaimDeviceRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClaimDeviceRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClaimDeviceRequest>
    {
        public ClaimDeviceRequest(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> devices) { }
        public string ClaimedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Devices { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ClaimDeviceRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ClaimDeviceRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ClaimDeviceRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClaimDeviceRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClaimDeviceRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ClaimDeviceRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClaimDeviceRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClaimDeviceRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClaimDeviceRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterDesiredProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterDesiredProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterDesiredProperties>
    {
        public ClusterDesiredProperties() { }
        public Azure.ResourceManager.Hci.Models.DiagnosticLevel? DiagnosticLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.ClusterDesiredProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ClusterDesiredProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ClusterDesiredProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterDesiredProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterDesiredProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ClusterDesiredProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterDesiredProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterDesiredProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterDesiredProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterIdentityResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterIdentityResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterIdentityResponse>
    {
        internal ClusterIdentityResponse() { }
        public string AadApplicationObjectId { get { throw null; } }
        public string AadClientId { get { throw null; } }
        public string AadServicePrincipalObjectId { get { throw null; } }
        public string AadTenantId { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ClusterIdentityResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ClusterIdentityResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ClusterIdentityResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterIdentityResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterIdentityResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ClusterIdentityResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterIdentityResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterIdentityResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterIdentityResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ClusterJobProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterJobProperties>
    {
        internal ClusterJobProperties() { }
        public Azure.ResourceManager.Hci.Models.DeploymentMode? DeploymentMode { get { throw null; } set { } }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } }
        public string JobId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.JobReportedProperties ReportedProperties { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.JobStatus? Status { get { throw null; } }
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
    public partial class ClusterNode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterNode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterNode>
    {
        internal ClusterNode() { }
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
        public string OsDisplayVersion { get { throw null; } }
        public string OsName { get { throw null; } }
        public string OsVersion { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ClusterNode JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ClusterNode PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ClusterNode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterNode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterNode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ClusterNode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterNode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterNode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterNode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterPatch>
    {
        public ClusterPatch() { }
        public string AadClientId { get { throw null; } set { } }
        public string AadTenantId { get { throw null; } set { } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ClusterPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ClusterPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ClusterReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterReportedProperties>
    {
        internal ClusterReportedProperties() { }
        public string ClusterId { get { throw null; } }
        public string ClusterName { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ClusterNodeType? ClusterType { get { throw null; } }
        public string ClusterVersion { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.DiagnosticLevel? DiagnosticLevel { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HardwareClass? HardwareClass { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ImdsAttestation? ImdsAttestation { get { throw null; } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public string Manufacturer { get { throw null; } }
        public System.DateTimeOffset? MsiExpirationTimeStamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.ClusterNode> Nodes { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.OemActivation? OemActivation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedCapabilities { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ClusterReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ClusterReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ClusterReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ClusterReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ClusterReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ClusterReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct ComplianceAssignmentType : System.IEquatable<Azure.ResourceManager.Hci.Models.ComplianceAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComplianceAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ComplianceAssignmentType ApplyAndAutoCorrect { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ComplianceAssignmentType Audit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ComplianceAssignmentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ComplianceAssignmentType left, Azure.ResourceManager.Hci.Models.ComplianceAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ComplianceAssignmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ComplianceAssignmentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ComplianceAssignmentType left, Azure.ResourceManager.Hci.Models.ComplianceAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectivityStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.ConnectivityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectivityStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ConnectivityStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ConnectivityStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ConnectivityStatus NotConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ConnectivityStatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ConnectivityStatus NotYetRegistered { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ConnectivityStatus PartiallyConnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ConnectivityStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ConnectivityStatus left, Azure.ResourceManager.Hci.Models.ConnectivityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ConnectivityStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ConnectivityStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ConnectivityStatus left, Azure.ResourceManager.Hci.Models.ConnectivityStatus right) { throw null; }
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
    public partial class DefaultExtensionDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DefaultExtensionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DefaultExtensionDetails>
    {
        internal DefaultExtensionDetails() { }
        public string Category { get { throw null; } }
        public System.DateTimeOffset? ConsentOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.DefaultExtensionDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DefaultExtensionDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DefaultExtensionDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DefaultExtensionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DefaultExtensionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DefaultExtensionDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DefaultExtensionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DefaultExtensionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DefaultExtensionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentCluster : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentCluster>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentCluster>
    {
        public DeploymentCluster() { }
        public string AzureServiceEndpoint { get { throw null; } set { } }
        public string CloudAccountName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ClusterPattern? ClusterPattern { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HardwareClass? HardwareClass { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string WitnessPath { get { throw null; } set { } }
        public string WitnessType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentCluster JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentCluster PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DeploymentCluster System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentCluster>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentCluster>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentCluster System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentCluster>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentCluster>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentCluster>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentConfiguration>
    {
        public DeploymentConfiguration(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.ScaleUnits> scaleUnits) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.ScaleUnits> ScaleUnits { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DeploymentConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentData>
    {
        public DeploymentData() { }
        public string AdouPath { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.AssemblyInfo AssemblyInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.DeploymentCluster Cluster { get { throw null; } set { } }
        public string DomainFqdn { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.DeploymentSettingHostNetwork HostNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.IdentityProvider? IdentityProvider { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.InfrastructureNetwork> InfrastructureNetwork { get { throw null; } }
        public bool? IsManagementCluster { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.LocalAvailabilityZones> LocalAvailabilityZones { get { throw null; } }
        public string NamingPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.Observability Observability { get { throw null; } set { } }
        public string OptionalServicesCustomLocation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.PhysicalNodes> PhysicalNodes { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.NetworkController SdnIntegrationNetworkController { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets> Secrets { get { throw null; } }
        public string SecretsLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.DeploymentSecuritySettings SecuritySettings { get { throw null; } set { } }
        public string StorageConfigurationMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentMode : System.IEquatable<Azure.ResourceManager.Hci.Models.DeploymentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentMode(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DeploymentMode Deploy { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.DeploymentMode Validate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.DeploymentMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.DeploymentMode left, Azure.ResourceManager.Hci.Models.DeploymentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.DeploymentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.DeploymentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.DeploymentMode left, Azure.ResourceManager.Hci.Models.DeploymentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentSecuritySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSecuritySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSecuritySettings>
    {
        public DeploymentSecuritySettings() { }
        public bool? BitlockerBootVolume { get { throw null; } set { } }
        public bool? BitlockerDataVolumes { get { throw null; } set { } }
        public bool? CredentialGuardEnforced { get { throw null; } set { } }
        public bool? DriftControlEnforced { get { throw null; } set { } }
        public bool? DrtmProtection { get { throw null; } set { } }
        public bool? HvciProtection { get { throw null; } set { } }
        public bool? SideChannelMitigationEnforced { get { throw null; } set { } }
        public bool? SmbClusterEncryption { get { throw null; } set { } }
        public bool? SmbSigningEnforced { get { throw null; } set { } }
        public bool? WdacEnforced { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSecuritySettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentSecuritySettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DeploymentSecuritySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSecuritySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSecuritySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentSecuritySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSecuritySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSecuritySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSecuritySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public bool? EnableStorageAutoIp { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeploymentSettingIntents> Intents { get { throw null; } }
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
    public partial class DeploymentSettingIntents : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIntents>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingIntents>
    {
        public DeploymentSettingIntents() { }
        public System.Collections.Generic.IList<string> Adapter { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.DeploymentSettingAdapterPropertyOverrides AdapterPropertyOverrides { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? OverrideAdapterProperty { get { throw null; } set { } }
        public bool? OverrideQosPolicy { get { throw null; } set { } }
        public bool? OverrideVirtualSwitchConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.QosPolicyOverrides QosPolicyOverrides { get { throw null; } set { } }
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
    public partial class DeploymentSettingStorageAdapterIPInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentSettingStorageAdapterIPInfo>
    {
        public DeploymentSettingStorageAdapterIPInfo() { }
        public string Ipv4Address { get { throw null; } set { } }
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
    public partial class DeploymentStep : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentStep>
    {
        internal DeploymentStep() { }
        public string Description { get { throw null; } }
        public string EndTimeUtc { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Exception { get { throw null; } }
        public string FullStepIndex { get { throw null; } }
        public string Name { get { throw null; } }
        public string StartTimeUtc { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.DeploymentStep> Steps { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentStep JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeploymentStep PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DeploymentStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeploymentStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeploymentStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeploymentStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeviceDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeviceDetail>
    {
        public DeviceDetail() { }
        public string ClaimedBy { get { throw null; } }
        public Azure.Core.ResourceIdentifier DeviceResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.DeviceDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DeviceDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DeviceDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeviceDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DeviceDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DeviceDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeviceDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeviceDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DeviceDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DeviceDetail> Devices { get { throw null; } }
        public string ManagedResourceGroup { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.OperationDetail> OperationDetails { get { throw null; } }
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
    public readonly partial struct DiagnosticLevel : System.IEquatable<Azure.ResourceManager.Hci.Models.DiagnosticLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiagnosticLevel(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DiagnosticLevel Basic { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.DiagnosticLevel Enhanced { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.DiagnosticLevel Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.DiagnosticLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.DiagnosticLevel left, Azure.ResourceManager.Hci.Models.DiagnosticLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.DiagnosticLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.DiagnosticLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.DiagnosticLevel left, Azure.ResourceManager.Hci.Models.DiagnosticLevel right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class DnsZones : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DnsZones>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DnsZones>
    {
        public DnsZones() { }
        public System.Collections.Generic.IList<string> DnsForwarder { get { throw null; } }
        public string DnsZoneName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.DnsZones JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DnsZones PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DnsZones System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DnsZones>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DnsZones>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DnsZones System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DnsZones>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DnsZones>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DnsZones>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DownloadOsJobProperties : Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DownloadOsJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadOsJobProperties>
    {
        public DownloadOsJobProperties(Azure.ResourceManager.Hci.Models.DownloadRequest downloadRequest) { }
        public Azure.ResourceManager.Hci.Models.DownloadRequest DownloadRequest { get { throw null; } set { } }
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
    public partial class DownloadRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DownloadRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadRequest>
    {
        public DownloadRequest(Azure.ResourceManager.Hci.Models.ProvisioningOsType target, Azure.ResourceManager.Hci.Models.DownloadOsProfile osProfile) { }
        public Azure.ResourceManager.Hci.Models.DownloadOsProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningOsType Target { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.DownloadRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.DownloadRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.DownloadRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DownloadRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.DownloadRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.DownloadRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.DownloadRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EceActionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EceActionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceActionStatus>
    {
        internal EceActionStatus() { }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.DeploymentStep> Steps { get { throw null; } }
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
    public partial class EceDeploymentSecrets : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EceDeploymentSecrets>
    {
        public EceDeploymentSecrets() { }
        public Azure.ResourceManager.Hci.Models.EceSecrets? EceSecretName { get { throw null; } set { } }
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
    public readonly partial struct EceSecrets : System.IEquatable<Azure.ResourceManager.Hci.Models.EceSecrets>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EceSecrets(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.EceSecrets AzureStackLCMUserCredential { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EceSecrets DefaultARBApplication { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EceSecrets LocalAdminCredential { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.EceSecrets WitnessStorageKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.EceSecrets other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.EceSecrets left, Azure.ResourceManager.Hci.Models.EceSecrets right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EceSecrets (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.EceSecrets? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.EceSecrets left, Azure.ResourceManager.Hci.Models.EceSecrets right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeDeviceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeDeviceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeDeviceProperties>
    {
        public EdgeDeviceProperties() { }
        public Azure.ResourceManager.Hci.Models.HciEdgeDeviceConfiguration DeviceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeDeviceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.EdgeDeviceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.EdgeDeviceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeDeviceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeDeviceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.EdgeDeviceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeDeviceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeDeviceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeDeviceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeMachineCollectLogJobProperties : Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobProperties>
    {
        public EdgeMachineCollectLogJobProperties(System.DateTimeOffset fromDate, System.DateTimeOffset toDate) { }
        public System.DateTimeOffset FromDate { get { throw null; } set { } }
        public System.DateTimeOffset? LastLogGenerated { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EdgeMachineCollectLogJobReportedProperties ReportedProperties { get { throw null; } }
        public System.DateTimeOffset ToDate { get { throw null; } set { } }
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
        public Azure.ResourceManager.Hci.Models.DeploymentMode? DeploymentMode { get { throw null; } set { } }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string JobId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.JobStatus? Status { get { throw null; } }
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
        public System.DateTimeOffset? LastSyncTimestamp { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EdgeMachineState? MachineState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.OperationDetail> OperationDetails { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails OwnershipVoucherDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningDetails ProvisioningDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EdgeMachineReportedProperties ReportedProperties { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SiteDetails SiteDetails { get { throw null; } set { } }
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
        public EdgeMachineRemoteSupportJobProperties(Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel accessLevel, System.DateTimeOffset expirationTimestamp, Azure.ResourceManager.Hci.Models.RemoteSupportType type) { }
        public Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel AccessLevel { get { throw null; } set { } }
        public System.DateTimeOffset ExpirationTimestamp { get { throw null; } set { } }
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
        public Azure.ResourceManager.Hci.Models.HardwareProfile HardwareProfile { get { throw null; } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.EdgeMachineNetworkProfile NetworkProfile { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.OsProfile OsProfile { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionAggregateState : System.IEquatable<Azure.ResourceManager.Hci.Models.ExtensionAggregateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionAggregateState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Updating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState UpgradeFailedRollbackSucceeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ExtensionAggregateState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ExtensionAggregateState left, Azure.ResourceManager.Hci.Models.ExtensionAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ExtensionAggregateState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ExtensionAggregateState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ExtensionAggregateState left, Azure.ResourceManager.Hci.Models.ExtensionAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtensionInstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>
    {
        internal ExtensionInstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.StatusLevelTypes? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionManagedBy : System.IEquatable<Azure.ResourceManager.Hci.Models.ExtensionManagedBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionManagedBy(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ExtensionManagedBy Azure { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionManagedBy User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ExtensionManagedBy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ExtensionManagedBy left, Azure.ResourceManager.Hci.Models.ExtensionManagedBy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ExtensionManagedBy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ExtensionManagedBy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ExtensionManagedBy left, Azure.ResourceManager.Hci.Models.ExtensionManagedBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtensionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionPatch>
    {
        public ExtensionPatch() { }
        public Azure.ResourceManager.Hci.Models.ExtensionPatchParameters ExtensionParameters { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.ExtensionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ExtensionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ExtensionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ExtensionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionPatchParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionPatchParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionPatchParameters>
    {
        public ExtensionPatchParameters() { }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.ExtensionPatchParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ExtensionPatchParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ExtensionPatchParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionPatchParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionPatchParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ExtensionPatchParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionPatchParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionPatchParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionPatchParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionProfile>
    {
        internal ExtensionProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> Extensions { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ExtensionProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ExtensionProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ExtensionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ExtensionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionUpgradeParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeParameters>
    {
        public ExtensionUpgradeParameters() { }
        public string TargetVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.ExtensionUpgradeParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ExtensionUpgradeParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ExtensionUpgradeParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ExtensionUpgradeParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ExtensionUpgradeParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HardwareProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HardwareProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HardwareProfile>
    {
        internal HardwareProfile() { }
        public long? CpuCores { get { throw null; } }
        public long? CpuSockets { get { throw null; } }
        public string Manufacturer { get { throw null; } }
        public long? MemoryCapacityInGb { get { throw null; } }
        public string Model { get { throw null; } }
        public string ProcessorType { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HardwareProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HardwareProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HardwareProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HardwareProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HardwareProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HardwareProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HardwareProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HardwareProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HardwareProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HciCollectLogJobProperties : Azure.ResourceManager.Hci.Models.HciEdgeDeviceJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciCollectLogJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciCollectLogJobProperties>
    {
        public HciCollectLogJobProperties(System.DateTimeOffset fromDate, System.DateTimeOffset toDate) { }
        public System.DateTimeOffset FromDate { get { throw null; } set { } }
        public System.DateTimeOffset? LastLogGenerated { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.LogCollectionReportedProperties ReportedProperties { get { throw null; } }
        public System.DateTimeOffset ToDate { get { throw null; } set { } }
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
    public partial class HciEdgeDevice : Azure.ResourceManager.Hci.EdgeDeviceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDevice>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDevice>
    {
        public HciEdgeDevice() { }
        public Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties Properties { get { throw null; } set { } }
        protected override Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciEdgeDevice System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDevice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDevice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDevice System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDevice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDevice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDevice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Models.ExtensionManagedBy? ManagedBy { get { throw null; } }
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
        public bool? EnableStorageAutoIp { get { throw null; } }
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
        public Azure.ResourceManager.Hci.Models.QosPolicyOverrides QosPolicyOverrides { get { throw null; } }
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
        public Azure.ResourceManager.Hci.Models.DeploymentMode? DeploymentMode { get { throw null; } set { } }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } }
        public string JobId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.JobStatus? Status { get { throw null; } }
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
        public string Ip4Address { get { throw null; } set { } }
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
    public partial class HciEdgeDeviceProperties : Azure.ResourceManager.Hci.Models.EdgeDeviceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>
    {
        public HciEdgeDeviceProperties() { }
        public Azure.ResourceManager.Hci.Models.HciReportedProperties ReportedProperties { get { throw null; } }
        protected override Azure.ResourceManager.Hci.Models.EdgeDeviceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Hci.Models.EdgeDeviceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciEdgeDeviceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string Ipv4Address { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.SwitchExtension> Extensions { get { throw null; } }
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
    public partial class HciExtensionInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciExtensionInstanceView>
    {
        internal HciExtensionInstanceView() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus Status { get { throw null; } }
        public string Type { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.HciExtensionInstanceView JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.HciExtensionInstanceView PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string Ip4Address { get { throw null; } }
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
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
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
        public Azure.ResourceManager.Hci.Models.Severity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.Status? Status { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.PrecheckResultTags Tags { get { throw null; } set { } }
        public string TargetResourceID { get { throw null; } set { } }
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
        public HciRemoteSupportJobProperties(Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel accessLevel, System.DateTimeOffset expirationTimestamp, Azure.ResourceManager.Hci.Models.RemoteSupportType type) { }
        public Azure.ResourceManager.Hci.Models.RemoteSupportAccessLevel AccessLevel { get { throw null; } set { } }
        public System.DateTimeOffset ExpirationTimestamp { get { throw null; } set { } }
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
    public partial class HciReportedProperties : Azure.ResourceManager.Hci.Models.ReportedProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>
    {
        internal HciReportedProperties() { }
        public string HardwareProcessorType { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciNetworkProfile NetworkProfile { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciOSProfile OsProfile { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SbeDeploymentPackageInfo SbeDeploymentPackageInfo { get { throw null; } }
        public long? StoragePoolableDisksCount { get { throw null; } }
        protected override Azure.ResourceManager.Hci.Models.ReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Hci.Models.ReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.HciReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.HciReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.HciReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        public string ExpectedExecutionTime { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTimeUtc { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
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
    public readonly partial struct IdentityProvider : System.IEquatable<Azure.ResourceManager.Hci.Models.IdentityProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityProvider(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.IdentityProvider ActiveDirectory { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.IdentityProvider LocalIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.IdentityProvider other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.IdentityProvider left, Azure.ResourceManager.Hci.Models.IdentityProvider right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.IdentityProvider (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.IdentityProvider? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.IdentityProvider left, Azure.ResourceManager.Hci.Models.IdentityProvider right) { throw null; }
        public override string ToString() { throw null; }
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
    public readonly partial struct ImdsAttestation : System.IEquatable<Azure.ResourceManager.Hci.Models.ImdsAttestation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImdsAttestation(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ImdsAttestation Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ImdsAttestation Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ImdsAttestation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ImdsAttestation left, Azure.ResourceManager.Hci.Models.ImdsAttestation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ImdsAttestation (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ImdsAttestation? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ImdsAttestation left, Azure.ResourceManager.Hci.Models.ImdsAttestation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InfrastructureNetwork : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.InfrastructureNetwork>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.InfrastructureNetwork>
    {
        public InfrastructureNetwork() { }
        public Azure.ResourceManager.Hci.Models.DnsServerConfig? DnsServerConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.DnsZones> DnsZones { get { throw null; } }
        public string Gateway { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.IpPools> IpPools { get { throw null; } }
        public string SubnetMask { get { throw null; } set { } }
        public bool? UseDhcp { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.InfrastructureNetwork JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.InfrastructureNetwork PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.InfrastructureNetwork System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.InfrastructureNetwork>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.InfrastructureNetwork>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.InfrastructureNetwork System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.InfrastructureNetwork>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.InfrastructureNetwork>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.InfrastructureNetwork>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IpAddressRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IpAddressRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IpAddressRange>
    {
        public IpAddressRange(string startIp, string endIp) { }
        public string EndIp { get { throw null; } set { } }
        public string StartIp { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.IpAddressRange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.IpAddressRange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.IpAddressRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IpAddressRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IpAddressRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.IpAddressRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IpAddressRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IpAddressRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IpAddressRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class IpPools : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IpPools>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IpPools>
    {
        public IpPools() { }
        public string EndingAddress { get { throw null; } set { } }
        public string StartingAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.IpPools JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.IpPools PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.IpPools System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IpPools>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.IpPools>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.IpPools System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IpPools>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IpPools>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.IpPools>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.JobStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.JobStatus DeploymentFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.JobStatus DeploymentInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.JobStatus DeploymentSuccess { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.JobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.JobStatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.JobStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.JobStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.JobStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.JobStatus ValidationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.JobStatus ValidationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.JobStatus ValidationSuccess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.JobStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.JobStatus left, Azure.ResourceManager.Hci.Models.JobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.JobStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.JobStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.JobStatus left, Azure.ResourceManager.Hci.Models.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KubernetesVersion : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.KubernetesVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.KubernetesVersion>
    {
        internal KubernetesVersion() { }
        public string KubernetesVersionValue { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.KubernetesVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.KubernetesVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.KubernetesVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.KubernetesVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.KubernetesVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.KubernetesVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.KubernetesVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LogCollectionRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionRequest>
    {
        public LogCollectionRequest() { }
        public Azure.ResourceManager.Hci.Models.LogCollectionRequestProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.LogCollectionRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogCollectionRequestProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionRequestProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionRequestProperties>
    {
        public LogCollectionRequestProperties(System.DateTimeOffset fromDate, System.DateTimeOffset toDate) { }
        public System.DateTimeOffset FromDate { get { throw null; } }
        public System.DateTimeOffset ToDate { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionRequestProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.LogCollectionRequestProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.LogCollectionRequestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionRequestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.LogCollectionRequestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.LogCollectionRequestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionRequestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionRequestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.LogCollectionRequestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NetworkAdapter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkAdapter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkAdapter>
    {
        public NetworkAdapter(Azure.ResourceManager.Hci.Models.IpAssignmentType ipAssignmentType) { }
        public string AdapterName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsAddressArray { get { throw null; } }
        public string Gateway { get { throw null; } set { } }
        public string IpAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.IpAddressRange IpAddressRange { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.IpAssignmentType IpAssignmentType { get { throw null; } set { } }
        public string MacAddress { get { throw null; } set { } }
        public string SubnetMask { get { throw null; } set { } }
        public string VlanId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.NetworkAdapter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.NetworkAdapter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.NetworkAdapter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkAdapter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkAdapter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.NetworkAdapter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkAdapter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkAdapter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkAdapter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkController : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkController>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkController>
    {
        public NetworkController() { }
        public string MacAddressPoolStart { get { throw null; } set { } }
        public string MacAddressPoolStop { get { throw null; } set { } }
        public bool? NetworkVirtualizationEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.NetworkController JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.NetworkController PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.NetworkController System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkController>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.NetworkController>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.NetworkController System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkController>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkController>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.NetworkController>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class Observability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.Observability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.Observability>
    {
        public Observability() { }
        public bool? EpisodicDataUpload { get { throw null; } set { } }
        public bool? EuLocation { get { throw null; } set { } }
        public bool? StreamingDataClient { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.Observability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.Observability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.Observability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.Observability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.Observability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.Observability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.Observability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.Observability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.Observability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class OperationDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OperationDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OperationDetail>
    {
        internal OperationDetail() { }
        public string Description { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string Status { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.OperationDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.OperationDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.OperationDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OperationDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OperationDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.OperationDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OperationDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OperationDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OperationDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationType : System.IEquatable<Azure.ResourceManager.Hci.Models.OperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.OperationType ClusterProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.OperationType ClusterUpgrade { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.OperationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.OperationType left, Azure.ResourceManager.Hci.Models.OperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OperationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.OperationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.OperationType left, Azure.ResourceManager.Hci.Models.OperationType right) { throw null; }
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
    public partial class OsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OsProfile>
    {
        internal OsProfile() { }
        public string AssemblyVersion { get { throw null; } }
        public string BaseImageVersion { get { throw null; } }
        public string BootType { get { throw null; } }
        public string BuildNumber { get { throw null; } }
        public string ImageVersion { get { throw null; } }
        public string OsSku { get { throw null; } }
        public string OsType { get { throw null; } }
        public string OsVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.OsProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.OsProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.OsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.OsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.OsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.OsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PasswordCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PasswordCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PasswordCredential>
    {
        internal PasswordCredential() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string KeyId { get { throw null; } }
        public string SecretText { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.PasswordCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.PasswordCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.PasswordCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PasswordCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PasswordCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PasswordCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PasswordCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PasswordCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PasswordCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PerNodeArcState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PerNodeArcState>
    {
        internal PerNodeArcState() { }
        public string ArcInstance { get { throw null; } }
        public string ArcNodeServicePrincipalObjectId { get { throw null; } }
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
    public partial class PhysicalNodes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PhysicalNodes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PhysicalNodes>
    {
        public PhysicalNodes() { }
        public string Ipv4Address { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.PhysicalNodes JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.PhysicalNodes PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.PhysicalNodes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PhysicalNodes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PhysicalNodes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PhysicalNodes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PhysicalNodes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PhysicalNodes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PhysicalNodes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PrecheckResultTags : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PrecheckResultTags>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PrecheckResultTags>
    {
        public PrecheckResultTags() { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.PrecheckResultTags JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.PrecheckResultTags PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.PrecheckResultTags System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PrecheckResultTags>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.PrecheckResultTags>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.PrecheckResultTags System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PrecheckResultTags>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PrecheckResultTags>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.PrecheckResultTags>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisioningDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisioningDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisioningDetails>
    {
        public ProvisioningDetails(Azure.ResourceManager.Hci.Models.OsProvisionProfile osProfile) { }
        public Azure.ResourceManager.Hci.Models.OsProvisionProfile OsProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.UserDetails> UserDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ProvisioningDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ProvisioningDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ProvisioningDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisioningDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisioningDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ProvisioningDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisioningDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisioningDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisioningDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ProvisioningRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisioningRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisioningRequest>
    {
        public ProvisioningRequest(Azure.ResourceManager.Hci.Models.ProvisioningOsType target, Azure.ResourceManager.Hci.Models.OsProvisionProfile osProfile) { }
        public string CustomConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration DeviceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OnboardingConfiguration OnboardingConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OsProvisionProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningOsType Target { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.UserDetails> UserDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ProvisioningRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ProvisioningRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ProvisioningRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisioningRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisioningRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ProvisioningRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisioningRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisioningRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisioningRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionOsJobProperties : Azure.ResourceManager.Hci.Models.EdgeMachineJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ProvisionOsJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ProvisionOsJobProperties>
    {
        public ProvisionOsJobProperties(Azure.ResourceManager.Hci.Models.ProvisioningRequest provisioningRequest) { }
        public Azure.ResourceManager.Hci.Models.ProvisioningRequest ProvisioningRequest { get { throw null; } set { } }
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
    public partial class QosPolicyOverrides : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.QosPolicyOverrides>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.QosPolicyOverrides>
    {
        public QosPolicyOverrides() { }
        public string BandwidthPercentageSMB { get { throw null; } set { } }
        public string PriorityValue8021ActionCluster { get { throw null; } set { } }
        public string PriorityValue8021ActionSMB { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.QosPolicyOverrides JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.QosPolicyOverrides PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.QosPolicyOverrides System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.QosPolicyOverrides>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.QosPolicyOverrides>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.QosPolicyOverrides System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.QosPolicyOverrides>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.QosPolicyOverrides>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.QosPolicyOverrides>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ReconcileArcSettingsRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsRequest>
    {
        public ReconcileArcSettingsRequest() { }
        public System.Collections.Generic.IList<string> ReconcileArcSettingsRequestClusterNodes { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ReconcileArcSettingsRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ReconcileArcSettingsRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ReconcileArcSettingsRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ReconcileArcSettingsRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReconcileArcSettingsRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReleaseDeviceRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest>
    {
        public ReleaseDeviceRequest(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> devices) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Devices { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReleaseDeviceRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string ArcResourceId { get { throw null; } }
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
        public System.DateTimeOffset? ExpirationTimeStamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.RemoteSupportNodeSettings> RemoteSupportNodeSettings { get { throw null; } }
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
    public partial class RemoteSupportRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequest>
    {
        public RemoteSupportRequest() { }
        public Azure.ResourceManager.Hci.Models.RemoteSupportRequestProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.RemoteSupportRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteSupportRequestProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequestProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequestProperties>
    {
        public RemoteSupportRequestProperties() { }
        public Azure.ResourceManager.Hci.Models.HciClusterAccessLevel? AccessLevel { get { throw null; } }
        public System.DateTimeOffset? ExpirationTimeStamp { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.RemoteSupportType? RemoteSupportType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportRequestProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.RemoteSupportRequestProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.RemoteSupportRequestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.RemoteSupportRequestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.RemoteSupportRequestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ReportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReportedProperties>
    {
        internal ReportedProperties() { }
        public Azure.ResourceManager.Hci.Models.ConfidentialVmProfile ConfidentialVmProfile { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciEdgeDeviceState? DeviceState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciEdgeDeviceArcExtension> Extensions { get { throw null; } }
        public System.DateTimeOffset? LastSyncTimestamp { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ReportedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ReportedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ReportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ReportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ReportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ReportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ScaleUnits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ScaleUnits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ScaleUnits>
    {
        public ScaleUnits(Azure.ResourceManager.Hci.Models.DeploymentData deploymentData) { }
        public Azure.ResourceManager.Hci.Models.DeploymentData DeploymentData { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.SbePartnerInfo SbePartnerInfo { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.ScaleUnits JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ScaleUnits PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ScaleUnits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ScaleUnits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ScaleUnits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ScaleUnits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ScaleUnits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ScaleUnits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ScaleUnits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public SecretsLocationDetails(Azure.ResourceManager.Hci.Models.SecretsType secretsType, string secretsLocation) { }
        public string SecretsLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.SecretsType SecretsType { get { throw null; } set { } }
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
    public partial class SecretsLocationsChangeRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest>
    {
        public SecretsLocationsChangeRequest() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.SecretsLocationDetails> Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecretsLocationsChangeRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretsType : System.IEquatable<Azure.ResourceManager.Hci.Models.SecretsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretsType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SecretsType BackupSecrets { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.SecretsType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.SecretsType left, Azure.ResourceManager.Hci.Models.SecretsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SecretsType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SecretsType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.SecretsType left, Azure.ResourceManager.Hci.Models.SecretsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretType : System.IEquatable<Azure.ResourceManager.Hci.Models.SecretType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SecretType KeyVault { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.SecretType SshPubKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.SecretType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.SecretType left, Azure.ResourceManager.Hci.Models.SecretType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SecretType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SecretType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.SecretType left, Azure.ResourceManager.Hci.Models.SecretType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityComplianceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SecurityComplianceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SecurityComplianceStatus>
    {
        internal SecurityComplianceStatus() { }
        public Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? DataAtRestEncrypted { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterComplianceStatus? DataInTransitProtected { get { throw null; } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
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
    public partial class ServiceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ServiceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ServiceConfiguration>
    {
        public ServiceConfiguration(Azure.ResourceManager.Hci.Models.ServiceName serviceName, long port) { }
        public long Port { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ServiceName ServiceName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.ServiceConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ServiceConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ServiceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ServiceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ServiceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ServiceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ServiceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ServiceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ServiceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceName : System.IEquatable<Azure.ResourceManager.Hci.Models.ServiceName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceName(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ServiceName WAC { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ServiceName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ServiceName left, Azure.ResourceManager.Hci.Models.ServiceName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ServiceName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ServiceName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ServiceName left, Azure.ResourceManager.Hci.Models.ServiceName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Severity : System.IEquatable<Azure.ResourceManager.Hci.Models.Severity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Severity(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.Severity Critical { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Severity Hidden { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Severity Informational { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Severity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.Severity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.Severity left, Azure.ResourceManager.Hci.Models.Severity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.Severity (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.Severity? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.Severity left, Azure.ResourceManager.Hci.Models.Severity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SiteDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SiteDetails>
    {
        public SiteDetails(Azure.Core.ResourceIdentifier siteResourceId) { }
        public Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration DeviceConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SiteResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.SiteDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SiteDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.SiteDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SiteDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SiteDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SiteDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SiteDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SiteDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SiteDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuMappings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SkuMappings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SkuMappings>
    {
        internal SkuMappings() { }
        public string CatalogPlanId { get { throw null; } }
        public string MarketplaceSkuId { get { throw null; } }
        public System.Collections.Generic.IList<string> MarketplaceSkuVersions { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.SkuMappings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SkuMappings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.SkuMappings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SkuMappings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SkuMappings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SkuMappings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SkuMappings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SkuMappings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SkuMappings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SoftwareAssuranceChangeRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeRequest>
    {
        public SoftwareAssuranceChangeRequest() { }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? SoftwareAssuranceIntent { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? SoftwareAssuranceIntent { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus? SoftwareAssuranceStatus { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.Hci.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.Status ConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Status DeploymentFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Status DeploymentInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Status DeploymentSuccess { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Status Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Status Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Status NotConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Status NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Status NotYetRegistered { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Status ValidationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Status ValidationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.Status ValidationSuccess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.Status other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.Status left, Azure.ResourceManager.Hci.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.Status (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.Status? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.Status left, Azure.ResourceManager.Hci.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusLevelTypes : System.IEquatable<Azure.ResourceManager.Hci.Models.StatusLevelTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusLevelTypes(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.StatusLevelTypes Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.StatusLevelTypes Info { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.StatusLevelTypes Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.StatusLevelTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.StatusLevelTypes left, Azure.ResourceManager.Hci.Models.StatusLevelTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.StatusLevelTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.StatusLevelTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.StatusLevelTypes left, Azure.ResourceManager.Hci.Models.StatusLevelTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SwitchExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SwitchExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SwitchExtension>
    {
        internal SwitchExtension() { }
        public bool? ExtensionEnabled { get { throw null; } }
        public string ExtensionName { get { throw null; } }
        public string SwitchId { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.SwitchExtension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.SwitchExtension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.SwitchExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SwitchExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.SwitchExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.SwitchExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SwitchExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SwitchExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.SwitchExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetDeviceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.TargetDeviceConfiguration>
    {
        public TargetDeviceConfiguration() { }
        public string HostName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.NetworkAdapter> NetworkAdapters { get { throw null; } }
        public string StoragePartitionSize { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.TimeConfiguration Time { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.WebProxyConfiguration WebProxy { get { throw null; } set { } }
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
    public partial class TimeConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.TimeConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.TimeConfiguration>
    {
        public TimeConfiguration() { }
        public string PrimaryTimeServer { get { throw null; } set { } }
        public string SecondaryTimeServer { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.TimeConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.TimeConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.TimeConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.TimeConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.TimeConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.TimeConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.TimeConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.TimeConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.TimeConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdatePrerequisite : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UpdatePrerequisite>
    {
        public UpdatePrerequisite() { }
        public string PackageName { get { throw null; } set { } }
        public string UpdateType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.UpdatePrerequisite JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.UpdatePrerequisite PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UploadCertificateRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UploadCertificateRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UploadCertificateRequest>
    {
        public UploadCertificateRequest() { }
        public System.Collections.Generic.IList<string> RawCertificateDataCertificates { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.UploadCertificateRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.UploadCertificateRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.UploadCertificateRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UploadCertificateRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UploadCertificateRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.UploadCertificateRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UploadCertificateRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UploadCertificateRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UploadCertificateRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UserDetails>
    {
        public UserDetails(string userName, Azure.ResourceManager.Hci.Models.SecretType secretType) { }
        public string SecretLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.SecretType SecretType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SshPubKey { get { throw null; } }
        public string UserName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.UserDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.UserDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.UserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.UserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.UserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.UserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ValidateOwnershipVouchersRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest>
    {
        public ValidateOwnershipVouchersRequest(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails> ownershipVoucherDetails) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.OwnershipVoucherDetails> OwnershipVoucherDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateOwnershipVouchersResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse>
    {
        internal ValidateOwnershipVouchersResponse() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.OwnershipVoucherValidationDetails> OwnershipVoucherValidationDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateOwnershipVouchersResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateRequest>
    {
        public ValidateRequest(System.Collections.Generic.IEnumerable<string> edgeDeviceIds) { }
        public string AdditionalInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EdgeDeviceIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidateRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidateRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidateRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidateRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateResponse>
    {
        internal ValidateResponse() { }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Models.ValidateResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.ValidateResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.ValidateResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.ValidateResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.ValidateResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.ValidateResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebProxyConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.WebProxyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.WebProxyConfiguration>
    {
        public WebProxyConfiguration() { }
        public System.Collections.Generic.IList<System.Uri> BypassList { get { throw null; } }
        public System.Uri ConnectionUri { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Models.WebProxyConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Models.WebProxyConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Models.WebProxyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.WebProxyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Models.WebProxyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Models.WebProxyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.WebProxyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.WebProxyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Models.WebProxyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
