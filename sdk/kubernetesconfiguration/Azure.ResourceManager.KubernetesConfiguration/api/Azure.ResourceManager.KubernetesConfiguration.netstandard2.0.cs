namespace Azure.ResourceManager.KubernetesConfiguration
{
    public partial class ExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource>, System.Collections.IEnumerable
    {
        protected ExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.KubernetesConfiguration.ExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.KubernetesConfiguration.ExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExtensionData : Azure.ResourceManager.Models.ResourceData
    {
        public ExtensionData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity AksAssignedIdentity { get { throw null; } set { } }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationSettings { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CustomLocationSettings { get { throw null; } }
        public Azure.ResponseError ErrorInfo { get { throw null; } }
        public string ExtensionType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string InstalledVersion { get { throw null; } }
        public System.Uri PackageUri { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ReleaseTrain { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.Scope Scope { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.Models.ExtensionStatus> Statuses { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtensionResource() { }
        public virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterRp, string clusterResourceName, string clusterName, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult> GetOperationStatu(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult>> GetOperationStatuAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.Models.ExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.Models.ExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FluxConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource>, System.Collections.IEnumerable
    {
        protected FluxConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fluxConfigurationName, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fluxConfigurationName, Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource> Get(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource>> GetAsync(string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FluxConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public FluxConfigurationData() { }
        public Azure.ResourceManager.KubernetesConfiguration.Models.AzureBlobDefinition AzureBlob { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.BucketDefinition Bucket { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState? ComplianceState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.GitRepositoryDefinition GitRepository { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.KubernetesConfiguration.Models.KustomizationDefinition> Kustomizations { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RepositoryPublicKey { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.ScopeType? Scope { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.SourceKindType? SourceKind { get { throw null; } set { } }
        public string SourceSyncedCommitId { get { throw null; } }
        public System.DateTimeOffset? SourceUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KubernetesConfiguration.Models.ObjectStatusDefinition> Statuses { get { throw null; } }
        public System.DateTimeOffset? StatusUpdatedOn { get { throw null; } }
        public bool? Suspend { get { throw null; } set { } }
    }
    public partial class FluxConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FluxConfigurationResource() { }
        public virtual Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult> GetFluxConfigOperationStatu(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult>> GetFluxConfigOperationStatuAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.Models.FluxConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.Models.FluxConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class KubernetesConfigurationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource> GetExtension(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionResource>> GetExtensionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionResource GetExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionCollection GetExtensions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource> GetFluxConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource>> GetFluxConfigurationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationResource GetFluxConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.FluxConfigurationCollection GetFluxConfigurations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult> GetOperationStatus(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KubernetesConfiguration.Models.OperationStatusResult> GetOperationStatusAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource> GetSourceControlConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource>> GetSourceControlConfigurationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource GetSourceControlConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationCollection GetSourceControlConfigurations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName) { throw null; }
    }
    public partial class SourceControlConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource>, System.Collections.IEnumerable
    {
        protected SourceControlConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sourceControlConfigurationName, Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sourceControlConfigurationName, Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource> Get(string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource>> GetAsync(string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SourceControlConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public SourceControlConfigurationData() { }
        public Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStatus ComplianceStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } }
        public bool? EnableHelmOperator { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.HelmOperatorProperties HelmOperatorProperties { get { throw null; } set { } }
        public string OperatorInstanceName { get { throw null; } set { } }
        public string OperatorNamespace { get { throw null; } set { } }
        public string OperatorParams { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.OperatorScopeType? OperatorScope { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.OperatorType? OperatorType { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningStateType? ProvisioningState { get { throw null; } }
        public string RepositoryPublicKey { get { throw null; } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public string SshKnownHostsContents { get { throw null; } set { } }
    }
    public partial class SourceControlConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SourceControlConfigurationResource() { }
        public virtual Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterRp, string clusterResourceName, string clusterName, string sourceControlConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.SourceControlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.KubernetesConfiguration.Models
{
    public partial class AzureBlobDefinition
    {
        public AzureBlobDefinition() { }
        public string AccountKey { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public string ManagedIdentityClientId { get { throw null; } set { } }
        public string SasToken { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.ServicePrincipalDefinition ServicePrincipal { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class AzureBlobPatchDefinition
    {
        public AzureBlobPatchDefinition() { }
        public string AccountKey { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public string ManagedIdentityClientId { get { throw null; } set { } }
        public string SasToken { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.ServicePrincipalPatchDefinition ServicePrincipal { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class BucketDefinition
    {
        public BucketDefinition() { }
        public string AccessKey { get { throw null; } set { } }
        public string BucketName { get { throw null; } set { } }
        public bool? Insecure { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class BucketPatchDefinition
    {
        public BucketPatchDefinition() { }
        public string AccessKey { get { throw null; } set { } }
        public string BucketName { get { throw null; } set { } }
        public bool? Insecure { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComplianceStateType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComplianceStateType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStateType Compliant { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStateType Failed { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStateType Installed { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStateType Noncompliant { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStateType Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStateType left, Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStateType left, Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComplianceStatus
    {
        internal ComplianceStatus() { }
        public Azure.ResourceManager.KubernetesConfiguration.Models.ComplianceStateType? ComplianceState { get { throw null; } }
        public System.DateTimeOffset? LastConfigApplied { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.MessageLevelType? MessageLevel { get { throw null; } }
    }
    public partial class ExtensionPatch
    {
        public ExtensionPatch() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationSettings { get { throw null; } set { } }
        public string ReleaseTrain { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ExtensionStatus
    {
        public ExtensionStatus() { }
        public string Code { get { throw null; } set { } }
        public string DisplayStatus { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.LevelType? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FluxComplianceState : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FluxComplianceState(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState Compliant { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState NonCompliant { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState Pending { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState Suspended { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState left, Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState left, Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FluxConfigurationPatch
    {
        public FluxConfigurationPatch() { }
        public Azure.ResourceManager.KubernetesConfiguration.Models.AzureBlobPatchDefinition AzureBlob { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.BucketPatchDefinition Bucket { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.GitRepositoryPatchDefinition GitRepository { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.KubernetesConfiguration.Models.KustomizationPatchDefinition> Kustomizations { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.SourceKindType? SourceKind { get { throw null; } set { } }
        public bool? Suspend { get { throw null; } set { } }
    }
    public partial class GitRepositoryDefinition
    {
        public GitRepositoryDefinition() { }
        public string HttpsCACert { get { throw null; } set { } }
        public string HttpsUser { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.RepositoryRefDefinition RepositoryRef { get { throw null; } set { } }
        public string SshKnownHosts { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class GitRepositoryPatchDefinition
    {
        public GitRepositoryPatchDefinition() { }
        public string HttpsCACert { get { throw null; } set { } }
        public string HttpsUser { get { throw null; } set { } }
        public string LocalAuthRef { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.RepositoryRefDefinition RepositoryRef { get { throw null; } set { } }
        public string SshKnownHosts { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class HelmOperatorProperties
    {
        public HelmOperatorProperties() { }
        public string ChartValues { get { throw null; } set { } }
        public string ChartVersion { get { throw null; } set { } }
    }
    public partial class HelmReleasePropertiesDefinition
    {
        internal HelmReleasePropertiesDefinition() { }
        public long? FailureCount { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.ObjectReferenceDefinition HelmChartRef { get { throw null; } }
        public long? InstallFailureCount { get { throw null; } }
        public long? LastRevisionApplied { get { throw null; } }
        public long? UpgradeFailureCount { get { throw null; } }
    }
    public partial class KustomizationDefinition
    {
        public KustomizationDefinition() { }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } set { } }
        public bool? Force { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Path { get { throw null; } set { } }
        public bool? Prune { get { throw null; } set { } }
        public long? RetryIntervalInSeconds { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
    }
    public partial class KustomizationPatchDefinition
    {
        public KustomizationPatchDefinition() { }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } set { } }
        public bool? Force { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public bool? Prune { get { throw null; } set { } }
        public long? RetryIntervalInSeconds { get { throw null; } set { } }
        public long? SyncIntervalInSeconds { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LevelType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.LevelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LevelType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.LevelType Error { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.LevelType Information { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.LevelType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.LevelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.LevelType left, Azure.ResourceManager.KubernetesConfiguration.Models.LevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.LevelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.LevelType left, Azure.ResourceManager.KubernetesConfiguration.Models.LevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageLevelType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.MessageLevelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageLevelType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.MessageLevelType Error { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.MessageLevelType Information { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.MessageLevelType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.MessageLevelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.MessageLevelType left, Azure.ResourceManager.KubernetesConfiguration.Models.MessageLevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.MessageLevelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.MessageLevelType left, Azure.ResourceManager.KubernetesConfiguration.Models.MessageLevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ObjectReferenceDefinition
    {
        internal ObjectReferenceDefinition() { }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
    }
    public partial class ObjectStatusConditionDefinition
    {
        internal ObjectStatusConditionDefinition() { }
        public System.DateTimeOffset? LastTransitionOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string ObjectStatusConditionDefinitionType { get { throw null; } }
        public string Reason { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ObjectStatusDefinition
    {
        internal ObjectStatusDefinition() { }
        public Azure.ResourceManager.KubernetesConfiguration.Models.ObjectReferenceDefinition AppliedBy { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.FluxComplianceState? ComplianceState { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.Models.HelmReleasePropertiesDefinition HelmReleaseProperties { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KubernetesConfiguration.Models.ObjectStatusConditionDefinition> StatusConditions { get { throw null; } }
    }
    public partial class OperationStatusResult
    {
        internal OperationStatusResult() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatorScopeType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.OperatorScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatorScopeType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.OperatorScopeType Cluster { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.OperatorScopeType Namespace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.OperatorScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.OperatorScopeType left, Azure.ResourceManager.KubernetesConfiguration.Models.OperatorScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.OperatorScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.OperatorScopeType left, Azure.ResourceManager.KubernetesConfiguration.Models.OperatorScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatorType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.OperatorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatorType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.OperatorType Flux { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.OperatorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.OperatorType left, Azure.ResourceManager.KubernetesConfiguration.Models.OperatorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.OperatorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.OperatorType left, Azure.ResourceManager.KubernetesConfiguration.Models.OperatorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState left, Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState left, Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStateType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStateType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningStateType Accepted { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningStateType Deleting { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningStateType Failed { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningStateType Running { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningStateType Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningStateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningStateType left, Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningStateType left, Azure.ResourceManager.KubernetesConfiguration.Models.ProvisioningStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RepositoryRefDefinition
    {
        public RepositoryRefDefinition() { }
        public string Branch { get { throw null; } set { } }
        public string Commit { get { throw null; } set { } }
        public string Semver { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class Scope
    {
        public Scope() { }
        public string ClusterReleaseNamespace { get { throw null; } set { } }
        public string TargetNamespace { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScopeType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.ScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScopeType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ScopeType Cluster { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.ScopeType Namespace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.ScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.ScopeType left, Azure.ResourceManager.KubernetesConfiguration.Models.ScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.ScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.ScopeType left, Azure.ResourceManager.KubernetesConfiguration.Models.ScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServicePrincipalDefinition
    {
        public ServicePrincipalDefinition() { }
        public string ClientCertificate { get { throw null; } set { } }
        public string ClientCertificatePassword { get { throw null; } set { } }
        public bool? ClientCertificateSendChain { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class ServicePrincipalPatchDefinition
    {
        public ServicePrincipalPatchDefinition() { }
        public string ClientCertificate { get { throw null; } set { } }
        public string ClientCertificatePassword { get { throw null; } set { } }
        public bool? ClientCertificateSendChain { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceKindType : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Models.SourceKindType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceKindType(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.SourceKindType AzureBlob { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.SourceKindType Bucket { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Models.SourceKindType GitRepository { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Models.SourceKindType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Models.SourceKindType left, Azure.ResourceManager.KubernetesConfiguration.Models.SourceKindType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Models.SourceKindType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Models.SourceKindType left, Azure.ResourceManager.KubernetesConfiguration.Models.SourceKindType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
