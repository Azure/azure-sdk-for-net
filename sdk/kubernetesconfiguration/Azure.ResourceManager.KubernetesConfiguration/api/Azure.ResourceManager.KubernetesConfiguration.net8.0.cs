namespace Azure.ResourceManager.KubernetesConfiguration
{
    public partial class AzureResourceManagerKubernetesConfigurationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerKubernetesConfigurationContext() { }
        public static Azure.ResourceManager.KubernetesConfiguration.AzureResourceManagerKubernetesConfigurationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class KubernetesClusterExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource>, System.Collections.IEnumerable
    {
        protected KubernetesClusterExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource> GetIfExists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource>> GetIfExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KubernetesClusterExtensionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>
    {
        public KubernetesClusterExtensionData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity AksAssignedIdentity { get { throw null; } set { } }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationSettings { get { throw null; } set { } }
        public string CurrentVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CustomLocationSettings { get { throw null; } }
        public Azure.ResponseError ErrorInfo { get { throw null; } }
        public string ExtensionType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsSystemExtension { get { throw null; } }
        public System.Uri PackageUri { get { throw null; } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public string ReleaseTrain { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionScope Scope { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatus> Statuses { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesClusterExtensionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KubernetesClusterExtensionResource() { }
        public virtual Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterRp, string clusterResourceName, string clusterName, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult> Get(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult>> GetAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class KubernetesConfigurationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource> GetKubernetesClusterExtension(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource>> GetKubernetesClusterExtensionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource GetKubernetesClusterExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionCollection GetKubernetesClusterExtensions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource> GetKubernetesFluxConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource>> GetKubernetesFluxConfigurationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource GetKubernetesFluxConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationCollection GetKubernetesFluxConfigurations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource> GetKubernetesSourceControlConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource>> GetKubernetesSourceControlConfigurationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource GetKubernetesSourceControlConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationCollection GetKubernetesSourceControlConfigurations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName) { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesFluxConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource>, System.Collections.IEnumerable
    {
        protected KubernetesFluxConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fluxConfigurationName, Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fluxConfigurationName, Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource> Get(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource>> GetAsync(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource> GetIfExists(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource>> GetIfExistsAsync(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesFluxConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public KubernetesFluxConfigurationData() { }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesAzureBlob AzureBlob { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesBucket Bucket { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState? ComplianceState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesGitRepository GitRepository { get { throw null; } set { } }
        public bool? IsReconciliationSuspended { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.KubernetesConfiguration.Models.Kustomization> Kustomizations { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public string RepositoryPublicKey { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationScope? Scope { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind? SourceKind { get { throw null; } set { } }
        public string SourceSyncedCommitId { get { throw null; } }
        public System.DateTimeOffset? SourceUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesObjectStatus> Statuses { get { throw null; } }
        public System.DateTimeOffset? StatusUpdatedOn { get { throw null; } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesFluxConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KubernetesFluxConfigurationResource() { }
        public virtual Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesSourceControlConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource>, System.Collections.IEnumerable
    {
        protected KubernetesSourceControlConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sourceControlConfigurationName, Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sourceControlConfigurationName, Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource> Get(string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource>> GetAsync(string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource> GetIfExists(string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource>> GetIfExistsAsync(string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesSourceControlConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public KubernetesSourceControlConfigurationData() { }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStatus ComplianceStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.HelmOperatorProperties HelmOperatorProperties { get { throw null; } set { } }
        public bool? IsHelmOperatorEnabled { get { throw null; } set { } }
        public string OperatorInstanceName { get { throw null; } set { } }
        public string OperatorNamespace { get { throw null; } set { } }
        public string OperatorParams { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperatorScope? OperatorScope { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperator? OperatorType { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType? ProvisioningState { get { throw null; } }
        public string RepositoryPublicKey { get { throw null; } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public string SshKnownHostsContents { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesSourceControlConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KubernetesSourceControlConfigurationResource() { }
        public virtual Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterRp, string clusterResourceName, string clusterName, string sourceControlConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.KubernetesConfiguration.Mocking
{
    public partial class MockableKubernetesConfigurationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableKubernetesConfigurationArmClient() { }
        public virtual Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource GetKubernetesClusterExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public virtual Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource GetKubernetesFluxConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public virtual Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource GetKubernetesSourceControlConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableKubernetesConfigurationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableKubernetesConfigurationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource> GetKubernetesClusterExtension(string clusterRp, string clusterResourceName, string clusterName, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionResource>> GetKubernetesClusterExtensionAsync(string clusterRp, string clusterResourceName, string clusterName, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionCollection GetKubernetesClusterExtensions(string clusterRp, string clusterResourceName, string clusterName) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource> GetKubernetesFluxConfiguration(string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationResource>> GetKubernetesFluxConfigurationAsync(string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public virtual Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationCollection GetKubernetesFluxConfigurations(string clusterRp, string clusterResourceName, string clusterName) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource> GetKubernetesSourceControlConfiguration(string clusterRp, string clusterResourceName, string clusterName, string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationResource>> GetKubernetesSourceControlConfigurationAsync(string clusterRp, string clusterResourceName, string clusterName, string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public virtual Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationCollection GetKubernetesSourceControlConfigurations(string clusterRp, string clusterResourceName, string clusterName) { throw null; }
    }
}
namespace Azure.ResourceManager.KubernetesConfiguration.Models
{
    public static partial class ArmKubernetesConfigurationModelFactory
    {
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.ResourceManager.KubernetesConfiguration.Models.HelmReleaseProperties HelmReleaseProperties(long? lastRevisionApplied = default(long?), Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesObjectReference helmChartRef = null, long? failureCount = default(long?), long? installFailureCount = default(long?), long? upgradeFailureCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.KubernetesClusterExtensionData KubernetesClusterExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Models.ArmPlan plan = null, string extensionType = null, bool? autoUpgradeMinorVersion = default(bool?), string releaseTrain = null, string version = null, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionScope scope = null, System.Collections.Generic.IDictionary<string, string> configurationSettings = null, System.Collections.Generic.IDictionary<string, string> configurationProtectedSettings = null, string currentVersion = null, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatus> statuses = null, Azure.ResponseError errorInfo = null, System.Collections.Generic.IReadOnlyDictionary<string, string> customLocationSettings = null, System.Uri packageUri = null, Azure.ResourceManager.Models.ManagedServiceIdentity aksAssignedIdentity = null, bool? isSystemExtension = default(bool?)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStatus KubernetesConfigurationComplianceStatus(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType? complianceState = default(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType?), System.DateTimeOffset? lastConfigAppliedOn = default(System.DateTimeOffset?), string message = null, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationMesageLevel? messageLevel = default(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationMesageLevel?)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.ResourceManager.KubernetesConfiguration.KubernetesFluxConfigurationData KubernetesFluxConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationScope? scope = default(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationScope?), string @namespace = null, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind? sourceKind = default(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind?), bool? isReconciliationSuspended = default(bool?), Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesGitRepository gitRepository = null, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesBucket bucket = null, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesAzureBlob azureBlob = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.KubernetesConfiguration.Models.Kustomization> kustomizations = null, System.Collections.Generic.IDictionary<string, string> configurationProtectedSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesObjectStatus> statuses = null, string repositoryPublicKey = null, string sourceSyncedCommitId = null, System.DateTimeOffset? sourceUpdatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? statusUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState? complianceState = default(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState?), Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState?), string errorMessage = null) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesObjectReference KubernetesObjectReference(string name = null, string @namespace = null) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesObjectStatus KubernetesObjectStatus(string name = null, string @namespace = null, string kind = null, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState? complianceState = default(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState?), Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesObjectReference appliedBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesObjectStatusCondition> statusConditions = null, Azure.ResourceManager.KubernetesConfiguration.Models.HelmReleaseProperties helmReleaseProperties = null) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesObjectStatusCondition KubernetesObjectStatusCondition(System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), string message = null, string reason = null, string status = null, string objectStatusConditionDefinitionType = null) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.ResourceManager.KubernetesConfiguration.KubernetesSourceControlConfigurationData KubernetesSourceControlConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Uri repositoryUri = null, string operatorNamespace = null, string operatorInstanceName = null, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperator? operatorType = default(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperator?), string operatorParams = null, System.Collections.Generic.IDictionary<string, string> configurationProtectedSettings = null, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperatorScope? operatorScope = default(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperatorScope?), string repositoryPublicKey = null, string sshKnownHostsContents = null, bool? isHelmOperatorEnabled = default(bool?), Azure.ResourceManager.KubernetesConfiguration.Models.HelmOperatorProperties helmOperatorProperties = null, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType? provisioningState = default(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType?), Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStatus complianceStatus = null) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        public static Azure.ResourceManager.KubernetesConfiguration.Models.Kustomization Kustomization(string name = null, string path = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, long? timeoutInSeconds = default(long?), long? syncIntervalInSeconds = default(long?), long? retryIntervalInSeconds = default(long?), bool? prune = default(bool?), bool? force = default(bool?)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult OperationStatusResult(string id = null, string name = null, string status = null, System.Collections.Generic.IDictionary<string, string> properties = null, Azure.ResponseError error = null) { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class HelmOperatorProperties
    {
        public HelmOperatorProperties() { }
        public string ChartValues { get { throw null; } set { } }
        public string ChartVersion { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class HelmReleaseProperties
    {
        internal HelmReleaseProperties() { }
        public long? FailureCount { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesObjectReference HelmChartRef { get { throw null; } }
        public long? InstallFailureCount { get { throw null; } }
        public long? LastRevisionApplied { get { throw null; } }
        public long? UpgradeFailureCount { get { throw null; } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesAzureBlob
    {
        public KubernetesAzureBlob() { }
        public string AccountKey { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public System.Guid? ManagedIdentityClientId { get { throw null; } set { } }
        public string SasToken { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesServicePrincipal ServicePrincipal { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesAzureBlobUpdateContent
    {
        public KubernetesAzureBlobUpdateContent() { }
        public string AccountKey { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public string ManagedIdentityClientId { get { throw null; } set { } }
        public string SasToken { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesServicePrincipalUpdateContent ServicePrincipal { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesBucket
    {
        public KubernetesBucket() { }
        public string AccessKey { get { throw null; } set { } }
        public string BucketName { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public bool? UseInsecureCommunication { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesBucketUpdateContent
    {
        public KubernetesBucketUpdateContent() { }
        public string AccessKey { get { throw null; } set { } }
        public string BucketName { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public bool? UseInsecureCommunication { get { throw null; } set { } }
    }
    public partial class KubernetesClusterExtensionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionPatch>
    {
        public KubernetesClusterExtensionPatch() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationSettings { get { throw null; } set { } }
        public string ReleaseTrain { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesClusterExtensionScope : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionScope>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionScope>
    {
        public KubernetesClusterExtensionScope() { }
        public string ClusterReleaseNamespace { get { throw null; } set { } }
        public string TargetNamespace { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionScope JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionScope PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionScope System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionScope>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionScope>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionScope System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionScope>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionScope>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionScope>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesClusterExtensionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatus>
    {
        public KubernetesClusterExtensionStatus() { }
        public string Code { get { throw null; } set { } }
        public string DisplayStatus { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatusLevel? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesClusterExtensionStatusLevel : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatusLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesClusterExtensionStatusLevel(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatusLevel Error { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatusLevel Information { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatusLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatusLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatusLevel left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatusLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatusLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatusLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatusLevel left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesClusterExtensionStatusLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesConfigurationComplianceStateType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesConfigurationComplianceStateType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType Compliant { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType Failed { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType Installed { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType Noncompliant { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesConfigurationComplianceStatus
    {
        internal KubernetesConfigurationComplianceStatus() { }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationComplianceStateType? ComplianceState { get { throw null; } }
        public System.DateTimeOffset? LastConfigAppliedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationMesageLevel? MessageLevel { get { throw null; } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesConfigurationMesageLevel : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationMesageLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesConfigurationMesageLevel(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationMesageLevel Error { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationMesageLevel Information { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationMesageLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationMesageLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationMesageLevel left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationMesageLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationMesageLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationMesageLevel left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationMesageLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesConfigurationProvisioningStateType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesConfigurationProvisioningStateType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType Accepted { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType Deleting { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType Failed { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType Running { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationProvisioningStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesConfigurationScope : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesConfigurationScope(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationScope Cluster { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationScope Namespace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationScope other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationScope left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationScope left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesConfigurationSourceKind : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesConfigurationSourceKind(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind AzureBlob { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind Bucket { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind GitRepository { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesFluxComplianceState : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesFluxComplianceState(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState Compliant { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState NonCompliant { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState Pending { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState Suspended { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesFluxConfigurationPatch
    {
        public KubernetesFluxConfigurationPatch() { }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesAzureBlobUpdateContent AzureBlob { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesBucketUpdateContent Bucket { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesGitRepositoryUpdateContent GitRepository { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.KubernetesConfiguration.Models.KustomizationUpdateContent> Kustomizations { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesConfigurationSourceKind? SourceKind { get { throw null; } set { } }
        public bool? Suspend { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesGitRepository
    {
        public KubernetesGitRepository() { }
        public string HttpsCACert { get { throw null; } set { } }
        public string HttpsUser { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesGitRepositoryRef RepositoryRef { get { throw null; } set { } }
        public string SshKnownHosts { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesGitRepositoryRef
    {
        public KubernetesGitRepositoryRef() { }
        public string Branch { get { throw null; } set { } }
        public string Commit { get { throw null; } set { } }
        public string Semver { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesGitRepositoryUpdateContent
    {
        public KubernetesGitRepositoryUpdateContent() { }
        public string HttpsCACert { get { throw null; } set { } }
        public string HttpsUser { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesGitRepositoryRef RepositoryRef { get { throw null; } set { } }
        public string SshKnownHosts { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesObjectReference
    {
        internal KubernetesObjectReference() { }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesObjectStatus
    {
        internal KubernetesObjectStatus() { }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesObjectReference AppliedBy { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesFluxComplianceState? ComplianceState { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.HelmReleaseProperties HelmReleaseProperties { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesObjectStatusCondition> StatusConditions { get { throw null; } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesObjectStatusCondition
    {
        internal KubernetesObjectStatusCondition() { }
        public System.DateTimeOffset? LastTransitionOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string ObjectStatusConditionDefinitionType { get { throw null; } }
        public string Reason { get { throw null; } }
        public string Status { get { throw null; } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesOperator : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesOperator(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperator Flux { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperator left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperator left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesOperatorScope : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperatorScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesOperatorScope(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperatorScope Cluster { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperatorScope Namespace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperatorScope other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperatorScope left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperatorScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperatorScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperatorScope left, Azure.ResourceManager.KubernetesConfiguration.Models.KubernetesOperatorScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesServicePrincipal
    {
        public KubernetesServicePrincipal() { }
        public string ClientCertificate { get { throw null; } set { } }
        public string ClientCertificatePassword { get { throw null; } set { } }
        public bool? ClientCertificateSendChain { get { throw null; } set { } }
        public System.Guid? ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KubernetesServicePrincipalUpdateContent
    {
        public KubernetesServicePrincipalUpdateContent() { }
        public string ClientCertificate { get { throw null; } set { } }
        public string ClientCertificatePassword { get { throw null; } set { } }
        public bool? ClientCertificateSendChain { get { throw null; } set { } }
        public System.Guid? ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class Kustomization
    {
        public Kustomization() { }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } set { } }
        public bool? Force { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Path { get { throw null; } set { } }
        public bool? Prune { get { throw null; } set { } }
        public long? RetryIntervalInSeconds { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    public partial class KustomizationUpdateContent
    {
        public KustomizationUpdateContent() { }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } set { } }
        public bool? Force { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public bool? Prune { get { throw null; } set { } }
        public long? RetryIntervalInSeconds { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
    }
    public partial class OperationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult>
    {
        internal OperationStatusResult() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
