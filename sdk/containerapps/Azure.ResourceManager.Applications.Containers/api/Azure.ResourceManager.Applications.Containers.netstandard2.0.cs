namespace Azure.ResourceManager.Applications.Containers
{
    public partial class AuthConfigCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.AuthConfigResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.AuthConfigResource>, System.Collections.IEnumerable
    {
        protected AuthConfigCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.AuthConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.AuthConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.AuthConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.AuthConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.AuthConfigResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.AuthConfigResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.AuthConfigResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.AuthConfigResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Applications.Containers.AuthConfigResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.AuthConfigResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Applications.Containers.AuthConfigResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.AuthConfigResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AuthConfigData : Azure.ResourceManager.Models.ResourceData
    {
        public AuthConfigData() { }
        public Azure.ResourceManager.Applications.Containers.Models.GlobalValidation GlobalValidation { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.HttpSettings HttpSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.IdentityProviders IdentityProviders { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.Login Login { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.AuthPlatform Platform { get { throw null; } set { } }
    }
    public partial class AuthConfigResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AuthConfigResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.AuthConfigData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerAppName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.AuthConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.AuthConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.AuthConfigResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.AuthConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.AuthConfigResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.AuthConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.CertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.CertificateResource>, System.Collections.IEnumerable
    {
        protected CertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.CertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.CertificateData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.CertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.CertificateData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.CertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.CertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Applications.Containers.CertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.CertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Applications.Containers.CertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.CertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CertificateData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Applications.Containers.Models.CertificateProperties Properties { get { throw null; } set { } }
    }
    public partial class CertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CertificateResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.CertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedEnvironmentName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource> Update(Azure.ResourceManager.Applications.Containers.Models.CertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource>> UpdateAsync(Azure.ResourceManager.Applications.Containers.Models.CertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerAppCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppResource>, System.Collections.IEnumerable
    {
        protected ContainerAppCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ContainerAppResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.ContainerAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.ContainerAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.ContainerAppResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ContainerAppResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Applications.Containers.ContainerAppResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Applications.Containers.ContainerAppResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerAppData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ContainerAppData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Applications.Containers.Models.Configuration Configuration { get { throw null; } set { } }
        public string CustomDomainVerificationId { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string LatestRevisionFqdn { get { throw null; } }
        public string LatestRevisionName { get { throw null; } }
        public string ManagedEnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> OutboundIPAddresses { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.ContainerAppProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.Template Template { get { throw null; } set { } }
    }
    public partial class ContainerAppResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerAppResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.ContainerAppData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.AuthConfigResource> GetAuthConfig(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.AuthConfigResource>> GetAuthConfigAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Applications.Containers.AuthConfigCollection GetAuthConfigs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.Models.CustomHostnameAnalysisResult> GetCustomHostNameAnalysis(string customHostname = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.Models.CustomHostnameAnalysisResult>> GetCustomHostNameAnalysisAsync(string customHostname = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.RevisionResource> GetRevision(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.RevisionResource>> GetRevisionAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Applications.Containers.RevisionCollection GetRevisions() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.Models.ContainerAppSecret> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.Models.ContainerAppSecret> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.SourceControlResource> GetSourceControl(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.SourceControlResource>> GetSourceControlAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Applications.Containers.SourceControlCollection GetSourceControls() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.ContainerAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.ContainerAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ContainersExtensions
    {
        public static Azure.ResourceManager.Applications.Containers.AuthConfigResource GetAuthConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.CertificateResource GetCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource> GetContainerApp(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> GetContainerAppAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ContainerAppResource GetContainerAppResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ContainerAppCollection GetContainerApps(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Applications.Containers.ContainerAppResource> GetContainerApps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ContainerAppResource> GetContainerAppsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.DaprComponentResource GetDaprComponentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> GetManagedEnvironment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>> GetManagedEnvironmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource GetManagedEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ManagedEnvironmentCollection GetManagedEnvironments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> GetManagedEnvironments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> GetManagedEnvironmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource GetManagedEnvironmentStorageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ReplicaResource GetReplicaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.RevisionResource GetRevisionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.SourceControlResource GetSourceControlResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DaprComponentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.DaprComponentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.DaprComponentResource>, System.Collections.IEnumerable
    {
        protected DaprComponentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.DaprComponentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.DaprComponentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.DaprComponentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.DaprComponentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.DaprComponentResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.DaprComponentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.DaprComponentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.DaprComponentResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Applications.Containers.DaprComponentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.DaprComponentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Applications.Containers.DaprComponentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.DaprComponentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DaprComponentData : Azure.ResourceManager.Models.ResourceData
    {
        public DaprComponentData() { }
        public string ComponentType { get { throw null; } set { } }
        public bool? IgnoreErrors { get { throw null; } set { } }
        public string InitTimeout { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.DaprMetadata> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.Secret> Secrets { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class DaprComponentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DaprComponentResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.DaprComponentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string environmentName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.DaprComponentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.DaprComponentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.Models.Secret> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.Models.Secret> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.DaprComponentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.DaprComponentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.DaprComponentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.DaprComponentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedEnvironmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>, System.Collections.IEnumerable
    {
        protected ManagedEnvironmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedEnvironmentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedEnvironmentData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Applications.Containers.Models.AppLogsConfiguration AppLogsConfiguration { get { throw null; } set { } }
        public string DaprAIConnectionString { get { throw null; } set { } }
        public string DaprAIInstrumentationKey { get { throw null; } set { } }
        public string DefaultDomain { get { throw null; } }
        public string DeploymentErrors { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState? ProvisioningState { get { throw null; } }
        public string StaticIP { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.VnetConfiguration VnetConfiguration { get { throw null; } set { } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class ManagedEnvironmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedEnvironmentResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.ManagedEnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityResponse> CheckNameAvailabilityNamespace(Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityResponse>> CheckNameAvailabilityNamespaceAsync(Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource> GetCertificate(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.CertificateResource>> GetCertificateAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Applications.Containers.CertificateCollection GetCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.DaprComponentResource> GetDaprComponent(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.DaprComponentResource>> GetDaprComponentAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Applications.Containers.DaprComponentCollection GetDaprComponents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> GetManagedEnvironmentStorage(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>> GetManagedEnvironmentStorageAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageCollection GetManagedEnvironmentStorages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedEnvironmentStorageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>, System.Collections.IEnumerable
    {
        protected ManagedEnvironmentStorageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedEnvironmentStorageData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedEnvironmentStorageData() { }
        public Azure.ResourceManager.Applications.Containers.Models.AzureFileProperties ManagedEnvironmentStorageAzureFile { get { throw null; } set { } }
    }
    public partial class ManagedEnvironmentStorageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedEnvironmentStorageResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string envName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ReplicaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ReplicaResource>, System.Collections.IEnumerable
    {
        protected ReplicaCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ReplicaResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.ReplicaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ReplicaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ReplicaResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Applications.Containers.ReplicaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ReplicaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Applications.Containers.ReplicaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ReplicaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReplicaData : Azure.ResourceManager.Models.ResourceData
    {
        public ReplicaData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ReplicaContainer> Containers { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
    }
    public partial class ReplicaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReplicaResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.ReplicaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerAppName, string revisionName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ReplicaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ReplicaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RevisionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.RevisionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.RevisionResource>, System.Collections.IEnumerable
    {
        protected RevisionCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.RevisionResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.RevisionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.RevisionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.RevisionResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Applications.Containers.RevisionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.RevisionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Applications.Containers.RevisionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.RevisionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RevisionData : Azure.ResourceManager.Models.ResourceData
    {
        public RevisionData() { }
        public bool? Active { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.RevisionHealthState? HealthState { get { throw null; } }
        public string ProvisioningError { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState? ProvisioningState { get { throw null; } }
        public int? Replicas { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.Template Template { get { throw null; } }
        public int? TrafficWeight { get { throw null; } }
    }
    public partial class RevisionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RevisionResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.RevisionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response ActivateRevision(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ActivateRevisionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerAppName, string name) { throw null; }
        public virtual Azure.Response DeactivateRevision(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeactivateRevisionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.RevisionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.RevisionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ReplicaResource> GetReplica(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ReplicaResource>> GetReplicaAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Applications.Containers.ReplicaCollection GetReplicas() { throw null; }
        public virtual Azure.Response RestartRevision(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestartRevisionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SourceControlCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.SourceControlResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.SourceControlResource>, System.Collections.IEnumerable
    {
        protected SourceControlCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.SourceControlResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.SourceControlResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Applications.Containers.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.SourceControlResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.SourceControlResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.SourceControlResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.SourceControlResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Applications.Containers.SourceControlResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.SourceControlResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Applications.Containers.SourceControlResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.SourceControlResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SourceControlData : Azure.ResourceManager.Models.ResourceData
    {
        public SourceControlData() { }
        public string Branch { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.GithubActionConfiguration GithubActionConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.SourceControlOperationState? OperationState { get { throw null; } }
        public System.Uri RepoUri { get { throw null; } set { } }
    }
    public partial class SourceControlResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SourceControlResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.SourceControlData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerAppName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.SourceControlResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.SourceControlResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.SourceControlResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.SourceControlResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Applications.Containers.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessMode : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.AccessMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessMode(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.AccessMode ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.AccessMode ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.AccessMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.AccessMode left, Azure.ResourceManager.Applications.Containers.Models.AccessMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.AccessMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.AccessMode left, Azure.ResourceManager.Applications.Containers.Models.AccessMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActiveRevisionsMode : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.ActiveRevisionsMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActiveRevisionsMode(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.ActiveRevisionsMode Multiple { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.ActiveRevisionsMode Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.ActiveRevisionsMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.ActiveRevisionsMode left, Azure.ResourceManager.Applications.Containers.Models.ActiveRevisionsMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.ActiveRevisionsMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.ActiveRevisionsMode left, Azure.ResourceManager.Applications.Containers.Models.ActiveRevisionsMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AllowedPrincipals
    {
        public AllowedPrincipals() { }
        public System.Collections.Generic.IList<string> Groups { get { throw null; } }
        public System.Collections.Generic.IList<string> Identities { get { throw null; } }
    }
    public partial class Apple
    {
        public Apple() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.AppleRegistration Registration { get { throw null; } set { } }
    }
    public partial class AppleRegistration
    {
        public AppleRegistration() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecretSettingName { get { throw null; } set { } }
    }
    public partial class AppLogsConfiguration
    {
        public AppLogsConfiguration() { }
        public string Destination { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.LogAnalyticsConfiguration LogAnalyticsConfiguration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppProtocol : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.AppProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.AppProtocol Grpc { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.AppProtocol Http { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.AppProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.AppProtocol left, Azure.ResourceManager.Applications.Containers.Models.AppProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.AppProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.AppProtocol left, Azure.ResourceManager.Applications.Containers.Models.AppProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppRegistration
    {
        public AppRegistration() { }
        public string AppId { get { throw null; } set { } }
        public string AppSecretSettingName { get { throw null; } set { } }
    }
    public partial class AuthPlatform
    {
        public AuthPlatform() { }
        public bool? Enabled { get { throw null; } set { } }
        public string RuntimeVersion { get { throw null; } set { } }
    }
    public partial class AzureActiveDirectory
    {
        public AzureActiveDirectory() { }
        public bool? Enabled { get { throw null; } set { } }
        public bool? IsAutoProvisioned { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.AzureActiveDirectoryLogin Login { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.AzureActiveDirectoryRegistration Registration { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.AzureActiveDirectoryValidation Validation { get { throw null; } set { } }
    }
    public partial class AzureActiveDirectoryLogin
    {
        public AzureActiveDirectoryLogin() { }
        public bool? DisableWWWAuthenticate { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginParameters { get { throw null; } }
    }
    public partial class AzureActiveDirectoryRegistration
    {
        public AzureActiveDirectoryRegistration() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecretCertificateIssuer { get { throw null; } set { } }
        public string ClientSecretCertificateSubjectAlternativeName { get { throw null; } set { } }
        public string ClientSecretCertificateThumbprint { get { throw null; } set { } }
        public string ClientSecretSettingName { get { throw null; } set { } }
        public string OpenIdIssuer { get { throw null; } set { } }
    }
    public partial class AzureActiveDirectoryValidation
    {
        public AzureActiveDirectoryValidation() { }
        public System.Collections.Generic.IList<string> AllowedAudiences { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.DefaultAuthorizationPolicy DefaultAuthorizationPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.JwtClaimChecks JwtClaimChecks { get { throw null; } set { } }
    }
    public partial class AzureCredentials
    {
        public AzureCredentials() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
    }
    public partial class AzureFileProperties
    {
        public AzureFileProperties() { }
        public Azure.ResourceManager.Applications.Containers.Models.AccessMode? AccessMode { get { throw null; } set { } }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string ShareName { get { throw null; } set { } }
    }
    public partial class AzureStaticWebApps
    {
        public AzureStaticWebApps() { }
        public bool? Enabled { get { throw null; } set { } }
        public string RegistrationClientId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BindingType : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.BindingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BindingType(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.BindingType Disabled { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.BindingType SniEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.BindingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.BindingType left, Azure.ResourceManager.Applications.Containers.Models.BindingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.BindingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.BindingType left, Azure.ResourceManager.Applications.Containers.Models.BindingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertificatePatch
    {
        public CertificatePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CertificateProperties
    {
        public CertificateProperties() { }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } }
        public System.DateTimeOffset? IssueOn { get { throw null; } }
        public string Issuer { get { throw null; } }
        public string Password { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.CertificateProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicKeyHash { get { throw null; } }
        public string SubjectName { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public bool? Valid { get { throw null; } }
        public byte[] Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateProvisioningState : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.CertificateProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.CertificateProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.CertificateProvisioningState DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.CertificateProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.CertificateProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.CertificateProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.CertificateProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.CertificateProvisioningState left, Azure.ResourceManager.Applications.Containers.Models.CertificateProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.CertificateProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.CertificateProvisioningState left, Azure.ResourceManager.Applications.Containers.Models.CertificateProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityResponse
    {
        internal CheckNameAvailabilityResponse() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
    }
    public partial class ClientRegistration
    {
        public ClientRegistration() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecretSettingName { get { throw null; } set { } }
    }
    public partial class Configuration
    {
        public Configuration() { }
        public Azure.ResourceManager.Applications.Containers.Models.ActiveRevisionsMode? ActiveRevisionsMode { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.Dapr Dapr { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.Ingress Ingress { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.RegistryCredentials> Registries { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.Secret> Secrets { get { throw null; } }
    }
    public partial class Container
    {
        public Container() { }
        public System.Collections.Generic.IList<string> Args { get { throw null; } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.EnvironmentVar> Env { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ContainerAppProbe> Probes { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.ContainerResources Resources { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.VolumeMount> VolumeMounts { get { throw null; } }
    }
    public partial class ContainerAppProbe
    {
        public ContainerAppProbe() { }
        public int? FailureThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.ContainerAppProbeHttpGet HttpGet { get { throw null; } set { } }
        public int? InitialDelaySeconds { get { throw null; } set { } }
        public int? PeriodSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.Type? ProbeType { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.ContainerAppProbeTcpSocket TcpSocket { get { throw null; } set { } }
        public long? TerminationGracePeriodSeconds { get { throw null; } set { } }
        public int? TimeoutSeconds { get { throw null; } set { } }
    }
    public partial class ContainerAppProbeHttpGet
    {
        public ContainerAppProbeHttpGet(int port) { }
        public string Host { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ContainerAppProbeHttpGetHttpHeadersItem> HttpHeaders { get { throw null; } }
        public string Path { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.Scheme? Scheme { get { throw null; } set { } }
    }
    public partial class ContainerAppProbeHttpGetHttpHeadersItem
    {
        public ContainerAppProbeHttpGetHttpHeadersItem(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ContainerAppProbeTcpSocket
    {
        public ContainerAppProbeTcpSocket(int port) { }
        public string Host { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerAppProvisioningState : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.ContainerAppProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerAppProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.ContainerAppProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.ContainerAppProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.ContainerAppProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.ContainerAppProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.ContainerAppProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.ContainerAppProvisioningState left, Azure.ResourceManager.Applications.Containers.Models.ContainerAppProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.ContainerAppProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.ContainerAppProvisioningState left, Azure.ResourceManager.Applications.Containers.Models.ContainerAppProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerAppSecret
    {
        internal ContainerAppSecret() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ContainerResources
    {
        public ContainerResources() { }
        public double? Cpu { get { throw null; } set { } }
        public string EphemeralStorage { get { throw null; } }
        public string Memory { get { throw null; } set { } }
    }
    public partial class CookieExpiration
    {
        public CookieExpiration() { }
        public Azure.ResourceManager.Applications.Containers.Models.CookieExpirationConvention? Convention { get { throw null; } set { } }
        public string TimeToExpiration { get { throw null; } set { } }
    }
    public enum CookieExpirationConvention
    {
        FixedTime = 0,
        IdentityProviderDerived = 1,
    }
    public partial class CustomDomain
    {
        public CustomDomain(string name, string certificateId) { }
        public Azure.ResourceManager.Applications.Containers.Models.BindingType? BindingType { get { throw null; } set { } }
        public string CertificateId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class CustomHostnameAnalysisResult : Azure.ResourceManager.Models.ResourceData
    {
        public CustomHostnameAnalysisResult() { }
        public System.Collections.Generic.IList<string> AlternateCNameRecords { get { throw null; } }
        public System.Collections.Generic.IList<string> AlternateTxtRecords { get { throw null; } }
        public System.Collections.Generic.IList<string> ARecords { get { throw null; } }
        public System.Collections.Generic.IList<string> CNameRecords { get { throw null; } }
        public string ConflictingContainerAppResourceId { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.DefaultErrorResponseError CustomDomainVerificationFailureInfoError { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.DnsVerificationTestResult? CustomDomainVerificationTest { get { throw null; } }
        public bool? HasConflictOnManagedEnvironment { get { throw null; } }
        public string HostName { get { throw null; } }
        public bool? IsHostnameAlreadyVerified { get { throw null; } }
        public System.Collections.Generic.IList<string> TxtRecords { get { throw null; } }
    }
    public partial class CustomOpenIdConnectProvider
    {
        public CustomOpenIdConnectProvider() { }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.OpenIdConnectLogin Login { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.OpenIdConnectRegistration Registration { get { throw null; } set { } }
    }
    public partial class CustomScaleRule
    {
        public CustomScaleRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ScaleRuleAuth> Auth { get { throw null; } }
        public string CustomScaleRuleType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
    public partial class Dapr
    {
        public Dapr() { }
        public string AppId { get { throw null; } set { } }
        public int? AppPort { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.AppProtocol? AppProtocol { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class DaprMetadata
    {
        public DaprMetadata() { }
        public string Name { get { throw null; } set { } }
        public string SecretRef { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class DefaultAuthorizationPolicy
    {
        public DefaultAuthorizationPolicy() { }
        public System.Collections.Generic.IList<string> AllowedApplications { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.AllowedPrincipals AllowedPrincipals { get { throw null; } set { } }
    }
    public partial class DefaultErrorResponseError
    {
        internal DefaultErrorResponseError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Applications.Containers.Models.DefaultErrorResponseErrorDetailsItem> Details { get { throw null; } }
        public string Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class DefaultErrorResponseErrorDetailsItem
    {
        internal DefaultErrorResponseErrorDetailsItem() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public enum DnsVerificationTestResult
    {
        Passed = 0,
        Failed = 1,
        Skipped = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentProvisioningState : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState InfrastructureSetupComplete { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState InfrastructureSetupInProgress { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState InitializationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState ScheduledForDelete { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState UpgradeFailed { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState UpgradeRequested { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState left, Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState left, Azure.ResourceManager.Applications.Containers.Models.EnvironmentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentVar
    {
        public EnvironmentVar() { }
        public string Name { get { throw null; } set { } }
        public string SecretRef { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class Facebook
    {
        public Facebook() { }
        public bool? Enabled { get { throw null; } set { } }
        public string GraphApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.AppRegistration Registration { get { throw null; } set { } }
    }
    public partial class ForwardProxy
    {
        public ForwardProxy() { }
        public Azure.ResourceManager.Applications.Containers.Models.ForwardProxyConvention? Convention { get { throw null; } set { } }
        public string CustomHostHeaderName { get { throw null; } set { } }
        public string CustomProtoHeaderName { get { throw null; } set { } }
    }
    public enum ForwardProxyConvention
    {
        NoProxy = 0,
        Standard = 1,
        Custom = 2,
    }
    public partial class GitHub
    {
        public GitHub() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.ClientRegistration Registration { get { throw null; } set { } }
    }
    public partial class GithubActionConfiguration
    {
        public GithubActionConfiguration() { }
        public Azure.ResourceManager.Applications.Containers.Models.AzureCredentials AzureCredentials { get { throw null; } set { } }
        public string ContextPath { get { throw null; } set { } }
        public string Image { get { throw null; } set { } }
        public string OS { get { throw null; } set { } }
        public string PublishType { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.RegistryInfo RegistryInfo { get { throw null; } set { } }
        public string RuntimeStack { get { throw null; } set { } }
        public string RuntimeVersion { get { throw null; } set { } }
    }
    public partial class GlobalValidation
    {
        public GlobalValidation() { }
        public System.Collections.Generic.IList<string> ExcludedPaths { get { throw null; } }
        public string RedirectToProvider { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.UnauthenticatedClientActionV2? UnauthenticatedClientAction { get { throw null; } set { } }
    }
    public partial class Google
    {
        public Google() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.ClientRegistration Registration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ValidationAllowedAudiences { get { throw null; } }
    }
    public partial class HttpScaleRule
    {
        public HttpScaleRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ScaleRuleAuth> Auth { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
    public partial class HttpSettings
    {
        public HttpSettings() { }
        public Azure.ResourceManager.Applications.Containers.Models.ForwardProxy ForwardProxy { get { throw null; } set { } }
        public bool? RequireHttps { get { throw null; } set { } }
        public string RoutesApiPrefix { get { throw null; } set { } }
    }
    public partial class IdentityProviders
    {
        public IdentityProviders() { }
        public Azure.ResourceManager.Applications.Containers.Models.Apple Apple { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.AzureActiveDirectory AzureActiveDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.AzureStaticWebApps AzureStaticWebApps { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Applications.Containers.Models.CustomOpenIdConnectProvider> CustomOpenIdConnectProviders { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.Facebook Facebook { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.GitHub GitHub { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.Google Google { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.Twitter Twitter { get { throw null; } set { } }
    }
    public partial class Ingress
    {
        public Ingress() { }
        public bool? AllowInsecure { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.CustomDomain> CustomDomains { get { throw null; } }
        public bool? External { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public int? TargetPort { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.TrafficWeight> Traffic { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.IngressTransportMethod? Transport { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IngressTransportMethod : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.IngressTransportMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngressTransportMethod(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.IngressTransportMethod Auto { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.IngressTransportMethod Http { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.IngressTransportMethod Http2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.IngressTransportMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.IngressTransportMethod left, Azure.ResourceManager.Applications.Containers.Models.IngressTransportMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.IngressTransportMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.IngressTransportMethod left, Azure.ResourceManager.Applications.Containers.Models.IngressTransportMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JwtClaimChecks
    {
        public JwtClaimChecks() { }
        public System.Collections.Generic.IList<string> AllowedClientApplications { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedGroups { get { throw null; } }
    }
    public partial class LogAnalyticsConfiguration
    {
        public LogAnalyticsConfiguration() { }
        public string CustomerId { get { throw null; } set { } }
        public string SharedKey { get { throw null; } set { } }
    }
    public partial class Login
    {
        public Login() { }
        public System.Collections.Generic.IList<string> AllowedExternalRedirectUrls { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.CookieExpiration CookieExpiration { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.Nonce Nonce { get { throw null; } set { } }
        public bool? PreserveUrlFragmentsForLogins { get { throw null; } set { } }
        public string RoutesLogoutEndpoint { get { throw null; } set { } }
    }
    public partial class Nonce
    {
        public Nonce() { }
        public string NonceExpirationInterval { get { throw null; } set { } }
        public bool? ValidateNonce { get { throw null; } set { } }
    }
    public partial class OpenIdConnectClientCredential
    {
        public OpenIdConnectClientCredential() { }
        public string ClientSecretSettingName { get { throw null; } set { } }
        public string Method { get { throw null; } set { } }
    }
    public partial class OpenIdConnectConfig
    {
        public OpenIdConnectConfig() { }
        public string AuthorizationEndpoint { get { throw null; } set { } }
        public System.Uri CertificationUri { get { throw null; } set { } }
        public string Issuer { get { throw null; } set { } }
        public string TokenEndpoint { get { throw null; } set { } }
        public string WellKnownOpenIdConfiguration { get { throw null; } set { } }
    }
    public partial class OpenIdConnectLogin
    {
        public OpenIdConnectLogin() { }
        public string NameClaimType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
    }
    public partial class OpenIdConnectRegistration
    {
        public OpenIdConnectRegistration() { }
        public Azure.ResourceManager.Applications.Containers.Models.OpenIdConnectClientCredential ClientCredential { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.OpenIdConnectConfig OpenIdConnectConfiguration { get { throw null; } set { } }
    }
    public partial class QueueScaleRule
    {
        public QueueScaleRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ScaleRuleAuth> Auth { get { throw null; } }
        public int? QueueLength { get { throw null; } set { } }
        public string QueueName { get { throw null; } set { } }
    }
    public partial class RegistryCredentials
    {
        public RegistryCredentials() { }
        public string Identity { get { throw null; } set { } }
        public string PasswordSecretRef { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class RegistryInfo
    {
        public RegistryInfo() { }
        public string RegistryPassword { get { throw null; } set { } }
        public System.Uri RegistryUri { get { throw null; } set { } }
        public string RegistryUserName { get { throw null; } set { } }
    }
    public partial class ReplicaContainer
    {
        public ReplicaContainer() { }
        public string ContainerId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? Ready { get { throw null; } set { } }
        public int? RestartCount { get { throw null; } set { } }
        public bool? Started { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RevisionHealthState : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.RevisionHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RevisionHealthState(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.RevisionHealthState Healthy { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.RevisionHealthState None { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.RevisionHealthState Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.RevisionHealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.RevisionHealthState left, Azure.ResourceManager.Applications.Containers.Models.RevisionHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.RevisionHealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.RevisionHealthState left, Azure.ResourceManager.Applications.Containers.Models.RevisionHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RevisionProvisioningState : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RevisionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState Deprovisioned { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState Deprovisioning { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState Provisioned { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState left, Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState left, Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Scale
    {
        public Scale() { }
        public int? MaxReplicas { get { throw null; } set { } }
        public int? MinReplicas { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ScaleRule> Rules { get { throw null; } }
    }
    public partial class ScaleRule
    {
        public ScaleRule() { }
        public Azure.ResourceManager.Applications.Containers.Models.QueueScaleRule AzureQueue { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.CustomScaleRule Custom { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.HttpScaleRule Http { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ScaleRuleAuth
    {
        public ScaleRuleAuth() { }
        public string SecretRef { get { throw null; } set { } }
        public string TriggerParameter { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Scheme : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.Scheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Scheme(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.Scheme Http { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.Scheme Https { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.Scheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.Scheme left, Azure.ResourceManager.Applications.Containers.Models.Scheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.Scheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.Scheme left, Azure.ResourceManager.Applications.Containers.Models.Scheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Secret
    {
        public Secret() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceControlOperationState : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.SourceControlOperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceControlOperationState(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.SourceControlOperationState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.SourceControlOperationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.SourceControlOperationState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.SourceControlOperationState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.SourceControlOperationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.SourceControlOperationState left, Azure.ResourceManager.Applications.Containers.Models.SourceControlOperationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.SourceControlOperationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.SourceControlOperationState left, Azure.ResourceManager.Applications.Containers.Models.SourceControlOperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageType : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.StorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageType(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.StorageType AzureFile { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.StorageType EmptyDir { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.StorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.StorageType left, Azure.ResourceManager.Applications.Containers.Models.StorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.StorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.StorageType left, Azure.ResourceManager.Applications.Containers.Models.StorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Template
    {
        public Template() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.Container> Containers { get { throw null; } }
        public string RevisionSuffix { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.Scale Scale { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.Volume> Volumes { get { throw null; } }
    }
    public partial class TrafficWeight
    {
        public TrafficWeight() { }
        public string Label { get { throw null; } set { } }
        public bool? LatestRevision { get { throw null; } set { } }
        public string RevisionName { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
    }
    public partial class Twitter
    {
        public Twitter() { }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.TwitterRegistration Registration { get { throw null; } set { } }
    }
    public partial class TwitterRegistration
    {
        public TwitterRegistration() { }
        public string ConsumerKey { get { throw null; } set { } }
        public string ConsumerSecretSettingName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Type : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.Type>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Type(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.Type Liveness { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.Type Readiness { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.Type Startup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.Type other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.Type left, Azure.ResourceManager.Applications.Containers.Models.Type right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.Type (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.Type left, Azure.ResourceManager.Applications.Containers.Models.Type right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum UnauthenticatedClientActionV2
    {
        RedirectToLoginPage = 0,
        AllowAnonymous = 1,
        Return401 = 2,
        Return403 = 3,
    }
    public partial class VnetConfiguration
    {
        public VnetConfiguration() { }
        public string DockerBridgeCidr { get { throw null; } set { } }
        public string InfrastructureSubnetId { get { throw null; } set { } }
        public bool? Internal { get { throw null; } set { } }
        public string PlatformReservedCidr { get { throw null; } set { } }
        public string PlatformReservedDnsIP { get { throw null; } set { } }
        public string RuntimeSubnetId { get { throw null; } set { } }
    }
    public partial class Volume
    {
        public Volume() { }
        public string Name { get { throw null; } set { } }
        public string StorageName { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.StorageType? StorageType { get { throw null; } set { } }
    }
    public partial class VolumeMount
    {
        public VolumeMount() { }
        public string MountPath { get { throw null; } set { } }
        public string VolumeName { get { throw null; } set { } }
    }
}
