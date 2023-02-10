namespace Azure.ResourceManager.Nginx
{
    public partial class NginxCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxCertificateResource>, System.Collections.IEnumerable
    {
        protected NginxCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Nginx.NginxCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Nginx.NginxCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.NginxCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Nginx.NginxCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Nginx.NginxCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NginxCertificateData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NginxCertificateData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Nginx.Models.NginxCertificateProperties Properties { get { throw null; } set { } }
    }
    public partial class NginxCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NginxCertificateResource() { }
        public virtual Azure.ResourceManager.Nginx.NginxCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deploymentName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.NginxCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.NginxCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NginxConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxConfigurationResource>, System.Collections.IEnumerable
    {
        protected NginxConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Nginx.NginxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Nginx.NginxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.NginxConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Nginx.NginxConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Nginx.NginxConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NginxConfigurationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NginxConfigurationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties Properties { get { throw null; } set { } }
    }
    public partial class NginxConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NginxConfigurationResource() { }
        public virtual Azure.ResourceManager.Nginx.NginxConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deploymentName, string configurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.NginxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.NginxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NginxDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentResource>, System.Collections.IEnumerable
    {
        protected NginxDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Nginx.NginxDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Nginx.NginxDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Nginx.NginxDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Nginx.NginxDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NginxDeploymentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NginxDeploymentData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
    }
    public partial class NginxDeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NginxDeploymentResource() { }
        public virtual Azure.ResourceManager.Nginx.NginxDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource> GetNginxCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource>> GetNginxCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxCertificateCollection GetNginxCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource> GetNginxConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource>> GetNginxConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxConfigurationCollection GetNginxConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NginxExtensions
    {
        public static Azure.ResourceManager.Nginx.NginxCertificateResource GetNginxCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxConfigurationResource GetNginxConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeployment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> GetNginxDeploymentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxDeploymentResource GetNginxDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxDeploymentCollection GetNginxDeployments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeployments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeploymentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Nginx.Models
{
    public partial class NginxCertificateProperties
    {
        public NginxCertificateProperties() { }
        public string CertificateVirtualPath { get { throw null; } set { } }
        public string KeyVaultSecretId { get { throw null; } set { } }
        public string KeyVirtualPath { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class NginxConfigurationFile
    {
        public NginxConfigurationFile() { }
        public string Content { get { throw null; } set { } }
        public string VirtualPath { get { throw null; } set { } }
    }
    public partial class NginxConfigurationProperties
    {
        public NginxConfigurationProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile> Files { get { throw null; } }
        public string PackageData { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile> ProtectedFiles { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RootFile { get { throw null; } set { } }
    }
    public partial class NginxDeploymentPatch
    {
        public NginxDeploymentPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NginxDeploymentProperties
    {
        public NginxDeploymentProperties() { }
        public bool? EnableDiagnosticsSupport { get { throw null; } set { } }
        public string IPAddress { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxStorageAccount LoggingStorageAccount { get { throw null; } set { } }
        public string ManagedResourceGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxNetworkProfile NetworkProfile { get { throw null; } set { } }
        public string NginxVersion { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class NginxDeploymentUpdateProperties
    {
        public NginxDeploymentUpdateProperties() { }
        public bool? EnableDiagnosticsSupport { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxStorageAccount LoggingStorageAccount { get { throw null; } set { } }
    }
    public partial class NginxFrontendIPConfiguration
    {
        public NginxFrontendIPConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress> PrivateIPAddresses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPAddresses { get { throw null; } }
    }
    public partial class NginxNetworkProfile
    {
        public NginxNetworkProfile() { }
        public Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration FrontEndIPConfiguration { get { throw null; } set { } }
        public string NetworkInterfaceSubnetId { get { throw null; } set { } }
    }
    public partial class NginxPrivateIPAddress
    {
        public NginxPrivateIPAddress() { }
        public string PrivateIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod? PrivateIPAllocationMethod { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NginxPrivateIPAllocationMethod : System.IEquatable<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NginxPrivateIPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod left, Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod left, Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NginxStorageAccount
    {
        public NginxStorageAccount() { }
        public string AccountName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Nginx.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Nginx.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Nginx.Models.ProvisioningState left, Azure.ResourceManager.Nginx.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Nginx.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Nginx.Models.ProvisioningState left, Azure.ResourceManager.Nginx.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
