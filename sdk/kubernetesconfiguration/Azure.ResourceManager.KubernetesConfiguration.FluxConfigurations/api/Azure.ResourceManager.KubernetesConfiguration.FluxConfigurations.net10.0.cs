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
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob AzureBlob { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket Bucket { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState? ComplianceState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository GitRepository { get { throw null; } set { } }
        public bool? IsSuspended { get { throw null; } set { } }
        public bool? IsWaitForReconciliation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization> Kustomizations { get { throw null; } }
        public string Namespace { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository OciRepository { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public string ReconciliationWaitDuration { get { throw null; } set { } }
        public string RepositoryPublicKey { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType? Scope { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType? SourceKind { get { throw null; } set { } }
        public string SourceSyncedCommitId { get { throw null; } }
        public System.DateTimeOffset? SourceUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus> Statuses { get { throw null; } }
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
        public static Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource> GetFluxConfiguration(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource>> GetFluxConfigurationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource GetFluxConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationCollection GetFluxConfigurations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
}
namespace Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Mocking
{
    public partial class MockableKubernetesConfigurationFluxConfigurationsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableKubernetesConfigurationFluxConfigurationsArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource> GetFluxConfiguration(Azure.Core.ResourceIdentifier scope, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource>> GetFluxConfigurationAsync(Azure.Core.ResourceIdentifier scope, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationResource GetFluxConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationCollection GetFluxConfigurations(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
}
namespace Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models
{
    public static partial class ArmKubernetesConfigurationFluxConfigurationsModelFactory
    {
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob AzureBlob(string uri = null, string containerName = null, long? timeoutInSeconds = default(long?), long? syncIntervalInSeconds = default(long?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal servicePrincipal = null, string accountKey = null, string sasToken = null, string managedIdentityClientId = null, string localAuthRef = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch AzureBlobPatch(string uri = null, string containerName = null, long? timeoutInSeconds = default(long?), long? syncIntervalInSeconds = default(long?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch servicePrincipal = null, string accountKey = null, string sasToken = null, string managedIdentityClientId = null, string localAuthRef = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket FluxBucket(string uri = null, string bucketName = null, bool? isInsecure = default(bool?), long? timeoutInSeconds = default(long?), long? syncIntervalInSeconds = default(long?), string accessKey = null, string localAuthRef = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch FluxBucketPatch(string uri = null, string bucketName = null, bool? isInsecure = default(bool?), long? timeoutInSeconds = default(long?), long? syncIntervalInSeconds = default(long?), string accessKey = null, string localAuthRef = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.FluxConfigurationData FluxConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType? scope = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationScopeType?), string @namespace = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType? sourceKind = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType?), bool? isSuspended = default(bool?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository gitRepository = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket bucket = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob azureBlob = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository ociRepository = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization> kustomizations = null, System.Collections.Generic.IDictionary<string, string> configurationProtectedSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus> statuses = null, string repositoryPublicKey = null, string sourceSyncedCommitId = null, System.DateTimeOffset? sourceUpdatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? statusUpdatedOn = default(System.DateTimeOffset?), bool? isWaitForReconciliation = default(bool?), string reconciliationWaitDuration = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState? complianceState = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProvisioningState?), string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationPatch FluxConfigurationPatch(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType? sourceKind = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationSourceKindType?), bool? isSuspended = default(bool?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch gitRepository = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch bucket = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch azureBlob = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch ociRepository = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch> kustomizations = null, System.Collections.Generic.IDictionary<string, string> configurationProtectedSettings = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization FluxConfigurationsKustomization(string name = null, string path = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, long? timeoutInSeconds = default(long?), long? syncIntervalInSeconds = default(long?), long? retryIntervalInSeconds = default(long?), bool? isPrune = default(bool?), bool? isForce = default(bool?), bool? isWait = default(bool?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild postBuild = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch FluxConfigurationsKustomizationPatch(string path = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, long? timeoutInSeconds = default(long?), long? syncIntervalInSeconds = default(long?), long? retryIntervalInSeconds = default(long?), bool? isPrune = default(bool?), bool? isForce = default(bool?), bool? isWait = default(bool?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch postBuild = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository FluxGitRepository(string uri = null, long? timeoutInSeconds = default(long?), long? syncIntervalInSeconds = default(long?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference repositoryRef = null, string sshKnownHosts = null, string httpsUser = null, string httpsCACert = null, string localAuthRef = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType? provider = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType?)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch FluxGitRepositoryPatch(string uri = null, long? timeoutInSeconds = default(long?), long? syncIntervalInSeconds = default(long?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference repositoryRef = null, string sshKnownHosts = null, string httpsUser = null, string httpsCACert = null, string localAuthRef = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType? provider = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType?)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector FluxLayerSelector(string mediaType = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType? operation = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType?)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch FluxLayerSelectorPatch(string mediaType = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType? operation = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType?)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference FluxObjectReference(string name = null, string @namespace = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus FluxObjectStatus(string name = null, string @namespace = null, string kind = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState? complianceState = default(Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference appliedBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition> statusConditions = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties helmReleaseProperties = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition FluxObjectStatusCondition(System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), string message = null, string reason = null, string status = null, string type = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild FluxPostBuild(System.Collections.Generic.IDictionary<string, string> substitute = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution> substituteFrom = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch FluxPostBuildPatch(System.Collections.Generic.IDictionary<string, string> substitute = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch> substituteFrom = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference FluxRepositoryReference(string branch = null, string tag = null, string semver = null, string commit = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal FluxServicePrincipal(string clientId = null, string tenantId = null, string clientSecret = null, string clientCertificate = null, string clientCertificatePassword = null, bool? isClientCertificateSendChain = default(bool?)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch FluxServicePrincipalPatch(string clientId = null, string tenantId = null, string clientSecret = null, string clientCertificate = null, string clientCertificatePassword = null, bool? isClientCertificateSendChain = default(bool?)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution FluxSubstitution(string kind = null, string name = null, bool? isOptional = default(bool?)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch FluxSubstitutionPatch(string kind = null, string name = null, bool? isOptional = default(bool?)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig FluxTlsConfig(string clientCertificate = null, string privateKey = null, string caCertificate = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch FluxTlsConfigPatch(string clientCertificate = null, string privateKey = null, string caCertificate = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties HelmReleaseProperties(long? lastRevisionApplied = default(long?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference helmChartRef = null, long? failureCount = default(long?), long? installFailureCount = default(long?), long? upgradeFailureCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity MatchOidcIdentity(string issuer = null, string subject = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch MatchOidcIdentityPatch(string issuer = null, string subject = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository OciRepository(System.Uri uri = null, long? timeoutInSeconds = default(long?), long? syncIntervalInSeconds = default(long?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef repositoryRef = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector layerSelector = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify verify = null, bool? isInsecure = default(bool?), bool? useWorkloadIdentity = default(bool?), string serviceAccountName = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig tlsConfig = null, string localAuthRef = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch OciRepositoryPatch(System.Uri uri = null, long? timeoutInSeconds = default(long?), long? syncIntervalInSeconds = default(long?), Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch repositoryRef = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch layerSelector = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch verify = null, bool? isInsecure = default(bool?), bool? useWorkloadIdentity = default(bool?), string serviceAccountName = null, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch tlsConfig = null, string localAuthRef = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef OciRepositoryRef(string tag = null, string semver = null, string digest = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch OciRepositoryRefPatch(string tag = null, string semver = null, string digest = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify OciRepositoryVerify(string provider = null, System.Collections.Generic.IDictionary<string, string> verificationConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity> matchOidcIdentity = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch OciRepositoryVerifyPatch(string provider = null, System.Collections.Generic.IDictionary<string, string> verificationConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch> matchOidcIdentity = null) { throw null; }
    }
    public partial class AzureBlob : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob>
    {
        public AzureBlob() { }
        public string AccountKey { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public string ManagedIdentityClientId { get { throw null; } set { } }
        public string SasToken { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal ServicePrincipal { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureBlobPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch>
    {
        public AzureBlobPatch() { }
        public string AccountKey { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public string ManagedIdentityClientId { get { throw null; } set { } }
        public string SasToken { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch ServicePrincipal { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxBucket : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket>
    {
        public FluxBucket() { }
        public string AccessKey { get { throw null; } set { } }
        public string BucketName { get { throw null; } set { } }
        public bool? IsInsecure { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucket>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxBucketPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch>
    {
        public FluxBucketPatch() { }
        public string AccessKey { get { throw null; } set { } }
        public string BucketName { get { throw null; } set { } }
        public bool? IsInsecure { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.AzureBlobPatch AzureBlob { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxBucketPatch Bucket { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch GitRepository { get { throw null; } set { } }
        public bool? IsSuspended { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch> Kustomizations { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch OciRepository { get { throw null; } set { } }
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
    public partial class FluxConfigurationsKustomization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization>
    {
        public FluxConfigurationsKustomization() { }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } set { } }
        public bool? IsForce { get { throw null; } set { } }
        public bool? IsPrune { get { throw null; } set { } }
        public bool? IsWait { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild PostBuild { get { throw null; } set { } }
        public long? RetryIntervalInSeconds { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxConfigurationsKustomizationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch>
    {
        public FluxConfigurationsKustomizationPatch() { }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } set { } }
        public bool? IsForce { get { throw null; } set { } }
        public bool? IsPrune { get { throw null; } set { } }
        public bool? IsWait { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch PostBuild { get { throw null; } set { } }
        public long? RetryIntervalInSeconds { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationsKustomizationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class FluxGitRepository : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository>
    {
        public FluxGitRepository() { }
        public string HttpsCACert { get { throw null; } set { } }
        public string HttpsUser { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType? Provider { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference RepositoryRef { get { throw null; } set { } }
        public string SshKnownHosts { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepository>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxGitRepositoryPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch>
    {
        public FluxGitRepositoryPatch() { }
        public string HttpsCACert { get { throw null; } set { } }
        public string HttpsUser { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationProviderType? Provider { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference RepositoryRef { get { throw null; } set { } }
        public string SshKnownHosts { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxGitRepositoryPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxLayerSelector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector>
    {
        public FluxLayerSelector() { }
        public string MediaType { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType? Operation { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxLayerSelectorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch>
    {
        public FluxLayerSelectorPatch() { }
        public string MediaType { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxConfigurationOperationType? Operation { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxObjectReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference>
    {
        internal FluxObjectReference() { }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxObjectStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus>
    {
        internal FluxObjectStatus() { }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference AppliedBy { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxComplianceState? ComplianceState { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties HelmReleaseProperties { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition> StatusConditions { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxObjectStatusCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition>
    {
        internal FluxObjectStatusCondition() { }
        public System.DateTimeOffset? LastTransitionOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        public string Status { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectStatusCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxPostBuild : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild>
    {
        public FluxPostBuild() { }
        public System.Collections.Generic.IDictionary<string, string> Substitute { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution> SubstituteFrom { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuild>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxPostBuildPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch>
    {
        public FluxPostBuildPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Substitute { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch> SubstituteFrom { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxPostBuildPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxRepositoryReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference>
    {
        public FluxRepositoryReference() { }
        public string Branch { get { throw null; } set { } }
        public string Commit { get { throw null; } set { } }
        public string Semver { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxRepositoryReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxServicePrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal>
    {
        public FluxServicePrincipal() { }
        public string ClientCertificate { get { throw null; } set { } }
        public string ClientCertificatePassword { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public bool? IsClientCertificateSendChain { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxServicePrincipalPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch>
    {
        public FluxServicePrincipalPatch() { }
        public string ClientCertificate { get { throw null; } set { } }
        public string ClientCertificatePassword { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public bool? IsClientCertificateSendChain { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxServicePrincipalPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxSubstitution : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution>
    {
        public FluxSubstitution() { }
        public bool? IsOptional { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxSubstitutionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch>
    {
        public FluxSubstitutionPatch() { }
        public bool? IsOptional { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxSubstitutionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxTlsConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig>
    {
        public FluxTlsConfig() { }
        public string CaCertificate { get { throw null; } set { } }
        public string ClientCertificate { get { throw null; } set { } }
        public string PrivateKey { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluxTlsConfigPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch>
    {
        public FluxTlsConfigPatch() { }
        public string CaCertificate { get { throw null; } set { } }
        public string ClientCertificate { get { throw null; } set { } }
        public string PrivateKey { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HelmReleaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties>
    {
        internal HelmReleaseProperties() { }
        public long? FailureCount { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxObjectReference HelmChartRef { get { throw null; } }
        public long? InstallFailureCount { get { throw null; } }
        public long? LastRevisionApplied { get { throw null; } }
        public long? UpgradeFailureCount { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.HelmReleaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MatchOidcIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity>
    {
        public MatchOidcIdentity() { }
        public string Issuer { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MatchOidcIdentityPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch>
    {
        public MatchOidcIdentityPatch() { }
        public string Issuer { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OciRepository : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository>
    {
        public OciRepository() { }
        public bool? IsInsecure { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelector LayerSelector { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef RepositoryRef { get { throw null; } set { } }
        public string ServiceAccountName { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfig TlsConfig { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public bool? UseWorkloadIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify Verify { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepository>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OciRepositoryPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch>
    {
        public OciRepositoryPatch() { }
        public bool? IsInsecure { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxLayerSelectorPatch LayerSelector { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch RepositoryRef { get { throw null; } set { } }
        public string ServiceAccountName { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.FluxTlsConfigPatch TlsConfig { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public bool? UseWorkloadIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch Verify { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OciRepositoryRef : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef>
    {
        public OciRepositoryRef() { }
        public string Digest { get { throw null; } set { } }
        public string Semver { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OciRepositoryRefPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch>
    {
        public OciRepositoryRefPatch() { }
        public string Digest { get { throw null; } set { } }
        public string Semver { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryRefPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OciRepositoryVerify : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify>
    {
        public OciRepositoryVerify() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentity> MatchOidcIdentity { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> VerificationConfig { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerify>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OciRepositoryVerifyPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch>
    {
        public OciRepositoryVerifyPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.MatchOidcIdentityPatch> MatchOidcIdentity { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> VerificationConfig { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations.Models.OciRepositoryVerifyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
