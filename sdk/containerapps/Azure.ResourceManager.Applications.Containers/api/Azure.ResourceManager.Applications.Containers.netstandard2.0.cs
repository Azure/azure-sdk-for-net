namespace Azure.ResourceManager.Applications.Containers
{
    public partial class AuthConfigCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.AuthConfigResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.AuthConfigResource>, System.Collections.IEnumerable
    {
        protected AuthConfigCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.AuthConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authConfigName, Azure.ResourceManager.Applications.Containers.AuthConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.AuthConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authConfigName, Azure.ResourceManager.Applications.Containers.AuthConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.AuthConfigResource> Get(string authConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.AuthConfigResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.AuthConfigResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.AuthConfigResource>> GetAsync(string authConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Applications.Containers.Models.ContainerAppLogin Login { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.AuthPlatform Platform { get { throw null; } set { } }
    }
    public partial class AuthConfigResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AuthConfigResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.AuthConfigData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerAppName, string authConfigName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.AuthConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.AuthConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.AuthConfigResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.AuthConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.AuthConfigResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.AuthConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerAppCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource>, System.Collections.IEnumerable
    {
        protected ContainerAppCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Applications.Containers.ContainerAppCertificateData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Applications.Containers.ContainerAppCertificateData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerAppCertificateData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ContainerAppCertificateData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Applications.Containers.Models.CertificateProperties Properties { get { throw null; } set { } }
    }
    public partial class ContainerAppCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerAppCertificateResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.ContainerAppCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string environmentName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource> Update(Azure.ResourceManager.Applications.Containers.Models.ContainerAppCertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource>> UpdateAsync(Azure.ResourceManager.Applications.Containers.Models.ContainerAppCertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerAppCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppResource>, System.Collections.IEnumerable
    {
        protected ContainerAppCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ContainerAppResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string containerAppName, Azure.ResourceManager.Applications.Containers.ContainerAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string containerAppName, Azure.ResourceManager.Applications.Containers.ContainerAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string containerAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string containerAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource> Get(string containerAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.ContainerAppResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ContainerAppResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> GetAsync(string containerAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Applications.Containers.ContainerAppResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Applications.Containers.ContainerAppResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerAppData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ContainerAppData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Applications.Containers.Models.ContainerAppConfiguration Configuration { get { throw null; } set { } }
        public string CustomDomainVerificationId { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string LatestRevisionFqdn { get { throw null; } }
        public string LatestRevisionName { get { throw null; } }
        public string ManagedEnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> OutboundIPAddresses { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.ContainerAppProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.ContainerAppTemplate Template { get { throw null; } set { } }
    }
    public partial class ContainerAppReplicaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource>, System.Collections.IEnumerable
    {
        protected ContainerAppReplicaCollection() { }
        public virtual Azure.Response<bool> Exists(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource> Get(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource>> GetAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerAppReplicaData : Azure.ResourceManager.Models.ResourceData
    {
        public ContainerAppReplicaData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ReplicaContainer> Containers { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
    }
    public partial class ContainerAppReplicaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerAppReplicaResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.ContainerAppReplicaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerAppName, string revisionName, string replicaName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerAppResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerAppResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.ContainerAppData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerAppName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.AuthConfigResource> GetAuthConfig(string authConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.AuthConfigResource>> GetAuthConfigAsync(string authConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Applications.Containers.AuthConfigCollection GetAuthConfigs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource> GetContainerAppRevision(string revisionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource>> GetContainerAppRevisionAsync(string revisionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Applications.Containers.ContainerAppRevisionCollection GetContainerAppRevisions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.Models.CustomHostnameAnalysisResult> GetCustomHostNameAnalysis(string customHostname = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.Models.CustomHostnameAnalysisResult>> GetCustomHostNameAnalysisAsync(string customHostname = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.Models.ContainerAppSecret> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.Models.ContainerAppSecret> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.SourceControlResource> GetSourceControl(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.SourceControlResource>> GetSourceControlAsync(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Applications.Containers.SourceControlCollection GetSourceControls() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.ContainerAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.ContainerAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerAppRevisionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource>, System.Collections.IEnumerable
    {
        protected ContainerAppRevisionCollection() { }
        public virtual Azure.Response<bool> Exists(string revisionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string revisionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource> Get(string revisionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource>> GetAsync(string revisionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerAppRevisionData : Azure.ResourceManager.Models.ResourceData
    {
        public ContainerAppRevisionData() { }
        public bool? Active { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.RevisionHealthState? HealthState { get { throw null; } }
        public string ProvisioningError { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.RevisionProvisioningState? ProvisioningState { get { throw null; } }
        public int? Replicas { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.ContainerAppTemplate Template { get { throw null; } }
        public int? TrafficWeight { get { throw null; } }
    }
    public partial class ContainerAppRevisionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerAppRevisionResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.ContainerAppRevisionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response ActivateRevision(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ActivateRevisionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerAppName, string revisionName) { throw null; }
        public virtual Azure.Response DeactivateRevision(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeactivateRevisionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource> GetContainerAppReplica(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource>> GetContainerAppReplicaAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Applications.Containers.ContainerAppReplicaCollection GetContainerAppReplicas() { throw null; }
        public virtual Azure.Response RestartRevision(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestartRevisionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ContainersExtensions
    {
        public static Azure.ResourceManager.Applications.Containers.AuthConfigResource GetAuthConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource> GetContainerApp(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string containerAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppResource>> GetContainerAppAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string containerAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource GetContainerAppCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ContainerAppReplicaResource GetContainerAppReplicaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ContainerAppResource GetContainerAppResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ContainerAppRevisionResource GetContainerAppRevisionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ContainerAppCollection GetContainerApps(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Applications.Containers.ContainerAppResource> GetContainerApps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ContainerAppResource> GetContainerAppsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.DaprComponentResource GetDaprComponentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> GetManagedEnvironment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>> GetManagedEnvironmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource GetManagedEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ManagedEnvironmentCollection GetManagedEnvironments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> GetManagedEnvironments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> GetManagedEnvironmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource GetManagedEnvironmentStorageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.SourceControlResource GetSourceControlResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DaprComponentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.DaprComponentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.DaprComponentResource>, System.Collections.IEnumerable
    {
        protected DaprComponentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.DaprComponentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string componentName, Azure.ResourceManager.Applications.Containers.DaprComponentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.DaprComponentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string componentName, Azure.ResourceManager.Applications.Containers.DaprComponentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.DaprComponentResource> Get(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.DaprComponentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.DaprComponentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.DaprComponentResource>> GetAsync(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.AppSecret> Secrets { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class DaprComponentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DaprComponentResource() { }
        public virtual Azure.ResourceManager.Applications.Containers.DaprComponentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string environmentName, string componentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.DaprComponentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.DaprComponentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.Models.AppSecret> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.Models.AppSecret> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.DaprComponentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.DaprComponentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.DaprComponentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.DaprComponentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedEnvironmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>, System.Collections.IEnumerable
    {
        protected ManagedEnvironmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string environmentName, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string environmentName, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> Get(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>> GetAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityResponse> CheckContainerAppNameAvailability(Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityResponse>> CheckContainerAppNameAvailabilityAsync(Azure.ResourceManager.Applications.Containers.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string environmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource> GetContainerAppCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ContainerAppCertificateResource>> GetContainerAppCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Applications.Containers.ContainerAppCertificateCollection GetContainerAppCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.DaprComponentResource> GetDaprComponent(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.DaprComponentResource>> GetDaprComponentAsync(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Applications.Containers.DaprComponentCollection GetDaprComponents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> GetManagedEnvironmentStorage(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>> GetManagedEnvironmentStorageAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageName, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageName, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> Get(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>> GetAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string environmentName, string storageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Applications.Containers.ManagedEnvironmentStorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SourceControlCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Applications.Containers.SourceControlResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Applications.Containers.SourceControlResource>, System.Collections.IEnumerable
    {
        protected SourceControlCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.SourceControlResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sourceControlName, Azure.ResourceManager.Applications.Containers.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Applications.Containers.SourceControlResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sourceControlName, Azure.ResourceManager.Applications.Containers.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Applications.Containers.SourceControlResource> Get(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Applications.Containers.SourceControlResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Applications.Containers.SourceControlResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Applications.Containers.SourceControlResource>> GetAsync(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerAppName, string sourceControlName) { throw null; }
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
    public partial class AppleProvider
    {
        public AppleProvider() { }
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
    public partial class AppSecret
    {
        public AppSecret() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
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
    public partial class ContainerAppCertificatePatch
    {
        public ContainerAppCertificatePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ContainerAppConfiguration
    {
        public ContainerAppConfiguration() { }
        public Azure.ResourceManager.Applications.Containers.Models.ActiveRevisionsMode? ActiveRevisionsMode { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.DaprProvider Dapr { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.IngressProvider Ingress { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.RegistryCredentials> Registries { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.AppSecret> Secrets { get { throw null; } }
    }
    public partial class ContainerAppContainer
    {
        public ContainerAppContainer() { }
        public System.Collections.Generic.IList<string> Args { get { throw null; } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.EnvironmentVar> Env { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ContainerAppProbe> Probes { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.ContainerResources Resources { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ContainerAppVolumeMount> VolumeMounts { get { throw null; } }
    }
    public partial class ContainerAppLogin
    {
        public ContainerAppLogin() { }
        public System.Collections.Generic.IList<string> AllowedExternalRedirectUrls { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.CookieExpiration CookieExpiration { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.LoginNonce Nonce { get { throw null; } set { } }
        public bool? PreserveUrlFragmentsForLogins { get { throw null; } set { } }
        public string RoutesLogoutEndpoint { get { throw null; } set { } }
    }
    public partial class ContainerAppProbe
    {
        public ContainerAppProbe() { }
        public int? FailureThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.HttpRequestData HttpRequest { get { throw null; } set { } }
        public int? InitialDelaySeconds { get { throw null; } set { } }
        public int? PeriodSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.ProbeType? ProbeType { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.TcpSocketRequestData TcpSocketRequest { get { throw null; } set { } }
        public long? TerminationGracePeriodSeconds { get { throw null; } set { } }
        public int? TimeoutSeconds { get { throw null; } set { } }
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
    public partial class ContainerAppScale
    {
        public ContainerAppScale() { }
        public int? MaxReplicas { get { throw null; } set { } }
        public int? MinReplicas { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ContainerAppScaleRule> Rules { get { throw null; } }
    }
    public partial class ContainerAppScaleRule
    {
        public ContainerAppScaleRule() { }
        public Azure.ResourceManager.Applications.Containers.Models.QueueScaleRule AzureQueue { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.CustomScaleRule Custom { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.HttpScaleRule Http { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ContainerAppScaleRuleAuth
    {
        public ContainerAppScaleRuleAuth() { }
        public string SecretRef { get { throw null; } set { } }
        public string TriggerParameter { get { throw null; } set { } }
    }
    public partial class ContainerAppSecret
    {
        internal ContainerAppSecret() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ContainerAppTemplate
    {
        public ContainerAppTemplate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ContainerAppContainer> Containers { get { throw null; } }
        public string RevisionSuffix { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.ContainerAppScale Scale { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ContainerAppVolume> Volumes { get { throw null; } }
    }
    public partial class ContainerAppVolume
    {
        public ContainerAppVolume() { }
        public string Name { get { throw null; } set { } }
        public string StorageName { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.StorageType? StorageType { get { throw null; } set { } }
    }
    public partial class ContainerAppVolumeMount
    {
        public ContainerAppVolumeMount() { }
        public string MountPath { get { throw null; } set { } }
        public string VolumeName { get { throw null; } set { } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ContainerAppScaleRuleAuth> Auth { get { throw null; } }
        public string CustomScaleRuleType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
    public partial class DaprMetadata
    {
        public DaprMetadata() { }
        public string Name { get { throw null; } set { } }
        public string SecretRef { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class DaprProvider
    {
        public DaprProvider() { }
        public string AppId { get { throw null; } set { } }
        public int? AppPort { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.AppProtocol? AppProtocol { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
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
        public string InnerError { get { throw null; } }
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
    public partial class FacebookProvider
    {
        public FacebookProvider() { }
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
    public partial class GitHubProvider
    {
        public GitHubProvider() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.ClientRegistration Registration { get { throw null; } set { } }
    }
    public partial class GlobalValidation
    {
        public GlobalValidation() { }
        public System.Collections.Generic.IList<string> ExcludedPaths { get { throw null; } }
        public string RedirectToProvider { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.UnauthenticatedClientActionV2? UnauthenticatedClientAction { get { throw null; } set { } }
    }
    public partial class GoogleProvider
    {
        public GoogleProvider() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.ClientRegistration Registration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ValidationAllowedAudiences { get { throw null; } }
    }
    public partial class HttpHeaderData
    {
        public HttpHeaderData(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class HttpRequestData
    {
        public HttpRequestData(int port) { }
        public string Host { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.HttpHeaderData> HttpHeaders { get { throw null; } }
        public string Path { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.HttpScheme? Scheme { get { throw null; } set { } }
    }
    public partial class HttpScaleRule
    {
        public HttpScaleRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ContainerAppScaleRuleAuth> Auth { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpScheme : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.HttpScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpScheme(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.HttpScheme Http { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.HttpScheme Https { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.HttpScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.HttpScheme left, Azure.ResourceManager.Applications.Containers.Models.HttpScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.HttpScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.HttpScheme left, Azure.ResourceManager.Applications.Containers.Models.HttpScheme right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.Applications.Containers.Models.AppleProvider Apple { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.AzureActiveDirectory AzureActiveDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.AzureStaticWebApps AzureStaticWebApps { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Applications.Containers.Models.CustomOpenIdConnectProvider> CustomOpenIdConnectProviders { get { throw null; } }
        public Azure.ResourceManager.Applications.Containers.Models.FacebookProvider Facebook { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.GitHubProvider GitHub { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.GoogleProvider Google { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.TwitterProvider Twitter { get { throw null; } set { } }
    }
    public partial class IngressProvider
    {
        public IngressProvider() { }
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
    public partial class LoginNonce
    {
        public LoginNonce() { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProbeType : System.IEquatable<Azure.ResourceManager.Applications.Containers.Models.ProbeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProbeType(string value) { throw null; }
        public static Azure.ResourceManager.Applications.Containers.Models.ProbeType Liveness { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.ProbeType Readiness { get { throw null; } }
        public static Azure.ResourceManager.Applications.Containers.Models.ProbeType Startup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Applications.Containers.Models.ProbeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Applications.Containers.Models.ProbeType left, Azure.ResourceManager.Applications.Containers.Models.ProbeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Applications.Containers.Models.ProbeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Applications.Containers.Models.ProbeType left, Azure.ResourceManager.Applications.Containers.Models.ProbeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueueScaleRule
    {
        public QueueScaleRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Applications.Containers.Models.ContainerAppScaleRuleAuth> Auth { get { throw null; } }
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
    public partial class TcpSocketRequestData
    {
        public TcpSocketRequestData(int port) { }
        public string Host { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
    }
    public partial class TrafficWeight
    {
        public TrafficWeight() { }
        public string Label { get { throw null; } set { } }
        public bool? LatestRevision { get { throw null; } set { } }
        public string RevisionName { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
    }
    public partial class TwitterProvider
    {
        public TwitterProvider() { }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Applications.Containers.Models.TwitterRegistration Registration { get { throw null; } set { } }
    }
    public partial class TwitterRegistration
    {
        public TwitterRegistration() { }
        public string ConsumerKey { get { throw null; } set { } }
        public string ConsumerSecretSettingName { get { throw null; } set { } }
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
}
