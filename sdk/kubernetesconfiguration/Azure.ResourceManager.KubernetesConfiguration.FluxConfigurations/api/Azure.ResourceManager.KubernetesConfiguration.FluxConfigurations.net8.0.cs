namespace Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations
{
    public partial class AzureResourceManagerKubernetesConfigurationFluxConfigurationsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerKubernetesConfigurationFluxConfigurationsContext() { }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.AzureResourceManagerKubernetesConfigurationFluxConfigurationsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class FluxConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource>, System.Collections.IEnumerable
    {
        protected FluxConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fluxConfigurationName, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fluxConfigurationName, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource> Get(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource>> GetAsync(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource> GetIfExists(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource>> GetIfExistsAsync(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FluxConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>
    {
        public FluxConfigurationData() { }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobDefinition AzureBlob { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketDefinition Bucket { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState? ComplianceState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryDefinition GitRepository { get { throw null; } set { } }
        public bool? IsSuspended { get { throw null; } set { } }
        public bool? IsWaitForReconciliation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition> Kustomizations { get { throw null; } }
        public string Namespace { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryDefinition OciRepository { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public string ReconciliationWaitDuration { get { throw null; } set { } }
        public string RepositoryPublicKey { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType? Scope { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType? SourceKind { get { throw null; } set { } }
        public string SourceSyncedCommitId { get { throw null; } }
        public System.DateTimeOffset? SourceUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition> Statuses { get { throw null; } }
        public System.DateTimeOffset? StatusUpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FluxConfigurationResource() { }
        public virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class KubernetesConfigurationFluxConfigurationsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource> GetFluxConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource>> GetFluxConfigurationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource GetFluxConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationCollection GetFluxConfigurations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName) { throw null; }
    }
}
namespace Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Mocking
{
    public partial class MockableKubernetesConfigurationFluxConfigurationsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableKubernetesConfigurationFluxConfigurationsArmClient() { }
        public virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource GetFluxConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableKubernetesConfigurationFluxConfigurationsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableKubernetesConfigurationFluxConfigurationsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource> GetFluxConfiguration(string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource>> GetFluxConfigurationAsync(string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationCollection GetFluxConfigurations(string clusterRp, string clusterResourceName, string clusterName) { throw null; }
    }
}
namespace Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models
{
    public static partial class ArmKubernetesConfigurationFluxConfigurationsModelFactory
    {
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData FluxConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType? scope = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType?), string @namespace = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType? sourceKind = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType?), bool? isSuspended = default(bool?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryDefinition gitRepository = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketDefinition bucket = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobDefinition azureBlob = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryDefinition ociRepository = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition> kustomizations = null, System.Collections.Generic.IDictionary<string, string> configurationProtectedSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition> statuses = null, string repositoryPublicKey = null, string sourceSyncedCommitId = null, System.DateTimeOffset? sourceUpdatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? statusUpdatedOn = default(System.DateTimeOffset?), bool? isWaitForReconciliation = default(bool?), string reconciliationWaitDuration = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState? complianceState = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState?), string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition HelmReleasePropertiesDefinition(long? lastRevisionApplied = default(long?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition helmChartRef = null, long? failureCount = default(long?), long? installFailureCount = default(long?), long? upgradeFailureCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition KustomizationDefinition(string name = null, string path = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, long? timeoutInSeconds = default(long?), long? syncIntervalInSeconds = default(long?), long? retryIntervalInSeconds = default(long?), bool? isPrune = default(bool?), bool? isForce = default(bool?), bool? isWait = default(bool?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition postBuild = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition ObjectReferenceDefinition(string name = null, string @namespace = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition ObjectStatusConditionDefinition(System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), string message = null, string reason = null, string status = null, string type = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition ObjectStatusDefinition(string name = null, string @namespace = null, string kind = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState? complianceState = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition appliedBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition> statusConditions = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition helmReleaseProperties = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition PostBuildDefinition(System.Collections.Generic.IDictionary<string, string> substitute = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromDefinition> substituteFrom = null) { throw null; }
    }
    public partial class AzureBlobDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobDefinition>
    {
        public AzureBlobDefinition() { }
        public string AccountKey { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public string ManagedIdentityClientId { get { throw null; } set { } }
        public string SasToken { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalDefinition ServicePrincipal { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureBlobPatchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatchDefinition>
    {
        public AzureBlobPatchDefinition() { }
        public string AccountKey { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public string ManagedIdentityClientId { get { throw null; } set { } }
        public string SasToken { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalPatchDefinition ServicePrincipal { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatchDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BucketDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketDefinition>
    {
        public BucketDefinition() { }
        public string AccessKey { get { throw null; } set { } }
        public string BucketName { get { throw null; } set { } }
        public bool? IsInsecure { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BucketPatchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketPatchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketPatchDefinition>
    {
        public BucketPatchDefinition() { }
        public string AccessKey { get { throw null; } set { } }
        public string BucketName { get { throw null; } set { } }
        public bool? IsInsecure { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketPatchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketPatchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketPatchDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketPatchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketPatchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketPatchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketPatchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketPatchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketPatchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FluxComplianceState : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FluxComplianceState(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState Compliant { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState NonCompliant { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState Pending { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState Suspended { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState left, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState left, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FluxConfigurationOperationType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FluxConfigurationOperationType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType Copy { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType Extract { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType left, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType left, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FluxConfigurationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch>
    {
        public FluxConfigurationPatch() { }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatchDefinition AzureBlob { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.BucketPatchDefinition Bucket { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryPatchDefinition GitRepository { get { throw null; } set { } }
        public bool? IsSuspended { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationPatchDefinition> Kustomizations { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatchDefinition OciRepository { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType? SourceKind { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FluxConfigurationProviderType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FluxConfigurationProviderType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType Azure { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType Generic { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType GitHub { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType left, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType left, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FluxConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FluxConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState left, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState left, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FluxConfigurationScopeType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FluxConfigurationScopeType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType Cluster { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType Namespace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType left, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType left, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FluxConfigurationSourceKindType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FluxConfigurationSourceKindType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType AzureBlob { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType Bucket { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType GitRepository { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType OciRepository { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType left, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType left, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GitRepositoryDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryDefinition>
    {
        public GitRepositoryDefinition() { }
        public string HttpsCACert { get { throw null; } set { } }
        public string HttpsUser { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType? Provider { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.RepositoryRefDefinition RepositoryRef { get { throw null; } set { } }
        public string SshKnownHosts { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitRepositoryPatchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryPatchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryPatchDefinition>
    {
        public GitRepositoryPatchDefinition() { }
        public string HttpsCACert { get { throw null; } set { } }
        public string HttpsUser { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType? Provider { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.RepositoryRefDefinition RepositoryRef { get { throw null; } set { } }
        public string SshKnownHosts { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryPatchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryPatchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryPatchDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryPatchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryPatchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryPatchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryPatchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryPatchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.GitRepositoryPatchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HelmReleasePropertiesDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition>
    {
        internal HelmReleasePropertiesDefinition() { }
        public long? FailureCount { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition HelmChartRef { get { throw null; } }
        public long? InstallFailureCount { get { throw null; } }
        public long? LastRevisionApplied { get { throw null; } }
        public long? UpgradeFailureCount { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KustomizationDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition>
    {
        public KustomizationDefinition() { }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } set { } }
        public bool? IsForce { get { throw null; } set { } }
        public bool? IsPrune { get { throw null; } set { } }
        public bool? IsWait { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition PostBuild { get { throw null; } set { } }
        public long? RetryIntervalInSeconds { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KustomizationPatchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationPatchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationPatchDefinition>
    {
        public KustomizationPatchDefinition() { }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } set { } }
        public bool? IsForce { get { throw null; } set { } }
        public bool? IsPrune { get { throw null; } set { } }
        public bool? IsWait { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildPatchDefinition PostBuild { get { throw null; } set { } }
        public long? RetryIntervalInSeconds { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationPatchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationPatchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationPatchDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationPatchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationPatchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationPatchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationPatchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationPatchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.KustomizationPatchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LayerSelectorDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorDefinition>
    {
        public LayerSelectorDefinition() { }
        public string MediaType { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType? Operation { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LayerSelectorPatchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorPatchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorPatchDefinition>
    {
        public LayerSelectorPatchDefinition() { }
        public string MediaType { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType? Operation { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorPatchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorPatchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorPatchDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorPatchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorPatchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorPatchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorPatchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorPatchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorPatchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MatchOidcIdentityDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityDefinition>
    {
        public MatchOidcIdentityDefinition() { }
        public string Issuer { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MatchOidcIdentityPatchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatchDefinition>
    {
        public MatchOidcIdentityPatchDefinition() { }
        public string Issuer { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatchDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObjectReferenceDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition>
    {
        internal ObjectReferenceDefinition() { }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObjectStatusConditionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition>
    {
        internal ObjectStatusConditionDefinition() { }
        public System.DateTimeOffset? LastTransitionOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        public string Status { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObjectStatusDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition>
    {
        internal ObjectStatusDefinition() { }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectReferenceDefinition AppliedBy { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState? ComplianceState { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleasePropertiesDefinition HelmReleaseProperties { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusConditionDefinition> StatusConditions { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ObjectStatusDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OciRepositoryDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryDefinition>
    {
        public OciRepositoryDefinition() { }
        public bool? Insecure { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorDefinition LayerSelector { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefDefinition RepositoryRef { get { throw null; } set { } }
        public string ServiceAccountName { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigDefinition TlsConfig { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public bool? UseWorkloadIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyDefinition Verify { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OciRepositoryPatchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatchDefinition>
    {
        public OciRepositoryPatchDefinition() { }
        public bool? Insecure { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.LayerSelectorPatchDefinition LayerSelector { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatchDefinition RepositoryRef { get { throw null; } set { } }
        public string ServiceAccountName { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigPatchDefinition TlsConfig { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public bool? UseWorkloadIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyPatchDefinition Verify { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatchDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OciRepositoryRefDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefDefinition>
    {
        public OciRepositoryRefDefinition() { }
        public string Digest { get { throw null; } set { } }
        public string Semver { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OciRepositoryRefPatchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatchDefinition>
    {
        public OciRepositoryRefPatchDefinition() { }
        public string Digest { get { throw null; } set { } }
        public string Semver { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatchDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostBuildDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition>
    {
        public PostBuildDefinition() { }
        public System.Collections.Generic.IDictionary<string, string> Substitute { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromDefinition> SubstituteFrom { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostBuildPatchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildPatchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildPatchDefinition>
    {
        public PostBuildPatchDefinition() { }
        public System.Collections.Generic.IDictionary<string, string> Substitute { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromPatchDefinition> SubstituteFrom { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildPatchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildPatchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildPatchDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildPatchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildPatchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildPatchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildPatchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildPatchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.PostBuildPatchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RepositoryRefDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.RepositoryRefDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.RepositoryRefDefinition>
    {
        public RepositoryRefDefinition() { }
        public string Branch { get { throw null; } set { } }
        public string Commit { get { throw null; } set { } }
        public string Semver { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.RepositoryRefDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.RepositoryRefDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.RepositoryRefDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.RepositoryRefDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.RepositoryRefDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.RepositoryRefDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.RepositoryRefDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.RepositoryRefDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.RepositoryRefDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePrincipalDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalDefinition>
    {
        public ServicePrincipalDefinition() { }
        public string ClientCertificate { get { throw null; } set { } }
        public string ClientCertificatePassword { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public bool? IsClientCertificateSendChain { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePrincipalPatchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalPatchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalPatchDefinition>
    {
        public ServicePrincipalPatchDefinition() { }
        public string ClientCertificate { get { throw null; } set { } }
        public string ClientCertificatePassword { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public bool? IsClientCertificateSendChain { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalPatchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalPatchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalPatchDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalPatchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalPatchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalPatchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalPatchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalPatchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.ServicePrincipalPatchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubstituteFromDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromDefinition>
    {
        public SubstituteFromDefinition() { }
        public bool? IsOptional { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubstituteFromPatchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromPatchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromPatchDefinition>
    {
        public SubstituteFromPatchDefinition() { }
        public bool? IsOptional { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromPatchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromPatchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromPatchDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromPatchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromPatchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromPatchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromPatchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromPatchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.SubstituteFromPatchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TlsConfigDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigDefinition>
    {
        public TlsConfigDefinition() { }
        public string CaCertificate { get { throw null; } set { } }
        public string ClientCertificate { get { throw null; } set { } }
        public string PrivateKey { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TlsConfigPatchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigPatchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigPatchDefinition>
    {
        public TlsConfigPatchDefinition() { }
        public string CaCertificate { get { throw null; } set { } }
        public string ClientCertificate { get { throw null; } set { } }
        public string PrivateKey { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigPatchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigPatchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigPatchDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigPatchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigPatchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigPatchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigPatchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigPatchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.TlsConfigPatchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VerifyDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyDefinition>
    {
        public VerifyDefinition() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityDefinition> MatchOidcIdentity { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> VerificationConfig { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VerifyPatchDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyPatchDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyPatchDefinition>
    {
        public VerifyPatchDefinition() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatchDefinition> MatchOidcIdentity { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> VerificationConfig { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyPatchDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyPatchDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyPatchDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyPatchDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyPatchDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyPatchDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyPatchDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyPatchDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.VerifyPatchDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
