namespace Azure.ResourceManager.RedHatOpenShift
{
    public partial class OpenShiftClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>, System.Collections.IEnumerable
    {
        protected OpenShiftClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OpenShiftClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public OpenShiftClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.RedHatOpenShift.Models.APIServerProfile ApiserverProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.ClusterProfile ClusterProfile { get { throw null; } set { } }
        public string ConsoleUrl { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShift.Models.IngressProfile> IngressProfiles { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShift.Models.MasterProfile MasterProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.PlatformWorkloadIdentityProfile PlatformWorkloadIdentityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.ServicePrincipalProfile ServicePrincipalProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShift.Models.WorkerProfile> WorkerProfiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedHatOpenShift.Models.WorkerProfile> WorkerProfilesStatus { get { throw null; } }
    }
    public partial class OpenShiftClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OpenShiftClusterResource() { }
        public virtual Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig> GetAdminCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig>> GetAdminCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials> GetCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials>> GetCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenShiftVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>, System.Collections.IEnumerable
    {
        protected OpenShiftVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> Get(string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>> GetAsync(string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> GetIfExists(string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>> GetIfExistsAsync(string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OpenShiftVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public OpenShiftVersionData() { }
        public string Version { get { throw null; } set { } }
    }
    public partial class OpenShiftVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OpenShiftVersionResource() { }
        public virtual Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string openShiftVersion) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PlatformWorkloadIdentityRoleSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>, System.Collections.IEnumerable
    {
        protected PlatformWorkloadIdentityRoleSetCollection() { }
        public virtual Azure.Response<bool> Exists(string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> Get(string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>> GetAsync(string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> GetIfExists(string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>> GetIfExistsAsync(string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlatformWorkloadIdentityRoleSetData : Azure.ResourceManager.Models.ResourceData
    {
        public PlatformWorkloadIdentityRoleSetData() { }
        public string OpenShiftVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShift.Models.PlatformWorkloadIdentityRole> PlatformWorkloadIdentityRoles { get { throw null; } }
    }
    public partial class PlatformWorkloadIdentityRoleSetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlatformWorkloadIdentityRoleSetResource() { }
        public virtual Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string openShiftMinorVersion) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RedHatOpenShiftExtensions
    {
        public static Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetOpenShiftCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> GetOpenShiftClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource GetOpenShiftClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterCollection GetOpenShiftClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetOpenShiftClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetOpenShiftClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> GetOpenShiftVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>> GetOpenShiftVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource GetOpenShiftVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionCollection GetOpenShiftVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> GetPlatformWorkloadIdentityRoleSet(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>> GetPlatformWorkloadIdentityRoleSetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource GetPlatformWorkloadIdentityRoleSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetCollection GetPlatformWorkloadIdentityRoleSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location) { throw null; }
    }
}
namespace Azure.ResourceManager.RedHatOpenShift.Mocking
{
    public partial class MockableRedHatOpenShiftArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRedHatOpenShiftArmClient() { }
        public virtual Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource GetOpenShiftClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource GetOpenShiftVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource GetPlatformWorkloadIdentityRoleSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableRedHatOpenShiftResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRedHatOpenShiftResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetOpenShiftCluster(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> GetOpenShiftClusterAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterCollection GetOpenShiftClusters() { throw null; }
    }
    public partial class MockableRedHatOpenShiftSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRedHatOpenShiftSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetOpenShiftClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetOpenShiftClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> GetOpenShiftVersion(string location, string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>> GetOpenShiftVersionAsync(string location, string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionCollection GetOpenShiftVersions(string location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> GetPlatformWorkloadIdentityRoleSet(string location, string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>> GetPlatformWorkloadIdentityRoleSetAsync(string location, string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetCollection GetPlatformWorkloadIdentityRoleSets(string location) { throw null; }
    }
}
namespace Azure.ResourceManager.RedHatOpenShift.Models
{
    public partial class APIServerProfile
    {
        public APIServerProfile() { }
        public string Ip { get { throw null; } }
        public string Url { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShift.Models.Visibility? Visibility { get { throw null; } set { } }
    }
    public static partial class ArmRedHatOpenShiftModelFactory
    {
        public static Azure.ResourceManager.RedHatOpenShift.Models.APIServerProfile APIServerProfile(Azure.ResourceManager.RedHatOpenShift.Models.Visibility? visibility = default(Azure.ResourceManager.RedHatOpenShift.Models.Visibility?), string url = null, string ip = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.ClusterProfile ClusterProfile(string pullSecret = null, string domain = null, string version = null, string resourceGroupId = null, Azure.ResourceManager.RedHatOpenShift.Models.FipsValidatedModule? fipsValidatedModules = default(Azure.ResourceManager.RedHatOpenShift.Models.FipsValidatedModule?), string oidcIssuer = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.IngressProfile IngressProfile(string name = null, Azure.ResourceManager.RedHatOpenShift.Models.Visibility? visibility = default(Azure.ResourceManager.RedHatOpenShift.Models.Visibility?), string ip = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.LoadBalancerProfile LoadBalancerProfile(int? managedOutboundIPsCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> effectiveOutboundIPs = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig OpenShiftClusterAdminKubeconfig(string kubeconfig = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials OpenShiftClusterCredentials(string kubeadminUsername = null, string kubeadminPassword = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData OpenShiftClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState?), Azure.ResourceManager.RedHatOpenShift.Models.ClusterProfile clusterProfile = null, string consoleUrl = null, Azure.ResourceManager.RedHatOpenShift.Models.ServicePrincipalProfile servicePrincipalProfile = null, Azure.ResourceManager.RedHatOpenShift.Models.PlatformWorkloadIdentityProfile platformWorkloadIdentityProfile = null, Azure.ResourceManager.RedHatOpenShift.Models.NetworkProfile networkProfile = null, Azure.ResourceManager.RedHatOpenShift.Models.MasterProfile masterProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.Models.WorkerProfile> workerProfiles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.Models.WorkerProfile> workerProfilesStatus = null, Azure.ResourceManager.RedHatOpenShift.Models.APIServerProfile apiserverProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.Models.IngressProfile> ingressProfiles = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData OpenShiftVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string version = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.PlatformWorkloadIdentity PlatformWorkloadIdentity(string resourceId = null, string clientId = null, string objectId = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData PlatformWorkloadIdentityRoleSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string openShiftVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.Models.PlatformWorkloadIdentityRole> platformWorkloadIdentityRoles = null) { throw null; }
    }
    public partial class ClusterProfile
    {
        public ClusterProfile() { }
        public string Domain { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.FipsValidatedModule? FipsValidatedModules { get { throw null; } set { } }
        public string OidcIssuer { get { throw null; } }
        public string PullSecret { get { throw null; } set { } }
        public string ResourceGroupId { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionAtHost : System.IEquatable<Azure.ResourceManager.RedHatOpenShift.Models.EncryptionAtHost>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionAtHost(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.EncryptionAtHost Disabled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.EncryptionAtHost Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShift.Models.EncryptionAtHost other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShift.Models.EncryptionAtHost left, Azure.ResourceManager.RedHatOpenShift.Models.EncryptionAtHost right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShift.Models.EncryptionAtHost (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShift.Models.EncryptionAtHost left, Azure.ResourceManager.RedHatOpenShift.Models.EncryptionAtHost right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FipsValidatedModule : System.IEquatable<Azure.ResourceManager.RedHatOpenShift.Models.FipsValidatedModule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FipsValidatedModule(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.FipsValidatedModule Disabled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.FipsValidatedModule Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShift.Models.FipsValidatedModule other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShift.Models.FipsValidatedModule left, Azure.ResourceManager.RedHatOpenShift.Models.FipsValidatedModule right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShift.Models.FipsValidatedModule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShift.Models.FipsValidatedModule left, Azure.ResourceManager.RedHatOpenShift.Models.FipsValidatedModule right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IngressProfile
    {
        public IngressProfile() { }
        public string Ip { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.Visibility? Visibility { get { throw null; } set { } }
    }
    public partial class LoadBalancerProfile
    {
        public LoadBalancerProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> EffectiveOutboundIps { get { throw null; } }
        public int? ManagedOutboundIpsCount { get { throw null; } set { } }
    }
    public partial class MasterProfile
    {
        public MasterProfile() { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.EncryptionAtHost? EncryptionAtHost { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class NetworkProfile
    {
        public NetworkProfile() { }
        public Azure.ResourceManager.RedHatOpenShift.Models.LoadBalancerProfile LoadBalancerProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OutboundType? OutboundType { get { throw null; } set { } }
        public string PodCidr { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.PreconfiguredNSG? PreconfiguredNSG { get { throw null; } set { } }
        public string ServiceCidr { get { throw null; } set { } }
    }
    public partial class OpenShiftClusterAdminKubeconfig
    {
        internal OpenShiftClusterAdminKubeconfig() { }
        public string Kubeconfig { get { throw null; } }
    }
    public partial class OpenShiftClusterCredentials
    {
        internal OpenShiftClusterCredentials() { }
        public string KubeadminPassword { get { throw null; } }
        public string KubeadminUsername { get { throw null; } }
    }
    public partial class OpenShiftClusterPatch
    {
        public OpenShiftClusterPatch() { }
        public Azure.ResourceManager.RedHatOpenShift.Models.APIServerProfile ApiserverProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.ClusterProfile ClusterProfile { get { throw null; } set { } }
        public string ConsoleUrl { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShift.Models.IngressProfile> IngressProfiles { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShift.Models.MasterProfile MasterProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.PlatformWorkloadIdentityProfile PlatformWorkloadIdentityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.ServicePrincipalProfile ServicePrincipalProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShift.Models.WorkerProfile> WorkerProfiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedHatOpenShift.Models.WorkerProfile> WorkerProfilesStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutboundType : System.IEquatable<Azure.ResourceManager.RedHatOpenShift.Models.OutboundType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutboundType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OutboundType Loadbalancer { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OutboundType UserDefinedRouting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShift.Models.OutboundType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShift.Models.OutboundType left, Azure.ResourceManager.RedHatOpenShift.Models.OutboundType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShift.Models.OutboundType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShift.Models.OutboundType left, Azure.ResourceManager.RedHatOpenShift.Models.OutboundType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlatformWorkloadIdentity
    {
        public PlatformWorkloadIdentity() { }
        public string ClientId { get { throw null; } }
        public string ObjectId { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class PlatformWorkloadIdentityProfile
    {
        public PlatformWorkloadIdentityProfile() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RedHatOpenShift.Models.PlatformWorkloadIdentity> PlatformWorkloadIdentities { get { throw null; } }
        public string UpgradeableTo { get { throw null; } set { } }
    }
    public partial class PlatformWorkloadIdentityRole
    {
        public PlatformWorkloadIdentityRole() { }
        public string OperatorName { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
        public string RoleDefinitionName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PreconfiguredNSG : System.IEquatable<Azure.ResourceManager.RedHatOpenShift.Models.PreconfiguredNSG>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PreconfiguredNSG(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.PreconfiguredNSG Disabled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.PreconfiguredNSG Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShift.Models.PreconfiguredNSG other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShift.Models.PreconfiguredNSG left, Azure.ResourceManager.RedHatOpenShift.Models.PreconfiguredNSG right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShift.Models.PreconfiguredNSG (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShift.Models.PreconfiguredNSG left, Azure.ResourceManager.RedHatOpenShift.Models.PreconfiguredNSG right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState AdminUpdating { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState left, Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState left, Azure.ResourceManager.RedHatOpenShift.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServicePrincipalProfile
    {
        public ServicePrincipalProfile() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Visibility : System.IEquatable<Azure.ResourceManager.RedHatOpenShift.Models.Visibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Visibility(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.Visibility Private { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.Visibility Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShift.Models.Visibility other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShift.Models.Visibility left, Azure.ResourceManager.RedHatOpenShift.Models.Visibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShift.Models.Visibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShift.Models.Visibility left, Azure.ResourceManager.RedHatOpenShift.Models.Visibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkerProfile
    {
        public WorkerProfile() { }
        public int? Count { get { throw null; } set { } }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.EncryptionAtHost? EncryptionAtHost { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
}
